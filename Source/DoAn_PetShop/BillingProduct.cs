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
    public partial class BillingProduct : Form
    {
        CSDL_Billing csdl_billing = new CSDL_Billing();
        CSDL_Login csdl_login = new CSDL_Login();
        BillingForm billing;
        public BillingProduct(BillingForm form)
        {
            InitializeComponent();
            billing = form;
        }

        private void btnGuidi_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in dgvProduct.Rows)
            {
                bool chkbox = Convert.ToBoolean(dr.Cells["Select"].Value);
                if (chkbox)
                {
                    csdl_billing.selectProDuct(dr.Cells[1].Value.ToString(), dr.Cells[2].Value.ToString(), Convert.ToDouble(dr.Cells[5].Value.ToString()), billing.lbUsername.Text);
                }
            }
            billing.LoadBilling();
            this.Dispose();
        }

        public void LoadProduct()
        {
            dgvProduct.Rows.Clear();
            List<billingPro> list = csdl_billing.LoadProduct(txtSearch.Text);
            for (int i = 0; i < list.Count; i++)
            {
                dgvProduct.Rows.Add(i, list[i].maSP.ToString(), list[i].tenSP.ToString(), list[i].maGiong.ToString(), list[i].maLoai.ToString(), list[i].giaBan.ToString());
            }
        }

        private void BillingProduct_Load(object sender, EventArgs e)
        {
            LoadProduct();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }
    }
}
