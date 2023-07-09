/* *******************************************************BUOC 2********************************************************* */

CREATE TABLE KhachHang
(
    makh CHAR(10),
    tenkh VARCHAR2 (50) NOT NULL,
    diachi VARCHAR2(50),
    dthoai CHAR (12),
    CONSTRAINT PK_KhachHang PRIMARY KEY (makh)
);

CREATE TABLE NhanVien
(
    manv CHAR(10),
    tennv VARCHAR2 (50) NOT NULL,
    imgnv BLOB, /*?nh nh�n vi�n*/
    dchi VARCHAR2 (50),
    dienthoai CHAR (13),
    chucvu VARCHAR2 (20),
    CONSTRAINT PK_NhanVien PRIMARY KEY (manv)
);

CREATE TABLE PhieuNhap
(
	mapn CHAR(10),
	ngaynhap DATE DEFAULT CURRENT_DATE,
	manv CHAR(10),
    tennv VARCHAR2(50) NOT NULL,
	tongtien FLOAT DEFAULT 0,
	CONSTRAINT PK_PhieuNhap PRIMARY KEY (mapn),
	Constraint FK_PhieuNhap_NhanVien Foreign Key (manv) References NhanVien(manv)
);

CREATE TABLE SanPham
(
    masp CHAR(10),
    tensp VARCHAR2 (50) NOT NULL,
    imgsp BLOB, /*?nh s?n ph?m*/
    tengiong VARCHAR2 (50) NOT NULL,
    tenloai VARCHAR2 (50) NOT NULL,
    soluongton NUMBER DEFAULT 0,
	gia FLOAT,
    CONSTRAINT PK_SanPham PRIMARY KEY (masp)
);

CREATE TABLE loc_SanPham
(
    masp CHAR(10),
    tensp VARCHAR2 (50),
    imgsp BLOB, 
    tengiong VARCHAR2 (50),
    tenloai VARCHAR2 (50),
    soluongton NUMBER,
	gia FLOAT
);

CREATE TABLE CTPhieuNhap
(
	mapn CHAR(10),
	masp CHAR(10),
    tensp VARCHAR2(50) NOT NULL,
	soluong NUMBER NOT NULL,
	gianhap FLOAT NOT NULL,
	thanhtien FLOAT DEFAULT 0,
	Constraint PK_ChiTietPN Primary Key (mapn,masp),
	Constraint FK_CTPN_PhieuNhap Foreign Key (mapn) References PhieuNhap(mapn),
	Constraint FK_CTPN_SanPham Foreign Key (masp) References SanPham(masp)
);

CREATE TABLE HoaDon
(
	mahd NUMBER, /*Tang tu dong +1*/
	transno VARCHAR(15) NOT NULL,
	masp CHAR(10),
    tensp VARCHAR2(50),
	soluong NUMBER,
	gia FLOAT,
	thanhtien FLOAT DEFAULT 0,
	makh CHAR(10),
    tenkh VARCHAR(50),
	thungan VARCHAR(20),
	CONSTRAINT PK_HoaDon PRIMARY KEY (mahd),
	CONSTRAINT FK_HoaDon_KhachHang Foreign Key (makh) References KhachHang(makh),
	CONSTRAINT FK_HoaDon_SanPham Foreign Key (masp) References SanPham(masp)
);

--Sequence tu dong tang mahd tren bang HoaDon
CREATE SEQUENCE AUTO_INCREMENT_HOADON
    INCREMENT BY 1
    MINVALUE 1
    MAXVALUE 1000000000 --Toi da 1 ty
    NOCYCLE;
/

--Table ghi nhan du lieu them, xoa, sua cua bang HoaDon
CREATE TABLE audit_HoaDon
(
      audit_id         NUMBER GENERATED BY DEFAULT AS IDENTITY PRIMARY KEY,
      table_name       VARCHAR2(255),
      operation        VARCHAR2(10),
      user_name        VARCHAR2(30),
      date_stamp       VARCHAR2(30),
      time_stamp       VARCHAR2(30),
      transno          VARCHAR2(15),
      masp_old         CHAR(10),
      masp_new         CHAR(10),
      tensp_old        VARCHAR2(50),
      tensp_new        VARCHAR2(50),
      soluong_old      NUMBER,
      soluong_new      NUMBER,
      gia_old          FLOAT,
      gia_new          FLOAT,
      thanhtien_old    FLOAT,
      thanhtien_new    FLOAT,
      makh_old         CHAR(10),
      makh_new         CHAR(10),
      tenkh_old        VARCHAR2(50),
      tenkh_new        VARCHAR2(50),
      thungan          VARCHAR2(20)
);
/
 --Bang View chua thong tin nhu bang hoadon
