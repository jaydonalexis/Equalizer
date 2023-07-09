namespace EqualizerGUI {
    partial class BarControl : UserControl, IVolumeControl {
        private System.ComponentModel.IContainer _components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (_components != null)) {
                _components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        public void InitializeComponent() {
            this.SuspendLayout();
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.VolumeControlPaint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VolumeControlMouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.VolumeControlMouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.VolumeControlMouseUp);
            this.ResumeLayout(false);
            this.Location = new System.Drawing.Point(47, 240);
            this.Size = new Size(438, 38);
            this.BackColor = Color.Black;
            this.Name = "BarControl";
            this.DoubleBuffered = true;
        }

        #endregion
    }
}