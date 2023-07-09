using System;
using System.Collections.Generic;
using System.Linq;
using DoAn_PetShop.Property;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_PetShop.CSDL
{
    class CSDL_Billing
    {
        DbConnect dbcon = new DbConnect();
        static List<Billing> listBill = new List<Billing>();
        OracleConnection con;
        OracleCommand cmd;
        OracleDataReader dr;
        static string transo = "000000000000";
        public CSDL_Billing()
        {
            con = dbcon.getDBConnection();
        }
        public List<billingPro> LoadProduct(string txtSearch)
        {
            List<billingPro> list = new List<billingPro>();
            try
            {
                con.Close();
                cmd = new OracleCommand("SELECT masp, tensp, tengiong, tenloai, gia FROM userQL.SanPham WHERE CONCAT(CONCAT(tensp, tengiong), tenloai) LIKE '" + txtSearch + "%' AND soluongton > 0", con);
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    billingPro bp = new billingPro();
                    bp.maSP = dr.GetValue(0).ToString();
                    bp.tenSP = dr.GetValue(1).ToString();
                    bp.maGiong = dr.GetValue(2).ToString();
                    bp.maLoai = dr.GetValue(3).ToString();
                    bp.giaBan = Convert.ToDouble(dr.GetValue(4).ToString());
                    list.Add(bp);
                }
                dr.Close();
                con.Close();
                return list;
            }
            catch
            {
                return list;
            }
        }
        public string getTranso()
        {
            return transo;
        }
        public void Transo()
        {
            try
            {
                string sdate = DateTime.Now.ToString("yyyyMMdd");
                int count;
                string transno;
                cmd = new OracleCommand("SELECT transno FROM userQL.HoaDon WHERE transno LIKE '" + sdate + "%' ORDER BY mahd DESC fetch first 1 rows only", con);
                con.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    transno = dr[0].ToString();
                    count = int.Parse(transno.Substring(8, 4));
                    transo = sdate + (count + 1);
                }
                else
                {
                    transno = sdate + "1001";
                    transo = transno;
                }
                dr.Close();
                con.Close();
            }
            catch
            {
                con.Close();
            }
        }

        //Tăng transno hiện tại lên 1
        public void setTranso(string n)
        {
            transo = (long.Parse(n) + 1).ToString();
        }

        public void selectProDuct(string masp, string tensp, double gia, string thungan)
        {
            try
            {
                cmd = new OracleCommand("INSERT INTO userQL.HoaDon_View(transno, masp, tensp, soluong, gia,thungan) VALUES('" + transo + "','" + masp + "','" + tensp + "'," + 1 + "," + gia + ",'" + thungan + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                con.Close();
            }
        }
        public List<Billing> loadBilling()
        {
            List<Billing> list = new List<Billing>();
            try
            {
                cmd = new OracleCommand("userQL.ShowBill", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("transno", OracleDbType.Varchar2).Value = transo;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Billing b = new Billing();
                    b.mahd = dr.GetValue(0).ToString();
                    b.masp = dr.GetValue(1).ToString();
                    b.tensp = dr.GetValue(2).ToString();
                    b.soluong = Convert.ToInt32(dr.GetValue(3).ToString());
                    b.gia = Convert.ToDouble(dr.GetValue(4).ToString());
                    b.thanhtien = Convert.ToDouble(dr.GetValue(5).ToString());
                    b.tenkh = dr.GetValue(6).ToString();
                    b.thungan = dr.GetValue(7).ToString();
                    list.Add(b);
                }
                dr.Close();
                con.Close();
                return list;
            }
            catch
            {
                return list;
            }
        }
        public List<Customer> loadCus(string txtsearch)
        {
            List<Customer> list = new List<Customer>();
            try
            {
                cmd = new OracleCommand("SELECT makh,tenkh,dthoai FROM userQL.KhachHang WHERE tenkh LIKE '%" + txtsearch + "%'", con);
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Customer cus = new Customer();
                    cus.makh = dr.GetValue(0).ToString();
                    cus.tenkh = dr.GetValue(1).ToString();
                    cus.sdt = dr.GetValue(2).ToString();
                    list.Add(cus);
                }
                dr.Close();
                con.Close();
                return list;
            }
            catch
            {
                con.Close();
                return list;
            }
        }
        public void selectCustomer(string makh, string tenkh)
        {
            cmd = new OracleCommand("UPDATE userQL.HoaDon SET makh= '" + makh + "', tenkh = '" + tenkh + "' WHERE transno='" + transo + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void deleteProFrBill(string mahd)
        {
            cmd = new OracleCommand("DELETE FROM userQL.HoaDon WHERE mahd LIKE '" + mahd + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public int checkPqty(string pcode)
        {
            int i = 0;
            cmd = new OracleCommand("SELECT soluongton FROM userQL.SanPham WHERE masp LIKE '" + pcode + "'", con);
            con.Open();
            i = int.Parse(cmd.ExecuteScalar().ToString());
            con.Close();
            return i;
        }
        public void updateQtyPro(string mahd)
        {

            cmd = new OracleCommand("UPDATE userQL.HoaDon SET soluong = soluong + 1 WHERE mahd LIKE " + mahd + "", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void decreaseQtyPro(string mahd)
        {
            cmd = new OracleCommand("UPDATE userQL.HoaDon SET soluong = soluong - 1 WHERE mahd LIKE " + mahd + "", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void UpdateSLT(int sl, string masp)
        {
            con.Open();
            cmd = new OracleCommand("UPDATE userQL.SanPham SET soluongton = soluongton -" + sl + " WHERE masp LIKE '" + masp + "' ", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<Billing> searchBill(string txtsearch)
        {
            List<Billing> list = new List<Billing>();
            try
            {
                con.Close();
                cmd = new OracleCommand("userQL.searchBill", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("txtsearch", OracleDbType.Varchar2).Value = txtsearch;
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Billing bill = new Billing();
                    bill.mahd = dr.GetValue(0).ToString();
                    bill.transno = dr.GetValue(1).ToString();
                    bill.masp = dr.GetValue(2).ToString();
                    bill.tensp = dr.GetValue(3).ToString();
                    bill.soluong = Convert.ToInt32(dr.GetValue(4).ToString());
                    bill.gia = Convert.ToDouble(dr.GetValue(5).ToString());
                    bill.thanhtien = Convert.ToDouble(dr.GetValue(6).ToString());
                    bill.makh = dr.GetValue(7).ToString();
                    bill.tenkh = dr.GetValue(8).ToString();
                    bill.thungan = dr.GetValue(9).ToString();
                    listBill.Add(bill);
                    list.Add(bill);
                }
                dr.Close();
                con.Close();
                return list;
            }
            catch
            {
                return list;
            }
        }

        // Lấy năm từ transno lên combobox
        public List<string> LoadCBB()
        {
            List<string> list = new List<string>();
            try
            {
                cmd = new OracleCommand("select distinct substr(transno,1,4) from userQL.HoaDon", con);
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    for (int i = 0; i < 1; i++)
                    {
                        list.Add(dr.GetValue(0).ToString());
                    }
                }
                con.Close();
                return list;
            }
            catch
            {
                con.Close();
                return list;
            }
        }

        public void deleteBill(string transno)
        {
            cmd = new OracleCommand("DELETE FROM userQL.HoaDon WHERE transno LIKE '%" + transno + "%'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
