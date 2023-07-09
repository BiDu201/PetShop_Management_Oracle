using DoAn_PetShop.CSDL;
using DoAn_PetShop.Property;
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
    public partial class ProductForm : Form
    {
        CSDL_Product csdl_Pro = new CSDL_Product();
        string title = "Dogily Petshop Management System";
        CSDL_Login login = new CSDL_Login();
        public ProductForm()
        {
            InitializeComponent();
            lbUsername.Text = login.getName();
            lbRole.Text = login.getRole();
        }

        private void LoaddCBBGia()
        {
            for (int i = 0; i <= 10000000; i += 500000)
            {
                cbbgiadau.Items.Add(i);
                cbbgiasau.Items.Add(i);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProductModule module = new ProductModule(this);
            module.btnSave.Enabled = true;
            module.btnSave.Visible = true;
            module.btnUpdate.Enabled = false;
            module.btnUpdate.Visible = false;
            module.txtQty.Enabled = false;
            module.ShowDialog();
            dgvProduct.Rows.Clear();
            ProductForm_Load(sender, e);
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            dgvProduct.Rows.Clear();
            List<Product> list = csdl_Pro.searchProduct(txtSearch.Text);
            for (int i = 0; i < list.Count; i++)
            {
                dgvProduct.Rows.Add(i, list[i].maSP.ToString(), list[i].tenSP.ToString(), list[i].tenGiong.ToString(), list[i].tenLoai.ToString(), list[i].soLuongTon.ToString(), list[i].giaBan.ToString());
            }
            csdl_Pro.checkfolder();
            LoaddCBBGia();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvProduct.Rows.Clear();
            List<Product> list = csdl_Pro.searchProduct(txtSearch.Text);
            for (int i = 0; i < list.Count; i++)
            {
                dgvProduct.Rows.Add(i, list[i].maSP.ToString(), list[i].tenSP.ToString(), list[i].tenGiong.ToString(), list[i].tenLoai.ToString(), list[i].soLuongTon.ToString(), list[i].giaBan.ToString());
            }
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvProduct.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                ProductModule module = new ProductModule(this);
                module.txtQty.Enabled = true;
                module.txtcode.Text = dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
                module.txtName.Text = dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
                module.cbType.SelectedItem = dgvProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
                module.cbCategory.SelectedItem = dgvProduct.Rows[e.RowIndex].Cells[3].Value.ToString();
                //csdl_Pro.getValue(dgvProduct.Rows[e.RowIndex].Cells[4].Value.ToString(), dgvProduct.Rows[e.RowIndex].Cells[3].Value.ToString());
                module.txtQty.Text = dgvProduct.Rows[e.RowIndex].Cells[5].Value.ToString();
                module.txtPrice.Text = dgvProduct.Rows[e.RowIndex].Cells[6].Value.ToString();
                module.btnSave.Enabled = false;
                module.btnSave.Visible = false;
                module.btnUpdate.Enabled = true;
                module.btnUpdate.Visible = true;
                module.lbtt.Text = "Sửa sản phẩm";
                module.ShowDialog();
                dgvProduct.Rows.Clear();
                csdl_Pro.delete_img();
                ProductForm_Load(sender, e);
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("bạn muốn xóa thú cưng này ?", "Edit Profile", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (csdl_Pro.deletePro(dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString()))
                    {
                        MessageBox.Show("xóa thành công", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("xóa thất bại", title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    dgvProduct.Rows.Clear();
                    ProductForm_Load(sender, e);
                }
            }
            else
            {
                string path = @"anhsp\" + "SP00" + (e.RowIndex + 1) + ".png";
                string absolutePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
                IMGTC.ImageLocation = absolutePath;
            }
        }

        private void btnlocsp_Click(object sender, EventArgs e)
        {
            if (cbbgiadau.Text == "" || cbbgiasau.Text == "")
            {
                MessageBox.Show("vui lòng chọn giá");
                return;
            }
            dgvProduct.Rows.Clear();
            List<Product> list = csdl_Pro.loc_SanPham(int.Parse(cbbgiadau.Text), int.Parse(cbbgiasau.Text));
            for (int i = 0; i < list.Count; i++)
            {
                dgvProduct.Rows.Add(i, list[i].maSP.ToString(), list[i].tenSP.ToString(), list[i].tenGiong.ToString(), list[i].tenLoai.ToString(), list[i].soLuongTon.ToString(), list[i].giaBan.ToString());
            }
        }
    }
}
