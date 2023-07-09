using DoAn_PetShop.CSDL;
using DoAn_PetShop.Property;
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
    public partial class BillingForm : Form
    {
        string title = "Pet Shop Management System";
        CSDL_Billing csdl_billing = new CSDL_Billing();
        CSDL_Login login = new CSDL_Login();
        public BillingForm()
        {
            InitializeComponent();
            lbUsername.Text = login.getName();
            lbRole.Text = login.getRole();
        }

        public void LoadBilling()
        {
            double total = 0;
            dgvBilling.Rows.Clear();
            List<Billing> list = csdl_billing.loadBilling();
            for (int i = 0; i < list.Count; i++)
            {
                dgvBilling.Rows.Add(i, list[i].mahd, list[i].masp.ToString(), list[i].tensp.ToString(), list[i].soluong.ToString(), list[i].gia.ToString(), list[i].thanhtien.ToString(), list[i].tenkh.ToString(), list[i].thungan.ToString());
                total += list[i].thanhtien; // Tính tổng tiền sản phẩm đã chọn
            }
            lblTotal.Text = total.ToString("#,##0,00");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BillingProduct product = new BillingProduct(this);
            product.ShowDialog();
        }

        private void BillingForm_Load(object sender, EventArgs e)
        {
            if (csdl_billing.getTranso() != lblTransno.Text)
            {
                lblTransno.Text = csdl_billing.getTranso();
            }
            if (lblTransno.Text == "000000000000")
            {
                csdl_billing.Transo();
                lblTransno.Text = csdl_billing.getTranso();
            }
            LoadBilling();
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            BillingCustomer customer = new BillingCustomer(this);
            customer.ShowDialog();
            if (MessageBox.Show("Bạn có chắc chắn tính tiền cho khách hàng này ?", "Thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                csdl_billing.setTranso(lblTransno.Text); //Tăng transno lên 1
                lblTransno.Text = csdl_billing.getTranso();

                for (int i = 0; i < dgvBilling.Rows.Count; i++)
                {
                    csdl_billing.UpdateSLT(int.Parse(dgvBilling.Rows[i].Cells[4].Value.ToString()), dgvBilling.Rows[i].Cells[2].Value.ToString());
                }
                dgvBilling.Rows.Clear();
            }
        }

        private void dgvBilling_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvBilling.Columns[e.ColumnIndex].Name;
        removeitem:
            if (colName == "Delete")
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa hóa đơn này không ?", "Xóa hóa đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    csdl_billing.deleteProFrBill(dgvBilling.Rows[e.RowIndex].Cells[1].Value.ToString());
                    MessageBox.Show("Hóa đơn đã được xóa", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (colName == "Increase")
            {
                int j = csdl_billing.checkPqty(dgvBilling.Rows[e.RowIndex].Cells[2].Value.ToString());
                if (int.Parse(dgvBilling.Rows[e.RowIndex].Cells[4].Value.ToString()) < j)
                {
                    csdl_billing.updateQtyPro(dgvBilling.Rows[e.RowIndex].Cells[1].Value.ToString());
                }
                else
                {
                    MessageBox.Show("Số lượng còn lại là: " + j + "!", "Hết hàng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (colName == "Decrease")
            {
                if (int.Parse(dgvBilling.Rows[e.RowIndex].Cells[4].Value.ToString()) == 1)
                {
                    colName = "Delete";
                    goto removeitem;
                }
                csdl_billing.decreaseQtyPro(dgvBilling.Rows[e.RowIndex].Cells[1].Value.ToString());
            }
            LoadBilling();
        }

        private void btnlshd_Click(object sender, EventArgs e)
        {
            HistoryBill his = new HistoryBill();
            his.ShowDialog();
        }
    }
}
