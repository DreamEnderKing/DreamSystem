using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Data;
using System.Linq;
using System.Text;
using System.Diagnostics;
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
            i = 1;
            LoadAsync();
            Tmp.DesktopTempData.IconUsed[dataSource.X, dataSource.Y] = i;
        }

        protected virtual async Task LoadAsync()
        {
            //初始化框架
            Width = 74;
            Height = 112;
            Left = 80 * dataSource.X + 3;
            Top = 120 * dataSource.Y + 4;
            //提取数据
            _label = dataSource.Name;
            _image = dataSource.Icon;
            //执行任务
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

        private String _label = "";

        public DIO.DI dataSource { get; set; }

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

        public int i { get; set; }

        private void DesktopIcon_MouseUp(object sender, MouseEventArgs e)
        {
            
            moving = false;
            #region 移动定位
            //存储旧位置
            int x = dataSource.X;
            int y = dataSource.Y;
            //模糊控制
            int l = Left - 3;
            int t = Top - 4;
            int xt = l % 80;
            int yt = t % 120;
            dataSource.X = (xt <= 40) ? (Left - 3) / 80 : (Left - 3) / 80 + 1;
            dataSource.Y = (yt <= 60) ? (Top - 3) / 120 : (Top - 3) / 120 + 1;
            //检查重复
            if (Tmp.DesktopTempData.IconUsed[dataSource.X, dataSource.Y] == 0)
            {
                //启用更改
                LoadAsync();
                timer1.Enabled = true;
                Tmp.DesktopTempData.IconUsed[x, y] = 0;
                Tmp.DesktopTempData.IconUsed[dataSource.X, dataSource.Y] = i;
            }
            else if(Tmp.DesktopTempData.IconUsed[dataSource.X,dataSource.Y]==5)
            {
                //回收图标
                DesktopSystemIcon ico = (DesktopSystemIcon)((PC_Main)FindForm()).GetDesktopIcon(dataSource.X, dataSource.Y);
                ico.AddIn();
                Dispose();
            }
            else
            {
                //恢复原状
                dataSource.X = x;
                dataSource.Y = y;
                LoadAsync();
                timer1.Enabled = true;
            }
            #endregion
            #region 写入更改
            Save();
            #endregion
        }

        Point origin = new Point(0, 0);
        Point Newtemp = new Point(0, 0);
        private void DesktopIcon_MouseMove(object sender, MouseEventArgs e)
        {
            if(moving)
            {
                //关闭自动处理
                timer1.Enabled = false;
                //初步移动
                Newtemp = new Point(e.X, e.Y);
                Left = Left + Newtemp.X - origin.X;
                Top = Top + Newtemp.Y - origin.Y;
            }
        }

        #endregion

        #region 执行主任务
        private void DesktopIcon_DoubleClick(object sender, EventArgs e)
        {
            if (!File.Exists(dataSource.Target))
            {
                DialogResult result = MessageBox.Show("指定的文件不存在！\n是否删除图标？", "Dream PC1.0", MessageBoxButtons.YesNo);
                if(result==DialogResult.Yes)
                {
                    //删除本图标
                    Dispose();
                }
            }
            else
            {
                Process.Start(dataSource.Target);
            }
        }

        public virtual void Save()
        {
            DIO.writeDI(Application.StartupPath + @"\PC\users\" + Tmp.user.User + @"\Desktop", dataSource);
        }
        #endregion
    }

    public class DesktopSystemIcon : DesktopIcon
    {
        

        public enum SystemIconType
        {
            explorer = 0,
            control  = 1,
            user     = 2,
            bin      = 3
        }

        public SystemIconType IconType{ get; set;}

        //根据类型写图标、定名称
        protected override Task LoadAsync()
        {
            switch (IconType)
            {
                case SystemIconType.explorer:
                    dataSource.Icon = MainPart.SystemIcon.Explorer;
                    dataSource.Name = "我的电脑";
                    i = 2;
                    break;
                case SystemIconType.control:
                    dataSource.Icon = MainPart.SystemIcon.Control;
                    dataSource.Name = "设置";
                    i = 3;
                    break;
                case SystemIconType.user:
                    dataSource.Icon = MainPart.SystemIcon.UserFolder;
                    dataSource.Name = Tmp.user.User;
                    i = 4;
                    break;
                case SystemIconType.bin:
                    dataSource.Icon = (!full) ? MainPart.SystemIcon.Bin_Empty : MainPart.SystemIcon.Bin_Full;
                    dataSource.Name = "回收站";
                    i = 5;
                    break;
                default:
                    break;
            }
            return base.LoadAsync();
        }

        //写入xml
        public override void Save()
        {
            string str = Application.StartupPath + @"\PC\users\" + Tmp.user.User + @"\Desktop\SystemIcon";
            if (!File.Exists(str + ".dll"))
            {
                MessageBox.Show("该用户文件已损坏", "Dream PC 1.0", MessageBoxButtons.OK);
            }
            else
            {
                File.Copy(str + ".dll", str + ".xml");
                XmlDocument xml = new XmlDocument();
                xml.Load(str + ".xml");
                XmlNodeList nodes = xml.SelectNodes("icons/icon");
                foreach (XmlNode nitem in nodes)
                {
                    XmlElement item = (XmlElement)nitem;
                    string name = item.GetAttribute("name");
                    if(IconType.ToString()==name)
                    {
                        item.SetAttribute("x", dataSource.X.ToString());
                        item.SetAttribute("y", dataSource.Y.ToString());
                    }

                }
                xml.Save(str + ".xml");

                File.Copy(str + ".xml", str + ".dll", true);
                File.Delete(str + ".xml");
            }

        }

        #region bin
        bool full = false;
        public void AddIn()
        {
            if (IconType == SystemIconType.bin)
            {
                full = true;
            }
        }
        #endregion
    }
}
