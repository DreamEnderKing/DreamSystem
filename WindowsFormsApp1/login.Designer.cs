namespace WindowsFormsApp1
{
    partial class login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.wait = new System.Windows.Forms.PictureBox();
            this.user = new System.Windows.Forms.PictureBox();
            this.username = new System.Windows.Forms.Label();
            this.loading = new System.Windows.Forms.Label();
            this.loginBtn = new System.Windows.Forms.Button();
            this.Shut = new System.Windows.Forms.PictureBox();
            this.forward = new System.Windows.Forms.PictureBox();
            this.back = new System.Windows.Forms.PictureBox();
            this.ShutMenu = new System.Windows.Forms.GroupBox();
            this.shut4 = new System.Windows.Forms.Label();
            this.shut3 = new System.Windows.Forms.Label();
            this.shut2 = new System.Windows.Forms.Label();
            this.shut1 = new System.Windows.Forms.Label();
            this.userpass = new System.Windows.Forms.TextBox();
            this.usercon = new System.Windows.Forms.Label();
            this.sleep = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.wait)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.user)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Shut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.forward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.back)).BeginInit();
            this.ShutMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // wait
            // 
            this.wait.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wait.BackColor = System.Drawing.Color.Transparent;
            this.wait.Image = global::WindowsFormsApp1.Properties.Resources.img001;
            this.wait.Location = new System.Drawing.Point(500, 379);
            this.wait.Name = "wait";
            this.wait.Size = new System.Drawing.Size(48, 45);
            this.wait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.wait.TabIndex = 0;
            this.wait.TabStop = false;
            this.wait.Visible = false;
            // 
            // user
            // 
            this.user.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.user.BackColor = System.Drawing.Color.Transparent;
            this.user.Image = ((System.Drawing.Image)(resources.GetObject("user.Image")));
            this.user.Location = new System.Drawing.Point(500, 100);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(200, 200);
            this.user.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.user.TabIndex = 2;
            this.user.TabStop = false;
            // 
            // username
            // 
            this.username.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.username.BackColor = System.Drawing.Color.Transparent;
            this.username.Font = new System.Drawing.Font("宋体", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.username.ForeColor = System.Drawing.Color.White;
            this.username.Location = new System.Drawing.Point(500, 319);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(200, 42);
            this.username.TabIndex = 3;
            this.username.Text = "label1";
            this.username.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // loading
            // 
            this.loading.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loading.BackColor = System.Drawing.Color.Transparent;
            this.loading.Font = new System.Drawing.Font("宋体", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.loading.ForeColor = System.Drawing.Color.White;
            this.loading.Location = new System.Drawing.Point(554, 382);
            this.loading.Name = "loading";
            this.loading.Size = new System.Drawing.Size(200, 42);
            this.loading.TabIndex = 4;
            this.loading.Text = "正在登录";
            this.loading.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.loading.Visible = false;
            // 
            // loginBtn
            // 
            this.loginBtn.BackColor = System.Drawing.Color.Transparent;
            this.loginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginBtn.Font = new System.Drawing.Font("宋体", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.loginBtn.ForeColor = System.Drawing.Color.Aqua;
            this.loginBtn.Location = new System.Drawing.Point(536, 427);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(119, 54);
            this.loginBtn.TabIndex = 5;
            this.loginBtn.Text = "登录\r\n";
            this.loginBtn.UseVisualStyleBackColor = false;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // Shut
            // 
            this.Shut.BackColor = System.Drawing.Color.Transparent;
            this.Shut.Image = ((System.Drawing.Image)(resources.GetObject("Shut.Image")));
            this.Shut.Location = new System.Drawing.Point(1130, 537);
            this.Shut.Name = "Shut";
            this.Shut.Size = new System.Drawing.Size(58, 51);
            this.Shut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Shut.TabIndex = 6;
            this.Shut.TabStop = false;
            this.Shut.Click += new System.EventHandler(this.Shut_Click);
            // 
            // forward
            // 
            this.forward.BackColor = System.Drawing.Color.Transparent;
            this.forward.Image = ((System.Drawing.Image)(resources.GetObject("forward.Image")));
            this.forward.Location = new System.Drawing.Point(714, 319);
            this.forward.Name = "forward";
            this.forward.Size = new System.Drawing.Size(40, 40);
            this.forward.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.forward.TabIndex = 14;
            this.forward.TabStop = false;
            this.forward.Click += new System.EventHandler(this.forward_Click);
            // 
            // back
            // 
            this.back.BackColor = System.Drawing.Color.Transparent;
            this.back.Image = ((System.Drawing.Image)(resources.GetObject("back.Image")));
            this.back.Location = new System.Drawing.Point(454, 319);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(40, 40);
            this.back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.back.TabIndex = 15;
            this.back.TabStop = false;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // ShutMenu
            // 
            this.ShutMenu.Controls.Add(this.shut4);
            this.ShutMenu.Controls.Add(this.shut3);
            this.ShutMenu.Controls.Add(this.shut2);
            this.ShutMenu.Controls.Add(this.shut1);
            this.ShutMenu.Location = new System.Drawing.Point(1068, 379);
            this.ShutMenu.Name = "ShutMenu";
            this.ShutMenu.Size = new System.Drawing.Size(120, 160);
            this.ShutMenu.TabIndex = 16;
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
            // userpass
            // 
            this.userpass.Font = new System.Drawing.Font("宋体", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.userpass.Location = new System.Drawing.Point(454, 377);
            this.userpass.Name = "userpass";
            this.userpass.PasswordChar = '•';
            this.userpass.Size = new System.Drawing.Size(300, 42);
            this.userpass.TabIndex = 17;
            this.userpass.WordWrap = false;
            // 
            // usercon
            // 
            this.usercon.BackColor = System.Drawing.Color.Transparent;
            this.usercon.Font = new System.Drawing.Font("宋体", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.usercon.ForeColor = System.Drawing.Color.White;
            this.usercon.Location = new System.Drawing.Point(100, 20);
            this.usercon.Name = "usercon";
            this.usercon.Size = new System.Drawing.Size(1000, 80);
            this.usercon.TabIndex = 18;
            this.usercon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sleep
            // 
            this.sleep.BackColor = System.Drawing.Color.Black;
            this.sleep.Location = new System.Drawing.Point(0, 0);
            this.sleep.Name = "sleep";
            this.sleep.Size = new System.Drawing.Size(62, 63);
            this.sleep.TabIndex = 19;
            this.sleep.Text = "sleep";
            this.sleep.Visible = false;
            this.sleep.Click += new System.EventHandler(this.sleep_Click);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1200, 600);
            this.Controls.Add(this.sleep);
            this.Controls.Add(this.usercon);
            this.Controls.Add(this.userpass);
            this.Controls.Add(this.ShutMenu);
            this.Controls.Add(this.back);
            this.Controls.Add(this.forward);
            this.Controls.Add(this.Shut);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.loading);
            this.Controls.Add(this.user);
            this.Controls.Add(this.wait);
            this.Controls.Add(this.username);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.login_Load);
            this.Click += new System.EventHandler(this.login_Click);
            ((System.ComponentModel.ISupportInitialize)(this.wait)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.user)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Shut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.forward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.back)).EndInit();
            this.ShutMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox wait;
        private System.Windows.Forms.PictureBox user;
        private System.Windows.Forms.Label username;
        private System.Windows.Forms.Label loading;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.PictureBox Shut;
        private System.Windows.Forms.PictureBox forward;
        private System.Windows.Forms.PictureBox back;
        private System.Windows.Forms.GroupBox ShutMenu;
        private System.Windows.Forms.Label shut4;
        private System.Windows.Forms.Label shut3;
        private System.Windows.Forms.Label shut2;
        private System.Windows.Forms.Label shut1;
        private System.Windows.Forms.TextBox userpass;
        private System.Windows.Forms.Label usercon;
        private System.Windows.Forms.Label sleep;
    }
}