namespace EqualizerGUI {
    partial class EqualizerMarkI : Form, IForm {
        private System.ComponentModel.IContainer _components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (_components != null)) {
                _components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        public void InitializeComponent() {
            this._components = new System.ComponentModel.Container();
            this._serialPort =  new System.IO.Ports.SerialPort();
            this._volumeLabel = new System.Windows.Forms.Label();
            this._timer = new System.Windows.Forms.Timer(this._components);
            this._trebleText = new System.Windows.Forms.TextBox();
            this._bassText = new System.Windows.Forms.TextBox();
            this._bandText = new System.Windows.Forms.TextBox();
            this._sendData = new System.Windows.Forms.Button();
            this._openPort = new System.Windows.Forms.Button();
            this._availablePorts = new System.Windows.Forms.ComboBox();
            this._trebleElement = _generateChannelElement.InitializeComponentTB();
            this._bassElement = _generateChannelElement.InitializeComponentTB();
            this._bandElement = _generateChannelElement.InitializeComponentTB();
            this.SuspendLayout();

            // volumeControl
            
            this._volumeControl.Min = 0;
            this._volumeControl.StartPoint = 50;
            this._volumeControl.Value = 50;
            this._volumeControl.Max = 100;

            // volumeLabel

            this._volumeLabel.AutoSize = true;
            this._volumeLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._volumeLabel.Location = new System.Drawing.Point(47, 214);
            this._volumeLabel.Name = "volumeLabel";
            this._volumeLabel.Size = new System.Drawing.Size(140, 23);
            this._volumeLabel.TabIndex = 1;
            this._volumeLabel.Text = "Volume : 50%";

            // timer1

            this._timer.Enabled = true;
            this._timer.Tick += new System.EventHandler(this.TimerTick);

            // trebleText

            this._trebleText.BackColor = System.Drawing.SystemColors.Control;
            this._trebleText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._trebleText.CausesValidation = false;
            this._trebleText.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._trebleText.Location = new System.Drawing.Point(50, 14);
            this._trebleText.Name = "trebleText";
            this._trebleText.Size = new System.Drawing.Size(125, 24);
            this._trebleText.TabIndex = 5;
            this._trebleText.Text = "Treble Ratio:";

            // bassText
            
            this._bassText.BackColor = System.Drawing.SystemColors.Control;
            this._bassText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._bassText.CausesValidation = false;
            this._bassText.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._bassText.Location = new System.Drawing.Point(50, 81);
            this._bassText.Name = "bassText";
            this._bassText.Size = new System.Drawing.Size(125, 24);
            this._bassText.TabIndex = 6;
            this._bassText.Text = "Bass Ratio:";

            // bandText

            this._bandText.BackColor = System.Drawing.SystemColors.Control;
            this._bandText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._bandText.CausesValidation = false;
            this._bandText.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._bandText.Location = new System.Drawing.Point(50, 149);
            this._bandText.Name = "bandText";
            this._bandText.Size = new System.Drawing.Size(125, 24);
            this._bandText.TabIndex = 7;
            this._bandText.Text = "Band Ratio:";

            // sendData

            this._sendData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
             this._sendData.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._sendData.Location = new System.Drawing.Point(47, 353);
            this._sendData.Name = "sendData";
            this._sendData.Size = new System.Drawing.Size(438, 33);
            this._sendData.TabIndex = 10;
            this._sendData.Text = "Write";
            this._sendData.UseVisualStyleBackColor = true;
            this._sendData.Click += new System.EventHandler(this.SendDataClickedEvent);

            // openPort

            this._openPort.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
             this._openPort.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._openPort.Location = new System.Drawing.Point(276, 302);
            this._openPort.Name = "openPort";
            this._openPort.Size = new System.Drawing.Size(209, 33);
            this._openPort.TabIndex = 8;
            this._openPort.Text = "Open";
            this._openPort.UseVisualStyleBackColor = true;
            this._openPort.Click += new System.EventHandler(this.OpenPortClickedEvent);

            // availablePorts

            this._availablePorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._availablePorts.FormattingEnabled = true;
            this._availablePorts.Location = new System.Drawing.Point(47, 303);
            this._availablePorts.Name = "availablePorts";
            this._availablePorts.Size = new System.Drawing.Size(209, 28);
            this._availablePorts.TabIndex = 9;
            this._availablePorts.DropDown += new System.EventHandler(this.ComboBoxDropDown);

            // trebleTrackBar

            this._trebleElement.LargeChange = 1;
            this._trebleElement.Location = new System.Drawing.Point(181, 14);
            this._trebleElement.Maximum = 5;
            this._trebleElement.Minimum = 1;
            this._trebleElement.Name = "trebleTrackBar";
            this._trebleElement.Size = new System.Drawing.Size(304, 56);
            this._trebleElement.TabIndex = 1;
            this._trebleElement.Value = 1;

            // bassTrackBar

            this._bassElement.LargeChange = 1;
            this._bassElement.Location = new System.Drawing.Point(181, 81);
            this._bassElement.Maximum = 5;
            this._bassElement.Minimum = 1;
            this._bassElement.Name = "bassTrackBar";
            this._bassElement.Size = new System.Drawing.Size(304, 56);
            this._bassElement.TabIndex = 11;
            this._bassElement.Value = 1;

            // bandTrackBar

            this._bandElement.LargeChange = 1;
            this._bandElement.Location = new System.Drawing.Point(181, 149);
            this._bandElement.Maximum = 5;
            this._bandElement.Minimum = 1;
            this._bandElement.Name = "bandTrackBar";
            this._bandElement.Size = new System.Drawing.Size(304, 56);
            this._bandElement.TabIndex = 12;
            this._bandElement.Value = 1;

            // Form1

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 405);
            this.Controls.Add(this._availablePorts);
            this.Controls.Add(this._volumeLabel);
            this.Controls.Add(this._volumeControl);
            this.Controls.Add(this._sendData);
            this.Controls.Add(this._openPort);
            this.Controls.Add(this._bandText);
            this.Controls.Add(this._bassText);
            this.Controls.Add(this._trebleText);
            this.Controls.Add(this._trebleElement);
            this.Controls.Add(this._bassElement);
            this.Controls.Add(this._bandElement);
            this.Name = "Audio Equalizer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Audio Equalizer";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private System.IO.Ports.SerialPort _serialPort;
        private System.Windows.Forms.Label _volumeLabel;
        private System.Windows.Forms.Timer _timer;
        private System.Windows.Forms.TextBox _trebleText;
        private System.Windows.Forms.TextBox _bassText;
        private System.Windows.Forms.TextBox _bandText;
        private System.Windows.Forms.Button _sendData;
        private System.Windows.Forms.Button _openPort;
        private System.Windows.Forms.ComboBox _availablePorts;
        private System.Windows.Forms.TrackBar _trebleElement;
        private System.Windows.Forms.TrackBar _bassElement;
        private System.Windows.Forms.TrackBar _bandElement;
    }
}