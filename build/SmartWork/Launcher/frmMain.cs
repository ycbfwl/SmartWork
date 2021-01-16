using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Launcher
{
    public partial class frmMain : Form
    {
        static string strPath = @"..\..\resp\ProgramsList.xml";
        string assPath = "bin";

        public frmMain()
        {
            InitializeComponent();
        }



        private void frmMain_Load(object sender, EventArgs e)
        {
            frmLogin F_Logon = new frmLogin();

            DataSet dsPrograms = Utils.getXmlInfo(strPath);
            assPath = dsPrograms.Tables["config"].Rows[0][0].ToString() ;
            DataTable dtPrograms = dsPrograms.Tables["program"].Copy();


            if (F_Logon.ShowDialog() == DialogResult.OK)
            {
                GetMenu(tvMain, dtPrograms);
            }


            this.plMainBody.Height = this.plMain.Height - this.plMainTop.Height - 20;

        }


        public void GetMenu(TreeView treeV,DataTable dtSource)
        {
            
            for (int i = 0; i < dtSource.Rows.Count; i++) 
            {
                String name = dtSource.Rows[i]["Name"].ToString();
                String id = dtSource.Rows[i]["ID"].ToString();
                String desc = dtSource.Rows[i]["DESC"].ToString();
                String assPath = dtSource.Rows[i]["AssemblyPath"].ToString();
                String className = dtSource.Rows[i]["ClassName"].ToString();
                FrmInfo f = new FrmInfo(name, id, desc, assPath, className);
                TreeNode newNode1 = treeV.Nodes.Add(name);
                newNode1.Tag = f;//标识，有子项的命令项
                
                
            }
        }

        private void tvMain_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode tn = e.Node;
            FrmInfo fi = (FrmInfo)tn.Tag;

            var uiClass = Assembly.LoadFrom(assPath.Trim() + fi.assemblyPath.Trim());
            var ui = uiClass.CreateInstance(fi.className);

            Form frm = (Form)ui;


            frm.TopLevel = false;
            TabPage tabPage = new TabPage();
            tabPage.Text = fi.name;
            tabPage.UseVisualStyleBackColor = true;
            this.tabMain.Controls.Add(tabPage);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.WindowState = FormWindowState.Maximized;
            frm.TopMost = false;
            frm.Show();
            frm.Dock = DockStyle.Fill;
            tabPage.Controls.Add(frm);
            this.tabMain.SelectedTab = tabPage;

        }
    }
}
