namespace EqualizerGUI {
    public interface IData {
        List<double> ComputeWriteValuesTB(BarControl volumeControl, List<TrackBar> ratioElements);

        string Format(List<double> writeValues);
    }
}