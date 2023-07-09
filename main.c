#include "main.h"
#include "usb_device.h"
#include "string.h"
#include <stdio.h>
#include <stdlib.h>
#include "stdbool.h"
#include "math.h"

#define BYTES_I2C_FRAME 2
#define RECEIVE_BUFFER_LENGTH 64
#define SIZE_OF_UINT16 2
#define WRITE_COUNT 4

void System_Clock_Configuration(void);
static void Initialize_GPIO(void);
static void Initialize_I2C_One(void);
static void Initialize_I2C_Two(void);

I2C_HandleTypeDef handleI2COne;
I2C_HandleTypeDef handleI2CTwo;

uint8_t TREBLE_MASK_I2C_ADDR = 0x2C << 1;
uint8_t BASS_MASK_I2C_ADDR = 0x2F << 1;
uint8_t BAND_MASK_I2C_ADDR = 0x2E << 1;
uint8_t MASTER_MASK_I2C_ADDR = 0x2E << 1;
uint16_t MASK_I2C_SET = 0x0400;
uint16_t MASK_I2C_READ = 0x0800;
uint16_t MASK_I2C_INIT = 0x1C00;

uint16_t channelBuffer[WRITE_COUNT];
uint8_t bufferI2C[BYTES_I2C_FRAME];
uint8_t addressList[WRITE_COUNT] = {0x2C << 1, 0x2F << 1, 0x2E << 1, 0x2E << 1};
uint8_t buffer[RECEIVE_BUFFER_LENGTH];
uint8_t iterator = 0;
HAL_StatusTypeDef returnStatus;
bool receiveFlag = false;
char * token;

void Configure_I2C_Buffer(uint16_t controlData, uint16_t registerData) {
    uint8_t controlDataMSB = (uint8_t) (controlData >> 8);
    uint8_t controlDataLSB = (uint8_t) (controlData >> 0);
    uint8_t registerDataMSB = (uint8_t) (registerData >> 8);
    uint8_t registerDataLSB = (uint8_t) (registerData >> 0);
    
    bufferI2C[0] = controlDataMSB | registerDataMSB;
    bufferI2C[1] = controlDataLSB | registerDataLSB;
}

void I2C_Init(void) {
    int mode = 2;
    Configure_I2C_Buffer(MASK_I2C_INIT, mode);
    returnStatus = HAL_I2C_Master_Transmit(&handleI2CTwo, TREBLE_MASK_I2C_ADDR, bufferI2C, SIZE_OF_UINT16, HAL_MAX_DELAY);
    
    if(returnStatus != HAL_OK) {}
    returnStatus = HAL_I2C_Master_Transmit(&handleI2CTwo, BASS_MASK_I2C_ADDR, bufferI2C, SIZE_OF_UINT16, HAL_MAX_DELAY);
    
    if(returnStatus != HAL_OK) {}
    returnStatus = HAL_I2C_Master_Transmit(&handleI2CTwo, BAND_MASK_I2C_ADDR, bufferI2C, SIZE_OF_UINT16, HAL_MAX_DELAY);
    
    if(returnStatus != HAL_OK) {}
    returnStatus = HAL_I2C_Master_Transmit(&handleI2COne, MASTER_MASK_I2C_ADDR, bufferI2C, SIZE_OF_UINT16, HAL_MAX_DELAY);
    
    if(returnStatus != HAL_OK) {}
}

void I2C_Write(uint16_t channelValues[], uint8_t size) {
    for(int i = 0; i < size - 1; i++) {
        Configure_I2C_Buffer(MASK_I2C_SET, channelValues[i]);
        returnStatus = HAL_I2C_Master_Transmit(&handleI2CTwo, addressList[i], bufferI2C, SIZE_OF_UINT16, HAL_MAX_DELAY);
        
        if(returnStatus != HAL_OK) {}
    }
    
    Configure_I2C_Buffer(MASK_I2C_SET, channelValues[size - 1]);
    returnStatus = HAL_I2C_Master_Transmit(&handleI2COne, addressList[size - 1], bufferI2C, SIZE_OF_UINT16, HAL_MAX_DELAY);
    
    if(returnStatus != HAL_OK) {}
}

int main(void) {
    HAL_Init();
    
    System_Clock_Configuration();
    
    Initialize_GPIO();
    Initialize_I2C_One();
    Initialize_I2C_Two();
    MX_USB_DEVICE_Init();
    
    while (1) {
        if(receiveFlag == true) {
            token = strtok(buffer, " ");
            
            while(token != NULL) {
                channelBuffer[iterator] = atoi(token);
                token = strtok(NULL, " ");
                iterator++;
            }
            
            iterator = 0;
            receiveFlag = false;
            I2C_Write(channelBuffer, sizeof channelBuffer / SIZE_OF_UINT16);
        }
    }
}

