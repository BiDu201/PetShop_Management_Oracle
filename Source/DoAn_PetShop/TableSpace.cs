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
    public partial class TableSpace : Form
    {
        CSDL_Oracle oracle = new CSDL_Oracle();
        string title = "Dogily PetShop Management System";
        public TableSpace()
        {
            InitializeComponent();
        }

        public void LoadDataGridView(List<string> dt, int cnt, DataGridView dgv)
        {
            List<string> data;
            data = /*oracle.dataTablespace();*/ dt;
            int count = 1, row = 0, cell = 0;
            //bắt buộc phải thêm 1 dòng vào dgv đầu tiên bởi vì dgv ko tự thêm dòng
            dgv.Rows.Add();
            for (int i = 0; i < data.Count; i++)
            {
                //nếu như nhập đủ cho 3 cột r bắt đầu xuống dòng nhập dòng mới
                if (count == cnt)
                {
                    dgv.Rows.Add();
                    //reset lại row và (cell là 1 cái ô ở dòng thứ ?)
                    cell = 0;
                    count = 1;
                    row++;
                }
                //thêm data vào dòng thứ row và cell(tương đương với cột)
                dgv.Rows[row].Cells[cell].Value = data[i];
                count++;
                cell++;
            }
        }

        #region
        private void TableSpace_Load(object sender, EventArgs e)
        {
            LoadDataGridView(oracle.dataTablespace(), 10, dgvTableSpace);
            LoadDataGridView(oracle.dataFile(), 4, dgvdatafile);
            Loadcbbuser();
        }
        #endregion

        public void Loadcbbuser()
        {
            cbbtbuser.DataSource = oracle.Load_cbb(oracle.us);
        }

        private void cbbtbuser_SelectionChangeCommitted(object sender, EventArgs e)
        {
            MessageBox.Show(oracle.getDefaultTableSpaceUser(cbbtbuser.Text));
        }

        private void dgvTableSpace_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvTableSpace.Columns[e.ColumnIndex].Name;
            if (colName == "DETAILS")
            {
                DetailTBSP detail = new DetailTBSP(this);
                detail.lbnametb.Text = dgvTableSpace.Rows[e.RowIndex].Cells[0].Value.ToString();
                detail.ShowDialog();

            }
            else if (colName == "DELETE")
            {
                if (MessageBox.Show("Bạn chắc chắn muốn xóa Tablespace này?", "Xóa tablespace", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (oracle.deleteTableSpace(dgvTableSpace.Rows[e.RowIndex].Cells[0].Value.ToString()))
                    {
                        MessageBox.Show("Xóa thành công", title, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại, vui lòng kiểm tra lại!", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                dgvTableSpace.Rows.Clear();
                LoadDataGridView(oracle.dataTablespace(), 10, dgvTableSpace);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TableSpaceModule tbm = new TableSpaceModule(this);
            tbm.ShowDialog();
            dgvTableSpace.Rows.Clear();
            LoadDataGridView(oracle.dataTablespace(), 10, dgvTableSpace);
        }
    }
}
