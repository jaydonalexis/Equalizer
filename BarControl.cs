using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;

namespace EqualizerGUI {
    public partial class BarControl : UserControl, IVolumeControl {
        public BarControl() {
            InitializeComponent();
        }

        private int _max;
        private int _min;
        private int _value;
        private int _startPoint;
        private bool _mouse = false;
        public int Max { get { return _max; } set { _max = value; Invalidate(); } }
        public int Min { get { return _min; } set { _min = value; Invalidate(); } }
        public int Value { get { return _value; } set { _value = value; Invalidate(); } }
        public int StartPoint { get { return _startPoint; } set { _startPoint = value; Invalidate(); } }

        public void VolumeControlPaint(object sender, PaintEventArgs e) {
            int gap = 10;
            int startPoint = _startPoint;
            SolidBrush dullTicks = new SolidBrush(Color.DimGray);
            for(int j = 0; j < (_max * ClientSize.Width / _max - 75) / gap; j++) {
                e.Graphics.FillRectangle(dullTicks, new Rectangle(startPoint, 0, gap - 5, ClientSize.Height));
                startPoint += gap;
            }
            
            int bufferPoint = 50;
            SolidBrush brightTicks = new SolidBrush(Color.Red);

            for(int i = 0; i < (_value * ClientSize.Width / _max - _value) / gap; i++) {
                e.Graphics.FillRectangle(brightTicks, new Rectangle(bufferPoint, 0, gap - 2, ClientSize.Height));
                bufferPoint += gap;
            }

            int thumbSize = 25;
            SolidBrush thumb = new SolidBrush(Color.White);
            e.Graphics.FillRectangle(thumb, new Rectangle(bufferPoint, 0, thumbSize, ClientSize.Height));

            if(_value > _min && _value <= _max / 3) {
                Image leftImage = Properties.Resources.soundLevelOne;
                e.Graphics.DrawImage(leftImage, 5, 0, ClientSize.Height, ClientSize.Height);
            }
            
            if(_value > _max / 3 && _value <= _max / 3 * 2) {
                Image leftImage = Properties.Resources.soundLevelTwo;
                e.Graphics.DrawImage(leftImage, 5, 0, ClientSize.Height, ClientSize.Height);
            }

            if(_value <= _min) {
                Image leftImage = Properties.Resources.soundMute;
                e.Graphics.DrawImage(leftImage, 5, 0, ClientSize.Height, ClientSize.Height);
            }
            
            if(_value >= _max / 3 * 2) {
                Image leftImage = Properties.Resources.soundLevelThree;
                e.Graphics.DrawImage(leftImage, 5, 0, ClientSize.Height, ClientSize.Height);
            }
        }

        private void BarValue(float value) {
            if(value < _min) value = _min;
            if(value > _max) value = _max;
            if(_value == value) return;
            _value = (int)value;
            this.Refresh();
        }

        private float ThumbValue(int value) {
            return _min + (_max  - _min) * value / (float)(ClientSize.Width);
        }

        public void VolumeControlMouseDown(object sender, MouseEventArgs e) {
            _mouse = true;
            BarValue(ThumbValue(e.X));
        }

        public void VolumeControlMouseMove(object sender, MouseEventArgs e) {
            if(!_mouse) return;
            BarValue(ThumbValue(e.X));
        }

        public void VolumeControlMouseUp(object sender, MouseEventArgs e) {
            _mouse = false;
        }
    }
}