CREATE OR REPLACE VIEW HoaDon_View AS
    Select * From userQL.HoaDon;
/

--Table ghi lai su kien LOGOFF v� LOGON user
CREATE TABLE db_evnt_audit
(
    User_name VARCHAR2(15),
    event_type VARCHAR2(30),
    logon_date DATE,
    logon_time VARCHAR2(15),
    logof_date DATE,
    logof_time VARCHAR2(15)
);

--Table ghi lai su kien startup & shutdown
CREATE TABLE startup_audit 
(
  Event_type  VARCHAR2(15),
  event_date  VARCHAR2(40),
  event_time  VARCHAR2(15)
);

--Drop Table HoaDon;
--Drop Table CTPhieuNhap;
--Drop Table SanPham;
--Drop Table PhieuNhap;
--Drop Table NhanVien;
--Drop Table KhachHang;
--Drop Table HoaDon;
--Drop View HoaDon_View;
--Drop Table audit_HoaDon;
--Drop sequence AUTO_INCREMENT_HOADON;
--Drop table db_evnt_audit;
--Drop table startup_audit ;
--Drop table loc_SanPham;

--Xoa tata ca du lieu trong bang
--Delete From HoaDon;
--Delete From CTPhieuNhap;
--Delete From SanPham;
--Delete From PhieuNhap;
--Delete From NhanVien;
--Delete From KhachHang;
--Delete From HoaDon_View;
--Delete From audit_HoaDon;
--Delete From db_evnt_audit;
--Delete From startup_audit;

----------------------------------------------------------PROCEDURE-------------------------------------------------------------
/*Procedure nhap NhanVien*/
Create or replace procedure NhapNV(ma in CHAR, ten in NVARCHAR2, dchi in NVARCHAR2, dthoai in CHAR, cv in NVARCHAR2, tenimg NVARCHAR2)
is
Begin
    DECLARE
        l_bfile BFILE;
        l_blob BLOB;
        l_dest_offset INTEGER := 1;
        l_src_offset INTEGER := 1;
        l_lobmaxsize CONSTANT INTEGER := DBMS_LOB.LOBMAXSIZE;
    BEGIN
        Insert Into userQL.NhanVien
        Values(ma,ten,empty_blob(),dchi,dthoai,cv)
        RETURN imgnv INTO l_blob;
        
        l_bfile := BFILENAME('PETSHOP_IMAGES', tenimg);
        
        DBMS_LOB.fileopen(l_bfile, DBMS_LOB.file_readonly);
        
        DBMS_LOB. loadblobfromfile (l_blob, l_bfile, l_lobmaxsize, l_dest_offset, l_src_offset);
        
        DBMS_LOB.fileclose(l_bfile);
            
        COMMIT;
    END;
END;
/

/*Procedure nhap SanPham*/
Create or replace procedure NhapSP(ma in CHAR, ten in NVARCHAR2, giong in NVARCHAR2, loai in NVARCHAR2, tenimg in nvarchar2, gia in DECIMAL)
is
Begin
    DECLARE
        l_bfile BFILE;
        l_blob BLOB;
        l_dest_offset INTEGER := 1;
        l_src_offset INTEGER := 1;
        l_lobmaxsize CONSTANT INTEGER := DBMS_LOB.LOBMAXSIZE;
    BEGIN
        Insert Into userQL.SanPham(masp,tensp,imgsp,tengiong,tenloai,gia)
        Values(ma,ten,empty_blob(),giong,loai,gia)
        RETURN imgsp INTO l_blob;
        
        l_bfile := BFILENAME('PETSHOP_IMAGES', tenimg);
        
        DBMS_LOB.fileopen(l_bfile, DBMS_LOB.file_readonly);
        
        DBMS_LOB. loadblobfromfile (l_blob, l_bfile, l_lobmaxsize, l_dest_offset, l_src_offset);
        
        DBMS_LOB.fileclose(l_bfile);
             
        COMMIT;
    END;
END;
/