void System_Clock_Configuration(void) {
    RCC_OscInitTypeDef RCC_OscInitStruct = {0};
    RCC_ClkInitTypeDef RCC_ClkInitStruct = {0};
    RCC_PeriphCLKInitTypeDef PeriphClkInit = {0};
    
    RCC_OscInitStruct.OscillatorType = RCC_OSCILLATORTYPE_HSE;
    RCC_OscInitStruct.HSEState = RCC_HSE_ON;
    RCC_OscInitStruct.HSEPredivValue = RCC_HSE_PREDIV_DIV1;
    RCC_OscInitStruct.HSIState = RCC_HSI_ON;
    RCC_OscInitStruct.PLL.PLLState = RCC_PLL_ON;
    RCC_OscInitStruct.PLL.PLLSource = RCC_PLLSOURCE_HSE;
    RCC_OscInitStruct.PLL.PLLMUL = RCC_PLL_MUL9;
    
    if (HAL_RCC_OscConfig(&RCC_OscInitStruct) != HAL_OK) {
        Error_Handler();
    }
    
    RCC_ClkInitStruct.ClockType = RCC_CLOCKTYPE_HCLK|RCC_CLOCKTYPE_SYSCLK
    |RCC_CLOCKTYPE_PCLK1|RCC_CLOCKTYPE_PCLK2;
    RCC_ClkInitStruct.SYSCLKSource = RCC_SYSCLKSOURCE_PLLCLK;
    RCC_ClkInitStruct.AHBCLKDivider = RCC_SYSCLK_DIV1;
    RCC_ClkInitStruct.APB1CLKDivider = RCC_HCLK_DIV2;
    RCC_ClkInitStruct.APB2CLKDivider = RCC_HCLK_DIV1;
    
    if (HAL_RCC_ClockConfig(&RCC_ClkInitStruct, FLASH_LATENCY_2) != HAL_OK) {
        Error_Handler();
    }
    
    PeriphClkInit.PeriphClockSelection = RCC_PERIPHCLK_USB;
    PeriphClkInit.UsbClockSelection = RCC_USBCLKSOURCE_PLL_DIV1_5;
    
    if (HAL_RCCEx_PeriphCLKConfig(&PeriphClkInit) != HAL_OK) {
        Error_Handler();
    }
}

static void Initialize_I2C_One(void) {
    handleI2COne.Instance = I2C1;
    handleI2COne.Init.ClockSpeed = 100000;
    handleI2COne.Init.DutyCycle = I2C_DUTYCYCLE_2;
    handleI2COne.Init.OwnAddress1 = 0;
    handleI2COne.Init.AddressingMode = I2C_ADDRESSINGMODE_7BIT;
    handleI2COne.Init.DualAddressMode = I2C_DUALADDRESS_DISABLE;
    handleI2COne.Init.OwnAddress2 = 0;
    handleI2COne.Init.GeneralCallMode = I2C_GENERALCALL_DISABLE;
    handleI2COne.Init.NoStretchMode = I2C_NOSTRETCH_DISABLE;
    
    if (HAL_I2C_Init(&handleI2COne) != HAL_OK) {
        Error_Handler();
    }
}

static void Initialize_I2C_Two(void) {
    handleI2CTwo.Instance = I2C2;
    handleI2CTwo.Init.ClockSpeed = 100000;
    handleI2CTwo.Init.DutyCycle = I2C_DUTYCYCLE_2;
    handleI2CTwo.Init.OwnAddress1 = 0;
    handleI2CTwo.Init.AddressingMode = I2C_ADDRESSINGMODE_7BIT;
    handleI2CTwo.Init.DualAddressMode = I2C_DUALADDRESS_DISABLE;
    handleI2CTwo.Init.OwnAddress2 = 0;
    handleI2CTwo.Init.GeneralCallMode = I2C_GENERALCALL_DISABLE;
    handleI2CTwo.Init.NoStretchMode = I2C_NOSTRETCH_DISABLE;
    
    if (HAL_I2C_Init(&handleI2CTwo) != HAL_OK) {
        Error_Handler();
    }
}

static void Initialize_GPIO(void) {
    __HAL_RCC_GPIOD_CLK_ENABLE();
    __HAL_RCC_GPIOB_CLK_ENABLE();
    __HAL_RCC_GPIOA_CLK_ENABLE();
}

void Error_Handler(void) {
    __disable_irq();
    
    while (1) {
    }
}

#ifdef USE_FULL_ASSERT
void assert_failed(uint8_t *file, uint32_t line) {
}
#endif
