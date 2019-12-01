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
        private void getTime()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(Application.StartupPath + "\\PC\\start\\start.xml");
            XmlElement element = (XmlElement)xml.DocumentElement.SelectSingleNode("prop[@id='time']");
            time = int.Parse(element.InnerText);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void StartManager_Load(object sender, EventArgs e)
        {
            getTime();
        }
    }
}
