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
    public partial class RightKeyMenu : UserControl
    {
        public RightKeyMenu(Control control)
        {
            InitializeComponent();
            linked = control;
            load();
        }

        #region Attributes

        //绑定的控件
        private Control linked { get; set; }

        #endregion

        #region Events

        //控件被删除
        private void DestroySelf( object sender, EventArgs e)
        {
            this.Dispose();
        }

        //控件被右击
        private void RightClick(object sender,EventArgs e)
        {
            if (1==0) return;
            /*
            Left = linked.Left + e.X;
            Top = linked.Top + e.Y; */
            Visible = true;
           
        }

        #endregion

        #region functions

        //初始化
        private void load()
        {
            linked.Parent.Controls.Add(this);
            Visible = false;
            linked.Disposed += DestroySelf;
            linked.Click += RightClick;

        }


        #endregion 
    }
}
