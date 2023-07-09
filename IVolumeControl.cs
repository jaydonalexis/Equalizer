namespace EqualizerGUI {
    public interface IVolumeControl {
        int Max { get; set; }
        int Min { get; set; }
        int Value { get; set; }
        int StartPoint { get; set; }

        void VolumeControlPaint(object sender, PaintEventArgs e);

        void VolumeControlMouseDown(object sender, MouseEventArgs e);

        void VolumeControlMouseUp(object sender, MouseEventArgs e);

        void VolumeControlMouseMove(object sender, MouseEventArgs e);

        void InitializeComponent();
    }
}