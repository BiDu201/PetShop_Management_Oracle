using System;
using DoAn_PetShop.CSDL;
using DoAn_PetShop.Property;
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
    public partial class HistoryBill : Form
    {
        CSDL_Billing csdl_billing = new CSDL_Billing();
        public HistoryBill()
        {
            InitializeComponent();
        }

        private void LoadDGV(string str)
        {
            dgvHistoryBill.Rows.Clear();
            List<Billing> list = csdl_billing.searchBill(str);
            for (int i = 0; i < list.Count; i++)
            {
                dgvHistoryBill.Rows.Add(list[i].mahd, list[i].transno.ToString(), list[i].masp.ToString(), list[i].tensp.ToString(), list[i].soluong.ToString(), list[i].gia.ToString(), list[i].thanhtien.ToString(), list[i].makh.ToString(), list[i].tenkh.ToString(), list[i].thungan.ToString());
            }
        }

        private void HistoryBill_Load(object sender, EventArgs e)
        {
            LoadDGV(txtSearch.Text);
            cbbnam.DataSource = csdl_billing.LoadCBB();
            cbbthang.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadDGV(txtSearch.Text);
        }

        private void btnthongke_Click(object sender, EventArgs e)
        {
            double total = 0.00;
            LoadDGV(cbbnam.Text+cbbthang.Text);
            foreach(DataGridViewRow r in dgvHistoryBill.Rows)
            {
                total += Convert.ToDouble(r.Cells[6].Value);
            }
            lblTotal.Text = total.ToString();
        }

        private void dgvHistoryBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvHistoryBill.Columns[e.ColumnIndex].Name;
            if (colName == "Delete")
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa hóa đơn này không ?", "Xóa hóa đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    csdl_billing.deleteProFrBill(dgvHistoryBill.Rows[e.RowIndex].Cells[0].Value.ToString());
                    MessageBox.Show("Hóa đơn đã được xóa", "Xóa hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            LoadDGV(txtSearch.Text);
        }

        private void btnxoabill_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa những hóa đơn này không ?", "Xóa hóa đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                csdl_billing.deleteBill(cbbnam.Text+cbbthang.Text);
                MessageBox.Show("Hóa đơn đã được xóa", "Xóa hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadDGV(txtSearch.Text);
        }
    }
}
