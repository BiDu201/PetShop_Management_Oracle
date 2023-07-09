/* *******************************************************BUOC 1********************************************************* */

/* -------------------------------------------------------Tao diraectory---------------------------------------------------- */
/*Trích xuat du lieu ra thu muc*/
CREATE DIRECTORY PETSHOP_IMAGES AS ''; /* Truyen duong dan den folder PETSHOP_IMAGES*/
/
--SELECT * FROM DBA_DIRECTORIES;
--Drop directory PETSHOP_IMAGES;

/* -------------------------------------------TableSpace & Datafile---------------------------------------------------- */
create tablespace nv_banhang;
create tablespace nv_nhaphang;
create tablespace nv_quanly;
/

/* Procedure tao moi tablespace tren nhieu datafile */
create or replace NONEDITIONABLE PROCEDURE create_tbspace(sl_dtf NUMBER, tb_name VARCHAR2, path_dtf VARCHAR2, d_size VARCHAR2, d_size_auto VARCHAR2)
IS
    dtf VARCHAR2(10000);
    tbs_name VARCHAR2(50) := tb_name;
    path_data VARCHAR2(500) := path_dtf;
    dtf_size VARCHAR2(10) := d_size;
    dtf_extend VARCHAR2(10) := d_size_auto;
BEGIN
    FOR loop_count IN 1..sl_dtf -- vong lap so luong datafile
    LOOP
        dtf := dtf || '''' || path_data || TO_CHAR(loop_count) || '.dbf''' || ' SIZE ' || dtf_size || ' AUTOEXTEND ON NEXT ' || dtf_extend || ' MAXSIZE 10G,' ;
    END LOOP;
    
    EXECUTE IMMEDIATE 'CREATE TABLESPACE ' || tbs_name || ' DATAFILE ' || substr(dtf,1,(length(dtf)-1));
END;
/
--execute create_tbspace(2,'','','','')

/* Procedure xem thong tin cua tablespace */
create or replace PROCEDURE show_Tablespace
as
    c1 SYS_REFCURSOR;
BEGIN
    open c1 for select TABLESPACE_NAME, INITIAL_EXTENT, NEXT_EXTENT, MIN_EXTENTS, MAX_EXTENTS, MAX_SIZE, PCT_INCREASE, STATUS, ALLOCATION_TYPE from dba_tablespaces;
    dbms_sql.return_result(c1);
end;
/

/* Xem tablespace cua user bat ki */
create or replace PROCEDURE show_TablespaceUser(user_name VARCHAR2)
as
    c1 SYS_REFCURSOR;
    us_name VARCHAR2(30) := user_name;
BEGIN
    open c1 for select default_tablespace from dba_users where username= us_name;
    dbms_sql.return_result(c1);
end;
/

/* Xoa tablespace */
create or replace PROCEDURE delete_Tablespace(tablespace_name VARCHAR2)
as
    tbs_name VARCHAR2(30) := tablespace_name;
BEGIN
    execute immediate 'drop tablespace ' || tbs_name || ' including contents and datafiles';
end;
/

/* Xem thong tin datafile */
create or replace PROCEDURE show_Datafile
as
    c1 SYS_REFCURSOR;
BEGIN
    open c1 for select FILE_NAME,FILE_ID,TABLESPACE_NAME from dba_data_files;
    dbms_sql.return_result(c1);
end;
/

/* Xem cac datafile co trong tablespace*/
create or replace PROCEDURE detail_Tablespace(tble_name VARCHAR2)
as
    c1 SYS_REFCURSOR;
    tbs_name VARCHAR2(30) := tble_name;
BEGIN
    open c1 for Select FILE_NAME, FILE_ID, BYTES, AUTOEXTENSIBLE, MAXBYTES from DBA_DATA_FILES where tablespace_name = tbs_name;
    dbms_sql.return_result(c1);
end;
/

/* Procedure xoa datafile */
create or replace procedure delete_Datafile(tble_name VARCHAR2, datafile_name VARCHAR2)
as
    tbs_name VARCHAR2(30) := tble_name;
    dtf_name VARCHAR2(200) := datafile_name;
