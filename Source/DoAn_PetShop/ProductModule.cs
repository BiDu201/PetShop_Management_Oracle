using DoAn_PetShop.CSDL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_PetShop
{
    public partial class ProductModule : Form
    {
        CSDL_Product csdl_pro = new CSDL_Product();
        string title = "Dogily Petshop Management System";
        bool check = false;
        ProductForm product;
        public ProductModule(ProductForm form)
        {
            InitializeComponent();
            product = form;
        }

        private void ProductModule_Load(object sender, EventArgs e)
        {
            //foreach (var item in csdl_pro.tenLoai())
            //{
            //    cbType.Items.Add(item.tenLoai);
            //    if (item.maLoai.Equals(csdl_pro.returnValueLoai().maLoai))
            //    {
            //        cbType.SelectedItem = item.tenLoai;
            //    }
            //}
            //foreach (var item in csdl_pro.tenGiong())
            //{
            //    cbCategory.Items.Add(item.tenGiong);
            //    if (item.maGiong.Equals(csdl_pro.returnValueGiong().maGiong))
            //    {
            //        cbCategory.SelectedItem = item.tenGiong;
            //    }
            //}
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CheckField();
                if (check)
                {
                    if (MessageBox.Show("Bạn muốn chắc chắn muốn thêm thú cưng này? ", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        csdl_pro.chuyen_file_hinh_anh();
                        if (csdl_pro.addproduct(txtName.Text, Path.GetFileName(csdl_pro.getImg()), cbCategory.Text, cbType.Text, double.Parse(txtPrice.Text)))
                        {
                            MessageBox.Show("Thêm thú cưng thành công", title);
                            this.Dispose();
                        }
                        else
                        {
                            MessageBox.Show("Thêm thú cưng thất bại", title);
                        }
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
            CheckField();
            if (check)
            {
                if (MessageBox.Show("bạn có muốn chỉnh sửa thông tin thú cưng này? ", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (csdl_pro.editProfileProDuct(txtcode.Text, txtName.Text, cbCategory.Text, cbType.Text, txtQty.Text, txtPrice.Text) && csdl_pro.editIMGPro(csdl_pro.getImg(), txtcode.Text))
                    {
                        MessageBox.Show("chỉnh sửa thành công", title);
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("chỉnh sửa thất bại", title);
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            //chỉ cho phép nhập số
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            //chỉ cho phép 1 dấu thập phân
            if (e.KeyChar == '.' && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        public void CheckField()
        {
            if (txtName.Text == "" | txtPrice.Text == "" | cbType.Text == "" | cbCategory.Text == "")
            {
                MessageBox.Show("vui lòng điền đầy đủ thông tin", title);
                return;
            }
            check = true;
        }

        private void btn_browse_Click(object sender, EventArgs e)
        {
            string imgpath = "";
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "PNG Files (*.png)|*.png|JPG Files (*.jpg)|*jpg|All Files (*.*)|*.*";
                dlg.Title = "chọn ảnh nhân viên";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    imgpath = dlg.FileName.ToString();
                    imageTC.ImageLocation = imgpath;
                    csdl_pro.setImg(imgpath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
