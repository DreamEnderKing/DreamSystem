using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Shutdown : Form
    {
        public Shutdown()
        {
            InitializeComponent();
        }

        private void Shutdown_Load(object sender, EventArgs e)
        {
            this.Show();
            DateTime dateTime = DateTime.Now;
            int s;
            do
            {
                TimeSpan span = DateTime.Now - dateTime;
                s = span.Seconds;
                Application.DoEvents();
            }
            while (s <= 4);

            Application.Exit();

        }
    }
}
