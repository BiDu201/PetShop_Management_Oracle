using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_PetShop.CSDL
{
    class DbConnect
    {
        private static string connString;
        public OracleConnection GetDBConnection(String username, String password)
        {
            connString = @"DATA SOURCE = localhost:1521/dtb; USER ID=" + username + ";PASSWORD=" + password + "";
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = connString;
            return conn;
        }
        public OracleConnection GetDBConnectionSys(String username, String password)
        {
            connString = @"DATA SOURCE = localhost:1521/dtb; USER ID=" + username + ";PASSWORD=" + password + ";DBA Privilege=SYSDBA";
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = connString;
            return conn;
        }
        public OracleConnection getDBConnection()
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = connString;
            return conn;
        }
        public OracleConnection connectionSYS()
        {
            StreamReader sr = new StreamReader(@"sys.txt");
            string conn = sr.ReadLine();
            sr.Close();
            OracleConnection con1 = new OracleConnection(conn);
            return con1;
        }
        public List<string> ListSessionKilled()
        {
            List<string> temp = new List<string>();
            OracleConnection con = connectionSYS();
            OracleCommand cmd = new OracleCommand("SELECT USERNAME FROM V$SESSION WHERE STATUS = 'KILLED'", con);
            con.Open();
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                temp.Add(dr.GetValue(0).ToString());
            }
            dr.Close();
            con.Close();
            con.Dispose();
            return temp;
        }
        public bool checkListSessionKilled()
        {
            List<string> temp = ListSessionKilled();
            CSDL_Login login = new CSDL_Login();
            foreach (string item in temp)
            {
                if (item.Equals(login.getName().ToUpper()))
                {
                    connString = "";
                    return true;
                }
            }
            return false;
        }
    }
}
