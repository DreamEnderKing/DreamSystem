using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml;



namespace WindowsFormsApp1
{
    public struct user
    {
        public string name;
        public string pass;

    }

    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void login_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
        #region 登录

        public user[] UserList;
        public Bitmap[] UserIconList;
        public int UserIndex = 0;
        public int UserNumber = 0;

        #region 基础
        //登录按钮
        private void login_Click(object sender, EventArgs e)
        {
            ShutTime = 0;
            ShutMenu.Visible = false;
            Shut.BorderStyle = BorderStyle.None;
        }

        //用户名翻页
        private void forward_Click(object sender, EventArgs e)
        {
            userpass.Text = "";
            int i = UserIndex;

            if ((i+1)<=UserNumber)
            {
                UserIndex = i + 1;
            }
            else
            {
                UserIndex = 0;
            }
            username.Text = UserList[UserIndex].name;
            user.Image = UserIconList[UserIndex];


        }

        private void back_Click(object sender, EventArgs e)
        {
            userpass.Text = "";
            int i = UserIndex;

            if ((i - 1) >= 0)
            {
                UserIndex = i - 1;
            }
            else
            {
                UserIndex = UserNumber;
            }
            username.Text = UserList[UserIndex].name;
            user.Image = UserIconList[UserIndex];


        }

        private void login_Load(object sender, EventArgs e)
        {
            //初始化环境
            #region temp文件夹
            try
            {
                Directory.Delete(Application.StartupPath + @"\PC\temp", true);
                Directory.CreateDirectory(Application.StartupPath + @"\PC\temp");
            }
            catch (Exception)
            {

            }

            #endregion

            //初始化杂项
            sleep.Height = 600;
            sleep.Width = 1200;
            Temp = (new temp()).newTemp();
            string file = Application.StartupPath + @"\Image\user.gif";
            Bitmap bitmap;


            //初始化用户列表
            //查询xml
            XmlDocument xml = new XmlDocument();
            xml.Load(Application.StartupPath + @"\PC\users\users.xml");
            XmlNodeList nodeList = xml.GetElementsByTagName("user");
            //初始化用户名
            UserList = new user[nodeList.Count];
            for (int i = 0; i < nodeList.Count; i++)
            {
                XmlNode node = nodeList.Item(i);
                string user_name = ((XmlElement)node.SelectSingleNode("username")).GetAttribute("username");
                string user_pass = ((XmlElement)node.SelectSingleNode("pass")).GetAttribute("word");
                UserList[i].name = user_name;
                UserList[i].pass = user_pass;
                UserNumber = i;
            }
            username.Text = UserList[UserIndex].name;
            //初始化用户图片
            UserIconList = new Bitmap[nodeList.Count];
            for (int i = 0; i < nodeList.Count; i++)
            {
                XmlNode node = nodeList.Item(i);
                string user_name = ((XmlElement)node.SelectSingleNode("username")).GetAttribute("username");
                file = Application.StartupPath + @"\PC\users\" + user_name + @"\icon.gif";
                if (File.Exists(file))
                {
                    bitmap = new Bitmap(file);
                }
                else
                {
                    bitmap = WindowsFormsApp1.Properties.Resources.user;
                }
                bitmap = AroundBitmap(bitmap);
                UserIconList[i] = bitmap;
            }
            user.Image = UserIconList[UserIndex];
            //初始化背景图片
            file = Application.StartupPath + @"\PC\public\lock.gif";
            //判断有无用户自定义图片
            if (File.Exists(file))
            {
                bitmap = new Bitmap(file);
            }
            else
            {
                bitmap = WindowsFormsApp1.Properties.Resources.log;
            }
            this.BackgroundImage = bitmap;

        }

        #endregion

        public temp Temp;
        int err_time = 0;
        DateTime err_start = new DateTime();

        private void loginBtn_Click(object sender, EventArgs e)
        {
            //判断密码
            string pass = UserList[UserIndex].pass;
            if (userpass.Text == pass)
            {
                Temp.User = UserList[UserIndex].name;
                userpass.Visible = false;
                back.Visible = false;
                forward.Visible = false;
                loginBtn.Visible = false;
                wait.Visible = true;
                loading.Visible = true;
                usercon.Text = "你好，" + UserList[UserIndex].name;
                Shut.Visible = false;
                ShutMenu.Visible = false;
                //延时3秒
                DateTime dateTime = DateTime.Now;
                int s;
                do
                {
                    TimeSpan span = DateTime.Now - dateTime;
                    s = span.Seconds;
                    Application.DoEvents();
                }
                while (s <= 3);
                Tmp.user = this.Temp;
                this.Close();

                (new PC_Main()).Show();


            }
            else
            {
                err_time++;
                err_start = DateTime.Now;
                if (err_time >= 8)
                {
                    usercon.Text = "密码错误次数过多，即将关机！";
                    //延时3秒
                    int s = 0;
                    do
                    {
                        TimeSpan span = DateTime.Now - err_start;
                        s = span.Seconds;
                        Application.DoEvents();
                    }
                    while (s <= 3);
                    this.Close();
                    (new Shutdown()).Show();
                }
                else if (err_time >= 3)
                {
                    usercon.Text = "密码错误次数过多，请等待30秒！";
                    //延时30秒
                    int s = 0;
                    do
                    {
                        TimeSpan span = DateTime.Now - err_start;
                        s = span.Seconds;
                        Application.DoEvents();
                    }
                    while (s <= 30);
                }
                else
                {
                    usercon.Text = "密码错误！";
                    userpass.Text = "";
                    userpass.Focus();
                }
            }
        }

