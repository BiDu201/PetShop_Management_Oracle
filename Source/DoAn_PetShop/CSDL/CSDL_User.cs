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
    class CSDL_User
    {
        DbConnect dbcon = new DbConnect();
        OracleConnection con;
        OracleCommand cmd;
        OracleDataReader dr;
        static object valueSelectCb = new object();
        static int countListUser = 0;
        static string img = string.Empty;
        public CSDL_User()
        {
            con = dbcon.getDBConnection();
        }
        public void setvalueSelectCb(object n)
        {
            valueSelectCb = n;
        }
        public object getValueSelectCb()
        {
            return valueSelectCb;
        }
        public List<User> LoadUser(string txtSearch)
        {
            List<User> list = new List<User>();
            try
            {
                cmd = new OracleCommand("SELECT * FROM userQL.nhanvien WHERE lower(manv) ||lower(tennv) ||lower(dchi) || lower(dienthoai) || lower(chucvu) LIKE '%" + txtSearch + "%'order by manv", con);
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    User user = new User();
                    user.maND = dr.GetValue(0).ToString();
                    user.tenND = dr.GetValue(1).ToString();
                    user.diaChi = dr.GetValue(3).ToString();
                    user.sdt = dr.GetValue(4).ToString();
                    user.tenCV = dr.GetValue(5).ToString();
                    list.Add(user);
                    countListUser++;
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
        public void commit()
        {
            cmd = new OracleCommand("commit", con);
            cmd.ExecuteNonQuery();
        }
        public bool deleteUser(string maND)
        {
            try
            {
                cmd = new OracleCommand("delete from userQL.nhanvien where manv='" + maND + "'", con);
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
        public bool updateUser(string mand, string tennd, string dchi, string dienthoai, string chucvu)
        {
            try
            {
                cmd = new OracleCommand("update userQL.nhanvien set tennv='" + tennd + "',dchi='" + dchi + "',dienthoai='" + dienthoai + "',chucvu='" + chucvu + "' where manv='" + mand + "'", con);
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
        public bool updateIMG(string img, string manv)
        {
            try
            {
                // Đọc dữ liệu từ file ảnh
                byte[] imageBytes = File.ReadAllBytes(img);
                // Tạo đối tượng OracleCommand và thiết lập truy vấn SQL UPDATE để cập nhật cột BLOB
                cmd = new OracleCommand("UPDATE userQL.nhanvien SET imgnv = :blobData WHERE manv = :id", con);
                con.Open();
                // Tạo đối tượng OracleParameter để chứa dữ liệu BLOB được cập nhật
                OracleParameter blobParam = new OracleParameter(":blobData", OracleDbType.Blob);
                blobParam.Value = imageBytes;

                // Thiết lập giá trị của tham số ID
                OracleParameter idParam = new OracleParameter(":id", OracleDbType.Char);
                idParam.Value = manv;

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
                return false;
            }
        }
        public bool addUser(string tennd, string dchi, string dienthoai, string chucvu, string tenimg)
        {
            try
            {
                string temp = layMaLast();
                string last = temp.Replace(" ", "");
                string last1 = last.Substring(2);
                string manv = string.Empty;
                if (int.Parse(last1) >= 10)
                {
                    manv = "NV0" + (int.Parse(last1) + 1);
                }
                else
                {
                    manv = "NV00" + (int.Parse(last1) + 1);
                }
                cmd = new OracleCommand("userQL.NhapNV", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("ma", OracleDbType.Char).Value = manv;
                cmd.Parameters.Add("ten", OracleDbType.Varchar2).Value = tennd;
                cmd.Parameters.Add("dchi", OracleDbType.Varchar2).Value = dchi;
                cmd.Parameters.Add("dthoai", OracleDbType.Char).Value = dienthoai;
                cmd.Parameters.Add("cv", OracleDbType.Varchar2).Value = chucvu;
                cmd.Parameters.Add("tenimg", OracleDbType.Varchar2).Value = tenimg;
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
            cmd = new OracleCommand("select manv from userQL.nhanvien where ROWNUM=1 order by manv desc", con);
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
        public int countNV()
        {
            try
            {
                cmd = new OracleCommand("SELECT count(*) FROM userQL.nhanvien", con);
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
            string folderPath = @"anhnv\";
            string[] files = Directory.GetFiles(folderPath, "*.png");
            if (files.Length < countNV())
            {
                foreach (string filePath in Directory.GetFiles(folderPath))
                {
                    File.Delete(filePath);
                }
                get_img_nhanvien();
            }
            if (files.Length > countNV())
            {
                foreach (string filePath in Directory.GetFiles(folderPath))
                {
                    File.Delete(filePath);
                }
                get_img_nhanvien();
            }
        }
        public void delete_img(int number)
        {
            string nameimg = @"anhnv\nv00" + (number + 1) + ".png";
            string folderPath = @"anhnv\";
            string[] files = Directory.GetFiles(folderPath, "*.png");
            foreach (string filePath in Directory.GetFiles(folderPath))
            {
                if (nameimg.Equals(filePath))
                {
                    File.Delete(filePath);
                }
            }
        }
        public void get_img_nhanvien()
        {
            try
            {
                int i = 1;
                cmd = new OracleCommand("SELECT imgnv FROM userQL.nhanvien order by manv", con);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string nameimg = "nv00" + i + ".png";
                    string path = @"anhnv\" + nameimg;
                    string absolutePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
                    byte[] bytes = (byte[])dr.GetValue(0);
                    FileStream fs = new FileStream(absolutePath, FileMode.Create);
                    i++;
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch
            {
                con.Close();
            }
        }
    }
}
