namespace EqualizerGUI {
    public class DataProcessorI : IData {
        public List<double> ComputeWriteValuesTB(BarControl volumeControl, List<TrackBar> ratioElements) {
            double maxVoltage = 5;
            double inputAmplitude = 1;
            double trebleWeight = 0.0981;
            double bassWeight = 0.8643;
            double bandWeight = 0.3451;
            double maxWriteValue = 1024;
            double maxResistanceValueTreble = 9853;
            double maxResistanceValueBass = 10345;
            double maxResistanceValueBand = 10288;
            double summerFeedbackResistance = 500;
            double masterInputResistance = 1000;
            double oneHundredPercent = 100;

            double targetVoltage = (double) volumeControl.Value * maxVoltage / oneHundredPercent;
            double trebleAmplitude = trebleWeight * inputAmplitude;
            double bassAmplitude = bassWeight * inputAmplitude;
            double bandAmplitude = bandWeight * inputAmplitude;

            double writeMaster = (double) volumeControl.Value / oneHundredPercent * maxWriteValue;
            int sumOfRatioValues = ratioElements[0].Value + ratioElements[1].Value + ratioElements[2].Value;

            List<double> writeValues = new List<double>();
            
            if(volumeControl.Value != 0) {
                double writeTreble = (summerFeedbackResistance / ((((targetVoltage / (((double) volumeControl.Value / oneHundredPercent * maxResistanceValueTreble) / masterInputResistance)) / (double) sumOfRatioValues) * (double) ratioElements[0].Value) / trebleWeight)) / maxResistanceValueTreble * maxWriteValue;
                double writeBass = (summerFeedbackResistance / ((((targetVoltage / (((double) volumeControl.Value / oneHundredPercent * maxResistanceValueBass) / masterInputResistance)) / (double) sumOfRatioValues) * (double) ratioElements[1].Value) / bassWeight)) / maxResistanceValueBass * maxWriteValue;
                double writeBand = (summerFeedbackResistance / ((((targetVoltage / (((double) volumeControl.Value / oneHundredPercent * maxResistanceValueBand) / masterInputResistance)) / (double) sumOfRatioValues) * (double) ratioElements[2].Value) / bandWeight)) / maxResistanceValueBand * maxWriteValue;

                writeValues.Add(writeTreble);
                writeValues.Add(writeBass);
                writeValues.Add(writeBand);
                writeValues.Add(writeMaster);
            }
            else {
                writeValues.Add(maxWriteValue);
                writeValues.Add(maxWriteValue);
                writeValues.Add(maxWriteValue);
                writeValues.Add(0);
            }

            return writeValues;
        }

        public string Format(List<double> writeValues) {
            string data = ((int) Math.Round(writeValues[0])).ToString() + " " + ((int) Math.Round(writeValues[1])).ToString() + " " + ((int) Math.Round(writeValues[2])).ToString() + " " + ((int) Math.Round(writeValues[3])).ToString();
            return data;
        }
    }
}