        public Bitmap AroundBitmap(Bitmap bitmap )
        {
            //创建圆形图片
            using (Image i = bitmap )
            {
                Bitmap b = new Bitmap(i.Width, i.Height);
                using (Graphics g = Graphics.FromImage(b))
                {
                    g.FillEllipse(new TextureBrush(i), 0, 0, i.Width, i.Height);
                }
                return b;
            }
        }
        #endregion

        #region 关机菜单
        public int ShutTime=0;
        private void Shut_Click(object sender, EventArgs e)
        {
            ShutTime = ShutTime + 1;
            if (ShutTime % 2 == 1)
            {
                ShutMenu.Visible = true;
                Shut.BorderStyle = BorderStyle.Fixed3D;

            }
            else
            {
                ShutMenu.Visible = false;
                Shut.BorderStyle = BorderStyle.None ;

            }
        }

        private void shut1_MouseEnter(object sender, EventArgs e)
        {
            shut1.BackColor = Color.DimGray;
            shut2.BackColor = Color.Black;
            shut3.BackColor = Color.Black;
            shut4.BackColor = Color.Black;

        }

        private void shut1_MouseLeave(object sender, EventArgs e)
        {
            shut1.BackColor = Color.Black;
            shut2.BackColor = Color.Black;
            shut3.BackColor = Color.Black;
            shut4.BackColor = Color.Black;

        }

        private void shut1_MouseDown(object sender, MouseEventArgs e)
        {
            shut1.BackColor = Color.Silver;
            shut2.BackColor = Color.Black;
            shut3.BackColor = Color.Black;
            shut4.BackColor = Color.Black;

        }

        private void shut1_MouseUp(object sender, MouseEventArgs e)
        {
            sleep.Visible = true;
        }

        private void shut2_MouseEnter(object sender, EventArgs e)
        {
            shut1.BackColor = Color.Black;
            shut2.BackColor = Color.DimGray;
            shut3.BackColor = Color.Black;
            shut4.BackColor = Color.Black;

        }

        private void shut2_MouseLeave(object sender, EventArgs e)
        {
            shut1.BackColor = Color.Black;
            shut2.BackColor = Color.Black;
            shut3.BackColor = Color.Black;
            shut4.BackColor = Color.Black;

        }

        private void shut2_MouseDown(object sender, MouseEventArgs e)
        {
            shut1.BackColor = Color.Black;
            shut2.BackColor = Color.Silver;
            shut3.BackColor = Color.Black;
            shut4.BackColor = Color.Black;

        }

        private void shut2_MouseUp(object sender, MouseEventArgs e)
        {
            sleep.Visible = true;
        }

        private void shut3_MouseEnter(object sender, EventArgs e)
        {
            shut1.BackColor = Color.Black;
            shut2.BackColor = Color.Black;
            shut3.BackColor = Color.DimGray;
            shut4.BackColor = Color.Black;

        }

        private void shut3_MouseLeave(object sender, EventArgs e)
        {
            shut1.BackColor = Color.Black;
            shut2.BackColor = Color.Black;
            shut3.BackColor = Color.Black;
            shut4.BackColor = Color.Black;

        }

        private void shut3_MouseDown(object sender, MouseEventArgs e)
        {
            shut1.BackColor = Color.Black;
            shut2.BackColor = Color.Black;
            shut3.BackColor = Color.Silver;
            shut4.BackColor = Color.Black;

        }

        private void shut3_MouseUp(object sender, MouseEventArgs e)
        {
            this.Hide();

            new Shutdown().Show();

        }

        private void shut4_MouseEnter(object sender, EventArgs e)
        {
            shut1.BackColor = Color.Black;
            shut2.BackColor = Color.Black;
            shut3.BackColor = Color.Black;
            shut4.BackColor = Color.DimGray;

        }

        private void shut4_MouseLeave(object sender, EventArgs e)
        {
            shut1.BackColor = Color.Black;
            shut2.BackColor = Color.Black;
            shut3.BackColor = Color.Black;
            shut4.BackColor = Color.Black;

        }

        private void shut4_MouseDown(object sender, MouseEventArgs e)
        {
            shut1.BackColor = Color.Black;
            shut2.BackColor = Color.Black;
            shut3.BackColor = Color.Black;
            shut4.BackColor = Color.Silver;

        }

        private void shut4_MouseUp(object sender, MouseEventArgs e)
        {
            MessageBox.Show("对不起，\n在本实验版本中重启功能无法启用。\a", "PC 1.0", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void sleep_Click(object sender, EventArgs e)
        {
            sleep.Visible = false;
        }

        #endregion

    }
}
