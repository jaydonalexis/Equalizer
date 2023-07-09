namespace EqualizerGUI {
    public class TrackBarRatios : TrackBar, IChannels {
        public TrackBarRatios() {
           InitializeComponentTB();
        }

        public TrackBar InitializeComponentTB() {
            return new TrackBar();
        }
    }
}