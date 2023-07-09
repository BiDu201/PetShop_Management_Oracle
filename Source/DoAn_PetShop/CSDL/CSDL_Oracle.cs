using DoAn_PetShop.CSDL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DoAn_PetShop
{
    class CSDL_Oracle
    {
        DbConnect dbconnect = new DbConnect();
        static string luachon = string.Empty;

        #region lenh truy van
        public string us = "Select USERNAME from DBA_USERS Order by USERNAME"; //truy vấn lấy tên user
        public string pr = "select Name From sys.profname$ Order by Name"; //truy vấn tên của profile
        public string tb = "select Tablespace_name from dba_tablespaces where tablespace_name not in 'TEMP' order by tablespace_name"; //truy vấn lấy tên tablespace(không bao gồm temp)
        public string tble = "select table_name from all_tables where table_name in ('NHANVIEN','KHACHHANG','SANPHAM','PHIEUNHAP','CTPHIEUNHAP','HOADON')"; //truy vấn tên 6 bảng chính của chương trình
        public string role = "select ROLE from dba_roles where oracle_maintained = 'N' order by ROLE"; //truy vấn tên role được tạo bởi người dùng
        public string proc_createRole = "ROLE_PACKAGE.createRole"; //gọi procedure tạo role
        public string proc_dropRole = "ROLE_PACKAGE.dropRole"; //gọi procedure xóa role       
        public string loadtime = "select distinct date_stamp from userQL.audit_HoaDon"; // load ngày audit lên cbb
        public string loaddate = "select distinct event_date from userQL.startup_audit";
        public string delete_log = "delete from userQL.db_evnt_audit";
        public string delete_audit_FGA = "TRUNCATE TABLE fga_log$";
        public string delete_audit_userQL = "TRUNCATE TABLE AUD$";
        public string delete_user(string name)
        {
            return "drop user " + name + " CASCADE";
        }
        public string pri(string txtsearch)
        {
            //truy vấn tên privilege trong hệ thống
            string cmd = "select distinct privilege from dba_sys_privs where privilege LIKE '" + txtsearch.ToUpper() + "%' order by privilege";
            return cmd;
        }
        public string pri_user(string usn)
        {
            // truy vấn lấy quyền của user được chỉ định
            return "select privilege from dba_sys_privs where grantee = '" + usn + "' Order by privilege";
        }
        public string role_user(string usn)
        {
            // truy vấn lấy role của user
            return "SELECT GRANTED_ROLE FROM dba_role_privs WHERE GRANTEE = '" + usn + "' Order by GRANTED_ROLE";
        }

        public string profile_name(string prname)
        {
            // tìm kiếm profile
            return "select distinct profile from dba_profiles where Profile LIKE '" + prname.ToUpper() + "%'";
        }

        public string delete_profile(string namepf)
        {
            return "Drop profile " + namepf + " CASCADE";
        }

        public string delete_hd(string date)
        {
            return "Delete from userQL.audit_HoaDon where date_stamp LIKE '" + date + "%' ";
        }

        public string delete_st_sd(string date)
        {
            return "Delete from userQL.startup_audit where event_date LIKE '" + date + "%' ";
        }
        #endregion

        public void setLuaChon(string s)
        {
            luachon = s;
        }
        public string getLuaChon()
        {
            return luachon;
        }
        #region đừng đụng vào
        #region ---tạo file excel
        //public void createFileExcel()
        //{
        //    Excel.Application excelApp = new Excel.Application();
        //    Excel.Workbook workbook = null;
        //    FileInfo file = new FileInfo(@"D:\Oracle.xlsx");
        //    if (!file.Exists)
        //    {
        //        workbook = excelApp.Workbooks.Add();
        //        workbook.SaveAs(@"D:\Oracle.xlsx");
        //        workbook.Close();
        //        excelApp.Quit();
        //    }
        //}
        #endregion
        #region ---kiểm tra session mong muốn
        //public bool ungDungDN()
        //{
        //    OracleConnection con = dbconnect.getDBConnection();
        //    Excel.Application excelapp = new Excel.Application();
        //    Excel.Workbook workbook = excelapp.Workbooks.Open(@"D:\Oracle.xlsx");
        //    Excel.Worksheet worksheet = workbook.Sheets.Add();
        //    try
        //    {
        //        con.Open();
        //        OracleCommand cmd = con.CreateCommand();
        //        cmd.CommandText = "SELECT column_name FROM all_tab_columns WHERE table_name = 'V_$SESSION' AND column_name IN ('SID','SERIAL#','USERNAME','PROGRAM') ORDER BY DECODE(column_name, 'SID', 1,'SERIAL#',2,'USERNAME',3,'PROGRAM',4)";
        //        cmd.CommandType = CommandType.Text;
        //        OracleDataReader dr = cmd.ExecuteReader();
        //        int i = 1;
        //        while (dr.Read())
        //        {
        //            worksheet.Cells[1, i] = dr.GetValue(0).ToString();
        //            i++;
        //        }
        //        Excel.Range entireColumn = worksheet.UsedRange.EntireColumn;
        //        entireColumn.ColumnWidth = 20; // Thiết lập độ rộng cột
        //        entireColumn.Font.Bold = true;
        //        dr.Close();
        //        cmd = con.CreateCommand();
        //        cmd.CommandText = "select sid,serial#,username,program from v$session where type != 'BACKGROUND'";
        //        cmd.CommandType = CommandType.Text;
        //        dr = cmd.ExecuteReader();
        //        int j = 2;
        //        while (dr.Read())
        //        {
        //            for (int k = 0; k < i - 1; k++)
        //            {
        //                worksheet.Cells[j, k + 1] = dr.GetValue(k).ToString();
        //            }
        //            j++;
        //        }
        //        dr.Close();
        //        con.Close();
        //        workbook.Save();
        //        workbook.Close();
        //        excelapp.Quit();
        //        return true;
        //    }
        //    catch
        //    {
        //        con.Close();
        //        workbook.Save();
        //        workbook.Close();
        //        excelapp.Quit();
        //        return false;
        //    }
        //}
        #endregion
        #region ---kiểm tra session đã muốn dừng
        //public bool checkSessionAfterkill(string SID, string serial)
        //{
        //    OracleConnection con = dbconnect.getDBConnection();
        //    Excel.Application excelapp = new Excel.Application();
        //    Excel.Workbook workbook = excelapp.Workbooks.Open(@"D:\Oracle.xlsx");
        //    Excel.Worksheet worksheet = workbook.Sheets.Add();
        //    try
        //    {
        //        con.Open();
        //        OracleCommand cmd = con.CreateCommand();
        //        cmd.CommandText = "SELECT column_name FROM all_tab_columns WHERE table_name = 'V_$SESSION' AND column_name IN ('SID','SERIAL#','USERNAME','STATUS','SERVER') ORDER BY DECODE(column_name, 'SID', 1,'SERIAL#',2,'USERNAME',3,'STATUS',4,'SERVER',5)";
        //        cmd.CommandType = CommandType.Text;
        //        OracleDataReader dr = cmd.ExecuteReader();
        //        int i = 1;
        //        while (dr.Read())
        //        {
        //            worksheet.Cells[1, i] = dr.GetValue(0).ToString();
        //            i++;
        //        }
        //        Excel.Range entireColumn = worksheet.UsedRange.EntireColumn;
        //        entireColumn.ColumnWidth = 20; // Thiết lập độ rộng cột
        //        entireColumn.Font.Bold = true;
        //        dr.Close();
        //        cmd = con.CreateCommand();
        //        cmd.CommandText = "SELECT SID, SERIAL#,username, STATUS, SERVER FROM V$SESSION WHERE sid='" + SID + "' and serial#='" + serial + "'";
        //        cmd.CommandType = CommandType.Text;
        //        dr = cmd.ExecuteReader();
        //        int j = 2;
        //        while (dr.Read())
        //        {
        //            for (int k = 0; k < i - 1; k++)
        //            {
        //                worksheet.Cells[j, k + 1] = dr.GetValue(k).ToString();
        //            }
        //            j++;
        //        }
        //        dr.Close();
        //        con.Close();
        //        workbook.Save();
        //        workbook.Close();
        //        excelapp.Quit();
        //        return true;
        //    }
        //    catch
        //    {
        //        con.Close();
        //        workbook.Save();
        //        workbook.Close();
        //        excelapp.Quit();
        //        return false;
        //    }
        //}
        #endregion
        #region ---xuất file excel
        //public string[] infoUser(string username)
        //{
        //    OracleConnection con = dbconnect.getDBConnection();
        //    string upperUserName = username.ToUpper();
        //    con.Open();
        //    OracleCommand cmd = con.CreateCommand();
        //    cmd.CommandText = "SELECT USERNAME,CREATED,EXPIRY_DATE,ACCOUNT_STATUS,LAST_LOGIN,PROFILE FROM DBA_USERS Where username = '" + upperUserName + "'";
        //    cmd.CommandType = CommandType.Text;
        //    OracleDataReader dr = cmd.ExecuteReader();
        //    dr.Read();
        //    string[] temp = new string[6];
        //    for (int i = 0; i < 6; i++)
        //    {
        //        temp[i] = dr.GetValue(i).ToString();
        //    }
        //    dr.Close();
        //    con.Close();
        //    return temp;
        //}
        //public void InforUserExcel(string username)
        //{
        //    Excel.Application excelApp = new Excel.Application();

        //    // Khởi tạo một Workbook mới
        //    Excel.Workbook workbook = excelApp.Workbooks.Open(@"D:\Oracle.xlsx");
        //    Excel.Worksheet worksheet = workbook.Sheets.Add();
        //    string[] temp = getColumnName();
        //    for (int i = 1; i < 7; i++)
        //    {
        //        worksheet.Cells[1, i] = temp[i - 1];
        //    }
        //    //format cột
        //    Excel.Range entireColumn = worksheet.UsedRange.EntireColumn;
        //    entireColumn.ColumnWidth = 20; // Thiết lập độ rộng cột
        //    entireColumn.Font.Bold = true; // Đặt đậm phông chữ
        //                                   //lấy dữ liệu trong bảng bỏ vào file excel
        //    temp = infoUser(username);
        //    for (int i = 1; i < 7; i++)
        //    {
        //        worksheet.Cells[2, i] = temp[i - 1];
        //    }
        //    //lưu file
        //    workbook.Save();
        //    workbook.Close();
        //    excelApp.Quit();
        //}

        #endregion
        #region ---xem thông tin các view
        //public bool InforView(string tableName, string fromTableName)
        //{
        //    OracleConnection con = dbconnect.getDBConnection();
        //    Excel.Application excelapp = new Excel.Application();
        //    Excel.Workbook workbook = excelapp.Workbooks.Open(@"D:\Oracle.xlsx");
        //    Excel.Worksheet worksheet = workbook.Sheets.Add();
        //    try
        //    {
        //        con.Open();
        //        OracleCommand cmd = con.CreateCommand();
        //        cmd.CommandText = "select column_name from all_tab_columns where table_name = '" + tableName + "' order by column_id";
        //        cmd.CommandType = CommandType.Text;
        //        OracleDataReader dr = cmd.ExecuteReader();
        //        int i = 1;
        //        while (dr.Read())
        //        {
        //            worksheet.Cells[1, i] = dr.GetValue(0).ToString();
        //            i++;
        //        }
        //        Excel.Range entireColumn = worksheet.UsedRange.EntireColumn;
        //        entireColumn.ColumnWidth = 30; // Thiết lập độ rộng cột
        //        entireColumn.Font.Bold = true;
        //        dr.Close();
        //        cmd = con.CreateCommand();
        //        cmd.CommandText = "Select * from " + fromTableName + "";
        //        cmd.CommandType = CommandType.Text;
        //        dr = cmd.ExecuteReader();
        //        int j = 2;
        //        while (dr.Read())
        //        {
        //            for (int k = 0; k < i - 1; k++)
        //            {
        //                worksheet.Cells[j, k + 1] = dr.GetValue(k).ToString();
        //            }
        //            j++;
        //        }
        //        dr.Close();
        //        con.Close();
        //        workbook.Save();
        //        workbook.Close();
        //        excelapp.Quit();
        //        return true;
        //    }
        //    catch
        //    {
        //        con.Close();
        //        workbook.Save();
        //        workbook.Close();
        //        excelapp.Quit();
        //        return false;
        //    }
        //}
        #endregion
        #region ---Database
        //public bool Database()
        //{
        //    OracleConnection con = dbconnect.getDBConnection();
        //    Excel.Application excelapp = new Excel.Application();
        //    Excel.Workbook workbook = excelapp.Workbooks.Open(@"D:\Oracle.xlsx");
        //    Excel.Worksheet worksheet = workbook.Sheets.Add();
        //    try
        //    {
        //        con.Open();
        //        OracleCommand cmd = con.CreateCommand();
        //        cmd.CommandText = "SELECT column_name FROM all_tab_columns WHERE table_name = 'V_$DATABASE' AND column_name IN ('DBID','NAME','CREATED','RESETLOGS_CHANGE#','RESETLOGS_TIME','PRIOR_RESETLOGS_CHANGE#','PRIOR_RESETLOGS_TIME') ORDER BY DECODE(column_name, 'DBID', 1, 'NAME', 2, 'CREATED', 3, 'RESETLOGS_CHANGE#', 4, 'RESETLOGS_TIME', 5, 'PRIOR_RESETLOGS_CHANGE#', 6, 'PRIOR_RESETLOGS_TIME', 7)";
        //        cmd.CommandType = CommandType.Text;
        //        OracleDataReader dr = cmd.ExecuteReader();
        //        int i = 1;
        //        while (dr.Read())
        //        {
        //            worksheet.Cells[1, i] = dr.GetValue(0).ToString();
        //            i++;
        //        }
        //        Excel.Range entireColumn = worksheet.UsedRange.EntireColumn;
        //        entireColumn.ColumnWidth = 20; // Thiết lập độ rộng cột
        //        entireColumn.Font.Bold = true;
        //        dr.Close();
        //        cmd = con.CreateCommand();
        //        cmd.CommandText = "Select DBID,NAME,CREATED,RESETLOGS_CHANGE#,RESETLOGS_TIME,PRIOR_RESETLOGS_CHANGE#,PRIOR_RESETLOGS_TIME from v$database";
        //        cmd.CommandType = CommandType.Text;
        //        dr = cmd.ExecuteReader();
        //        int j = 2;
        //        while (dr.Read())
        //        {
        //            for (int k = 0; k < 6; k++)
        //            {
        //                worksheet.Cells[j, k + 1] = dr.GetValue(k).ToString();
        //            }
        //            j++;
        //        }
        //        dr.Close();
        //        con.Close();
        //        workbook.Save();
        //        workbook.Close();
        //        excelapp.Quit();
        //        return true;
        //    }
        //    catch
        //    {
        //        con.Close();
        //        workbook.Save();
        //        workbook.Close();
        //        excelapp.Quit();
        //        return false;
        //    }
        //}
        #endregion
        #endregion

        #region spfile
        public List<string> columnSPFile(string tableName)
        {
            OracleConnection con = dbconnect.getDBConnection();
            con.Open();
            OracleCommand cmd = new OracleCommand("get_column_thongtintuychon", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("tablename", OracleDbType.Varchar2).Value = tableName;
            OracleDataReader dr = cmd.ExecuteReader();
            List<string> temp = new List<string>();
            while (dr.Read())
            {
                temp.Add(dr.GetValue(0).ToString());
                countColumn++;
            }
            dr.Close();
            con.Close();
            return temp;
        }
        public List<string> dataSPFile()
        {
            OracleConnection con = dbconnect.getDBConnection();
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from v$parameter where name = 'spfile'";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            List<string> temp = new List<string>();
            while (dr.Read())
            {
                for (int i = 0; i < countColumn; i++)
                {
                    temp.Add(dr.GetValue(i).ToString());
                }
            }
            countColumn = 0;
            dr.Close();
            con.Close();
            return temp;
        }
        #endregion

        #region thongtintuychon
        private int countColumn = 0;
        public List<string> ColumnThongTinTuyChon(string tableName)
        {
            OracleConnection con = dbconnect.getDBConnection();
            List<string> temp = new List<string>();
            try
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("get_column_thongtintuychon", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("tablename", OracleDbType.Varchar2).Value = tableName;
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temp.Add(dr.GetValue(0).ToString());
                    countColumn++;
                }
                dr.Close();
                con.Close();
                return temp;
            }
            catch
            {
                con.Close();
                return temp;
            }
        }
        public List<string> dataThongTinTuyChon(string fromTableName)
        {
            OracleConnection con = dbconnect.getDBConnection();
            List<string> temp = new List<string>();
            try
            {
                con.Open();
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select * from " + fromTableName + "";
                cmd.CommandType = CommandType.Text;
                OracleDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    for (int i = 0; i < countColumn; i++)
                    {
                        temp.Add(dr.GetValue(i).ToString());
                    }
                }
                countColumn = 0;
                dr.Close();
                con.Close();
                return temp;
            }
            catch
            {
                con.Close();
                return temp;
            }
        }
        #endregion

        #region đếm số session
        public int demSession()
        {
            try
            {
                OracleConnection con = dbconnect.getDBConnection();
                con.Open();
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = "select count(*) from v$session";
                cmd.CommandType = CommandType.Text;
                int result = int.Parse(cmd.ExecuteScalar().ToString());
                con.Close();
                return result;
            }
            catch
            {
                return 0;
            }
        }
        #endregion

        #region dừng 1 session mong muốn
        public bool killSession(string SID, string serial)
        {
            OracleConnection con = dbconnect.getDBConnection();
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "Alter system kill session '" + SID + "," + serial + "'";
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                con.Close();
                return false;
            }
        }
        #endregion

        #region kiểm tra session đang đăng nhập
        public List<string> GetColumnsessionDN()
        {
            OracleConnection con = dbconnect.getDBConnection();
            List<string> temp = new List<string>();

            try
            {

                con.Open();
                OracleCommand cmd = new OracleCommand("get_column_sessiondn", con);
                cmd.CommandType = CommandType.StoredProcedure;
                OracleDataReader dr = cmd.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {
                    temp.Add(dr.GetValue(0).ToString());
                    i++;
                }
                dr.Close();
                con.Close();
                return temp;
            }
            catch
            {
                con.Close();
                return temp;
            }
        }

        public List<string> sessionDN()
        {
            OracleConnection con = dbconnect.getDBConnection();
            List<string> temp = new List<string>();
            try
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("get_data_sessiondn", con);
                cmd.CommandType = CommandType.StoredProcedure;
                OracleDataReader dr = cmd.ExecuteReader();
                int j = 0;
                while (dr.Read())
                {
                    for (int k = 0; k < 4; k++)
                    {
                        temp.Add(dr.GetValue(k).ToString());
                        j++;
                    }
                }
                dr.Close();
                con.Close();
                return temp;
            }
            catch
            {
                con.Close();
                return temp;
            }
        }
        #endregion

        #region datatableGetInfoUser
        static string GetUserName;
        public void setGetUserName(string s)
        {
            GetUserName = s;
        }
        public List<string> getColumnName()
        {
            OracleConnection con = dbconnect.getDBConnection();
            List<string> temp = new List<string>();
            try
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("get_column_inforuser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                OracleDataReader dr = cmd.ExecuteReader();

                int i = 0;
                while (dr.Read())
                {
                    temp.Add(dr.GetValue(0).ToString());
                    i++;
                }
                dr.Close();
                con.Close();
                return temp;
            }
            catch
            {
                con.Close();
                return temp;
            }
        }
        public List<string> getInforUser()
        {
            OracleConnection con = dbconnect.getDBConnection();
            List<string> temp = new List<string>();
            try
            {


                string upperUserName = GetUserName.ToUpper();
                con.Open();
                OracleCommand cmd = new OracleCommand("get_data_inforuser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("USERNAME", OracleDbType.Varchar2).Value = upperUserName;
                OracleDataReader dr = cmd.ExecuteReader();
                dr.Read();
                for (int i = 0; i < 6; i++)
                {
                    temp.Add(dr.GetValue(i).ToString());
                }
                dr.Close();
                con.Close();
                return temp;
            }
            catch
            {
                con.Close();
                return temp;
            }
        }
        #endregion

        #region dataTableCheckKill
        static string SIDSerrial = string.Empty;

        public string getSIDSerial()
        {
            return SIDSerrial;
        }
        public void setSIDSerial(string s)
        {
            SIDSerrial = s;
        }
        public List<string> getColumnSessionkilled()
        {
            OracleConnection con = dbconnect.getDBConnection();
            List<string> temp = new List<string>();

            try
            {

                con.Open();
                OracleCommand cmd = new OracleCommand("get_column_sessionkilled", con);
                cmd.CommandType = CommandType.StoredProcedure;
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temp.Add(dr.GetValue(0).ToString());
                }
                dr.Close();
                con.Close();
                return temp;
            }
            catch
            {
                con.Close();
                return temp;
            }
        }
        public List<string> checkSessionKilled(string SID, string serial)
        {
            OracleConnection con = dbconnect.getDBConnection();
            List<string> temp = new List<string>();

            try
            {
                killSession(SID, serial);
                con.Open();
                OracleCommand cmd = new OracleCommand("get_data_sessionkilled", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("SID", OracleDbType.Varchar2).Value = SID;
                cmd.Parameters.Add("SERIAL#", OracleDbType.Varchar2).Value = serial;
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    for (int k = 0; k < 5; k++)
                    {
                        temp.Add(dr.GetValue(k).ToString());
                    }
                }
                dr.Close();
                con.Close();
                return temp;
            }
            catch
            {
                con.Close();
                return temp;
            }
        }
        #endregion

        #region block session
        public string getSidSerrialBlock()
        {
            OracleConnection con = dbconnect.getDBConnection();
            string temp = string.Empty;
            try
            {

                con.Open();
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT s.sid,s.serial# FROM v$session s WHERE s.blocking_session is not null";
                cmd.CommandType = CommandType.Text;
                OracleDataReader dr = cmd.ExecuteReader();
                dr.Read();
                temp += dr.GetValue(0).ToString() + "," + dr.GetValue(1).ToString();
                con.Close();
                return temp;
            }
            catch
            {
                con.Close();
                return temp;
            }
        }
        public bool KillBlockSession(string SID, string serial)
        {
            OracleConnection con = dbconnect.getDBConnection();
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "Alter system kill session '" + SID + "," + serial + "' immediate";
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                con.Close();
                return false;
            }
        }
        public List<string> checkSessionBlockKilled(string SID, string serial)
        {
            OracleConnection con = dbconnect.getDBConnection();
            List<string> temp = new List<string>();

            try
            {
                KillBlockSession(SID, serial);
                con.Open();
                OracleCommand cmd = new OracleCommand("get_data_sessionkilled", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("SID", OracleDbType.Varchar2).Value = SID;
                cmd.Parameters.Add("SERIAL#", OracleDbType.Varchar2).Value = serial;
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    for (int k = 0; k < 5; k++)
                    {
                        temp.Add(dr.GetValue(k).ToString());
                    }
                }
                dr.Close();
                con.Close();
                return temp;
            }
            catch
            {
                con.Close();
                return temp;
            }
        }
        public List<string> GetColumnBlockedSession()
        {
            OracleConnection con = dbconnect.getDBConnection();
            List<string> temp = new List<string>();

            try
            {

                con.Open();
                OracleCommand cmd = new OracleCommand("get_column_sessionblocked", con);
                cmd.CommandType = CommandType.StoredProcedure;
                OracleDataReader dr = cmd.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {
                    temp.Add(dr.GetValue(0).ToString());
                    i++;
                }
                dr.Close();
                con.Close();
                return temp;
            }
            catch
            {
                con.Close();
                return temp;
            }
        }
        public List<string> checkSessionBlocked()
        {
            OracleConnection con = dbconnect.getDBConnection();
            List<string> temp = new List<string>();
            try
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("get_data_sessionblocked", con);
                cmd.CommandType = CommandType.StoredProcedure;
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    for (int k = 0; k < 9; k++)
                    {
                        temp.Add(dr.GetValue(k).ToString());
                    }
                }
                dr.Close();
                con.Close();
                return temp;
            }
            catch
            {
                con.Close();
                return temp;
            }
        }
        #endregion


        #region Tablespace        
        public List<string> dataTablespace()
        {
            OracleConnection con = dbconnect.getDBConnection();
            List<string> temp = new List<string>();
            try
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("sys.show_Tablespace", con);
                cmd.CommandType = CommandType.StoredProcedure;
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    for (int i = 0; i < 9; i++)
                    {
                        //lấy thứ tự từng cột của 1 dòng (i là thứ tự cột bắt đầu từ 0 trong dr)
                        temp.Add(dr.GetValue(i).ToString());
                    }
                }
                dr.Close();
                con.Close();
                return temp;
            }
            catch
            {
                con.Close();
                return temp;
            }
        }
        #endregion

        #region combobox 
        public List<string> Load_cbb(string cl)
        {
            OracleConnection con = dbconnect.getDBConnection();
            List<string> temp = new List<string>();
            try
            {
                con.Open();
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = cl;
                cmd.CommandType = CommandType.Text;
                OracleDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    for (int i = 0; i < 1; i++)
                    {
                        //lấy thứ tự từng cột của 1 dòng (i là thứ tự cột bắt đầu từ 0 trong dr)
                        temp.Add(dr.GetValue(i).ToString());
                    }
                }
                dr.Close();
                con.Close();
                return temp;
            }
            catch
            {
                con.Close();
                return temp;
            }
        }
        #endregion

        #region tablespaceofuser
        public string getDefaultTableSpaceUser(string username)
        {
            try
            {
                OracleConnection con = dbconnect.getDBConnection();
                con.Open();
                OracleCommand cmd = new OracleCommand("sys.show_TablespaceUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("username", OracleDbType.Varchar2).Value = username;
                string role = cmd.ExecuteScalar().ToString();
                con.Close();

                return role;
            }
            catch
            {
                return "";
            }
        }
        #endregion

        #region deletetablespace
        public bool deleteTableSpace(string name)
        {
            try
            {
                OracleConnection con = dbconnect.getDBConnection();
                con.Open();
                OracleCommand cmd = new OracleCommand("sys.delete_Tablespace", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("tbs_name", OracleDbType.Varchar2).Value = name;
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region loaddatafile
        public List<string> dataFile()
        {
            OracleConnection con = dbconnect.getDBConnection();
            List<string> temp = new List<string>();
            try
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("sys.show_Datafile", con);
                cmd.CommandType = CommandType.StoredProcedure;
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    for (int i = 0; i < 3; i++)
                    {
                        //lấy thứ tự từng cột của 1 dòng (i là thứ tự cột bắt đầu từ 0 trong dr)
                        temp.Add(dr.GetValue(i).ToString());
                    }
                }
                dr.Close();
                con.Close();
                return temp;
            }
            catch
            {
                con.Close();
                return temp;
            }
        }
        #endregion

        #region detailtablespace
        public List<string> detailtbspace(string name)
        {
            OracleConnection con = dbconnect.getDBConnection();
            List<string> temp = new List<string>();
            try
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("sys.detail_Tablespace", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("tbs_name", OracleDbType.Varchar2).Value = name;
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    for (int i = 0; i < 5; i++)
                    {
                        //lấy thứ tự từng cột của 1 dòng (i là thứ tự cột bắt đầu từ 0 trong dr)
                        temp.Add(dr.GetValue(i).ToString());
                    }
                }
                dr.Close();
                con.Close();
                return temp;
            }
            catch
            {
                con.Close();
                return temp;
            }
        }
        #endregion

        #region deletedatafile
        public bool deleteDatafile(string tb, string file)
        {
            try
            {
                OracleConnection con = dbconnect.getDBConnection();
                con.Open();
                OracleCommand cmd = new OracleCommand("sys.delete_Datafile", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("tbs_name", OracleDbType.Varchar2).Value = tb;
                cmd.Parameters.Add("datafile", OracleDbType.Varchar2).Value = file;
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region resizedatafile
        public bool resizeDatafile(string file, string size)
        {
            try
            {
                OracleConnection con = dbconnect.getDBConnection();
                con.Open();
                OracleCommand cmd = new OracleCommand("sys.resize_Datafile", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("dtf_name", OracleDbType.Varchar2).Value = file;
                cmd.Parameters.Add("size_new", OracleDbType.Varchar2).Value = size;
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region adddatafile
        public bool addDatafile(string tbspace, string file, string size, string sizeauto)
        {
            try
            {

                OracleConnection con = dbconnect.getDBConnection();
                con.Open();
                OracleCommand cmd = new OracleCommand("sys.create_datafile", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("tablespace_name", OracleDbType.Varchar2).Value = tbspace;
                cmd.Parameters.Add("datafile_name", OracleDbType.Varchar2).Value = file;
                cmd.Parameters.Add("size", OracleDbType.Varchar2).Value = size;
                cmd.Parameters.Add("autoextend", OracleDbType.Varchar2).Value = sizeauto;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region addtablespace
        public bool addTablespace(string sl, string nametb, string namedtfile, string size, string extend)
        {
            try
            {
                OracleConnection con = dbconnect.getDBConnection();
                con.Open();
                OracleCommand cmd = new OracleCommand("create_tbspace", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("soluong_datafile", OracleDbType.Int32).Value = int.Parse(sl);
                cmd.Parameters.Add("tablespace_name", OracleDbType.Varchar2).Value = nametb;
                cmd.Parameters.Add("datafile_name", OracleDbType.Varchar2).Value = namedtfile;
                cmd.Parameters.Add("size", OracleDbType.Varchar2).Value = size;
                cmd.Parameters.Add("autoextend", OracleDbType.Varchar2).Value = extend;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion


        #region dgvuser
        public List<string> User()
        {
            OracleConnection con = dbconnect.getDBConnection();
            List<string> temp = new List<string>();
            try
            {
                con.Open();
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = "select USERNAME,LOCK_DATE,EXPIRY_DATE,CREATED,DEFAULT_TABLESPACE,PROFILE from dba_users where ACCOUNT_STATUS = 'OPEN'";
                cmd.CommandType = CommandType.Text;
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    for (int i = 0; i < 6; i++)
                    {
                        //lấy thứ tự từng cột của 1 dòng (i là thứ tự cột bắt đầu từ 0 trong dr)
                        temp.Add(dr.GetValue(i).ToString());
                    }
                }
                dr.Close();
                con.Close();
                return temp;
            }
            catch
            {
                con.Close();
                return temp;
            }
        }
        #endregion

        #region delete
        public bool delete(string cl)
        {
            try
            {
                OracleConnection con = dbconnect.getDBConnection();
                con.Open();
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = cl;
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region createuser
        public bool createUser(string name, string pass, string tbsp, string pro, string role, string privs)
        {
            try
            {
                OracleConnection con = dbconnect.getDBConnection();
                con.Open();
                OracleCommand cmd = new OracleCommand("sys.AL_CR_GNT_USER_PACKAGE.CR_GRT", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("txtusername", OracleDbType.Varchar2).Value = name;
                cmd.Parameters.Add("txtpass", OracleDbType.Varchar2).Value = pass;
                cmd.Parameters.Add("cbbtps", OracleDbType.Varchar2).Value = tbsp;
                cmd.Parameters.Add("cbbprofile", OracleDbType.Varchar2).Value = pro;
                cmd.Parameters.Add("cbbrole", OracleDbType.Varchar2).Value = role;
                cmd.Parameters.Add("lbpri", OracleDbType.Varchar2).Value = privs;
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region revoke_privs_user
        public bool revoke(string usn, string pri)
        {
            try
            {
                OracleConnection con = dbconnect.getDBConnection();
                con.Open();
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = "REVOKE " + pri + " FROM " + usn + "";
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region alteruser
        public bool alterUser(string name, string pass, string tbsp, string pro, string role, string privs)
        {
            try
            {
                OracleConnection con = dbconnect.getDBConnection();
                con.Open();
                OracleCommand cmd = new OracleCommand("sys.AL_CR_GNT_USER_PACKAGE.AL_USER", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("txtusername", OracleDbType.Varchar2).Value = name;
                cmd.Parameters.Add("txtpass", OracleDbType.Varchar2).Value = pass;
                cmd.Parameters.Add("cbbtps", OracleDbType.Varchar2).Value = tbsp;
                cmd.Parameters.Add("cbbprofile", OracleDbType.Varchar2).Value = pro;
                cmd.Parameters.Add("cbbrole", OracleDbType.Varchar2).Value = role;
                cmd.Parameters.Add("lbpri", OracleDbType.Varchar2).Value = privs;
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region privilege of role
        public List<string> privs_Role(string grantee)
        {
            OracleConnection con = dbconnect.getDBConnection();
            List<string> temp = new List<string>();
            try
            {
                con.Open();
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT TABLE_NAME,PRIVILEGE, TYPE FROM DBA_TAB_PRIVS WHERE GRANTEE = '" + grantee + "' ORDER BY GRANTEE, TABLE_NAME, PRIVILEGE";
                cmd.CommandType = CommandType.Text;
                OracleDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    for (int i = 0; i < 3; i++)
                    {
                        //lấy thứ tự từng cột của 1 dòng (i là thứ tự cột bắt đầu từ 0 trong dr)
                        temp.Add(dr.GetValue(i).ToString());
                    }
                }
                dr.Close();
                con.Close();
                return temp;
            }
            catch
            {
                con.Close();
                return temp;
            }
        }
        #endregion

        #region create_drop_role
        public bool create_drop_role(string proc, string rolename)
        {
            try
            {
                OracleConnection con = dbconnect.getDBConnection();
                con.Open();
                OracleCommand cmd = new OracleCommand(proc, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("txtrolename", OracleDbType.Varchar2).Value = rolename;
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region grant_role
        public bool grant_role(string rolename, string query, string table)
        {
            try
            {
                OracleConnection con = dbconnect.getDBConnection();
                con.Open();
                OracleCommand cmd = new OracleCommand("ROLE_PACKAGE.grantRole", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("txtrolename", OracleDbType.Varchar2).Value = rolename;
                cmd.Parameters.Add("query", OracleDbType.Varchar2).Value = query;
                cmd.Parameters.Add("table", OracleDbType.Varchar2).Value = table;
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region revoke_privs_role
        public bool revoke_privs_role(string query, string table, string role)
        {
            try
            {
                OracleConnection con = dbconnect.getDBConnection();
                con.Open();
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = "REVOKE " + query + " ON userQL." + table + " FROM " + role + " ";
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region createProfile
        public bool create_Profile(string lenh, string profname, string fla, string plt, string prt, string prm, string plte, string pgt, string spu, string idt, string cnt)
        {
            try
            {
                OracleConnection con = dbconnect.getDBConnection();
                con.Open();
                OracleCommand cmd = new OracleCommand("CREATE_ALTER_PROFILE", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("Cmd", OracleDbType.Varchar2).Value = lenh;
                cmd.Parameters.Add("profilename", OracleDbType.Varchar2).Value = profname;
                cmd.Parameters.Add("FAILED_LOGIN_ATTEMPTS", OracleDbType.Varchar2).Value = fla == "" ? DBNull.Value : (object)fla; // Nếu chuỗi rỗng sẽ thay thế bằng Null
                cmd.Parameters.Add("PASSWORD_LIFE_TIME", OracleDbType.Varchar2).Value = plt == "" ? DBNull.Value : (object)plt;
                cmd.Parameters.Add("PASSWORD_REUSE_TIME", OracleDbType.Varchar2).Value = prt == "" ? DBNull.Value : (object)prt;
                cmd.Parameters.Add("PASSWORD_REUSE_MAX", OracleDbType.Varchar2).Value = prm == "" ? DBNull.Value : (object)prm;
                cmd.Parameters.Add("PASSWORD_LOCK_TIME", OracleDbType.Varchar2).Value = plte == "" ? DBNull.Value : (object)plte;
                cmd.Parameters.Add("PASSWORD_GRACE_TIME", OracleDbType.Varchar2).Value = pgt == "" ? DBNull.Value : (object)pgt;
                cmd.Parameters.Add("SESSIONS_PER_USER", OracleDbType.Varchar2).Value = spu == "" ? DBNull.Value : (object)spu;
                cmd.Parameters.Add("IDLE_TIME", OracleDbType.Varchar2).Value = idt == "" ? DBNull.Value : (object)idt;
                cmd.Parameters.Add("CONNECT_TIME", OracleDbType.Varchar2).Value = cnt == "" ? DBNull.Value : (object)cnt;
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region show_profile
        public List<string> Profile(string profile)
        {
            OracleConnection con = dbconnect.getDBConnection();
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "select resource_name, resource_type, LIMIT from dba_profiles Where Profile || resource_name LIKE '" + profile + "%' order by resource_type desc";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            List<string> temp = new List<string>();
            while (dr.Read())
            {
                for (int i = 0; i < 3; i++)
                {
                    //lấy thứ tự từng cột của 1 dòng (i là thứ tự cột bắt đầu từ 0 trong dr)
                    temp.Add(dr.GetValue(i).ToString());
                }
            }
            dr.Close();
            con.Close();
            return temp;
        }
        #endregion

        #region policy      
        public List<string> FGA_Policy()
        {
            OracleConnection con = dbconnect.getDBConnection();
            List<string> temp = new List<string>();
            try
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("select object_schema, object_name, policy_name, policy_column, enabled from dba_audit_policies", con);
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    for (int i = 0; i < 5; i++)
                    {
                        //lấy thứ tự từng cột của 1 dòng (i là thứ tự cột bắt đầu từ 0 trong dr)
                        temp.Add(dr.GetValue(i).ToString());
                    }
                }
                dr.Close();
                con.Close();
                return temp;
            }
            catch
            {
                con.Close();
                return temp;
            }
        }
        #endregion

        #region ban ghi audit FGA
        public List<string> history_audit(string policy_name)
        {
            List<string> temp = new List<string>();
            OracleConnection con = dbconnect.getDBConnection();
            try
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("sys.History_AuditFGA", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("policy_name", OracleDbType.Varchar2).Value = policy_name;
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    for (int i = 0; i < 6; i++)
                    {
                        //lấy thứ tự từng cột của 1 dòng (i là thứ tự cột bắt đầu từ 0 trong dr)
                        temp.Add(dr.GetValue(i).ToString());
                    }
                }
                dr.Close();
                con.Close();
                return temp;
            }
            catch
            {
                con.Close();
                return temp;
            }
        }
        #endregion

        #region delete policy
        public bool delete_Policy(string ob_name, string po_name)
        {
            try
            {
                OracleConnection con = dbconnect.getDBConnection();
                con.Open();
                OracleCommand cmd = new OracleCommand("xoa_FGA", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("object_name", OracleDbType.Varchar2).Value = ob_name;
                cmd.Parameters.Add("policy_name", OracleDbType.Varchar2).Value = po_name;
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region enable policy
        public bool enable_Policy(string ob_name, string po_name, string status)
        {
            try
            {
                OracleConnection con = dbconnect.getDBConnection();
                con.Open();
                OracleCommand cmd = new OracleCommand("sys.enable_FGA", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("object_name", OracleDbType.Varchar2).Value = ob_name;
                cmd.Parameters.Add("policy_name", OracleDbType.Varchar2).Value = po_name;
                cmd.Parameters.Add("status", OracleDbType.Varchar2).Value = status;
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region audit log        
        public List<string> audit_LOG()
        {
            OracleConnection con = dbconnect.getDBConnection();
            List<string> temp = new List<string>();
            try
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("select * from userQL.db_evnt_audit order by logon_date, logof_date", con);
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    for (int i = 0; i < 6; i++)
                    {
                        //lấy thứ tự từng cột của 1 dòng (i là thứ tự cột bắt đầu từ 0 trong dr)
                        temp.Add(dr.GetValue(i).ToString());
                    }
                }
                dr.Close();
                con.Close();
                return temp;
            }
            catch
            {
                con.Close();
                return temp;
            }
        }
        #endregion

        #region audit startup-shutdown   
        public List<string> audit_STR(string date)
        {
            OracleConnection con = dbconnect.getDBConnection();
            List<string> temp = new List<string>();
            try
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("select * from userQL.startup_audit where event_date LIKE '" + date + "%'", con);
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    for (int i = 0; i < 3; i++)
                    {
                        //lấy thứ tự từng cột của 1 dòng (i là thứ tự cột bắt đầu từ 0 trong dr)
                        temp.Add(dr.GetValue(i).ToString());
                    }
                }
                dr.Close();
                con.Close();
                return temp;
            }
            catch
            {
                con.Close();
                return temp;
            }
        }
        #endregion

        #region hoadon audit       
        public List<string> audit_HD(string date)
        {
            OracleConnection con = dbconnect.getDBConnection();
            List<string> temp = new List<string>();
            try
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("select * from userQL.audit_HoaDon Where date_stamp LIKE '" + date + "%'order by audit_id", con);
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    for (int i = 0; i < 22; i++)
                    {
                        //lấy thứ tự từng cột của 1 dòng (i là thứ tự cột bắt đầu từ 0 trong dr)
                        temp.Add(dr.GetValue(i).ToString());
                    }
                }
                dr.Close();
                con.Close();
                return temp;
            }
            catch
            {
                con.Close();
                return temp;
            }
        }
        #endregion

        #region alterpassuser
        public bool alterPassUser(string user, string old_pass, string new_pass)
        {
            try
            {
                OracleConnection con = dbconnect.getDBConnection();
                con.Open();
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = "alter user " + user.ToUpper() + " identified by " + new_pass + " replace " + old_pass + "";
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region ban ghi audit user
        public List<string> history_user()
        {
            List<string> temp = new List<string>();
            OracleConnection con = dbconnect.getDBConnection();
            try
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("sys.HisAudit_User", con);
                cmd.CommandType = CommandType.StoredProcedure;
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    for (int i = 0; i < 4; i++)
                    {
                        //lấy thứ tự từng cột của 1 dòng (i là thứ tự cột bắt đầu từ 0 trong dr)
                        temp.Add(dr.GetValue(i).ToString());
                    }
                }
                dr.Close();
                con.Close();
                return temp;
            }
            catch
            {
                con.Close();
                return temp;
            }
        }
        #endregion

        #region delete unified_audit_trail
        public bool delete_audit_trail()
        {
            try
            {
                OracleConnection con = dbconnect.getDBConnection();
                con.Open();
                OracleCommand cmd = new OracleCommand("dbms_audit_mgmt.clean_audit_trail(audit_trail_type=>dbms_audit_mgmt.audit_trail_unified,use_last_arch_timestamp=>FALSE)", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}
