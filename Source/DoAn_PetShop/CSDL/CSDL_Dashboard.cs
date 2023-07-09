using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_PetShop.CSDL
{
    class CSDL_Dashboard
    {
        DbConnect dbcon = new DbConnect();
        CSDL_Login login = new CSDL_Login();
        OracleConnection con;
        OracleCommand cmd;
        public CSDL_Dashboard()
        {
            con = dbcon.getDBConnection();
        }
        // trả về tên của user đang đăng nhập
        public string getName()
        {
            return login.getName();
        }
        public string getRole()
        {
            return login.getRole();
        }
        public int ExtracData(string loaiSP)
        {
            try
            {
                cmd = con.CreateCommand();
                cmd.CommandText = "select nvl(SUM(soluongton),0) SL from userQL.sanpham where tenloai='" + loaiSP + "'";
                con.Open();
                int data = int.Parse(cmd.ExecuteScalar().ToString());
                con.Close();
                return data;
            }
            catch
            {
                con.Close();
                return 0;
            }
        }
    }
}
