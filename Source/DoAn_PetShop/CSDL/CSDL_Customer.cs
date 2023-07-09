using DoAn_PetShop.Property;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace DoAn_PetShop.CSDL
{

    class CSDL_Customer
    {
        DbConnect dbcon = new DbConnect();
        OracleConnection con;
        OracleCommand cmd;
        OracleDataReader dr;
        public CSDL_Customer()
        {
            con = dbcon.getDBConnection();
        }
        static List<Customer> listCus = new List<Customer>();
        public List<Customer> searchCustomer(string txtsearch)
        {

            List<Customer> list = new List<Customer>();
            try
            {
                cmd = new OracleCommand("userQL.searchCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("txtsearch", OracleDbType.Varchar2).Value = txtsearch;
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Customer cu = new Customer();
                    cu.makh = dr.GetValue(0).ToString();
                    cu.tenkh = dr.GetValue(1).ToString();
                    cu.diachi = dr.GetValue(2).ToString();
                    cu.sdt = dr.GetValue(3).ToString();
                    list.Add(cu);
                }
                dr.Close();
                con.Close();
                listCus = list;
                return list;
            }
            catch
            {
                con.Close();
                return list;
            }
        }
        public bool updateProFileCus(string makh, string tenkh, string diachi, string sdt)
        {
            try
            {
                cmd = new OracleCommand("UPDATE userQL.khachhang set tenkh='" + tenkh + "',dthoai='" + sdt + "',diachi='" + diachi + "' where makh='" + makh + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                commit();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool insertCus(string tenkh, string diachi, string sdt)
        {
            try
            {
                string temp = layMaLast();
                string last = temp.Replace(" ", "");
                string last1 = last.Substring(2);
                string makh = string.Empty;
                if (int.Parse(last1) >= 10)
                {
                    makh = "KH0" + (int.Parse(last1) + 1);
                }
                else
                {
                    makh = "KH00" + (int.Parse(last1) + 1);
                }
                cmd = new OracleCommand("Insert Into userQL.KhachHang Values('" + makh + "','" + tenkh + "','" + diachi + "','" + sdt + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteCustomer(string makh)
        {
            try
            {
                cmd = new OracleCommand("delete from userQL.KhachHang where makh='" + makh + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                commit();
                con.Close();
                return true;
            }
            catch
            {
                con.Close();
                return false;
            }
        }
        public void commit()
        {
            cmd = new OracleCommand("commit", con);
            cmd.ExecuteNonQuery();
        }
        public string layMaLast()
        {
            cmd = new OracleCommand("select makh from userQL.khachhang where ROWNUM=1 order by makh desc", con);
            con.Open();
            string ma = cmd.ExecuteScalar().ToString();
            con.Close();
            return ma;
        }
    }
}
