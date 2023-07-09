using DoAn_PetShop.Property;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_PetShop.CSDL
{
    class CSDL_OrderEntrys
    {
        DbConnect dbcon = new DbConnect();
        OracleConnection con;
        OracleCommand cmd;
        OracleDataReader dr;
        public CSDL_OrderEntrys()
        {
            con = dbcon.getDBConnection();
        }
        #region method
        public List<OrderEntrys> searchOrderEntry(string txtsearch)
        {
            List<OrderEntrys> list = new List<OrderEntrys>();
            try
            {
                cmd = new OracleCommand("SELECT * FROM userQL.phieunhap WHERE lower(mapn) || lower(ngaynhap) || lower(manv) || lower(tennv) || lower(tongtien) LIKE '%" + txtsearch + "%'", con);
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    OrderEntrys ord = new OrderEntrys();
                    ord.mapn = dr.GetValue(0).ToString();
                    ord.ngaynhap = dr.GetValue(1).ToString();
                    ord.manv = dr.GetValue(2).ToString();
                    ord.tennv = dr.GetValue(3).ToString();
                    ord.tongtien = dr.GetValue(4).ToString();
                    list.Add(ord);
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

        public List<OrderEntrys> searchOrderEntryDetails(string mapn)
        {
            List<OrderEntrys> list = new List<OrderEntrys>();
            try
            {
                cmd = new OracleCommand("select * from userQL.ctphieunhap where mapn = '" + mapn + "'", con);
                con.Open();
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    OrderEntrys ord = new OrderEntrys();
                    ord.mapn = dr.GetValue(0).ToString();
                    ord.masp = dr.GetValue(1).ToString();
                    ord.tensp = dr.GetValue(2).ToString();
                    ord.soluong = dr.GetValue(3).ToString();
                    ord.gianhap = dr.GetValue(4).ToString();
                    ord.thanhtien = dr.GetValue(5).ToString();
                    list.Add(ord);
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

        #region get_masp   
        public string get_masp(string tensp)
        {
            string masp = "";
            try
            {
                cmd = new OracleCommand("select masp from userQL.sanpham where tensp = '" + tensp + "'", con);
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    for (int i = 0; i < 1; i++)
                    {
                        masp = dr.GetValue(0).ToString();
                    }
                }
                con.Close();
                return masp;
            }
            catch
            {
                con.Close();
                return masp;
            }
        }
        #endregion

        public List<string> LoadCBB()
        {
            List<string> list = new List<string>();
            try
            {
                cmd = new OracleCommand("select tensp from userQL.sanpham", con);
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

        public int countPN()
        {
            cmd = new OracleCommand("select count(*) from userQL.phieunhap", con);
            con.Open();
            int x = int.Parse(cmd.ExecuteScalar().ToString()) + 1;
            con.Close();
            return x;
        }
        public bool insertOder(string manv)
        {
            string tennv = getTenNV(manv);
            string mapn = "PN00" + countPN();
            cmd = new OracleCommand("Insert Into userQL.PhieuNhap(mapn,manv,tennv)Values('" + mapn + "', '" + manv + "', '" + tennv + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            commit();
            con.Close();
            return true;
        }
        public List<string> listMaNV()
        {
            List<string> list = new List<string>();
            cmd = new OracleCommand("select manv from userQL.NhanVien", con);
            con.Open();
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                list.Add(dr.GetValue(0).ToString());
            }
            con.Close();
            return list;
        }

        public string getTenNV(string manv)
        {
            string ma = "";
            try
            {
                cmd = new OracleCommand("select tennv from userQL.NhanVien where manv = '" + manv + "'", con);
                con.Open();
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ma = dr.GetValue(0).ToString();
                }
                con.Close();
                return ma;
            }
            catch
            {
                con.Close();
                return ma;
            }
        }

        public void commit()
        {
            cmd = new OracleCommand("commit", con);
            cmd.ExecuteNonQuery();
        }
        public bool insertOderDetails(string mapn, string masp, string tensp, string sl, string gianhap)
        {
            try
            {
                cmd = new OracleCommand("userQL.NhapCTPN", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("mapn", OracleDbType.Char).Value = mapn;
                cmd.Parameters.Add("masp", OracleDbType.Varchar2).Value = masp;
                cmd.Parameters.Add("tensp", OracleDbType.Varchar2).Value = tensp;
                cmd.Parameters.Add("soluong", OracleDbType.Varchar2).Value = sl;
                cmd.Parameters.Add("gianhap", OracleDbType.Varchar2).Value = gianhap;
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

        public bool updateProFileOder(string mapn, string manv)
        {
            try
            {
                string tennv = getTenNV(manv);
                cmd = new OracleCommand("update userQL.phieunhap set manv='" + manv + "', tennv = '" + tennv + "' where mapn='" + mapn + "'", con);
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

        public bool deleteOderEntry(string mapn)
        {
            try
            {
                cmd = new OracleCommand("delete from userQL.phieunhap where mapn='" + mapn + "'", con);
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

        public void deleteOderEntryDetail(string mapn, string masp)
        {
            cmd = new OracleCommand("delete from userQL.ctphieunhap where mapn='" + mapn + "' and masp='" + masp + "'", con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.ExecuteNonQuery();
            commit();

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        #endregion method
    }
}
