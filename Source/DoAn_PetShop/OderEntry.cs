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
    public partial class OderEntry : Form
    {
        CSDL_OrderEntrys o;
        CSDL_Login login = new CSDL_Login();
        string title = "Dogily PetShop Management System";
        public OderEntry()
        {
            InitializeComponent();
            o = new CSDL_OrderEntrys();
            lbUsername.Text = login.getName();
            lbRole.Text = login.getRole();
        }

        private void LoadDGV()
        {
            dgvOderEntry.Rows.Clear();
            List<OrderEntrys> list = o.searchOrderEntry(txtSearch.Text);
            for (int i = 0; i < list.Count; i++)
            {
                dgvOderEntry.Rows.Add(list[i].mapn.ToString(), list[i].ngaynhap.ToString(), list[i].manv.ToString(), list[i].tennv.ToString(), list[i].tongtien.ToString());
            }
        }

        private void OderEntry_Load(object sender, EventArgs e)
        {
            List<OrderEntrys> list = o.searchOrderEntry(txtSearch.Text);
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    dgvOderEntry.Rows.Add(list[i].mapn.ToString(), list[i].ngaynhap.ToString(), list[i].manv.ToString(), list[i].tennv.ToString(), list[i].tongtien.ToString());
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadDGV();
        }
        #region không động đến
        private void dgvOderEntry_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //string colName = dgvOderEntry.Columns[e.ColumnIndex].Name;
            //if (colName == "Edit")
            //{
            //    OderEntryModule module = new OderEntryModule(this);
            //    module.btnSave.Visible = false;
            //    module.btnSave.Enabled = false;
            //    module.btnUpdate.Enabled = true;
            //    module.btnUpdate.Visible = true;
            //    module.txtIDGE.Enabled = false;
            //    module.txtIDGE.Text = dgvOderEntry.Rows[e.RowIndex].Cells[0].Value.ToString();
            //    module.txtDateImport.Text = dgvOderEntry.Rows[e.RowIndex].Cells[1].Value.ToString();
            //    module.cbIDGoodSupplier.SelectedText = dgvOderEntry.Rows[e.RowIndex].Cells[2].Value.ToString();
            //    module.cbIDUser.SelectedText = dgvOderEntry.Rows[e.RowIndex].Cells[3].Value.ToString();
            //    module.btnSave.Enabled = true;
            //    module.ShowDialog();
            //    dgvOderEntry.Rows.Clear();
            //    List<OrderEntrys> list = o.searchOrderEntry(txtSearch.Text);
            //    for (int i = 0; i < list.Count; i++)
            //    {
            //        dgvOderEntry.Rows.Add(list[i].mapn.ToString(), list[i].ngaynhap.ToString(), list[i].mancc.ToString(), list[i].mand.ToString(), list[i].tongtien.ToString());
            //    }
            //}
            //else if (colName == "Delete")
            //{
            //    if (MessageBox.Show("Are you sure you want to delete this customer?", "Edit Profile", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        o.deleteOderEntry(dgvOderEntry.Rows[e.RowIndex].Cells[0].Value.ToString());
            //        MessageBox.Show("Delete success", title, MessageBoxButtons.OK, MessageBoxIcon.Question);
            //        dgvOderEntry.Rows.Clear();
            //        List<OrderEntrys> list = o.searchOrderEntry(txtSearch.Text);
            //        for (int i = 0; i < list.Count; i++)
            //        {
            //            dgvOderEntry.Rows.Add(list[i].mapn.ToString(), list[i].ngaynhap.ToString(), list[i].mancc.ToString(), list[i].mand.ToString(), list[i].tongtien.ToString());
            //        }
            //    }
            //}
            //else if (colName == "ShowDetail")
            //{
            //    OderEntryDetail modules = new OderEntryDetail(this);
            //    modules.lblidod.Text = dgvOderEntry.Rows[e.RowIndex].Cells[0].Value.ToString();
            //    modules.ShowDialog();
            //    dgvOderEntry.Rows.Clear();
            //    List<OrderEntrys> list = o.searchOrderEntry(txtSearch.Text);
            //    for (int i = 0; i < list.Count; i++)
            //    {
            //        dgvOderEntry.Rows.Add(list[i].mapn.ToString(), list[i].ngaynhap.ToString(), list[i].mancc.ToString(), list[i].mand.ToString(), list[i].tongtien.ToString());
            //    }
            //}
        }
        #endregion
        private void btnAdd_Click(object sender, EventArgs e)
        {
            OderEntryModule module = new OderEntryModule(this);
            module.btnUpdate.Enabled = false;
            module.btnUpdate.Visible = false;
            module.btnSave.Enabled = true;
            module.btnSave.Visible = true;
            module.txtDateImport.Enabled = false;
            module.ShowDialog();
            LoadDGV();
        }

        private void dgvOderEntry_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvOderEntry.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                OderEntryModule module = new OderEntryModule(this);
                module.btnSave.Visible = false;
                module.btnSave.Enabled = false;
                module.btnUpdate.Enabled = true;
                module.btnUpdate.Visible = true;
                module.guna2TextBox1.Enabled = false;
                module.guna2TextBox2.Enabled = false;
                module.guna2TextBox1.Text = dgvOderEntry.Rows[e.RowIndex].Cells[0].Value.ToString();
                module.txtDateImport.Text = dgvOderEntry.Rows[e.RowIndex].Cells[1].Value.ToString();
                module.cb_maNV.SelectedText = dgvOderEntry.Rows[e.RowIndex].Cells[2].Value.ToString();
                module.guna2TextBox2.Text = dgvOderEntry.Rows[e.RowIndex].Cells[3].Value.ToString();
                module.btnSave.Enabled = true;
                module.ShowDialog();
                LoadDGV();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Bạn muốn xóa phiếu nhập này ?", "xóa phiếu nhập", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (o.deleteOderEntry(dgvOderEntry.Rows[e.RowIndex].Cells[0].Value.ToString()))
                    {
                        MessageBox.Show("Xóa phiếu nhập thành công", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Xóa phiếu nhập thất bại!", title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    LoadDGV();
                }
            }
            else if (colName == "ShowDetail")
            {
                OderEntryDetail modules = new OderEntryDetail(this);
                modules.lblidod.Text = dgvOderEntry.Rows[e.RowIndex].Cells[0].Value.ToString();
                modules.ShowDialog();
                LoadDGV();
            }
        }

        
    }
}
