﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml;
using System.Drawing.Imaging;


namespace WindowsFormsApp1
{
    public partial class PC_Main : Form
    {
        #region ImportArea
        #endregion

        public PC_Main()
        {
            InitializeComponent();
        }

        public PC_Main(temp Tm)
        {
            Temp = Tm;
            InitializeComponent();
        }

        private void PC_Main_FormClosed(object sender, FormClosedEventArgs e)
        {


            Application.Exit();

        }

        private void PC_Main_Load(object sender, EventArgs e)
        {
            string file;
            Bitmap bitmap;
            Temp = Tmp.user;
            //初始化背景图片
            file = Application.StartupPath + @"\Image\back.gif";
            //判断有无用户自定义图片
            if (File.Exists(file))
            {
                bitmap = new Bitmap(file);
            }
            else
            {
                bitmap = WindowsFormsApp1.Properties.Resources.back;
            }
            this.BackgroundImage = bitmap;

            //初始化菜单
            Menu_Load();

            //初始化桌面
            Desktop_Load();
        }

        public temp Temp;


        #region 菜单组
            private void Menu_Load()
            {
                #region 初始化
                Bitmap b = new Bitmap(1200,40);
                Graphics g = Graphics.FromImage(b);
                g.FillRectangle(new SolidBrush(Color.FromArgb(0,0,0,0)), 0, 0, 1200, 40);
                //初始化控件
                settings.Top = 298;
                UserIcon.Top = 252;
                task.Image = b;
                #endregion
                #region 读背景图像
                string file = Application.StartupPath + @"\PC\users\" + Temp.User + @"\back.gif";
                if (File.Exists(file))
                {
                    b = new Bitmap(file);
                    this.BackgroundImage = b;
                }
                #endregion
                #region 读开始菜单xml
                if (File.Exists(Application.StartupPath + @"\PC\users\"+ Temp.User + @"\menu.xml")) File.Delete(Application.StartupPath + @"\PC\users\" + Temp.User + @"\menu.xml");
                File.Copy(Application.StartupPath + @"\PC\users\" + Temp.User + @"\menu.dll", Application.StartupPath + @"\PC\users\" + Temp.User + @"\menu.xml");
                XmlDocument xml = new XmlDocument();
                xml.Load(Application.StartupPath + @"\PC\users\" + Temp.User + @"\menu.xml");
                XmlElement root = (XmlElement)xml.SelectSingleNode("menu");
                XmlNodeList nodeList = root.GetElementsByTagName("item");
                    //读开始菜单项
                    string[] menu_items_text = new string[nodeList.Count];
                    Label label = new Label();
                    for(int i=0;i<nodeList.Count;i++)
                    {
                        menu_items_text[i] = ((XmlElement)nodeList[i]).GetAttribute("name");
                        label = new Label();
                        label.Name = "menu_" + ((XmlElement)nodeList[i]).GetAttribute("start");
                        label.Text = menu_items_text[i];
                        label.ForeColor = Color.White;
                        label.Font = new Font("宋体", 30F, FontStyle.Regular, GraphicsUnit.Pixel, (byte)134);
                        menuList.Controls.Add(label);
                        label.Parent = menuList;
                        label.BackColor = Color.Black;
                        label.Width = 280;
                        label.Left = 40;
                        label.Height = 40;
                        label.Top = 40 * i;
                        label.Click += new EventHandler(menu_item_click);
                    }
                    #region 读开始菜单图标
                    PictureBox pictureBox = new PictureBox();
                        for(int i=0; i<nodeList.Count;i++)
                        {
                            pictureBox = new PictureBox();
                            pictureBox.BackColor = Color.Transparent;
                            string str = ((XmlElement)nodeList[i]).GetAttribute("start");
                            pictureBox.Name = "menu_" + str;
                            string exe = str;
                            if (exe.Substring(0, 1) == "$")
                            {
                                //有$按相对路径
                                exe = Application.StartupPath + exe.Substring(1);
                            }
                            else if (exe.Substring(0, 1) == "%")
                            {
                                //有%查询系统路径
                                if (exe.Substring(0, 7) == "%Drive%")
                                {
                                    var a = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
                                    DirectoryInfo d = new DirectoryInfo(a);
                                    d = d.Root;
                                    a = d.FullName; //a带有"\"
                                    a = a.Substring(0, 2);  //只有盘符（C:)
                                    exe = a + exe.Substring(7);

                                }
                                else if (exe.Substring(0, 6) == "%Root%")
                                {
                                    var a = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
                                    DirectoryInfo d = new DirectoryInfo(a);
                                    a = d.FullName; //a带有"\"
                                    exe = a + exe.Substring(6);

                                }
                                else;
                                {

                                }
                            }
                            str = exe;
                            pictureBox.Left = 4;
                            pictureBox.Top = 40 * i + 4;
                            pictureBox.Width = 32;
                            pictureBox.Height = 32;
                            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                            menuList.Controls.Add(pictureBox);
                            file = ((XmlElement)nodeList[i]).GetAttribute("icon");
                            if (File.Exists(file))
                            {
                                b = new Bitmap(file);
                            }
                            else if (file.Substring(0, 1) == ",")
                            {
                                str = @"-open " + str + @" -save " + Application.StartupPath + @"\PC\temp\abc.rc" + @" -action extract" + @" -mask ICONGROUP,,";
                                System.Diagnostics.Process process = System.Diagnostics.Process.Start(Application.StartupPath + @"\PC\public\extern\RH\ResourceHacker.exe ", str);
                                while(process.HasExited==false)
                                { Application.DoEvents(); }
                                file = "ICON_" + file.Substring(1);
                                if (File.Exists(Application.StartupPath + @"\PC\temp\" + file))
                                {
                                    b = new Bitmap(Application.StartupPath + @"\PC\temp\" + file);
                                }
                                else
                                {
                                    b = Properties.Resources.emptyFile;
                                }
                            }

                            else if (file.Substring(0, 1) == ";")
                            {
                                str = @"-open " + str + @" -save " + Application.StartupPath + @"\PC\temp\abc.rc" + @" -action extract" + @" -mask ICONGROUP,,";
                                System.Diagnostics.Process process = System.Diagnostics.Process.Start(Application.StartupPath + @"\PC\public\extern\RH\ResourceHacker.exe ", str);
                                while (process.HasExited == false)
                                { Application.DoEvents(); }
                                file = "ICO_" + file.Substring(1);
                                if (File.Exists(Application.StartupPath + @"\PC\temp\" + file))
                                {
                                    b = new Bitmap(Application.StartupPath + @"\PC\temp\" + file);
                                }
                                else
                                {
                                    b = Properties.Resources.emptyFile;
                                }
                            }

                        else

                        {
                                b = Properties.Resources.emptyFile;
                            }
                            pictureBox.Image = b;
                            pictureBox.Click += new EventHandler(this.menu_item_click);

                        }
                    #endregion
                File.Delete(Application.StartupPath + @"\PC\users\" + Temp.User + @"\menu.xml");
                #endregion
                #region  读用户头像
                file = Application.StartupPath + @"\PC\users\" + Temp.User + @"\icon.gif";
                if (File.Exists(file))
                {
                    b = new Bitmap(file);
                }
                else
                {
                    b = WindowsFormsApp1.Properties.Resources.user;
                }
                login login = new login();
                UserIcon.Image = login.AroundBitmap(b);
                #endregion
            }

            private void menu_item_click(object sender,EventArgs e)
            {
                dynamic l = sender;
                string exe = l.Name.Substring(5);
                if(exe.Substring(0,1)=="$")
                {
                    //有$按相对路径
                    exe = Application.StartupPath + exe.Substring(1);
                }
                else if(exe.Substring(0,1)=="%")
                {
                    //有%查询系统路径
                    if (exe.Substring(0, 7) == "%Drive%")
                    {
                        var a = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
                        DirectoryInfo d = new DirectoryInfo(a);
                        d = d.Root;
                        a = d.FullName; //a带有"\"
                        a = a.Substring(0, 2);  //只有盘符（C:)
                        exe = a + exe.Substring(7);

                    }
                    else if (exe.Substring(0, 6) == "%Root%")
                    {
                        var a = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
                        DirectoryInfo d = new DirectoryInfo(a);
                        a = d.FullName; //a带有"\"
                        exe = a + exe.Substring(6);

                    }
                    else;
                    {
                    
                    }
                }
                System.Diagnostics.Process.Start(exe);

            }
            #region 关机菜单
            private void sleep_Click(object sender, EventArgs e)
            {
                sleep.Size = new Size(0, 0);
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
                sleep.Size = new Size(Width, Height);
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
                sleep.Size = new Size(Width, Height);
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
            #endregion
            #region 菜单出入管理
            int ShutMenuT = 0;
            private void shutBtn_Click(object sender, EventArgs e)
            {
                ShutMenuT = ShutMenuT + 1;
                if(ShutMenuT%2==1)
                {
                    ShutMenu.Visible = true;
                }
                else
                {
                    ShutMenu.Visible = false;
                }
            }
            int menuMainT = 0;
            private void menuBtn_Click(object sender, EventArgs e)
            {
                menuMainT = menuMainT + 1;
                if(menuMainT%2==1)
                {
                    menuMain.Visible = true;
                }
                else
                {
                    menuMain.Visible = false;
                }
            }

            #endregion
            private void settings_Click(object sender, EventArgs e)
            {
                System.Diagnostics.Process.Start(Application.StartupPath + @"\control.exe");
            }

            private void task_Click(object sender, EventArgs e)
            {

            }
        #endregion

        private void PC_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        #region 桌面组        
            private void Desktop_Load()
            {
                #region Get DesktopIcons
                ArrayList DI_List = new ArrayList();
                DirectoryInfo d = new DirectoryInfo(Application.StartupPath + @"\PC\users\" + Temp.User + @"\Desktop");
                /*
                Bitmap btemp = new Bitmap(@"E:\3.gif");
                DIO.DI dI = new DIO.DI("new icon", btemp);
                dI.X = 2;
                dI.Y = 3;
                DIO.writeDI(d.FullName, dI);
                */
                DIO.readDIs(d, out DI_List);
                #endregion
                #region Draw DesktopIcons
                foreach (DIO.DI i in DI_List)
                {
                    //Create a Control
                    MainPart.DesktopIcon desktopIcon = new MainPart.DesktopIcon();
                    desktopIcon.Name = "DesktopIcon";
                    //Put the control
                    desktopIcon.Left = 80 * i.X + 3;
                    desktopIcon.Top = 120 * i.Y + 4;
                    //Show the control
                    desktopIcon.Image = i.Icon;
                    desktopIcon.Caption = i.Name;
                    Desktop_Main.Controls.Add(desktopIcon);
                    //Try the existed control
                    desktopIcon1.Caption = ((DIO.DI)DI_List[0]).Name;
                    desktopIcon1.Image = ((DIO.DI)DI_List[0]).Icon;
                
                }
                #endregion
            }

            #region 图标拖动
            private void Icon_MouseDown(object sender, MouseEventArgs e)
            {

            }
            
            private void Icon_MouseMove(object sender, MouseEventArgs e)
            {

            }
            #endregion
        #endregion
    }
}