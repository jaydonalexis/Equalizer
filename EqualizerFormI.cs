using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EqualizerGUI {
    public partial class EqualizerMarkI : Form, IForm {
        private BarControl _volumeControl;
        private IData _dataProcessor;
        private IChannels _generateChannelElement;

        public EqualizerMarkI(BarControl volumeControl, IData dataProcessor, IChannels generateChannelElement) {
            this._volumeControl = volumeControl;
            this._dataProcessor = dataProcessor;
            this._generateChannelElement = generateChannelElement;
            InitializeComponent();
        }

        private void TimerTick(object sender, EventArgs e) {
            _volumeLabel.Text = "Volume : " + _volumeControl.Value.ToString() + "%";
        }

        private void ComboBoxDropDown(object sender, EventArgs e) {
            string[] portLists = SerialPort.GetPortNames();
            _availablePorts.Items.Clear();
            _availablePorts.Items.AddRange(portLists);
        }

        private void OpenPortClickedEvent(object sender, EventArgs e) {
            try {
                _serialPort.PortName = _availablePorts.Text;
                _serialPort.BaudRate = 115200;
                _serialPort.Open();
            }
            catch(Exception error) {
                MessageBox.Show(error.Message);
            }
        }
        
        private void SendDataClickedEvent(object sender, EventArgs e) {
            List<TrackBar> ratioElements = new List<TrackBar>();
            List<double> writeValues = new List<double>();
            string data;

            ratioElements.Add(_trebleElement);
            ratioElements.Add(_bassElement);
            ratioElements.Add(_bandElement);

            writeValues = _dataProcessor.ComputeWriteValuesTB(_volumeControl, ratioElements);

            data = _dataProcessor.Format(writeValues);

            Console.WriteLine(data);

            try {
                _serialPort.Write(data);
            }
            catch(Exception error) {
                MessageBox.Show(error.Message);
            }
        }
    }
}
