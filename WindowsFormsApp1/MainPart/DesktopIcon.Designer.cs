namespace WindowsFormsApp1.MainPart
{
    partial class DesktopIcon
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "12345678901234567890\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Click += new System.EventHandler(this.DesktopIcon_Click);
            this.label1.DoubleClick += new System.EventHandler(this.DesktopIcon_DoubleClick);
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DesktopIcon_MouseDown);
            this.label1.MouseEnter += new System.EventHandler(this.DesktopIcon_MouseEnter);
            this.label1.MouseLeave += new System.EventHandler(this.DesktopIcon_MouseLeave);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DesktopIcon_MouseMove);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DesktopIcon_MouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(5, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.DesktopIcon_Click);
            this.pictureBox1.DoubleClick += new System.EventHandler(this.DesktopIcon_DoubleClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DesktopIcon_MouseDown);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.DesktopIcon_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.DesktopIcon_MouseLeave);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DesktopIcon_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DesktopIcon_MouseUp);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // DesktopIcon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "DesktopIcon";
            this.Size = new System.Drawing.Size(74, 111);
            this.Load += new System.EventHandler(this.DesktopIcon_Load);
            this.Click += new System.EventHandler(this.DesktopIcon_Click);
            this.DoubleClick += new System.EventHandler(this.DesktopIcon_DoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DesktopIcon_MouseDown);
            this.MouseEnter += new System.EventHandler(this.DesktopIcon_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.DesktopIcon_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DesktopIcon_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DesktopIcon_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}
