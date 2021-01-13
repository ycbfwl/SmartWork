using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Launcher
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserID.Text.Equals(txtPW.Text ))
            {
                DialogResult = DialogResult.OK;//将当前窗体的对话框返回值设为OK
                this.Close();
            }
            else
            {
                MessageBox.Show("用户名或密码错误。");
            }
                
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
