namespace Launcher
{
    partial class frmMain
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.plMainTop = new System.Windows.Forms.Panel();
            this.plMainBody = new System.Windows.Forms.Panel();
            this.plUIBase = new System.Windows.Forms.Panel();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.plMainTreeView = new System.Windows.Forms.Panel();
            this.tvMain = new System.Windows.Forms.TreeView();
            this.plMain = new System.Windows.Forms.Panel();
            this.plMainBody.SuspendLayout();
            this.plUIBase.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.plMainTreeView.SuspendLayout();
            this.plMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // plMainTop
            // 
            this.plMainTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.plMainTop.Location = new System.Drawing.Point(0, 0);
            this.plMainTop.Name = "plMainTop";
            this.plMainTop.Size = new System.Drawing.Size(834, 51);
            this.plMainTop.TabIndex = 0;
            // 
            // plMainBody
            // 
            this.plMainBody.Controls.Add(this.plUIBase);
            this.plMainBody.Controls.Add(this.plMainTreeView);
            this.plMainBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plMainBody.Location = new System.Drawing.Point(0, 51);
            this.plMainBody.Name = "plMainBody";
            this.plMainBody.Size = new System.Drawing.Size(834, 482);
            this.plMainBody.TabIndex = 1;
            // 
            // plUIBase
            // 
            this.plUIBase.Controls.Add(this.tabMain);
            this.plUIBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plUIBase.Location = new System.Drawing.Point(203, 0);
            this.plUIBase.Name = "plUIBase";
            this.plUIBase.Size = new System.Drawing.Size(631, 482);
            this.plUIBase.TabIndex = 1;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(631, 482);
            this.tabMain.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(623, 456);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Home";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // plMainTreeView
            // 
            this.plMainTreeView.Controls.Add(this.tvMain);
            this.plMainTreeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.plMainTreeView.Location = new System.Drawing.Point(0, 0);
            this.plMainTreeView.Name = "plMainTreeView";
            this.plMainTreeView.Size = new System.Drawing.Size(203, 482);
            this.plMainTreeView.TabIndex = 0;
            // 
            // tvMain
            // 
            this.tvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvMain.Location = new System.Drawing.Point(0, 0);
            this.tvMain.Name = "tvMain";
            this.tvMain.Size = new System.Drawing.Size(203, 482);
            this.tvMain.TabIndex = 0;
            this.tvMain.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvMain_NodeMouseDoubleClick);
            // 
            // plMain
            // 
            this.plMain.Controls.Add(this.plMainBody);
            this.plMain.Controls.Add(this.plMainTop);
            this.plMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plMain.Location = new System.Drawing.Point(0, 0);
            this.plMain.Name = "plMain";
            this.plMain.Size = new System.Drawing.Size(834, 533);
            this.plMain.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 533);
            this.Controls.Add(this.plMain);
            this.Name = "frmMain";
            this.Text = "SmartWork";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.plMainBody.ResumeLayout(false);
            this.plUIBase.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.plMainTreeView.ResumeLayout(false);
            this.plMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plMainTop;
        private System.Windows.Forms.Panel plMainBody;
        private System.Windows.Forms.Panel plUIBase;
        private System.Windows.Forms.Panel plMainTreeView;
        private System.Windows.Forms.TreeView tvMain;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel plMain;
    }
}

