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
    public partial class OderEntryModule : Form
    {
        CSDL_OrderEntrys csdl = new CSDL_OrderEntrys();
        string title = "Dogily PetShop Management System";
        bool check = false;
        OderEntry oderentry;
        public OderEntryModule(OderEntry form)
        {
            InitializeComponent();
            oderentry = form;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CheckField();
                if (check)
                {
                    if (MessageBox.Show("Bạn có muốn thêm phiếu nhập này không ?", "thêm phiếu nhập", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (csdl.insertOder(cb_maNV.Text))
                        {
                            MessageBox.Show("Thêm dữ liệu thành công", title);
                        }
                        else
                        {
                            MessageBox.Show("Thêm dữ liệu thất bại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if (MessageBox.Show("cập nhật phiếu nhập ?", "cập nhật phiếu nhập", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (csdl.updateProFileOder(guna2TextBox1.Text,cb_maNV.Text))
                        {
                            MessageBox.Show("cập nhật dữ liệu thành công", title);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            #region
            //txtIDGE.Clear();
            //txtDateImport.Clear();
            //cbIDGoodSupplier.SelectedItem = null;
            //cbIDUser.SelectedItem = null;
            #endregion
        }
        public void LoadCBB()
        {
            #region
            //cbIDGoodSupplier.DataSource = csdl.LoadData(csdl.cmd2, "NhaCungCap");
            //cbIDGoodSupplier.DisplayMember = "mancc";
            ////cbIDGoodSupplier.ValueMember = "masp";
            //cbIDGoodSupplier.DropDownStyle = ComboBoxStyle.DropDownList;

            //cbIDUser.DataSource = csdl.LoadData(csdl.cmd1, "NguoiDung");
            //cbIDUser.DisplayMember = "mand";
            ////cbIDUser.ValueMember = "mand";
            //cbIDUser.DropDownStyle = ComboBoxStyle.DropDown;
            #endregion
            cb_maNV.DataSource = csdl.listMaNV();
        }

        private void OderEntryModule_Load(object sender, EventArgs e)
        {
            LoadCBB();
            txtDateImport.Enabled = false;
        }

        public void CheckField()
        {  
            if (cb_maNV.Text == "")
            {
                MessageBox.Show("Bạn chưa điền đầy đủ thông tin", "Error");
                return;
            }
            check = true;
        }
    }
}
