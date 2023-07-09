/*sga*/
Select * from v$sga;
/*pga*/
Select * from v$pgastat;
/*process*/
Select * from v$process;
/*instance*/
Select * from v$instance;
/*database*/
Select DBID,NAME,CREATED,RESETLOGS_CHANGE#,RESETLOGS_TIME,PRIOR_RESETLOGS_CHANGE#,PRIOR_RESETLOGS_TIME from v$database;
/*datafile*/
select * from v$datafile;
/*control files*/
select * from v$controlfile;
select * from v$parameter where name = 'control_files';
/*spfile*/
select * from v$parameter where name = 'spfile';

/*kiem tra mot so thông tin cua session: so luong session, sid, serial, username, ung dung nào dang dang nhap…*/
select count(*) from v$session;
--select * from v$session;
select sid,serial#,username,program from v$session where type != 'BACKGROUND';
--desc v$session;
/*huy mot session dang dang nhap;*/
Alter system kill session ','; /*'SID,SERIAL#'*/
/*xem các process cung voi các session dang dang nhap*/
select sid,serial#,process from v$session;

/* ------------------------------------------------------------------------------------------------------------------------- */
Select USERNAME from DBA_USERS Order by USERNAME; --truy v?n l?y tên user
select Name From sys.profname$ Order by Name; -- truy v?n tên c?a profile
select Tablespace_name from dba_tablespaces where tablespace_name not in 'TEMP' order by tablespace_name; --truy v?n l?y tên tablespace(không bao g?m temp)
select table_name from all_tables where table_name in ('NHANVIEN','KHACHHANG','SANPHAM','PHIEUNHAP','CTPHIEUNHAP','HOADON'); -- truy v?n tên 6 b?ng chính c?a ch??ng trình
select ROLE from dba_roles where oracle_maintained = 'N' order by ROLE; -- truy v?n tên role ???c t?o b?i ng??i dùng
select distinct date_stamp from userQL.audit_HoaDon;
select distinct event_date from userQL.startup_audit;
delete from userQL.db_evnt_audit;
select distinct privilege from dba_sys_privs where privilege LIKE ' %' order by privilege; -- truy v?n tên privilege trong h? th?ng
select privilege from dba_sys_privs where grantee = '' Order by privilege; -- truy v?n l?y quy?n c?a user ???c ch? ??nh
SELECT GRANTED_ROLE FROM dba_role_privs WHERE GRANTEE = '' Order by GRANTED_ROLE; -- truy v?n l?y role c?a user
select distinct profile from dba_profiles where Profile LIKE ' %'; -- Tim kiem ten profile
Drop profile /*ten profile*/ CASCADE; -- Drop profile
select USERNAME,LOCK_DATE,EXPIRY_DATE,CREATED,DEFAULT_TABLESPACE,PROFILE from dba_users where ACCOUNT_STATUS = 'OPEN'; -- truy van user o trang thai open
SELECT TABLE_NAME,PRIVILEGE, TYPE FROM DBA_TAB_PRIVS WHERE GRANTEE = '' ORDER BY GRANTEE, TABLE_NAME, PRIVILEGE; -- Xem privilege cua role
-- Xem thong tin cua profile nao do
select resource_name, resource_type, LIMIT from dba_profiles Where Profile || resource_name LIKE 'PF_NhanVienBH%' order by resource_type desc;
alter user "+user.ToUpper()+" identified by /* pass moi */ replace /* pass cu */; -- Sua pass user

-- Lay lan dang nhap cuoi cua user
SELECT username, logon_time FROM v$session WHERE type = 'USER' AND Program = 'DoAn_PetShop.exe' ORDER BY logon_time DESC FETCH FIRST 1 ROWS ONLY;