--Procedure nhap CTPhieuNhap
CREATE OR REPLACE PROCEDURE NhapCTPN (
   p_mapn IN CTPhieuNhap.mapn%TYPE,
   p_masp IN CTPhieuNhap.masp%TYPE,
   p_tensp IN SanPham.tensp%TYPE,
   p_soluong IN CTPhieuNhap.soluong%TYPE,
   p_gianhap IN CTPhieuNhap.gianhap%TYPE
)
IS
   v_thanhtien CTPhieuNhap.thanhtien%TYPE;
BEGIN
   BEGIN
   COMMIT;
      --SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
      -- Bat dau transaction
      SAVEPOINT sv1;
      IF(p_soluong <= 0 or p_gianhap < 0) THEN 
        ROLLBACK to sv1;
        RAISE_APPLICATION_ERROR(-20000, 'Lenh da duoc rollback, do co loi xay ra');
      ELSE
          -- T�nh gi� tri thanh tien cho chi tiet phieu nhap moi
          v_thanhtien := p_soluong * p_gianhap;
          
          --Nhap moi 1 dong vao bang CTPhieuNhap
          Insert Into CTPhieuNhap
          Values(p_mapn,p_masp,p_tensp,p_soluong,p_gianhap,v_thanhtien);
        
          -- Cap nhat so luong ton cua san pham trong kho
          UPDATE SanPham SET soluongton = soluongton + p_soluong WHERE masp = p_masp;
          -- T�nh tong gi� tri nhap hang cua phieu nhap v� cap nhat lai tr�n bang PhieuNhap
          UPDATE PhieuNhap SET tongtien = tongtien + v_thanhtien WHERE mapn = p_mapn;
          -- Ket th�c transaction v� commit thay doi
          COMMIT;
      END IF;
   EXCEPTION
      -- Neu xay ra loi trong qu� tr�nh thuc hien transaction th� rollback
      WHEN OTHERS THEN       
         ROLLBACK to savepoint sv1;
         RAISE_APPLICATION_ERROR(-20000, 'Lenh da duoc rollback, do co loi xay ra');
   END;
END;
/

--Procedure xem thong tin bang KhachHang
create or replace PROCEDURE searchCustomer(txtsearch in varchar2)
as
    c1 SYS_REFCURSOR;
BEGIN
    open c1 for SELECT * FROM userQL.KhachHang WHERE lower(tenkh) || lower(diachi) || lower(dthoai) LIKE '%'||txtsearch||'%'order by makh;
    dbms_sql.return_result(c1);
end;
/

--Procedure update KhachHang
create or replace PROCEDURE updateCustomer(MAKH in varchar2,TENKH in varchar2,DIACHI in varchar2,SDT in varchar2)
as
BEGIN
    UPDATE userQL.khachhang set tenkh=TENKH,dthoai=SDT,diachi=DIACHI where makh=MAKH;
end;
/

-- Procedure xuat, tim kiem hoa don sau khi da duoc thanh toan
create or replace procedure searchBill(txtsearch in VARCHAR2)
as
    c1 SYS_REFCURSOR;
begin
    open c1 for SELECT * 
    FROM userQL.HoaDon
    WHERE transno || tensp || gia || thanhtien || tenkh || thungan LIKE '%'||searchBill.txtsearch||'%' 
    order by transno;
    
    dbms_sql.return_result(c1);
end;
/

--Procedure hien thi thong tin HoaDon
CREATE OR REPLACE PROCEDURE ShowBill (transno_t VARCHAR2)
AS
    s_makh CHAR(10);
    c1 SYS_REFCURSOR;
BEGIN
		OPEN c1 for SELECT DISTINCT mahd, masp, tensp, soluong, gia, thanhtien, NULL as tenkh ,thungan
		FROM userQL.HoaDon
        Where transno = transno_t;
        
        dbms_sql.return_result(c1);
END;
/

--drop procedure NHAPNV;
--drop procedure NHAPSP;
--drop procedure NHAPCTPN;
--drop procedure SEARCHCUSTOMER;
--drop procedure SHOWBILL;
--drop procedure SEARCHBILL;
--drop procedure UPDATECUSTOMER;

---------------------------------------------------------TRIGGER----------------------------------------------------------------
--Trigger kich hoat sequence tu dong tang tren bang HoaDon cho cot mahd
CREATE OR REPLACE TRIGGER AUTO_INCREMENT_TRIGGER
BEFORE INSERT ON HoaDon
REFERENCING NEW AS NEW
    FOR EACH ROW BEGIN
    SELECT AUTO_INCREMENT_HOADON.NEXTVAL INTO :NEW.mahd
    FROM DUAL;
END;
/

