using DoAn_PetShop.CSDL;
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
    public partial class CustomerModule : Form
    {
        CSDL_Customer csdl_Customer = new CSDL_Customer();
        string title = "Dogily Petshop Management System";
        bool check = false;
        CustomerForm customer;
        public CustomerModule(CustomerForm form)
        {
            InitializeComponent();
            customer = form;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CheckField();
                if (check)
                {
                    if (MessageBox.Show("bạn có chắc muốn thêm vào khác hàng mới ?", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                    {
                        if (csdl_Customer.insertCus(txtName.Text, txtAddress.Text, txtPhone.Text))
                        {
                            MessageBox.Show("thêm thành công", title);
                        }
                        else
                        {
                            MessageBox.Show("thêm thất bại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        this.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                CheckField();
                if (check)
                {
                    if (MessageBox.Show("bạn có muốn cập nhật thông tin khách hàng? ", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (csdl_Customer.updateProFileCus(txtma.Text, txtName.Text, txtAddress.Text, txtPhone.Text))
                        {
                            MessageBox.Show("cập nhật thành công", title);
                        }
                        else
                        {
                            MessageBox.Show("cập nhật thất bại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        this.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void CheckField()
        {
            if (txtName.Text == "" | txtAddress.Text == "" | txtPhone.Text == "")
            {
                MessageBox.Show("bạn chưa nhập gì cả", title);
                return;
            }
            check = true;
        }
    }
}
