using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_PetShop
{
    public partial class Policy : Form
    {
        CSDL_Oracle oracle = new CSDL_Oracle();
        TableSpace tb = new TableSpace();
        string title = "Dogily PetShop Management System";
        public Policy()
        {
            InitializeComponent();
        }

        private void Policy_Load(object sender, EventArgs e)
        {
            tb.LoadDataGridView(oracle.FGA_Policy(), 6, dgvpolicy);
            tb.LoadDataGridView(oracle.audit_LOG(), 7, dgvlog);
            tb.LoadDataGridView(oracle.audit_STR(cbbdate.Text), 4, dgvstratup);
            tb.LoadDataGridView(oracle.audit_HD(""), 23, dgvhd);
            tb.LoadDataGridView(oracle.history_user(), 5, dgvAuditQL);

            List<string> cbb1 = oracle.Load_cbb(oracle.loadtime);
            cbb1.Insert(0, "Tất cả");
            cbbtime.DataSource = cbb1;
            cbbtime.SelectedItem = null;

            List<string> cbb = oracle.Load_cbb(oracle.loaddate);
            cbb.Insert(0, "Tất cả");

            cbbdate.DataSource = cbb;
            cbbdate.SelectedItem = null;
        }

        private void dgvpolicy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvpolicy.Columns[e.ColumnIndex].Name;
            if (colName == "Detail")
            {
                History_Audit his = new History_Audit(this);
                his.lbname.Text = dgvpolicy.Rows[e.RowIndex].Cells[2].Value.ToString();
                his.ShowDialog();

            }
            else if (colName == "DELETE")
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa policy này?", "Xóa Policy", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (oracle.delete_Policy(dgvpolicy.Rows[e.RowIndex].Cells[1].Value.ToString(), dgvpolicy.Rows[e.RowIndex].Cells[2].Value.ToString()))
                    {
                        MessageBox.Show("Xóa thành công", title, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                dgvpolicy.Rows.Clear();
                tb.LoadDataGridView(oracle.FGA_Policy(), 6, dgvpolicy);
            }
            else if (colName == "ENABLED")
            {
                if (MessageBox.Show("Bạn có muốn tắt/mở policy này?", "Tắt policy", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (oracle.enable_Policy(dgvpolicy.Rows[e.RowIndex].Cells[1].Value.ToString(), dgvpolicy.Rows[e.RowIndex].Cells[2].Value.ToString(), dgvpolicy.Rows[e.RowIndex].Cells[4].Value.ToString()))
                    {
                        MessageBox.Show("Policy đã được tắt/mở thành công", title, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    else
                    {
                        MessageBox.Show("Tắt/mở thất bại", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                dgvpolicy.Rows.Clear();
                tb.LoadDataGridView(oracle.FGA_Policy(), 6, dgvpolicy);
            }
        }

        private void btnhd_Click(object sender, EventArgs e)
        {            
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi này?", "Xóa Policy", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Boolean kt;
                if (cbbtime.Text == "Tất cả")
                {
                    kt = oracle.delete(oracle.delete_hd(""));
                }
                else
                {
                    kt = oracle.delete(oracle.delete_hd(cbbtime.Text));
                }
                if (kt)
                {
                    MessageBox.Show("Xóa thành công", title, MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            dgvhd.Rows.Clear();
            tb.LoadDataGridView(oracle.audit_HD(""), 23, dgvhd);
        }

        private void btnxoalog_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi?", "Xóa Policy", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (oracle.delete(oracle.delete_log))
                {
                    MessageBox.Show("Xóa thành công", title, MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            dgvlog.Rows.Clear();
            tb.LoadDataGridView(oracle.audit_LOG(), 7, dgvlog);
        }

        //private void txtSearch_TextChanged(object sender, EventArgs e)
        //{
        //    dgvAuditQL.Rows.Clear();
        //    tb.LoadDataGridView(oracle.history_user(txtSearch.Text.ToUpper()), 5, dgvAuditQL);
        //}

        private void btnauditst_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi?", "Xóa Policy", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Boolean kt;
                if (cbbdate.Text == "Tất cả")
                {
                    kt = oracle.delete(oracle.delete_st_sd(""));
                }
                else
                {
                    kt = oracle.delete(oracle.delete_st_sd(cbbdate.Text));
                }
                if (kt)
                {
                    MessageBox.Show("Xóa thành công", title, MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            dgvstratup.Rows.Clear();
            tb.LoadDataGridView(oracle.audit_STR(""), 4, dgvstratup);
        }

        private void btnaudittable_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi?", "Xóa Policy", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (oracle.delete(oracle.delete_audit_FGA))
                {
                    MessageBox.Show("Xóa thành công", title, MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            dgvpolicy.Rows.Clear();
            tb.LoadDataGridView(oracle.FGA_Policy(), 6, dgvpolicy);
        }

        private void cbbdate_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dgvstratup.Rows.Clear();
            if (cbbdate.SelectedItem.ToString() == "Tất cả")
            {
                tb.LoadDataGridView(oracle.audit_STR(""), 4, dgvstratup);
            }
            else
            {
                tb.LoadDataGridView(oracle.audit_STR(cbbdate.Text), 4, dgvstratup);
            }
        }

        private void cbbtime_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dgvhd.Rows.Clear();
            if (cbbtime.SelectedItem.ToString() == "Tất cả")
            {
                tb.LoadDataGridView(oracle.audit_HD(""), 23, dgvhd);
            }
            else
            {
                tb.LoadDataGridView(oracle.audit_HD(cbbtime.Text), 23, dgvhd);
            }
        }

        private void btnxoaauditql_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi?", "Xóa Policy", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (oracle.delete(oracle.delete_audit_userQL))
                {
                    MessageBox.Show("Xóa thành công", title, MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            dgvAuditQL.Rows.Clear();
            tb.LoadDataGridView(oracle.history_user(), 5, dgvAuditQL);
        }
    }
}