--Trigger tu dong ghi lai thong tin insert, update, delete tren bang HoaDon
CREATE OR REPLACE TRIGGER HoaDon_Trigger
        AFTER 
        INSERT OR UPDATE OR DELETE 
        ON HoaDon
        FOR EACH ROW
    DECLARE
       T_DML VARCHAR2(10);
    BEGIN
       -- Loai hanh dong DML
       T_DML := CASE  
             WHEN INSERTING THEN 'INSERT'
             WHEN UPDATING THEN 'UPDATE'
             WHEN DELETING THEN 'DELETE'
       END;

       -- Them 1 dong vao bang audit_CTPhieuNhap
       IF INSERTING THEN
           INSERT INTO audit_HoaDon (table_name, operation, user_name, date_stamp, time_stamp, transno, masp_old, masp_new, tensp_old, tensp_new, soluong_old, soluong_new, gia_old, gia_new, thanhtien_old, thanhtien_new, makh_old, makh_new, tenkh_old, tenkh_new, thungan)
           VALUES('HoaDon', T_DML, USER, TO_CHAR(SYSDATE,'DD/MM/YYYY'), TO_CHAR(sysdate, 'hh24:mi:ss'), :NEW.transno, :OLD.masp, :NEW.masp, :OLD.tensp, :NEW.tensp, :OLD.soluong, :NEW.soluong, :OLD.gia, :NEW.gia, :OLD.thanhtien, :NEW.thanhtien, :OLD.makh, :NEW.makh, :OLD.tenkh, :NEW.tenkh, :NEW.thungan);
       ELSIF UPDATING OR DELETING THEN
           INSERT INTO audit_HoaDon (table_name, operation, user_name, date_stamp, time_stamp, transno, masp_old, masp_new, tensp_old, tensp_new, soluong_old, soluong_new, gia_old, gia_new, thanhtien_old, thanhtien_new, makh_old, makh_new, tenkh_old, tenkh_new, thungan)
           VALUES('HoaDon', T_DML, USER, TO_CHAR(SYSDATE,'DD/MM/YYYY'), TO_CHAR(sysdate, 'hh24:mi:ss'), :OLD.transno, :OLD.masp, :NEW.masp, :OLD.tensp, :NEW.tensp, :OLD.soluong, :NEW.soluong, :OLD.gia, :NEW.gia, :OLD.thanhtien, :NEW.thanhtien, :OLD.makh, :NEW.makh, :OLD.tenkh, :NEW.tenkh, :OLD.thungan);

        END IF;
    END;
/

--Trigger tu dong tinh thanhtien khi nhap va update bang HoaDon
CREATE OR REPLACE TRIGGER thanhtien_hoadon
    BEFORE 
    INSERT OR UPDATE OF SoLuong, Gia
    ON HoaDon
    FOR EACH ROW
BEGIN       
    IF(:NEW.SoLuong <= 0) THEN Raise_application_error(-20326,'Soluong phai lon hon 0'); --Bao loi khi so luong nhap vao hoac update <= 0
    ELSE
        :NEW.ThanhTien := :NEW.SoLuong*:NEW.Gia;    
    END IF;
END;
/

--Trigger update soluong cua nhung hoa don giong nhau
CREATE OR REPLACE TRIGGER UpdateSL_Same
INSTEAD OF INSERT ON HoaDon_View FOR EACH ROW
DECLARE
    c_masp NUMBER;
BEGIN	
        Select Count(*) INTO c_masp From userQL.HoaDon Where masp = :NEW.masp and transno = :NEW.transno;
        IF c_masp = 0 THEN --Neu khong co dong nao thi insert vao bang HoaDon
            INSERT INTO userQL.HoaDon(transno, masp, tensp, soluong, gia, makh, tenkh, thungan) VALUES(:NEW.transno, :NEW.masp, :NEW.tensp, :NEW.soluong, :NEW.gia, :NEW.makh, :NEW.tenkh, :NEW.thungan);            
        ELSE --Neu da co 1 dong, thi se update soluong cua dong do + voi soluong dong moi
            UPDATE userQL.HoaDon
            Set soluong = soluong + :NEW.soluong
            Where masp = :NEW.masp and transno = :NEW.transno;
        END IF;       
END;
/

-- Trigger xoa nhanvien
CREATE OR REPLACE TRIGGER delete_nhanvien
BEFORE DELETE ON NHANVIEN
FOR EACH ROW
BEGIN
    Update userQL.PhieuNhap set manv = null where manv = :OLD.manv;
