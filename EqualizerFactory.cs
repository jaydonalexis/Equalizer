namespace EqualizerGUI
{
    public static class EqualizerFactory {
        public static Form CreateNewForm() {
            return new EqualizerMarkI(CreateNewControl(), CreateNewDataProcessor(), CreateNewChannelType());
        }

        public static BarControl CreateNewControl() {
            return new BarControl();
        }

        public static IData CreateNewDataProcessor() {
            return new DataProcessorI();
        }

        public static IChannels CreateNewChannelType() {
            return new TrackBarRatios();
        }
    }
}
