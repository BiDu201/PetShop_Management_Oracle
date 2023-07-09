using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DoAn_PetShop
{
    public partial class UserProfile : Form
    {
        CSDL_Oracle oracle = new CSDL_Oracle();
        TableSpace tb = new TableSpace();
        string title = "Dogily PetShop Management System";
        public UserProfile()
        {
            InitializeComponent();
        }
        private void Loadcbb()
        {
            //Load tên tất cả profile lên cbb
            cbbprofile.DataSource = oracle.Load_cbb(oracle.pr);
            cbbprofile.SelectedItem = "DEFAULT";

            //Load tất cả tablespace lên cbb
            cbbtbs.DataSource = oracle.Load_cbb(oracle.tb);
            cbbtbs.SelectedItem = "USERS";

            //Load những role về nghiệp vụ lên cbb
            cbbrole.DataSource = oracle.Load_cbb(oracle.role);
        }

        private void UserProfile_Load(object sender, EventArgs e)
        {
            btnupdate.Enabled = false; // tắt btn update
            btnupdaterole.Enabled = false; //tắt btn update role
            btnsua.Enabled = false;
            Loadcbb();
            txtusername.Focus();
            tb.LoadDataGridView(oracle.User(), 7, dgvuser); //Load thông tin user lên datagridview
            tb.LoadDataGridView(oracle.Load_cbb(oracle.pri(txtSearch.Text)), 2, dgvPrivilege); //Load tên privilege lên datagridview
            tb.LoadDataGridView(oracle.Load_cbb(oracle.tble), 2, dgvTables); //Load các table của chương trình lên datagridview
            tb.LoadDataGridView(oracle.Load_cbb(oracle.role), 2, dgvroles); //Load thông tin role của chương trình lên datagridview
            tb.LoadDataGridView(oracle.Load_cbb(oracle.profile_name(txtsearchpf.Text)), 2, dgvProfiles); //Load tên profile
        }

        //Reset lại textbox, datagridview
        private void reset_txt()
        {
            txtusername.Enabled = true;
            btnsaveuser.Enabled = true;
            btnupdate.Enabled = false;
            txtusername.Text = "";
            txtpass.Text = "";
            txtSearch.Text = "";
            dgvPrivilege.Rows.Clear();
            tb.LoadDataGridView(oracle.Load_cbb(oracle.pri(txtSearch.Text)), 2, dgvPrivilege);
            txtusername.Focus();
        }

        private void reset_role()
        {
            txtrolename.Text = "";
            txtrolename.Focus();
            txtrolename.Enabled = true;
            dgvTables.Rows.Clear();
            tb.LoadDataGridView(oracle.Load_cbb(oracle.tble), 2, dgvTables);
        }

        private void reset_profile()
        {
            txtprofname.Text = "";
            txtfla.Text = "";
            txtplt.Text = "";
            txtprt.Text = "";
            txtprm.Text = "";
            txtplockt.Text = "";
            txtpgt.Text = "";
            txtspu.Text = "";
            txtidle.Text = "";
            txtcnt.Text = "";
            txtprofname.Enabled = true;
            btnsua.Enabled = false;
            btnluu.Enabled = true;
            txtprofname.Focus();
        }

        // Lấy những quyền được chọn trên checkbox
        private string get_privs()
        {
            string cmd = "";
            foreach (DataGridViewRow dr in dgvPrivilege.Rows)
            {
                bool chkbox = Convert.ToBoolean(dr.Cells["Select"].Value);
                if (chkbox)
                {
                    if (dr.Cells[0].Value.ToString() == "CREATE SESSION")
                    {
                        continue; // bỏ qua dòng là quyền create session
                    }
                    else
                    {
                        cmd = cmd + "," + dr.Cells[0].Value.ToString();
                    }
                }
            }
            return cmd;
        }

        private bool get_query()
        {
            string cmd = "";
            bool flag = true; // cờ dùng để kiểm tra việc grant quyền cho bảng có thành công hay không
            foreach (DataGridViewRow dr in dgvTables.Rows)
            {
                // kiểm tra xem checkbox có giá trị true hay flase
                bool chkbox = Convert.ToBoolean(dr.Cells["Selects"].Value);
                bool chkbox1 = Convert.ToBoolean(dr.Cells["Insert"].Value);
                bool chkbox2 = Convert.ToBoolean(dr.Cells["Deletes"].Value);
                bool chkbox3 = Convert.ToBoolean(dr.Cells["Updates"].Value);
                if (chkbox)
                {
                    cmd = "Select,";
                    if (dr.Cells[0].Value.ToString() == "HOADON")
                    {
                        oracle.grant_role(txtrolename.Text, "EXECUTE", "userQL.ShowBill");
                        oracle.grant_role(txtrolename.Text, "Select", "userQL.HoaDon_View");
                    }
                    if (dr.Cells[0].Value.ToString() == "KHACHANG")
                    {
                        oracle.grant_role(txtrolename.Text, "EXECUTE", "userQL.searchcustomer");                       
                    }
                }
                if (chkbox1)
                {
                    cmd = cmd + "Insert,";
                    if(dr.Cells[0].Value.ToString() == "SANPHAM")
                    {
                        oracle.grant_role(txtrolename.Text,"EXECUTE","userQL.NhapSP");
                    }
                    if (dr.Cells[0].Value.ToString() == "NHANVIEN")
                    {
                        oracle.grant_role(txtrolename.Text, "EXECUTE", "userQL.NhapNV");
                    }
                    if (dr.Cells[0].Value.ToString() == "CTPHIEUNHAP")
                    {
                        oracle.grant_role(txtrolename.Text, "EXECUTE", "userQL.NhapCTPN");
                    }
                    if (dr.Cells[0].Value.ToString() == "HOADON")
                    {                      
                        oracle.grant_role(txtrolename.Text, "Insert", "userQL.HoaDon_View");
                    }
                }
                if (chkbox2)
                {
                    cmd = cmd + "Delete,";
                    if (dr.Cells[0].Value.ToString() == "HOADON")
                    {
                        oracle.grant_role(txtrolename.Text, "Delete", "userQL.HoaDon_View");
                    }
                }
                if (chkbox3)
                {
                    cmd = cmd + "Update";
                    if (dr.Cells[0].Value.ToString() == "HOADON")
                    {
                        oracle.grant_role(txtrolename.Text, "Update", "userQL.HoaDon_View");
                    }
                    if (dr.Cells[0].Value.ToString() == "KHACHHANG")
                    {
                        oracle.grant_role(txtrolename.Text, "EXECUTE", "userQL.updatecustomer");
                    }
                }
                string query = cmd.TrimEnd(','); // bỏ đi dấu "," ở cuối chuỗi
                if (oracle.grant_role(txtrolename.Text, query, "userQL." + dr.Cells[0].Value.ToString())) // nếu grant role thành công
                {
                    cmd = ""; // khởi tạo lại chuỗi rỗng
                    continue; // tiếp tục vòng lặp
                }
                else // nếu có lỗi xảy ra
                {
                    //oracle.create_drop_role(oracle.proc_dropRole, txtrolename.Text); // xóa role vừa tạo
                    MessageBox.Show("Grant quyền cho bảng " + dr.Cells[0].Value.ToString() + " thất bại. Bạn vui lòng thực hiện lại!");
                    flag = false; // gán cờ trở thành false
                    break; // dừng vòng lặp
                }
            }
            return flag;
        }

        private void dgvuser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvuser.Columns[e.ColumnIndex].Name;
            if (colName == "Privilege")
            {
                PrivilegeofUser p = new PrivilegeofUser(this);
                p.lbusn.Text = dgvuser.Rows[e.RowIndex].Cells[0].Value.ToString();
                p.ShowDialog();

            }
            else if (colName == "Edit")
            {
                txtusername.Text = dgvuser.Rows[e.RowIndex].Cells[0].Value.ToString();
                cbbtbs.SelectedItem = dgvuser.Rows[e.RowIndex].Cells[4].Value.ToString();
                cbbprofile.SelectedItem = dgvuser.Rows[e.RowIndex].Cells[5].Value.ToString();

                txtusername.Enabled = false; // tắt không cho sửa tên
                btnsaveuser.Enabled = false; //tắt btn save
                btnupdate.Enabled = true;// mở lại btn update

                //Select item của cb ứng với role của user
                cbbrole.SelectedItem = null;
                List<string> rl = oracle.Load_cbb(oracle.role_user(dgvuser.Rows[e.RowIndex].Cells[0].Value.ToString()));
                foreach (string s in cbbrole.Items)
                {
                    if (rl.Contains(s))
                    {
                        cbbrole.SelectedItem = s;
                    }
                }

                // Checked checkbox
                // làm mới datagridview
                dgvPrivilege.Rows.Clear();
                tb.LoadDataGridView(oracle.Load_cbb(oracle.pri(txtSearch.Text)), 2, dgvPrivilege);
                List<string> temp = oracle.Load_cbb(oracle.pri_user(dgvuser.Rows[e.RowIndex].Cells[0].Value.ToString()));
                foreach (DataGridViewRow r in dgvPrivilege.Rows) // load từng dòng trong datagridview
                {
                    if (r.Cells[0].Value != null)
                    {
                        if (temp.Contains(r.Cells[0].Value.ToString())) // nếu tìm thấy quyền trong danh sách quyền của user
                        {
                            r.Cells["Select"].Value = true; // checked checkbox dòng đó
                        }
                    }
                }
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Bạn chắc chắn muốn xóa user này?", "Xóa User", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (oracle.delete(oracle.delete_user(dgvuser.Rows[e.RowIndex].Cells[0].Value.ToString())))
                    {
                        MessageBox.Show("Xóa thành công", title, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                dgvuser.Rows.Clear();
                tb.LoadDataGridView(oracle.User(), 7, dgvuser);
            }
        }

        private void btnsaveuser_Click(object sender, EventArgs e)
        {
            if (txtusername.Text == "" | txtpass.Text == "" | cbbtbs.Text == "" | cbbprofile.Text == "" | cbbrole.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi tạo user", title);
                return;
            }
            else
            {
                if (MessageBox.Show("Bạn chắc chắn muốn thêm user này?", "Create User", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (oracle.createUser(txtusername.Text, txtpass.Text, cbbtbs.Text, cbbprofile.Text, cbbrole.Text, get_privs()))
                    {
                        MessageBox.Show("Thêm thành công", title, MessageBoxButtons.OK, MessageBoxIcon.Question);
                        reset_txt();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            dgvuser.Rows.Clear();
            tb.LoadDataGridView(oracle.User(), 7, dgvuser);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvPrivilege.Rows.Clear();
            tb.LoadDataGridView(oracle.Load_cbb(oracle.pri(txtSearch.Text)), 2, dgvPrivilege);
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            txtusername.Enabled = true;
            btnsaveuser.Enabled = true;
            btnupdate.Enabled = false;

            if (txtusername.Text == "" | cbbtbs.Text == "" | cbbprofile.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi sửa user", title);
                return;
            }
            else
            {
                if (MessageBox.Show("Bạn chắc chắn muốn sửa thông tin của user này?", "Sửa User", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (oracle.alterUser(txtusername.Text, txtpass.Text, cbbtbs.Text, cbbprofile.Text, cbbrole.Text, get_privs()))
                    {
                        MessageBox.Show("Sửa thành công", title, MessageBoxButtons.OK, MessageBoxIcon.Question);
                        reset_txt();
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            dgvuser.Rows.Clear();
            tb.LoadDataGridView(oracle.User(), 7, dgvuser);
            reset_txt();
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            reset_txt();
        }

        //Phần tab ROLE
        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtrolename.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên role cần tạo", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (MessageBox.Show("Bạn chắc chắn muốn thêm role này?", "Tạo Role", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (oracle.create_drop_role(oracle.proc_createRole, txtrolename.Text)) // nếu tạo role thành công
                    {
                        // kiểm tra xem grant quyền cho role có xảy ra lỗi không, flag sẽ trả về true (thành công), false (thất bại)
                        if (get_query())
                        {
                            MessageBox.Show("Thêm role thành công", title, MessageBoxButtons.OK, MessageBoxIcon.Question);
                        }
                        else
                        {
                            MessageBox.Show("Thêm role thất bại", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Thêm role thất bại", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            dgvroles.Rows.Clear();
            tb.LoadDataGridView(oracle.Load_cbb(oracle.role), 2, dgvroles);
            reset_role();
        }

        private void dgvroles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {          
            RoleDetail role = new RoleDetail(this);

            string colName = dgvroles.Columns[e.ColumnIndex].Name;
            if (colName == "Detail")
            {
                role.lbrole.Text = dgvroles.Rows[e.RowIndex].Cells[0].Value.ToString();
                role.ShowDialog();
            }
            else if (colName == "Grant")
            {
                btnupdaterole.Enabled = true;
                btnsave.Enabled = false;
                txtrolename.Enabled = false;
                txtrolename.Text = dgvroles.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            else if (colName == "Xoa")
            {
                if (MessageBox.Show("Bạn chắc chắn muốn xóa Role này?", "Xóa Role", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (oracle.create_drop_role(oracle.proc_dropRole, dgvroles.Rows[e.RowIndex].Cells[0].Value.ToString()))
                    {
                        MessageBox.Show("Xóa thành công", title, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                dgvroles.Rows.Clear();
                tb.LoadDataGridView(oracle.Load_cbb(oracle.role), 2, dgvroles);
            }
        }

        private void btnupdaterole_Click(object sender, EventArgs e)
        {
            btnsave.Enabled = true;
            if (MessageBox.Show("Bạn chắc chắn muốn sửa quyền role này?", "Sửa role", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (get_query())
                {
                    MessageBox.Show("Sửa quyền của role thành công", title, MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
            reset_role();
            btnupdaterole.Enabled = false;
        }

        private void txtsearchpf_TextChanged(object sender, EventArgs e)
        {
            dgvProfiles.Rows.Clear();
            tb.LoadDataGridView(oracle.Load_cbb(oracle.profile_name(txtsearchpf.Text)), 2, dgvProfiles);
        }

        //Phần tab PROFILE
        private void dgvProfiles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvProfiles.Columns[e.ColumnIndex].Name;
            if(colName == "ChiTiet")
            {
                ProfileDetail pr = new ProfileDetail(this);
                pr.lbprof.Text = dgvProfiles.Rows[e.RowIndex].Cells[0].Value.ToString();
                pr.ShowDialog();
            }
            if (colName == "Sua")
            {
                txtprofname.Enabled = false;
                btnsua.Enabled = true;
                btnluu.Enabled = false;
                txtprofname.Text = dgvProfiles.Rows[e.RowIndex].Cells[0].Value.ToString();
                List<string> resorce_name = oracle.Profile(dgvProfiles.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtfla.Text = resorce_name[17];
                txtplt.Text = resorce_name[14];
                txtprt.Text = resorce_name[11];
                txtprm.Text = resorce_name[8];
                txtplockt.Text = resorce_name[2];
                txtpgt.Text = resorce_name[20];
                txtspu.Text = resorce_name[47];
                txtidle.Text = resorce_name[29];
                txtcnt.Text = resorce_name[26];
                
            }
            if (colName == "Xoas")
            {
                if (MessageBox.Show("Bạn chắc chắn muốn xóa Profile này?", "Xóa Profile", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (oracle.delete(oracle.delete_profile(dgvProfiles.Rows[e.RowIndex].Cells[0].Value.ToString())))
                    {
                        MessageBox.Show("Xóa thành công", title, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                dgvProfiles.Rows.Clear();
                tb.LoadDataGridView(oracle.Load_cbb(oracle.profile_name(txtsearchpf.Text)), 2, dgvProfiles);
            }
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            if(txtprofname.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên profile muốn tạo!", title, MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                if (MessageBox.Show("Bạn chắc chắn muốn thêm profile này?", "Tạo profile", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (oracle.create_Profile("CREATE",txtprofname.Text, txtfla.Text, txtplt.Text, txtprt.Text, txtprm.Text, txtplockt.Text, txtpgt.Text, txtspu.Text, txtidle.Text, txtcnt.Text))
                    {
                        MessageBox.Show("Thêm thành công", title, MessageBoxButtons.OK, MessageBoxIcon.Question);
                        reset_profile();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            dgvProfiles.Rows.Clear();
            tb.LoadDataGridView(oracle.Load_cbb(oracle.profile_name(txtsearchpf.Text)), 2, dgvProfiles);
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            reset_profile();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (txtprofname.Text == "" | txtfla.Text == "" | txtplt.Text == "" | txtprt.Text == "" | txtprm.Text == "" | txtplockt.Text == "" | txtpgt.Text == "" | txtspu.Text == "" | txtidle.Text == "" | txtcnt.Text == "")
            {
                MessageBox.Show("Vui lòng không để trống thông tin!", title, MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                if (MessageBox.Show("Bạn chắc chắn muốn sửa profile này?", "Sửa profile", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (oracle.create_Profile("ALTER", txtprofname.Text, txtfla.Text, txtplt.Text, txtprt.Text, txtprm.Text, txtplockt.Text, txtpgt.Text, txtspu.Text, txtidle.Text, txtcnt.Text))
                    {
                        MessageBox.Show("Sửa thành công", title, MessageBoxButtons.OK, MessageBoxIcon.Question);
                        reset_profile();
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            dgvProfiles.Rows.Clear();
            tb.LoadDataGridView(oracle.Load_cbb(oracle.profile_name(txtsearchpf.Text)), 2, dgvProfiles);
        }
    }
}