END;
/

-- Trigger xoa khachhang
CREATE OR REPLACE TRIGGER delete_khachhang
BEFORE DELETE ON KHACHHANG
FOR EACH ROW
BEGIN
    Update userQL.HoaDon set makh = null where makh = :OLD.makh;
END;
/

--Trigger xoa sanpham
CREATE OR REPLACE TRIGGER delete_sanpham
BEFORE DELETE ON SANPHAM
FOR EACH ROW
BEGIN
    Delete From CTPhieuNhap Where masp = :OLD.masp;
    
    Update userQL.HoaDon set masp = null where masp = :OLD.masp;
END;
/

--Trigger cap nhat lai tong tien cua phieu nhap khi xoa ctphieunhap
CREATE OR REPLACE TRIGGER updatePN_delCTPN
AFTER DELETE ON CTPHIEUNHAP
FOR EACH ROW
BEGIN
    Update PhieuNhap Set tongtien = tongtien - (:OLD.SoLuong*:OLD.GiaNhap) Where PhieuNhap.mapn = :OLD.mapn;
END;
/

--Drop trigger AUTO_INCREMENT_TRIGGER;
--Drop trigger CTPHIEUNHAP_TRIGGER;
--Drop trigger THANHTIEN_HOADON;
--Drop trigger UPDATESL_SAME;
--Drop trigger delete_nhanvien;
--Drop trigger delete_sanpham;

-------------------------------------------------------CURSOR-------------------------------------------------------------------
/* Cursor tuong minh co tham so loc san pham theo gia */
CREATE OR REPLACE PROCEDURE loc_SP_TheoGia(gia_dau NUMBER, gia_sau NUMBER)
AS
    r_sanpham userQL.SanPham%rowtype;
    c1 SYS_REFCURSOR;
    CURSOR c_sanpham (giadau NUMBER, giasau NUMBER)
    IS
        SELECT *
        FROM userQL.SanPham
        WHERE Gia BETWEEN giadau AND giasau;
BEGIN
   delete from userQL.loc_SanPham; -- Lam moi bang
   commit;
   
    OPEN c_sanpham(gia_dau, gia_sau);
    LOOP
        FETCH c_sanpham INTO r_sanpham;
        EXIT WHEN c_sanpham%notfound;
        
        INSERT INTO userQL.loc_SanPham VALUES( r_sanpham.masp,r_sanpham.tensp,r_sanpham.imgsp,r_sanpham.tengiong,r_sanpham.tenloai,r_sanpham.soluongton,r_sanpham.gia );
    END LOOP;
    CLOSE c_sanpham;
    
   OPEN c1 for SELECT masp,tensp,tengiong,tenloai,soluongton,gia
		FROM userQL.loc_SanPham;
        
        dbms_sql.return_result(c1);
        commit;
END;
/

--Drop procedure loc_SP_TheoGia;

----Con tro ngam dinh
----Cap nhat Gia len 50000 cho giong cho tay
--Set SERVEROUTPUT ON;
--DECLARE
--total_rows number(2);
--BEGIN
--UPDATE userQL.SanPham
--SET Gia = Gia + 50000
--where tengiong = N'Ch� t�y';
--IF sql%notfound THEN
--    dbms_output.put_line('Kh�ng c� th� c?ng n�y');
--ELSIF sql%found THEN
--    total_rows := sql%rowcount;
--    dbms_output.put_line( total_rows || ' SanPham updated ');
--END IF;
--END;
--

----Cursor For Update and Where current of
--CREATE OR REPLACE Procedure UpPr( tengiong IN varchar2 )
--   RETURN number
--IS
--   cnumber number;
--
--   CURSOR Update_Gia_ChoTay
--   IS
--     SELECT TenSP
--     FROM userQL.SanPham
--     WHERE TenGiong = tengiong
--     FOR UPDATE of gia;
--
--BEGIN
--
--   OPEN Update_Gia_ChoTay;
--   FETCH Update_Gia_ChoTay INTO cnumber;
--
--   if Update_Gia_ChoTay%notfound then
--      cnumber := 999;
--
--   else
--      UPDATE userQL.SanPham
--      SET Gia = Gia + 50000
--      WHERE CURRENT OF Update_Gia_ChoTay;
--
--      cnumber := 0;
--      COMMIT;
--
--   end if;
--
--   CLOSE Update_Gia_ChoTay;
--
--RETURN cnumber;
--
--END;
--
------Goi ham
--DECLARE   
--   pr number(2);    
--BEGIN   
--   pr := UpPr('Ch� t�y');     
--END;
-------------------------------------------------------Nhap Lieu----------------------------------------------------------------
/*Nhap khach hang*/
Insert Into KhachHang
Values('KH001','Duong Van Tu','Thu Duc','0978063224');
Insert Into KhachHang
Values('KH002','Le Loi','Tan Phu','0378163224');
Insert Into KhachHang
Values('KH003','Tran Anh Tuan','Binh Thanh','0394521002');
Insert Into KhachHang
Values('KH004','Ta Phi Long','Thu Duc','0379964782');
Insert Into KhachHang
Values('KH005','Le Huynh Yen Nhi','Di An','0972001201');
/

