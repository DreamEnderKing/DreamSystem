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
    }
}
