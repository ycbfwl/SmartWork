namespace SmartWork.UI
{
    partial class frmAlipayCostRepot
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.cboOwner = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.labMonth = new System.Windows.Forms.Label();
            this.dtpMonth = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvSum = new System.Windows.Forms.DataGridView();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cboOwner);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.labMonth);
            this.panel2.Controls.Add(this.dtpMonth);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1069, 37);
            this.panel2.TabIndex = 2;
            // 
            // cboOwner
            // 
            this.cboOwner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOwner.FormattingEnabled = true;
            this.cboOwner.Location = new System.Drawing.Point(236, 9);
            this.cboOwner.Name = "cboOwner";
            this.cboOwner.Size = new System.Drawing.Size(240, 20);
            this.cboOwner.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(195, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 12);
            this.label11.TabIndex = 5;
            this.label11.Text = "owner";
            // 
            // labMonth
            // 
            this.labMonth.AutoSize = true;
            this.labMonth.Location = new System.Drawing.Point(12, 13);
            this.labMonth.Name = "labMonth";
            this.labMonth.Size = new System.Drawing.Size(35, 12);
            this.labMonth.TabIndex = 4;
            this.labMonth.Text = "Month";
            // 
            // dtpMonth
            // 
            this.dtpMonth.Location = new System.Drawing.Point(53, 9);
            this.dtpMonth.Name = "dtpMonth";
            this.dtpMonth.Size = new System.Drawing.Size(112, 21);
            this.dtpMonth.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Location = new System.Drawing.Point(998, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 37);
            this.button1.TabIndex = 2;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tabControl1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 37);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1069, 464);
            this.panel3.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1069, 501);
            this.panel1.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1069, 464);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvSum);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1061, 438);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "SUM";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvDetail);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1061, 438);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "DETAIL";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvSum
            // 
            this.dgvSum.AllowUserToAddRows = false;
            this.dgvSum.AllowUserToDeleteRows = false;
            this.dgvSum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSum.Location = new System.Drawing.Point(3, 3);
            this.dgvSum.Name = "dgvSum";
            this.dgvSum.RowTemplate.Height = 23;
            this.dgvSum.Size = new System.Drawing.Size(1055, 432);
            this.dgvSum.TabIndex = 0;
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.Location = new System.Drawing.Point(3, 3);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.Size = new System.Drawing.Size(1055, 432);
            this.dgvDetail.TabIndex = 1;
            // 
            // frmAlipayCostRepot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 501);
            this.Controls.Add(this.panel1);
            this.Name = "frmAlipayCostRepot";
            this.Text = "frmAlipayCostRepot";
            this.Load += new System.EventHandler(this.frmAlipayCostRepot_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cboOwner;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labMonth;
        private System.Windows.Forms.DateTimePicker dtpMonth;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvSum;
        private System.Windows.Forms.DataGridView dgvDetail;
    }
}