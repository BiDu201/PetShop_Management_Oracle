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
    public partial class OderEntryDetail : Form
    {
        CSDL_OrderEntrys csdl = new CSDL_OrderEntrys();
        string title = "Dogily PetShop Management System";
        bool check = false;
        OderEntry oderentry;
        public OderEntryDetail(OderEntry form)
        {
            InitializeComponent();
            oderentry = form;
        }
        public void LoaddCBBIDPr()
        {
            cbIDProDuct.DataSource = csdl.LoadCBB();    
        }

        private void Load_DataGrid()
        {
            List<OrderEntrys> list = csdl.searchOrderEntryDetails(lblidod.Text);
            for (int i = 0; i < list.Count; i++)
            {
                dgvOderEntryDetails.Rows.Add(list[i].masp.ToString(), list[i].tensp.ToString(), list[i].soluong.ToString(), list[i].gianhap.ToString(), list[i].thanhtien.ToString());
            }
        }

        private void OderEntryDetail_Load(object sender, EventArgs e)
        {
            Load_DataGrid();
            txttotals.Enabled = false;
            LoaddCBBIDPr();
        }

        private void dgvOderEntryDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvOderEntryDetails.Columns[e.ColumnIndex].Name;
            if (colName == "Delete")
            {
                if (MessageBox.Show("Bạn có muốn xóa thú cưng này trong phiếu nhập ?", "xóa thú cưng trong phiếu nhập", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    csdl.deleteOderEntryDetail(lblidod.Text, dgvOderEntryDetails.Rows[e.RowIndex].Cells[0].Value.ToString().Trim());
                    MessageBox.Show("Xóa thành công", title, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    dgvOderEntryDetails.Rows.Clear();
                    Load_DataGrid();
                }
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                CheckField();
                if (check)
                {
                    if (MessageBox.Show("Bạn có muốn thêm thú cưng vào phiếu nhập này không ?", "thêm thú cưng", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (csdl.insertOderDetails(lblidod.Text, csdl.get_masp(cbIDProDuct.Text),cbIDProDuct.Text, txtquan.Text, txtprpr.Text))
                        {
                            MessageBox.Show("Thêm dữ liệu thành công", title);
                        }
                        else
                        {
                            MessageBox.Show("Thêm dữ liệu thất bại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        dgvOderEntryDetails.Rows.Clear();
                        Load_DataGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
        }
        public void CheckField()
        {
            if (cbIDProDuct.Text.Length == 0 | txtquan.TextLength == 0 | txtprpr.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa điền đầy đủ thông tin", "Error");
                return;
            }
            check = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }       
    }
}
