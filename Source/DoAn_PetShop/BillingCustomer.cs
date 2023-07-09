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
    public partial class BillingCustomer : Form
    {
        CSDL_Billing csdl_billing = new CSDL_Billing();
        BillingForm billing;
        public BillingCustomer(BillingForm form)
        {
            InitializeComponent();
            billing = form;
        }

        public void LoadCustomer()
        {
            dgvCustomer.Rows.Clear();
            List<Customer> list = csdl_billing.loadCus(txtSearch.Text);
            for (int i = 0; i < list.Count; i++)
            {
                dgvCustomer.Rows.Add(i, list[i].makh, list[i].tenkh, list[i].sdt);
            }
        }

        private void BillingCustomer_Load(object sender, EventArgs e)
        {
            LoadCustomer();
        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvCustomer.Columns[e.ColumnIndex].Name;
            if (colName == "Choice")
            {
                csdl_billing.selectCustomer(dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString(), dgvCustomer.Rows[e.RowIndex].Cells[2].Value.ToString());
                csdl_billing.loadBilling();
                billing.LoadBilling();
                this.Dispose();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadCustomer();
        }
    }
}
