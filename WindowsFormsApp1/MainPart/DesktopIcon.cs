using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.MainPart
{
    public partial class DesktopIcon : UserControl
    {
        public DesktopIcon()
        {
            InitializeComponent();
        }

        #region 主工作区
        private void DesktopIcon_Load(object sender, EventArgs e)
        {
            LoadAsync();
        }

        private async Task LoadAsync()
        {
            Changed += new EventHandler(emptyEvent);
            Width = 74;
            Height = 112;

            pictureBox1.Image = _image;
            if(_label.Length<=18)
            {
                label1.Text = _label;
            }
            else
            {
                string str = _label.Substring(0, 16) + "...";
                label1.Text = str;
            }

        }

        private Image _image = new Bitmap(64, 64);

        public Image Image
        {
            get => _image;
            set
            {
                _image = value;
                LoadAsync();
                Changed(this, new EventArgs());
            }
        }

        private String _label = "";

        public String Caption
        {
            get => _label;
            set
            {
                _label = value;
                LoadAsync();
                Changed(this, new EventArgs());

            }
        }

        public event EventHandler Changed;

        private void emptyEvent(object sender,EventArgs e)
        { }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadAsync();
        }
        #endregion

        #region 图标突出
        private void DesktopIcon_Click(object sender, EventArgs e)
        {
            foreach (DesktopIcon item in Parent.Controls)
            {
                item.BorderStyle = BorderStyle.None;
                item.BackColor = Color.Transparent;
                item.choosed = false;
            }
            if (!leave)
            {
                BorderStyle = BorderStyle.Fixed3D;
                BackColor = Color.FromArgb(175, 128, 255, 255);
                choosed = true;
            }
        }
        bool leave = false;
        protected bool choosed = false;
        private void DesktopIcon_MouseLeave(object sender, EventArgs e)
        {
            leave = true;
            if(!choosed)
            {
                BackColor = Color.Transparent;
            }
        }

        private void DesktopIcon_MouseEnter(object sender, EventArgs e)
        {
            leave = false;
            if (!choosed)
            {
                BackColor = Color.FromArgb(125, 128, 255, 255);
            }
        }
        #endregion

        #region 图标拖动
        bool moving = false;

        private void DesktopIcon_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            origin = new Point(e.X, e.Y);
        }

        private void DesktopIcon_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            #region 移动定位
            //模糊控制
            int l = Left - 3;
            int t = Top - 4;
            int xt = l % 80;
            int yt = t % 120;
            int x = (xt <= 40) ? (Left - 3) / 80 : (Left - 3) / 80 + 1;
            int y = (yt <= 60) ? (Top - 3) / 120 : (Top - 3) / 120 + 1;
            //结果赋值
            Left = x * 80 + 3;
            Top = y * 120 + 4;
            #endregion
        }

        Point origin = new Point(0, 0);
        Point Newtemp = new Point(0, 0);
        private void DesktopIcon_MouseMove(object sender, MouseEventArgs e)
        {
            if(moving)
            {
                //初步移动
                Newtemp = new Point(e.X, e.Y);
                Left = Left + Newtemp.X - origin.X;
                Top = Top + Newtemp.Y - origin.Y;
            }
        }

        #endregion

    }
}
