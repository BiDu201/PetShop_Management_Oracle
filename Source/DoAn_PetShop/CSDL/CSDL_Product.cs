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
    class CSDL_Product
    {
        DbConnect dbcon = new DbConnect();
        //static LoaiPet valueCbLoai = new LoaiPet();
        //static GiongPet valueCbGiong = new GiongPet();
        static List<Product> listProDuct = new List<Product>();
        //static List<LoaiPet> listLoaiPet = new List<LoaiPet>();
        //static List<GiongPet> listGiongPet = new List<GiongPet>();
        OracleConnection con;
        OracleCommand cmd;
        OracleDataReader dr;
        static string img = string.Empty;
        public CSDL_Product()
        {
            con = dbcon.getDBConnection();
        }
        #region đừng động vào
        //public List<LoaiPet> tenLoai()
        //{
        //    //List<LoaiPet> list = new List<LoaiPet>();
        //    //cmd = new OracleCommand("select * from LoaiPet", con);
        //    //con.Open();
        //    //dr = cm.ExecuteReader();
        //    //while (dr.Read())
        //    //{
        //    //    LoaiPet lp = new LoaiPet();
        //    //    lp.maLoai = dr.GetValue(0).ToString();
        //    //    lp.tenLoai = dr.GetValue(1).ToString();
        //    //    listLoaiPet.Add(lp);
        //    //    list.Add(lp);
        //    //}
        //    //dr.Close();
        //    //con.Close();
        //    //return list;
        //}
        //public List<GiongPet> tenGiong()
        //{
        //    List<GiongPet> list = new List<GiongPet>();
        //    cm = new OracleCommand("select * from GiongPet", con);
        //    con.Open();
        //    dr = cm.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        GiongPet gp = new GiongPet();
        //        gp.maGiong = dr.GetValue(0).ToString();
        //        gp.tenGiong = dr.GetValue(1).ToString();
        //        list.Add(gp);
        //        listGiongPet.Add(gp);
        //    }
        //    dr.Close();
        //    con.Close();
        //    return list;
        //}
        //public void getValue(string loai, string giong)
        //{
        //    listGiongPet.Clear();
        //    listLoaiPet.Clear();
        //    listGiongPet = tenGiong();
        //    listLoaiPet = tenLoai();
        //    valueCbGiong = listGiongPet.Find(x => x.tenGiong == giong);
        //    valueCbLoai = listLoaiPet.Find(x => x.tenLoai == loai);
        //}
        //public GiongPet returnValueGiong()
        //{
        //    return valueCbGiong;
        //}
        //public LoaiPet returnValueLoai()
        //{
        //    return valueCbLoai;
        //}
        #endregion
        public List<Product> searchProduct(string txtsearch)
        {
            List<Product> list = new List<Product>();
            try
            {
                con.Close();
                cmd = new OracleCommand("SELECT * FROM userQL.Sanpham WHERE lower(tensp) || lower(tengiong) || lower(tenloai) || lower(soluongton) || lower(gia) LIKE '%" + txtsearch + "%' order by masp", con);
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Product pro = new Product();
                    pro.maSP = dr.GetValue(0).ToString();
                    pro.tenSP = dr.GetValue(1).ToString();
                    pro.tenGiong = dr.GetValue(3).ToString();
                    pro.tenLoai = dr.GetValue(4).ToString();
                    pro.soLuongTon = dr.GetValue(5).ToString();
                    pro.giaBan = Convert.ToDouble(dr.GetValue(6).ToString());
                    listProDuct.Add(pro);
                    list.Add(pro);
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
        public bool addproduct(string ten, string img, string tengiong, string tenloai, double giaban)
        {
            try
            {
                string temp = layMaLast();
                string last = temp.Replace(" ", "");
                string last1 = last.Substring(2);
                string masp = string.Empty;
                if (int.Parse(last1) >= 10)
                {
                    masp = "SP0" + (int.Parse(last1) + 1);
                }
                else
                {
                    masp = "SP00" + (int.Parse(last1) + 1);
                }
                cmd = new OracleCommand("userQL.NhapSP", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("ma", OracleDbType.Char).Value = masp;
                cmd.Parameters.Add("ten", OracleDbType.Varchar2).Value = ten;
                cmd.Parameters.Add("giong", OracleDbType.Varchar2).Value = tengiong;
                cmd.Parameters.Add("loai", OracleDbType.Varchar2).Value = tenloai;
                cmd.Parameters.Add("tenimg", OracleDbType.Varchar2).Value = img;
                cmd.Parameters.Add("giaban", OracleDbType.Decimal).Value = giaban;
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
        public string layMaLast()
        {
            cmd = new OracleCommand("select masp from userQL.sanpham where ROWNUM=1 order by masp desc", con);
            con.Open();
            string ma = cmd.ExecuteScalar().ToString();
            con.Close();
            return ma;
        }
        public string getImg()
        {
            return img;
        }
        public void setImg(string n)
        {
            img = n;
        }
        public void chuyen_file_hinh_anh()
        {
            string sourceFile = getImg();
            string destinationFolder = @"C:\Users\Windows 7\Desktop\DoAn_Oracle\chuong_trinh_quanly_thucung\PETSHOP_IMAGES";
            // Xác định đường dẫn đầy đủ của tập tin đích
            string destinationFile = Path.Combine(destinationFolder, Path.GetFileName(sourceFile));
            if (!File.Exists(destinationFile))
            {
                File.Copy(sourceFile, destinationFile);
            }
            // Di chuyển tập tin từ thư mục nguồn đến thư mục đích

        }
        public void get_img_sanPham()
        {
            try
            {
                int i = 1;
                cmd = new OracleCommand("SELECT imgsp FROM userQL.sanpham order by masp", con);
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string nameimg = "SP00" + i + ".png";
                    string path = @"anhsp\" + nameimg;
                    string absolutePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
                    byte[] bytes = (byte[])dr.GetValue(0);
                    FileStream fs = new FileStream(absolutePath, FileMode.Create);
                    i++;
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Close();
                }
                con.Close();
            }
            catch
            {
                con.Close();
            }
        }
        public int countSP()
        {
            try
            {
                cmd = new OracleCommand("SELECT count(*) FROM userQL.sanpham", con);
                con.Open();
                int x = int.Parse(cmd.ExecuteScalar().ToString());
                con.Close();
                return x;
            }
            catch
            {
                return 0;
            }
        }
        public void checkfolder()
        {
            string folderPath = @"anhsp\";
            string[] files = Directory.GetFiles(folderPath, "*.png");
            if (files.Length < countSP())
            {
                foreach (string filePath in Directory.GetFiles(folderPath))
                {
                    File.Delete(filePath);
                }
                get_img_sanPham();
            }
            if (files.Length > countSP())
            {
                foreach (string filePath in Directory.GetFiles(folderPath))
                {
                    File.Delete(filePath);
                }
                get_img_sanPham();
            }
        }
        public bool editProfileProDuct(string masp, string tenSP, string tengiong, string tenloai, string soLuongTon, string giaBan)
        {
            try
            {
                //valueCbGiong = listGiongPet.Find(x => x.tenGiong == tengiong);
                //valueCbLoai = listLoaiPet.Find(x => x.tenLoai == tenLoai);
                cmd = new OracleCommand("UPDATE userQL.sanpham SET tensp = '" + tenSP + "',tengiong='" + tengiong + "',tenloai='" + tenloai + "', soluongton = " + soLuongTon + ", gia= " + giaBan + "WHERE masp = '" + masp + "'", con);
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
        public bool editIMGPro(string img, string masp)
        {
            try
            {
                // Đọc dữ liệu từ file ảnh
                byte[] imageBytes = File.ReadAllBytes(img);
                // Tạo đối tượng OracleCommand và thiết lập truy vấn SQL UPDATE để cập nhật cột BLOB
                cmd = new OracleCommand("UPDATE userQL.sanpham SET imgsp = :blobData WHERE masp = :id", con);
                con.Open();
                // Tạo đối tượng OracleParameter để chứa dữ liệu BLOB được cập nhật
                OracleParameter blobParam = new OracleParameter(":blobData", OracleDbType.Blob);
                blobParam.Value = imageBytes;

                // Thiết lập giá trị của tham số ID
                OracleParameter idParam = new OracleParameter(":id", OracleDbType.Char);
                idParam.Value = masp;

                // Thêm các tham số vào đối tượng OracleCommand
                cmd.Parameters.Add(blobParam);
                cmd.Parameters.Add(idParam);
                // Thực thi truy vấn SQL UPDATE để cập nhật cột BLOB
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
        #region ///
        //public bool insertProDuct(string tensp, string tengiong, string tenloai, string giaban)
        //{
        //    string masp = "SP00" + (listProDuct.Count + 1);
        //    try
        //    {
        //        cmd = new OracleCommand("", con);
        //        con.Open();
        //        cm.ExecuteNonQuery();
        //        con.Close();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        #endregion
        public void commit()
        {
            cmd = new OracleCommand("commit", con);
            cmd.ExecuteNonQuery();
        }
        public bool deletePro(string masp)
        {
            try
            {
                cmd = new OracleCommand("delete from userQL.sanpham where masp='" + masp + "'", con);
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
        public void delete_img()
        {
            string folderPath = @"anhsp\";
            string[] files = Directory.GetFiles(folderPath, "*.png");
            foreach (string filePath in Directory.GetFiles(folderPath))
            {
                File.Delete(filePath);
            }
        }

        public List<Product> loc_SanPham(int giadau, int giacuoi)
        {
            List<Product> list = new List<Product>();
            try
            {
                cmd = new OracleCommand("userQL.loc_SP_TheoGia", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("giadau", OracleDbType.Int32).Value = giadau;
                cmd.Parameters.Add("giacuoi", OracleDbType.Int32).Value = giacuoi;
                con.Open();
                //commit();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Product pro = new Product();
                    pro.maSP = dr.GetValue(0).ToString();
                    pro.tenSP = dr.GetValue(1).ToString();
                    pro.tenGiong = dr.GetValue(2).ToString();
                    pro.tenLoai = dr.GetValue(3).ToString();
                    pro.soLuongTon = dr.GetValue(4).ToString();
                    pro.giaBan = Convert.ToDouble(dr.GetValue(5).ToString());
                    listProDuct.Add(pro);
                    list.Add(pro);
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
    }
}
