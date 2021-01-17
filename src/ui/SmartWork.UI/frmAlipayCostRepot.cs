using SmartWork.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartWork.UI
{
    public partial class frmAlipayCostRepot : Form
    {
        public frmAlipayCostRepot()
        {
            InitializeComponent();
        }

        private void frmAlipayCostRepot_Load(object sender, EventArgs e)
        {
            DataSet dsDataSource = this.getInitInfos();

            //
            DataTable dtSource = dsDataSource.Tables[0].Copy();
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                cboOwner.Items.Add(dtSource.Rows[i][0].ToString());
            }

            if (dtSource.Rows.Count > 0)
            {
                cboOwner.SelectedIndex = 0;
            }
        }

        private DataSet getInitInfos()
        {
            ExecHelper execHelper = new ExecHelper();


            DataSet ds = execHelper.Select("SmartWork.Biz.bizAlipayChecker#GET_INFS");


            return ds;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrawSheet();
        }

        private void DrawSheet()
        {
            ExecHelper execHelper = new ExecHelper();

            execHelper.addArg("ARG_DT", this.dtpMonth.Value.ToString("yyyyMMdd"));
            execHelper.addArg("ARG_OWNER", cboOwner.Text);

            DataSet ds = execHelper.Select("SmartWork.Biz.bizAlipayChecker#SELECT_COST_REPORT");

            dgvSum.DataSource = ds.Tables[0].Copy();
            dgvDetail.DataSource = ds.Tables[1].Copy();


            for (int i = 0; i < this.dgvSum.Columns.Count; i++)
            {
                //this.dgvSum.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                this.dgvSum.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                this.dgvDetail.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
            //dgvSum.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            Utils.SetCellBackColor(dgvSum, "TYPE2", "TOTAL", "ROW", Color.Yellow);
            Utils.SetCellBackColor(dgvSum, "TYPE1", "TOTAL", "ROW", Color.Green);

        }
    }
}
