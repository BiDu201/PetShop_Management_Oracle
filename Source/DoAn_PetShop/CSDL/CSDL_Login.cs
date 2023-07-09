using DoAn_PetShop.CSDL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_PetShop
{
    class CSDL_Login
    {
        OracleDataReader dr;
        DbConnect dbcon = new DbConnect();
        static string[] listSession;
        private static string name { get; set; }
        private static string role { get; set; }
        //private static string 
        public string getName()
        {
            return name;
        }
        public void setName(string n)
        {
            name = n;
        }
        public string getRole()
        {
            return role;
        }
        public void setRole(string r)
        {
            role = r;
        }

        private OracleConnection GetDBConnection(string username, string password)
        {
            return dbcon.GetDBConnection(username, password);
        }
        public bool connectDBSys(string username, string password)
        {
            OracleConnection conn = dbcon.GetDBConnectionSys(username, password);
            StreamWriter sw = new StreamWriter(@"sys.txt");
            sw.WriteLine(conn.ConnectionString);
            sw.Close();
            try
            {
                conn.Open();
                setName(username);
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool connectDB(string username, string password)
        {
            OracleConnection conn = GetDBConnection(username, password);
            try
            {
                conn.Open();
                setName(username);
                listSession = new string[10];
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string getLastLogin()
        {
            OracleConnection conn = dbcon.connectionSYS();
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT username, logon_time FROM v$session WHERE type = 'USER' AND Program = 'DoAn_PetShop.exe' ORDER BY logon_time DESC FETCH FIRST 1 ROWS ONLY";
            cmd.CommandType = System.Data.CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            dr.Read();
            string result = dr.GetValue(0).ToString() + "\t";
            result += dr.GetValue(1).ToString();
            dr.Close();
            conn.Close();
            conn.Dispose();
            return result;
        }
        #region chưa cần tới
        public string getSIDSerial()
        {
            OracleConnection con = dbcon.getDBConnection();
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "select sid,serial# from v$session where type != 'BACKGROUND'and  program = 'DoAn_PetShop.exe' and username='" + name.ToUpper() + "'";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            string temp = string.Empty;
            dr.Read();
            temp = dr.GetValue(0).ToString() + " ";
            temp += dr.GetValue(1).ToString();
            dr.Close();
            con.Close();
            return temp;
        }
        public void logOut()
        {
            string temp = getSIDSerial();
            string[] s = temp.Split(' ');
            OracleConnection con = dbcon.getDBConnection();
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "ALTER SYSTEM KILL SESSION '" + s[0] + "," + s[1] + "'";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        #endregion
        #region lấy quyền của username
        public void getDefaultTableSpace()
        {
            OracleConnection conn = dbcon.connectionSYS();
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select default_tablespace from dba_users where username='" + name.ToUpper() + "'";
            cmd.CommandType = CommandType.Text;
            role = cmd.ExecuteScalar().ToString();
            conn.Close();
            conn.Dispose();
        }
        #endregion
        public bool checkNgayHetHan(string username)
        {
            OracleConnection conn = dbcon.connectionSYS();
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("SELECT TRUNC(EXPIRY_DATE) - TRUNC(SYSDATE) AS remaining_days FROM DBA_USERS WHERE USERNAME = '" + username.ToUpper() + "'", conn);
                if (int.Parse(cmd.ExecuteScalar().ToString()) > 0)
                {
                    conn.Close();
                    conn.Dispose();
                    return true;
                }
                conn.Close();
                conn.Dispose();
                return false;
            }
            catch
            {
                conn.Close();
                conn.Dispose();
                return false;
            }
        }
    }
}
