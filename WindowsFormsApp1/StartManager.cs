using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApp1
{
    public partial class StartManager : Form
    {
        public StartManager()
        {
            InitializeComponent();
        }

        //获取开机秒数
        int time = 0;
        private void setTime()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(Application.StartupPath + "\\PC\\start\\start.xml");
            XmlElement element = (XmlElement)xml.DocumentElement.SelectSingleNode("prop[@id='time']");
            time = int.Parse(element.InnerText);
        }

        //执行开机秒数
        int rest = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(rest==0)
            {
                timer1.Enabled = false;
                return;
            }
            rest -= rest;s
        }

        private void StartManager_Load(object sender, EventArgs e)
        {
            setTime();
            rest = time;
            timer1.Enabled = true;
        }
    }
}