begin
    execute immediate 'ALTER TABLESPACE ' || tbs_name || ' DROP DATAFILE ''' || dtf_name || '''';
end;
/

/* Procedure resize datafile */
create or replace procedure resize_Datafile(datafile_name VARCHAR2, size_dtf VARCHAR2)
as
    dtf_name VARCHAR2(500) := datafile_name;
    size_new VARCHAR(10) := size_dtf;
begin
    execute immediate 'ALTER DATABASE DATAFILE ''' || dtf_name || ''' RESIZE ' || size_dtf;
end;
/

/* Procedure them datafile vao tablespace da ton tai */
create or replace NONEDITIONABLE PROCEDURE create_datafile (tb_name VARCHAR2, path_dtf VARCHAR2, d_size VARCHAR2, d_size_auto VARCHAR2)
IS
    tbs_name VARCHAR2(50) := tb_name;
    path_data VARCHAR2(500) := path_dtf;
    dtf_size VARCHAR2(10) := d_size;
    dtf_extend VARCHAR2(10) := d_size_auto;
BEGIN
    EXECUTE IMMEDIATE 'ALTER TABLESPACE ' || tbs_name || ' ADD DATAFILE ''' || path_dtf || ''' SIZE ' || d_size || ' AUTOEXTEND ON NEXT ' || d_size_auto || ' MAXSIZE 10G';
END;
/

--Drop procedure create_tbspace;
--Drop procedure show_Tablespace;
--Drop procedure show_TablespaceUser;
--Drop procedure delete_Tablespace;
--Drop procedure show_Datafile;
--Drop procedure detail_Tablespace;
--Drop procedure delete_Datafile;
--Drop procedure resize_Datafile;
--Drop procedure create_datafile;

-----------------------------------------------------PROCEDURE THONG TIN HE THONG----------------------------------------------------------
create or replace NONEDITIONABLE PROCEDURE get_column_inforuser
as
    c1 SYS_REFCURSOR;
BEGIN
    open c1 for SELECT column_name FROM all_tab_columns WHERE table_name = 'DBA_USERS' AND column_name IN ('USERNAME', 'CREATED','EXPIRY_DATE','ACCOUNT_STATUS','LAST_LOGIN','PROFILE') order by case column_name when 'USERNAME' then 1 when 'CREATED' then 2 when 'EXPIRY_DATE' then 3 when 'ACCOUNT_STATUS' then 4 when 'LAST_LOGIN' then 5 when 'PROFILE' then 6 end;
    dbms_sql.return_result(c1);
end;
/

create or replace NONEDITIONABLE PROCEDURE get_column_sessionDN
as
    c1 SYS_REFCURSOR;
BEGIN
    open c1 for SELECT column_name FROM all_tab_columns WHERE table_name = 'V_$SESSION' AND column_name IN ('SID','SERIAL#','USERNAME','PROGRAM') ORDER BY DECODE(column_name, 'SID', 1,'SERIAL#',2,'USERNAME',3,'PROGRAM',4);
    dbms_sql.return_result(c1);
end;
/

create or replace NONEDITIONABLE PROCEDURE get_column_sessionkilled
as
    c1 SYS_REFCURSOR;
BEGIN
    open c1 for SELECT column_name FROM all_tab_columns WHERE table_name = 'V_$SESSION' AND column_name IN ('SID','SERIAL#','USERNAME','STATUS','SERVER') ORDER BY DECODE(column_name, 'SID', 1,'SERIAL#',2,'USERNAME',3,'STATUS',4,'SERVER',5);
    dbms_sql.return_result(c1);
end;
/

create or replace NONEDITIONABLE PROCEDURE get_column_thongtintuychon(tablename IN VARCHAR2)
as
    c1 SYS_REFCURSOR;
BEGIN
    open c1 for select column_name from all_tab_columns where table_name = tablename order by column_id;
    dbms_sql.return_result(c1);
end;
/

create or replace NONEDITIONABLE PROCEDURE get_data_inforuser(USERNAME in VARCHAR2)
as
    c1 SYS_REFCURSOR;
BEGIN
    open c1 for SELECT USERNAME,CREATED,EXPIRY_DATE,ACCOUNT_STATUS,LAST_LOGIN,PROFILE FROM DBA_USERS Where username = get_data_inforuser.USERNAME;
    dbms_sql.return_result(c1);
end;
/

create or replace NONEDITIONABLE PROCEDURE get_data_sessionDN
as
    c1 SYS_REFCURSOR;
BEGIN
    open c1 for select sid,serial#,username,program from v$session where type != 'BACKGROUND';
    dbms_sql.return_result(c1);
end;
/

create or replace NONEDITIONABLE PROCEDURE get_data_sessionkilled(SID in VARCHAR2 ,SERIAL# in VARCHAR2)
as
    c1 SYS_REFCURSOR;
BEGIN
    open c1 for SELECT SID, SERIAL#,username, STATUS, SERVER FROM V$SESSION WHERE sid=get_data_sessionkilled.SID and serial#=get_data_sessionkilled.SERIAL#;
    dbms_sql.return_result(c1);
end;
/

/* Xem user, session block data */
-- Lay cot
create or replace NONEDITIONABLE PROCEDURE get_column_sessionblocked
as
    c1 SYS_REFCURSOR;
BEGIN
    open c1 for SELECT column_name FROM all_tab_columns WHERE table_name = 'V_$SESSION' AND column_name IN ('SID','SERIAL#','USERNAME','OSUSER','MACHINE','PROGRAM','LOGON_TIME','BLOCKING_SESSION','BLOCKING_SESSION_STATUS') ORDER BY DECODE(column_name, 'SID', 1,'SERIAL#',2,'USERNAME',3,'OSUSER',4,'MACHINE',5,'PROGRAM',6,'LOGON_TIME',7,'BLOCKING_SESSION',8,'BLOCKING_SESSION_STATUS',9);
    dbms_sql.return_result(c1);
end;
/
-- Xuat du lieu
create or replace NONEDITIONABLE PROCEDURE get_data_sessionblocked
as
    c1 SYS_REFCURSOR;
BEGIN
    open c1 for SELECT 
    s.sid,
    s.serial#,
    s.username,
    s.osuser,
    s.machine,
    s.program,
    s.logon_time,
    s.blocking_session,
    s.blocking_session_status
FROM 
    v$session s
WHERE 
    s.blocking_session is not null
Order by s.blocking_session;
    dbms_sql.return_result(c1);
end;
/

--Drop procedure get_column_inforuser;
--Drop procedure get_column_sessionDN;
--Drop procedure get_column_sessionkilled;
--Drop procedure get_column_thongtintuychon;
--Drop procedure get_data_inforuser;
--Drop procedure get_data_sessionDN;
--Drop procedure get_data_sessionkilled;
--Drop procedure get_column_sessionblocked;
--Drop procedure get_data_sessionblocked;

/* --------------------------------------------PROFILE-------------------------------------------------------- */
--Dat gia tri true de he thong co the thi hanh viec rang buoc gioi han tai nguyen
ALTER SYSTEM SET RESOURCE_LIMIT = TRUE;
/
--Profile cho nhan vien ban hang
CREATE PROFILE PF_NhanVienBH LIMIT
    FAILED_LOGIN_ATTEMPTS 5 --so lan duoc nhap sai mat khau
    PASSWORD_LIFE_TIME 210 --so ngay su dung mat khau moi ke tu khi bat dau thay doi mat khau
    PASSWORD_REUSE_TIME 90 --so ngay co the tai su dung mat khau cu
    PASSWORD_REUSE_MAX 10 --so lan toi da có the su dung lai mot mat khau
    PASSWORD_LOCK_TIME 1/48 --thoi gian tài khoan bi khóa khi nhap sai password (30p)
    PASSWORD_GRACE_TIME 3 --thoi gian gia han cho viec thay doi mat khau
    SESSIONS_PER_USER 2 -- Toi da 2 session duoc truy cap cung luc
    IDLE_TIME 10 --Thoi gian khong hoat dong 10p
    CONNECT_TIME 480; --Thoi gian ket noi 480p(8h)
/

--Profile cho nhan vien nhap hang
CREATE PROFILE PF_NhanVienNH LIMIT
    FAILED_LOGIN_ATTEMPTS 5 --so lan duoc nhap sai mat khau
    PASSWORD_LIFE_TIME 210 --so ngay su dung mat khau moi ke tu khi bat dau thay doi mat khau
    PASSWORD_REUSE_TIME 90 --so ngay co the tai su dung mat khau cu
    PASSWORD_REUSE_MAX 10 --so lan toi da có the su dung lai mot mat khau
    PASSWORD_LOCK_TIME 1/24 --thoi gian tài khoan bi khóa khi nhap sai password (1h)
    PASSWORD_GRACE_TIME 5 --thoi gian gia han cho viec thay doi mat khau
    SESSIONS_PER_USER 2
    IDLE_TIME 20 --Thoi khong hoat dong 20p
    CONNECT_TIME 480; --Thoi gian ket noi 480p(8h)
/

--Profile cho quan tri, quan ly
CREATE PROFILE PF_QUANLY LIMIT
    FAILED_LOGIN_ATTEMPTS 10 --so lan duoc nhap sai mat khau
    PASSWORD_LIFE_TIME 210 --so ngay su dung mat khau moi ke tu khi bat dau thay doi mat khau
    PASSWORD_REUSE_TIME UNLIMITED --so ngay co the tai su dung mat khau cu
    PASSWORD_REUSE_MAX UNLIMITED --so lan toi da có the su dung lai mot mat khau
    PASSWORD_LOCK_TIME 1/72 --thoi gian tài khoan bi khóa khi nhap sai password (20p)
    PASSWORD_GRACE_TIME 7 --thoi gian gia han cho viec thay doi mat khau
    SESSIONS_PER_USER UNLIMITED
    IDLE_TIME 5 --Thoi khong hoat dong 10p
    CONNECT_TIME 720; --Thoi gian ket noi 720p(12h)
/

--Procedure tao moi profile
CREATE OR REPLACE PROCEDURE CREATE_ALTER_PROFILE(
p_lenh VARCHAR2,
p_name_profile VARCHAR2,
p_failed_login_attempts VARCHAR2,
p_password_life_time VARCHAR2,
p_password_reuse_time VARCHAR2,
p_password_reuse_max VARCHAR2,
p_password_lock_time VARCHAR2, --30p (48 = 2 ngay => (1/48)ngay = 30p)
p_password_grace_time VARCHAR2,
p_sessions_per_user VARCHAR2,
p_idle_time VARCHAR2,
p_connect_time VARCHAR2
) AS
    u_cmd VARCHAR2(1000);
BEGIN
    u_cmd := p_lenh || ' PROFILE ' || p_name_profile || ' LIMIT
 FAILED_LOGIN_ATTEMPTS '|| nvl(p_failed_login_attempts,5) ||'
 PASSWORD_LIFE_TIME '|| nvl(p_password_life_time,210) ||'
 PASSWORD_REUSE_TIME '|| nvl(p_password_reuse_time,60) ||'
 PASSWORD_REUSE_MAX '|| nvl(p_password_reuse_max,10) ||'
 PASSWORD_LOCK_TIME '|| nvl(p_password_lock_time,1/24) ||'
 PASSWORD_GRACE_TIME '|| nvl(p_password_grace_time,7) ||'
 SESSIONS_PER_USER ' || nvl(p_sessions_per_user,2) ||'
 IDLE_TIME ' || nvl(p_idle_time,10) ||'
 CONNECT_TIME ' || nvl(p_connect_time,480);
    
    EXECUTE IMMEDIATE u_cmd;
END;
/

--Drop profile PF_NhanVienBH CASCADE;
--Drop profile PF_NhanVienNH CASCADE;
--Drop profile PF_QUANLY CASCADE;
--Drop procedure CREATE_ALTER_PROFILE;

/* ----------------------------------------------------------USER------------------------------------------------------------ */
--Package chua procecure tao, sua, grant user
CREATE OR REPLACE PACKAGE AL_CR_GNT_USER_PACKAGE AS
    --create user
    PROCEDURE createUser(u_username IN dba_users.USERNAME%TYPE,
    u_password IN dba_users.PASSWORD%TYPE,
    u_tablespace IN dba_users.DEFAULT_TABLESPACE%TYPE,
    u_profile IN dba_users.PROFILE%TYPE,
    u_role IN dba_roles.ROLE%TYPE);
    --alter user
    PROCEDURE ALTER_USER(a_username in dba_users.USERNAME%TYPE,
    a_password in dba_users.PASSWORD%TYPE DEFAULT NULL,
    a_tablespace in dba_users.DEFAULT_TABLESPACE%TYPE DEFAULT NULL,
    a_profile in dba_users.PROFILE%TYPE DEFAULT NULL,
    a_role IN dba_roles.ROLE%TYPE DEFAULT NULL);
    --grant privs user
    PROCEDURE grant_pri(g_pri IN dba_sys_privs.privilege%TYPE, g_username IN dba_users.USERNAME%TYPE);
    
    PROCEDURE CR_GRT(u_username IN dba_users.USERNAME%TYPE,u_password IN dba_users.PASSWORD%TYPE,u_tablespace IN dba_users.DEFAULT_TABLESPACE%TYPE,u_profile IN dba_users.PROFILE%TYPE,u_role IN dba_roles.ROLE%TYPE,g_pri IN dba_sys_privs.privilege%TYPE);
    PROCEDURE AL_USER(a_username IN dba_users.USERNAME%TYPE,a_password IN dba_users.PASSWORD%TYPE DEFAULT NULL,a_tablespace IN dba_users.DEFAULT_TABLESPACE%TYPE DEFAULT NULL,a_profile IN dba_users.PROFILE%TYPE DEFAULT NULL,a_role IN dba_roles.ROLE%TYPE DEFAULT NULL,g_pri IN dba_sys_privs.privilege%TYPE);
END AL_CR_GNT_USER_PACKAGE;
/

CREATE OR REPLACE PACKAGE BODY AL_CR_GNT_USER_PACKAGE AS
    --Tao user voi profile
    PROCEDURE createUser(u_username IN dba_users.USERNAME%TYPE,
    u_password IN dba_users.PASSWORD%TYPE,
    u_tablespace IN dba_users.DEFAULT_TABLESPACE%TYPE,
    u_profile IN dba_users.PROFILE%TYPE,
    u_role IN dba_roles.ROLE%TYPE)
    IS
        u_count INTEGER := 0;
        u_cmd VARCHAR2(1000);
    BEGIN
        SELECT COUNT (1) INTO u_count
        FROM dba_users
        WHERE username = UPPER ( u_username );
    
        IF u_count != 0
        THEN
            ROLLBACK;
        END IF;
        
        u_cmd := 'CREATE USER ' || u_username || ' IDENTIFIED BY ' || u_password || ' DEFAULT TABLESPACE ' || u_tablespace || ' QUOTA UNLIMITED ON ' || u_tablespace ||' PROFILE ' || u_profile;
        EXECUTE IMMEDIATE ( u_cmd ); 
                                                    
            -- ****** Grant role ******
        u_cmd := 'GRANT RESOURCE, CONNECT, ' || u_role || ' TO ' || u_username;
        EXECUTE IMMEDIATE ( u_cmd );
            
        COMMIT;
    END createUser;

    --Thay doi(sua)user
    PROCEDURE ALTER_USER(a_username in dba_users.USERNAME%TYPE,
    a_password in dba_users.PASSWORD%TYPE DEFAULT NULL,
    a_tablespace in dba_users.DEFAULT_TABLESPACE%TYPE DEFAULT NULL,
    a_profile in dba_users.PROFILE%TYPE DEFAULT NULL,
    a_role IN dba_roles.ROLE%TYPE DEFAULT NULL) IS
    BEGIN
        IF a_password IS NOT NULL THEN
            EXECUTE IMMEDIATE 'ALTER USER ' || a_username || ' IDENTIFIED BY ' || a_password;       
        END IF;
        
        IF a_profile IS NOT NULL THEN
        EXECUTE IMMEDIATE 'ALTER USER ' || a_username || ' PROFILE ' || a_profile;              
        END IF;
        
        IF a_tablespace IS NOT NULL THEN
        EXECUTE IMMEDIATE 'ALTER USER ' || a_username || ' DEFAULT TABLESPACE ' || a_tablespace;
        END IF;
        
        IF a_role IS NOT NULL THEN
            EXECUTE IMMEDIATE 'GRANT ' || a_role || ' TO ' ||a_username;
        END IF;
        
        COMMIT;
    END;
 
    --grant quyen cho user
    PROCEDURE grant_pri(g_pri IN dba_sys_privs.privilege%TYPE, g_username IN dba_users.USERNAME%TYPE)
    IS
        g_cmd VARCHAR2(1000);
    BEGIN
        g_cmd := 'GRANT CREATE SESSION, ALTER USER' ||g_pri|| ' TO ' || g_username;
        EXECUTE IMMEDIATE (g_cmd);
        
        COMMIT;
    END;
    
    --Procedure chua 2 procedure tao va grant
    PROCEDURE CR_GRT(u_username IN dba_users.USERNAME%TYPE,u_password IN dba_users.PASSWORD%TYPE,u_tablespace IN dba_users.DEFAULT_TABLESPACE%TYPE,u_profile IN dba_users.PROFILE%TYPE,u_role IN dba_roles.ROLE%TYPE,g_pri IN dba_sys_privs.privilege%TYPE) IS
    BEGIN
        createUser(u_username,u_password,u_tablespace,u_profile,u_role);   
        grant_pri(g_pri, u_username);
        
        COMMIT;
    END;
 
    --Procedure chua 2 procedure sua va grant
    PROCEDURE AL_USER(a_username IN dba_users.USERNAME%TYPE,a_password IN dba_users.PASSWORD%TYPE DEFAULT NULL,a_tablespace IN dba_users.DEFAULT_TABLESPACE%TYPE DEFAULT NULL,a_profile IN dba_users.PROFILE%TYPE DEFAULT NULL,a_role IN dba_roles.ROLE%TYPE DEFAULT NULL ,g_pri IN dba_sys_privs.privilege%TYPE) IS
    BEGIN
        ALTER_USER(a_username,a_password,a_tablespace,a_profile,a_role);   
        grant_pri(g_pri, a_username);
        
        COMMIT;
    END;
END AL_CR_GNT_USER_PACKAGE;
/

--Drop package AL_CR_GNT_USER_PACKAGE;

/* ----------------------------------------------Tao user quan ly------------------------------------------------- */
--Tao userQL
CREATE USER userQL IDENTIFIED BY quanly
DEFAULT TABLESPACE NV_QUANLY
QUOTA UNLIMITED ON NV_QUANLY
PROFILE PF_QUANLY;
Grant Create Session to userQL;
GRANT READ, WRITE ON DIRECTORY PETSHOP_IMAGES TO userQL;
/

/* --------------------------------------------ROLE-------------------------------------------------------- */

--Package chua procedure tao, xoa, grant quyen cho nhom quyen
CREATE OR REPLACE PACKAGE ROLE_PACKAGE AS
    PROCEDURE createRole(r_rolename VARCHAR2);
    PROCEDURE grantRole(g_rolename VARCHAR2, g_query VARCHAR2 DEFAULT NULL, g_tablename VARCHAR2);
    PROCEDURE dropRole(dr_rolename VARCHAR2);
    END ROLE_PACKAGE;
/
CREATE OR REPLACE PACKAGE BODY ROLE_PACKAGE AS
    --Tao role
    PROCEDURE createRole(r_rolename VARCHAR2)
    IS
    BEGIN
        EXECUTE IMMEDIATE 'CREATE ROLE '|| r_rolename;
        
        COMMIT;
    END createRole;
    
    --Grany quyen cho role
    PROCEDURE grantRole(g_rolename VARCHAR2, g_query VARCHAR2 DEFAULT NULL, g_tablename VARCHAR2)
    IS
    BEGIN
        IF g_query IS NOT NULL THEN
            EXECUTE IMMEDIATE 'GRANT '|| g_query || ' ON '|| g_tablename || ' TO ' || g_rolename;
        END IF; 
        COMMIT;
    END grantRole;

    --Xoa role
    PROCEDURE dropRole(dr_rolename VARCHAR2)
    IS
    BEGIN
        EXECUTE IMMEDIATE 'DROP ROLE '|| dr_rolename;
        
        COMMIT;
    END dropRole;
    
END ROLE_PACKAGE;
/

CREATE ROLE nhanvien_banhang; --nhom quyen nhan vien ban hang
CREATE ROLE nhanvien_nhaphang; --nhom quyen nhan vien nhap hang
CREATE ROLE nhanvien_quanly; --nhom quyen nhan vien quan ly
/

--Phan quyen cho nhom quyen nhanvien_quanly
GRANT CREATE SESSION, RESOURCE, CONNECT, CREATE TABLE, CREATE ANY SEQUENCE, CREATE PROCEDURE, CREATE TRIGGER, 
CREATE ANY VIEW, CREATE USER, ALTER USER, DROP USER, EXECUTE ANY PROCEDURE, GRANT ANY PRIVILEGE, GRANT ANY ROLE TO nhanvien_quanly;
GRANT nhanvien_quanly TO userQL;

--Xem lai ban ghi audit trail
CREATE OR REPLACE PROCEDURE History_AuditFGA(policy_name VARCHAR2)
AS
    c1 SYS_REFCURSOR;
BEGIN
    OPEN c1 for select STATEMENT_TYPE, DB_USER, OBJECT_SCHEMA, OBJECT_NAME, TIMESTAMP, SQL_TEXT from dba_fga_audit_trail where POLICY_NAME = History_AuditFGA.policy_name ORDER BY TIMESTAMP DESC;
    --select ACTION_NAME,DBUSERNAME,OBJECT_SCHEMA,OBJECT_NAME,EVENT_TIMESTAMP,SQL_TEXT from unified_audit_trail where FGA_POLICY_NAME = History_AuditFGA.policy_name ORDER BY EVENT_TIMESTAMP DESC;
    dbms_sql.return_result(c1);
END;
/

---------------------------------------------------------AUDIT USER-------------------------------------------------------------
/* Xem cac ban ghi cua userQL*/
CREATE OR REPLACE PROCEDURE HisAudit_User
AS
    c1 SYS_REFCURSOR;
BEGIN
    OPEN c1 for select ACTION_NAME, TIMESTAMP, OBJ_NAME, SQL_TEXT
                from dba_audit_trail
                where owner = 'USERQL';
    dbms_sql.return_result(c1);
END;
/
--Drop procedure HisAudit_User;

----Bat audit
----Auditing tat, khi audit_trail la NONE
--show PARAMETERS audit_trail; -- Xem da bat audit_trail hay chua
alter system set audit_trail=db,extended scope=spfile;
/
---- Liet kê các câu lenh dã audit trong database:
--select *
--from dba_stmt_audit_opts
--order by user_name, proxy_name, audit_option;

----Hien thi các câu lenh duoc phep audit
--select * from STMT_AUDIT_OPTION_MAP;

--2. Audit muc lenh
-- Cho phép audit muc câu lenh 
audit table by USERQL whenever successful;
audit role by USERQL;

--3. Audit muc object
audit execute procedure by USERQL by access;
audit insert table, update table, delete table by USERQL by access;

----4. Audit muc he thong
audit drop user by USERQL;
audit alter user by USERQL;
audit create user by USERQL;
/
--5. Tim cac du lieu da audit cua 1 user
--TRUNCATE TABLE AUD$

/* *******************************************************BUOC 3********************************************************* */

GRANT SELECT ON dba_audit_policies TO nhanvien_quanly; -- De xem audit FGA
GRANT SELECT ON DBA_USERS TO nhanvien_quanly; -- De xem tai khoan user
GRANT SELECT ON unified_audit_trail TO nhanvien_quanly; -- De xem ba ghi audit FGA
GRANT SELECT ON dba_tablespaces TO nhanvien_quanly; -- De xem ten tablespace
GRANT SELECT ON dba_roles TO nhanvien_quanly; -- De xem ten role
GRANT SELECT ON dba_role_privs to nhanvien_quanly; -- De xem role cua user
GRANT SELECT ON sys.profname$ TO nhanvien_quanly; -- De xem ten profile
GRANT EXECUTE ON sys.History_AuditFGA TO nhanvien_quanly; -- De chay procedure xem ban ghi audit FGA
GRANT EXECUTE ON sys.AL_CR_GNT_USER_PACKAGE TO nhanvien_quanly;
--GRANT EXECUTE ON sys.HisAudit_User TO nhanvien_quanly;
/* Grant moi quyen tren tat ca bang */
GRANT ALL PRIVILEGES ON userQL.audit_HoaDon TO nhanvien_quanly;
GRANT ALL PRIVILEGES ON userQL.KhachHang TO nhanvien_quanly;
GRANT ALL PRIVILEGES ON userQL.PhieuNhap TO nhanvien_quanly;
GRANT ALL PRIVILEGES ON userQL.SanPham TO nhanvien_quanly;
GRANT ALL PRIVILEGES ON userQL.CTPhieuNhap TO nhanvien_quanly;
GRANT ALL PRIVILEGES ON userQL.NhanVien TO nhanvien_quanly;
GRANT ALL PRIVILEGES ON userQL.HoaDon TO nhanvien_quanly;
GRANT ALL PRIVILEGES ON userQL.db_evnt_audit TO nhanvien_quanly;
GRANT ALL PRIVILEGES ON userQL.startup_audit TO nhanvien_quanly;
GRANT ALL PRIVILEGES ON userQL.HoaDon_View TO nhanvien_quanly;
GRANT nhanvien_quanly TO userQL;
/

--Phan quyen cho nhom quyen nhanvien_banhang
GRANT SELECT, INSERT, UPDATE, DELETE
ON userQL.HOADON
TO nhanvien_banhang;
/
GRANT SELECT, INSERT, UPDATE, DELETE
ON userQL.HoaDon_View
TO nhanvien_banhang;
/
GRANT EXECUTE ON userQL.ShowBill TO nhanvien_banhang;
GRANT EXECUTE ON userQL.searchBill TO nhanvien_banhang;
/
GRANT SELECT, INSERT, UPDATE, DELETE
ON userQL.KHACHHANG
TO nhanvien_banhang;
/
GRANT EXECUTE ON userQL.searchcustomer TO nhanvien_banhang;
/
GRANT EXECUTE ON userQL.updatecustomer TO nhanvien_banhang;
/
GRANT SELECT, UPDATE
ON userQL.SANPHAM
TO nhanvien_banhang;
/
GRANT EXECUTE ON userQL.loc_SP_TheoGia TO nhanvien_banhang;

--Phan quyen cho nhom quyen nhanvien_nhaphang
GRANT SELECT, INSERT, UPDATE, DELETE
ON userQL.PHIEUNHAP
TO nhanvien_nhaphang;
/
GRANT SELECT, INSERT, UPDATE, DELETE
ON userQL.CTPHIEUNHAP
TO nhanvien_nhaphang;
/
GRANT SELECT, INSERT, UPDATE, DELETE
ON userQL.SANPHAM
TO nhanvien_nhaphang;
/
GRANT EXECUTE ON userQL.NhapSP TO nhanvien_nhaphang;
/
GRANT EXECUTE ON userQL.NhapCTPN TO nhanvien_nhaphang;
/
GRANT EXECUTE ON userQL.loc_SP_TheoGia TO nhanvien_nhaphang;
/
--Cap nhom quyen cho user
--GRANT nhanvien_banhang to ;

----Thu hoi quyen cua role
--REVOKE ... ON ... from ...;

--DROP ROLE nhanvien_banhang;
--DROP ROLE nhanvien_nhaphang;
--DROP ROLE nhanvien_quanly;
--DROP PACKAGE ROLE_PACKAGE;
------------------------------------------------------TRIGGER------------------------------------------------------------------
--Tao package de luu tru 2 procedure tao và grant user
CREATE OR REPLACE PACKAGE CR_GNT_USER_PACKAGE AS
PROCEDURE CREATE_USER(USERNAME IN VARCHAR2);
PROCEDURE GRANT_PRI_USER(USERNAME IN VARCHAR2);
PROCEDURE GRANT_ROLE_USER(CHUCVU VARCHAR2,USERNAME IN VARCHAR2);
PROCEDURE DUAL(CHUCVU IN VARCHAR2, USERNAME IN VARCHAR2);
END CR_GNT_USER_PACKAGE;
/
--Phan than cua package
CREATE OR REPLACE PACKAGE BODY CR_GNT_USER_PACKAGE AS
  PROCEDURE CREATE_USER(USERNAME IN VARCHAR2) IS
    PRAGMA AUTONOMOUS_TRANSACTION;
  BEGIN
    EXECUTE IMMEDIATE 'create user ' || USERNAME || ' identified by 123 default tablespace users temporary tablespace temp QUOTA UNLIMITED ON USERS';
  END;
  
  PROCEDURE GRANT_PRI_USER(USERNAME IN VARCHAR2) IS
    PRAGMA AUTONOMOUS_TRANSACTION;
  BEGIN
    EXECUTE IMMEDIATE 'GRANT                                           
                       ALTER USER,                      
                       CREATE SESSION TO ' || USERNAME;
  END;
  
  PROCEDURE GRANT_ROLE_USER(CHUCVU VARCHAR2,USERNAME IN VARCHAR2) IS
  BEGIN
    if(CHUCVU = 'Nhap Hang' or CHUCVU = 'Nhap hang') THEN
        EXECUTE IMMEDIATE 'GRANT nhanvien_nhaphang TO ' || username;
        
        EXECUTE IMMEDIATE 'ALTER USER ' || username || ' PROFILE PF_NhanVienNH';
        
        EXECUTE IMMEDIATE 'ALTER USER ' || username || ' DEFAULT TABLESPACE NV_NHAPHANG';
    else
        EXECUTE IMMEDIATE 'GRANT nhanvien_banhang TO ' || username;
        
        EXECUTE IMMEDIATE 'ALTER USER ' || username || ' PROFILE PF_NhanVienBH';
        
        EXECUTE IMMEDIATE 'ALTER USER ' || username || ' DEFAULT TABLESPACE NV_BANHANG';
    END IF;
    
  END;
  
  PROCEDURE DUAL(CHUCVU IN VARCHAR2,USERNAME IN VARCHAR2) IS
  BEGIN
     CREATE_USER(username);
     GRANT_PRI_USER(username);
     GRANT_ROLE_USER(chucvu,username);
  END;
END CR_GNT_USER_PACKAGE;
/

--DROP PACKAGE CR_GNT_USER_PACKAGE;

--Trigger tu dong tao user va gan quyen khi nhap moi mot NhanVien
CREATE OR REPLACE TRIGGER user_trigger
AFTER INSERT ON userQL.NhanVien
FOR EACH ROW
DECLARE
    PRAGMA AUTONOMOUS_TRANSACTION;
    c_space NUMBER;
    c_user NUMBER;
    vt NUMBER;
    vt1 NUMBER;
    ho_ VARCHAR2(10);
    lot1 VARCHAR2(10);
    lot_ VARCHAR2(10);
    ten_ VARCHAR2(10);
    user_name VARCHAR2(15);
    username VARCHAR2(15);
BEGIN
    c_space := REGEXP_COUNT(:NEW.TenNV, ' '); --dem so khoang trang trong chuoi ten
    IF (c_space > 1) THEN --neu ten lon hon 2 chu
        FOR c_i IN REVERSE 1..(c_space - 1) --vong lap tu vi tri khoang trang 1 den vi tri khoang trang cuoi cung - 1
        LOOP
            vt1 := Instr(:NEW.TenNV, ' ', 1, c_i); --vi tri khoang trang truoc ten lot (tuy thuoc so khoang trang)
            lot1 := substr(:NEW.TenNV,vt1 +1,1); --lay chu cai dau tu ten lot
            
            lot_ := concat(lot1,lot_); --noi nhung chu cai dau cua ten lot
        END LOOP;
        vt := Instr(:NEW.TenNV, ' ', 1, c_space); --vi tri khoang trang truoc ten
        ho_ := substr(:NEW.TenNV,1,1); --lay chu cai dau cua ho
        ten_ := substr(:NEW.TenNV,vt); --lay ten
        user_name := concat(ten_,concat(ho_,lot_)); --noi ca 3 lai
    ELSIF (c_space = 1) THEN --neu ten chi co 2 chu
        vt1 := Instr(:NEW.TenNV, ' ', 1, c_space); --vi tri khoang trang truoc ten
        ho_ := substr(:NEW.TenNV,1,1); --lay chu cai dau tu ho
        ten_ := substr(:NEW.TenNV,vt1); --lay ten tu vi tri khoang trang truoc ten den het
        user_name := CONCAT(ten_,ho_); --noi ca 2 lai
    END IF;

    select count(*) into c_user from dba_users where username LIKE(CONCAT(LTRIM(UPPER(user_name)),'%')); --tim kiem username trung
    
    IF(c_user >= 1) THEN
        username := concat(user_name,TO_CHAR(c_user)); --noi ten user trung voi stt trung
    ELSE
        username := user_name;
    END IF;
    
    CR_GNT_USER_PACKAGE.DUAL(:NEW.chucvu,username);
    
END;
/

--Trigger ghi lai su kien LOGOFF cua user
CREATE OR REPLACE TRIGGER db_lgof_audit
BEFORE LOGOFF ON DATABASE
BEGIN
  INSERT INTO userQL.db_evnt_audit 
  VALUES(user,ora_sysevent,NULL,NULL,SYSDATE,TO_CHAR(sysdate, 'hh24:mi:ss'));
END;
/

--Trigger ghi lai su kien LOGON cua user
CREATE OR REPLACE TRIGGER db_lgon_audit
AFTER LOGON ON DATABASE
BEGIN
  INSERT INTO userQL.db_evnt_audit 
  VALUES(user,ora_sysevent,SYSDATE,TO_CHAR(sysdate, 'hh24:mi:ss'),NULL,NULL);
END;
/

--Trigger ghi lai su kien startup
CREATE OR REPLACE TRIGGER startup_audit
AFTER STARTUP ON DATABASE
BEGIN
  INSERT INTO userQL.startup_audit VALUES
(
    ora_sysevent,
    TO_CHAR(sysdate, 'DD/MM/YYYY'),
    TO_CHAR(sysdate, 'hh24:mm:ss')
  );
END;
/

--Trigger ghi lai su kien shutdown
CREATE OR REPLACE TRIGGER shutdown_audit
BEFORE SHUTDOWN ON DATABASE
BEGIN
  INSERT INTO userQL.startup_audit VALUES(
    ora_sysevent,
    TO_CHAR(sysdate, 'DD/MM/YYYY'),
    TO_CHAR(sysdate, 'hh24:mm:ss')
  );
END;
/

--Drop trigger user_trigger;
--Drop trigger db_lgof_audit;
--Drop trigger db_lgon_audit;
--Drop trigger startup_audit;
--Drop trigger shutdown_audit;

/* ----------------------------------------------------FGA (khong audit user SYS)-------------------------------------------------- */
-- Tao policy tren bang KhachHang
BEGIN
  DBMS_FGA.add_policy(
    object_schema   => 'USERQL',
    object_name     => 'KHACHHANG',
    policy_name     => 'KHACHHANG_AUDIT',
    audit_condition => NULL,
    audit_column    => 'MAKH,TENKH,DIACHI,DTHOAI',
    enable          => true,
    statement_types => 'INSERT,DELETE,UPDATE');
END;
/

-- Tao policy tren bang NhanVien
BEGIN
  DBMS_FGA.add_policy(
    object_schema   => 'USERQL',
    object_name     => 'NHANVIEN',
    policy_name     => 'NHANVIEN_AUDIT',
    audit_condition => NULL,
    audit_column    => 'MANV,TENNV,IMGNV,DCHI,DIENTHOAI,CHUCVU',
    enable          => true,
    statement_types => 'INSERT,UPDATE,DELETE');
END;
/

-- Tao policy tren bang SanPham
BEGIN
  DBMS_FGA.add_policy(
    object_schema   => 'USERQL',
    object_name     => 'SANPHAM',
    policy_name     => 'SANPHAM_AUDIT',
    audit_condition => NULL,
    audit_column    => 'MASP,TENSP,SOLUONGTON',
    enable          => true,
    statement_types => 'INSERT,UPDATE,DELETE');
END;
/

-- Tao policy tren bang CTPhieuNhap
BEGIN
  DBMS_FGA.add_policy(
    object_schema   => 'USERQL',
    object_name     => 'CTPhieuNhap',
    policy_name     => 'CTPHIEUNHAP_AUDIT',
    audit_condition => NULL,
    audit_column    => 'MAPN,MASP',
    enable          => true,
    statement_types => 'INSERT,DELETE');
END;
/

-- Tao policy tren bang PHIEUNHAP
BEGIN
  DBMS_FGA.add_policy(
    object_schema   => 'USERQL',
    object_name     => 'PHIEUNHAP',
    policy_name     => 'PHIEUNHAP_AUDIT',
    audit_condition => NULL, --tuong duong voi TRUE
    audit_column    => 'MAPN,MANV,TENNV',
    enable          => true,
    statement_types => 'INSERT,DELETE,UPDATE');
END;
/

-- Bo policy ra khoi bang.
CREATE OR REPLACE PROCEDURE xoa_FGA(ob_name VARCHAR2, po_name VARCHAR2)
IS
BEGIN
    DBMS_FGA.drop_policy(
    object_schema   => 'USERQL',
    object_name     => ob_name,
    policy_name     => po_name);
END;
/

--Bat tat policy FGA
CREATE OR REPLACE PROCEDURE enable_FGA(ob_name VARCHAR2, po_name VARCHAR2, status VARCHAR2)
AS
    enble BOOLEAN;
BEGIN
    IF (status = 'YES') THEN
        enble := FALSE;
    ELSE
        enble := TRUE;
    END IF;
    
    DBMS_FGA.enable_policy(
    object_schema   => 'USERQL',
    object_name     => ob_name,
    policy_name     => po_name,
    enable          => enble);
END;
/

--Xem các FGA da tao
--select object_schema, object_name, policy_name, policy_column, enabled from dba_audit_policies;

--Xoa tat ca ban ghi
--TRUNCATE TABLE fga_log$;

--Drop procedure History_AuditFGA;
--Drop procedure xoa_FGA;
--Drop procedure enable_FGA;

------------------------------------------------------------AUDIT--------------------------------------------------------------

--------------------------------------------------------AUDIT POLICY------------------------------------------------------------
----Truy van V$OPTION de xac minh xem co so du lieu da duoc chuyen sang 'unified auditing' chua:
--SELECT value FROM v$option WHERE parameter = 'Unified Auditing';
--
---- Xem cac policy hien co
--select distinct policy_name from audit_unified_policies;
--
--/*Tao audit poilicy tren bang KhachHang*/
--Create audit policy audit_nv_kh
--actions select on userQL.KhachHang, update on userQL.KhachHang, delete on userQL.KhachHang,
--        select on userQL.NhanVien, update on userQL.NhanVien, delete on userQL.NhanVien;
--

--/*Huy 1 audit policy*/
----Drop audit policy audit_quanly;
--
--/*Xem policy vua duoc tao*/
--SELECT audit_option, audit_option_type, object_schema,object_name
--FROM audit_unified_policies
--WHERE policy_name = 'AUDIT_NV_KH';
--
---- Audit cho all users
--AUDIT POLICY audit_nv_kh;
--
---- Xem thong tin ve audit policy da enable
--select * FROM audit_unified_enabled_policies;
--
---- Xem các ban ghi audit trail.
--select *
--from unified_audit_trail;
--where unified_audit_policies = 'AUDIT_NV_KH';

----Xoa ban ghi unified_audit_trail
--EXECUTE dbms_audit_mgmt.clean_audit_trail(audit_trail_type=>dbms_audit_mgmt.audit_trail_unified,use_last_arch_timestamp=>FALSE);