/*Nhap nhan vien*/
Begin
    NhapNV('NV001','Doan Tri Binh','Binh Tan','0339961120','Thanh toan','nv001.png');
    NhapNV('NV002','Duong Trong Binh','Tan Phu','0339541120','Nhap hang','nv002.png');
    NhapNV('NV003','Le Loi','Thu Duc','0311254556','Nhap hang','nv003.png');
    NhapNV('NV004','Dang Nguyen Hoang Yen Nhi','Thu Duc','0311254556','Nhap hang','nv003.png');
End;
/

/*Nhap san pham*/
BEGIN
  NhapSP('SP001','Cho Bac Ha','Cho ta','Cho','dog.png','2500000');
  NhapSP('SP002','Cho Lai','Cho ta','Cho','dog.png','1200000'); 
  NhapSP('SP003','Cho HUSKY','Cho tay','Cho','dog.png','2000000');
  NhapSP('SP004','Cho SIBA INU','Cho tay','Cho','dog.png','3000000');
  NhapSP('SP005','Cho GOLDEN','Cho tay','Cho','dog.png','3100000');
  NhapSP('SP006','Cho CORGI','Cho tay','Cho','dog.png','2300000');
  NhapSP('SP007','Meo Muop','Meo ta','Meo','cat.png','400000');
  NhapSP('SP008','Meo Vang','Meo ta','Meo','cat.png','500000');
  NhapSP('SP009','Meo Xiem','Meo ta','Meo','cat.png','600000');
  NhapSP('SP010','Meo Anh Long Ngan','Meo tay','Meo','cat.png','2400000');
  NhapSP('SP011','Meo Anh Ragdoll','Meo tay','Meo','cat.png','2600000');
  NhapSP('SP012','Meo Tai Cup','Meo tay','Meo','cat.png','2000000');
END;
/

/*Nhap phieu nhap*/
Insert Into PhieuNhap(mapn,manv,tennv)
Values('PN001','NV001','Doan Tri Binh');
Insert Into PhieuNhap(mapn,manv,tennv)
Values('PN002','NV002','Duong Trong Binh');
Insert Into PhieuNhap(mapn,manv,tennv)
Values('PN003','NV003','Le Loi');
Insert Into PhieuNhap(mapn,manv,tennv)
Values('PN004','NV004','Dang Nguyen Hoang Yen Nhi');

/*Nhap chi tiet phieu nhap*/
execute NhapCTPN('PN001','SP001','Cho Bac Ha',10,2500000);
execute NhapCTPN('PN001','SP002','Cho Lai',10,1500000);
execute NhapCTPN('PN002','SP003','Cho HUSKY',10,1000000);
execute NhapCTPN('PN002','SP011','Meo Anh Ragdoll',10,1000000);
execute NhapCTPN('PN003','SP004','Cho SIBA INU',10,1200000);
execute NhapCTPN('PN003','SP007','Meo Muop',10,1500000);
/

/*Nhap lieu bang HoaDon*/
Insert Into HoaDon_View(transno,masp,tensp,soluong,gia,makh,tenkh,thungan)
Values('202303251001','SP001','Cho Bac Ha',2,500000,'KH002','Le Loi','CTruong');
Insert Into HoaDon_View(transno,masp,tensp,soluong,gia,makh,tenkh,thungan)
Values('202303251001','SP003','Cho HUSKY',1,150000,'KH002','Le Loi','CTruong');
Insert Into HoaDon_View(transno,masp,tensp,soluong,gia,makh,tenkh,thungan)
Values('202303261001','SP002','Cho Lai',2,150000,'KH001','Duong Van Tu','CTruong');
commit;