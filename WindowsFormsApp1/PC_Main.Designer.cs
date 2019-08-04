namespace WindowsFormsApp1
{
    partial class PC_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PC_Main));
            this.task = new System.Windows.Forms.PictureBox();
            this.menuBtn = new System.Windows.Forms.PictureBox();
            this.menuMain = new System.Windows.Forms.GroupBox();
            this.ShutMenu = new System.Windows.Forms.GroupBox();
            this.shut4 = new System.Windows.Forms.Label();
            this.shut3 = new System.Windows.Forms.Label();
            this.shut2 = new System.Windows.Forms.Label();
            this.shut1 = new System.Windows.Forms.Label();
            this.UserIcon = new System.Windows.Forms.PictureBox();
            this.menuList = new System.Windows.Forms.Panel();
            this.shutBtn = new System.Windows.Forms.PictureBox();
            this.settings = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sleep = new System.Windows.Forms.Label();
            this.wlanShow1 = new MyControls.WlanShow_Icon();
            this.timeShow2 = new MyControls.TimeShow();
            this.Desktop_Main = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.task)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuBtn)).BeginInit();
            this.menuMain.SuspendLayout();
            this.ShutMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shutBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.settings)).BeginInit();
            this.SuspendLayout();
            // 
            // task
            // 
            this.task.BackColor = System.Drawing.Color.Black;
            this.task.Location = new System.Drawing.Point(0, 600);
            this.task.Name = "task";
            this.task.Size = new System.Drawing.Size(1200, 50);
            this.task.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.task.TabIndex = 0;
            this.task.TabStop = false;
            this.task.Click += new System.EventHandler(this.task_Click);
            // 
            // menuBtn
            // 
            this.menuBtn.BackColor = System.Drawing.Color.Black;
            this.menuBtn.Image = ((System.Drawing.Image)(resources.GetObject("menuBtn.Image")));
            this.menuBtn.Location = new System.Drawing.Point(0, 600);
            this.menuBtn.Name = "menuBtn";
            this.menuBtn.Size = new System.Drawing.Size(53, 50);
            this.menuBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.menuBtn.TabIndex = 1;
            this.menuBtn.TabStop = false;
            this.menuBtn.Click += new System.EventHandler(this.menuBtn_Click);
            // 
            // menuMain
            // 
            this.menuMain.BackColor = System.Drawing.Color.Black;
            this.menuMain.Controls.Add(this.ShutMenu);
            this.menuMain.Controls.Add(this.UserIcon);
            this.menuMain.Controls.Add(this.menuList);
            this.menuMain.Controls.Add(this.shutBtn);
            this.menuMain.Controls.Add(this.settings);
            this.menuMain.Controls.Add(this.label1);
            this.menuMain.Location = new System.Drawing.Point(0, 219);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(390, 381);
            this.menuMain.TabIndex = 2;
            this.menuMain.TabStop = false;
            this.menuMain.Text = "1111111111111111111111111111111111111111111111111111111111111111";
            this.menuMain.Visible = false;
            // 
            // ShutMenu
            // 
            this.ShutMenu.Controls.Add(this.shut4);
            this.ShutMenu.Controls.Add(this.shut3);
            this.ShutMenu.Controls.Add(this.shut2);
            this.ShutMenu.Controls.Add(this.shut1);
            this.ShutMenu.Location = new System.Drawing.Point(0, 174);
            this.ShutMenu.Name = "ShutMenu";
            this.ShutMenu.Size = new System.Drawing.Size(120, 160);
            this.ShutMenu.TabIndex = 17;
            this.ShutMenu.TabStop = false;
            this.ShutMenu.Text = "groupBox1";
            this.ShutMenu.Visible = false;
            // 
            // shut4
            // 
            this.shut4.BackColor = System.Drawing.Color.Black;
            this.shut4.Font = new System.Drawing.Font("宋体", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.shut4.ForeColor = System.Drawing.Color.White;
            this.shut4.Location = new System.Drawing.Point(0, 120);
            this.shut4.Name = "shut4";
            this.shut4.Size = new System.Drawing.Size(120, 40);
            this.shut4.TabIndex = 3;
            this.shut4.Text = "重启";
            this.shut4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.shut4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.shut4_MouseDown);
            this.shut4.MouseEnter += new System.EventHandler(this.shut4_MouseEnter);
            this.shut4.MouseLeave += new System.EventHandler(this.shut4_MouseLeave);
            this.shut4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.shut4_MouseUp);
            // 
            // shut3
            // 
            this.shut3.BackColor = System.Drawing.Color.Black;
            this.shut3.Font = new System.Drawing.Font("宋体", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.shut3.ForeColor = System.Drawing.Color.White;
            this.shut3.Location = new System.Drawing.Point(0, 80);
            this.shut3.Name = "shut3";
            this.shut3.Size = new System.Drawing.Size(120, 40);
            this.shut3.TabIndex = 2;
            this.shut3.Text = "关机";
            this.shut3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.shut3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.shut3_MouseDown);
            this.shut3.MouseEnter += new System.EventHandler(this.shut3_MouseEnter);
            this.shut3.MouseLeave += new System.EventHandler(this.shut3_MouseLeave);
            this.shut3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.shut3_MouseUp);
            // 
            // shut2
            // 
            this.shut2.BackColor = System.Drawing.Color.Black;
            this.shut2.Font = new System.Drawing.Font("宋体", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.shut2.ForeColor = System.Drawing.Color.White;
            this.shut2.Location = new System.Drawing.Point(0, 40);
            this.shut2.Name = "shut2";
            this.shut2.Size = new System.Drawing.Size(120, 40);
            this.shut2.TabIndex = 1;
            this.shut2.Text = "休眠";
            this.shut2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.shut2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.shut2_MouseDown);
            this.shut2.MouseEnter += new System.EventHandler(this.shut2_MouseEnter);
            this.shut2.MouseLeave += new System.EventHandler(this.shut2_MouseLeave);
            this.shut2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.shut2_MouseUp);
            // 
            // shut1
            // 
            this.shut1.BackColor = System.Drawing.Color.Black;
            this.shut1.Font = new System.Drawing.Font("宋体", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.shut1.ForeColor = System.Drawing.Color.White;
            this.shut1.Location = new System.Drawing.Point(0, 0);
            this.shut1.Name = "shut1";
            this.shut1.Size = new System.Drawing.Size(120, 40);
            this.shut1.TabIndex = 0;
            this.shut1.Text = "睡眠";
            this.shut1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.shut1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.shut1_MouseDown);
            this.shut1.MouseEnter += new System.EventHandler(this.shut1_MouseEnter);
            this.shut1.MouseLeave += new System.EventHandler(this.shut1_MouseLeave);
            this.shut1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.shut1_MouseUp);
            // 
            // UserIcon
            // 
            this.UserIcon.Location = new System.Drawing.Point(0, 40);
            this.UserIcon.Name = "UserIcon";
            this.UserIcon.Size = new System.Drawing.Size(46, 46);
            this.UserIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.UserIcon.TabIndex = 20;
            this.UserIcon.TabStop = false;
            // 
            // menuList
            // 
            this.menuList.AutoScroll = true;
            this.menuList.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.menuList.Location = new System.Drawing.Point(46, 0);
            this.menuList.Name = "menuList";
            this.menuList.Size = new System.Drawing.Size(344, 381);
            this.menuList.TabIndex = 19;
            // 
            // shutBtn
            // 
            this.shutBtn.Image = ((System.Drawing.Image)(resources.GetObject("shutBtn.Image")));
            this.shutBtn.Location = new System.Drawing.Point(0, 331);
            this.shutBtn.Name = "shutBtn";
            this.shutBtn.Size = new System.Drawing.Size(53, 50);
            this.shutBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.shutBtn.TabIndex = 0;
            this.shutBtn.TabStop = false;
            this.shutBtn.Click += new System.EventHandler(this.shutBtn_Click);
            // 
            // settings
            // 
            this.settings.BackColor = System.Drawing.Color.Transparent;
            this.settings.Image = ((System.Drawing.Image)(resources.GetObject("settings.Image")));
            this.settings.Location = new System.Drawing.Point(7, 347);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(34, 33);
            this.settings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.settings.TabIndex = 18;
            this.settings.TabStop = false;
            this.settings.Click += new System.EventHandler(this.settings_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 381);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // sleep
            // 
            this.sleep.BackColor = System.Drawing.Color.Black;
            this.sleep.Location = new System.Drawing.Point(0, 0);
            this.sleep.Name = "sleep";
            this.sleep.Size = new System.Drawing.Size(0, 0);
            this.sleep.TabIndex = 3;
            this.sleep.Click += new System.EventHandler(this.sleep_Click);
            // 
            // wlanShow1
            // 
            this.wlanShow1.BackColor = System.Drawing.Color.Black;
            this.wlanShow1.Location = new System.Drawing.Point(1124, 600);
            this.wlanShow1.Name = "wlanShow1";
            this.wlanShow1.Size = new System.Drawing.Size(48, 48);
            this.wlanShow1.TabIndex = 0;
            // 
            // timeShow2
            // 
            this.timeShow2.BackColor = System.Drawing.Color.Black;
            this.timeShow2.Location = new System.Drawing.Point(963, 600);
            this.timeShow2.Name = "timeShow2";
            this.timeShow2.Size = new System.Drawing.Size(155, 51);
            this.timeShow2.TabIndex = 4;
            // 
            // Desktop_Main
            // 
            this.Desktop_Main.AllowDrop = true;
            this.Desktop_Main.BackColor = System.Drawing.Color.Transparent;
            this.Desktop_Main.Location = new System.Drawing.Point(0, 0);
            this.Desktop_Main.Name = "Desktop_Main";
            this.Desktop_Main.Size = new System.Drawing.Size(1200, 600);
            this.Desktop_Main.TabIndex = 5;
            this.Desktop_Main.DragDrop += new System.Windows.Forms.DragEventHandler(this.Desktop_Main_DragDrop);
            this.Desktop_Main.DragEnter += new System.Windows.Forms.DragEventHandler(this.Desktop_Main_DragEnter);
            // 
            // PC_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1200, 650);
            this.Controls.Add(this.sleep);
            this.Controls.Add(this.timeShow2);
            this.Controls.Add(this.wlanShow1);
            this.Controls.Add(this.menuMain);
            this.Controls.Add(this.menuBtn);
            this.Controls.Add(this.task);
            this.Controls.Add(this.Desktop_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PC_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PC_Main_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PC_Main_FormClosed);
            this.Load += new System.EventHandler(this.PC_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.task)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuBtn)).EndInit();
            this.menuMain.ResumeLayout(false);
            this.ShutMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UserIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shutBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.settings)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox task;
        private System.Windows.Forms.PictureBox menuBtn;
        private System.Windows.Forms.GroupBox menuMain;
        private System.Windows.Forms.PictureBox shutBtn;
        private System.Windows.Forms.GroupBox ShutMenu;
        private System.Windows.Forms.Label shut4;
        private System.Windows.Forms.Label shut3;
        private System.Windows.Forms.Label shut2;
        private System.Windows.Forms.Label shut1;
        private System.Windows.Forms.Label sleep;
        private System.Windows.Forms.PictureBox settings;
        private System.Windows.Forms.Panel menuList;
        private System.Windows.Forms.PictureBox UserIcon;
        private MyControls.WlanShow_Icon wlanShow1;
        private MyControls.TimeShow timeShow2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel Desktop_Main;
    }
}