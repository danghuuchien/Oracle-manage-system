CREATE OR REPLACE FUNCTION is_admin(
    p_username IN VARCHAR2
) RETURN BOOLEAN
IS
    v_count NUMBER;
begin
    SELECT COUNT(*) INTO v_count 
    FROM admin_role
    WHERE username = UPPER(p_username);

    IF v_count = 1 THEN
        RETURN TRUE;
    ELSE
        RETURN FALSE;
    END IF;
END;
/
//nay loi
CREATE OR REPLACE PROCEDURE GetTablesByOwner(
    p_owner IN VARCHAR2,
    p_tables OUT SYS_REFCURSOR
)
IS
BEGIN
    OPEN p_tables FOR
        SELECT TABLE_NAME, TABLESPACE_NAME FROM dba_tables WHERE owner = p_owner;
END;


select * from admin_role;


CREATE OR REPLACE PROCEDURE GetTableColumnInfo(
    p_table_name IN VARCHAR2,
    p_owner IN VARCHAR2,
    p_cursor OUT SYS_REFCURSOR
)
IS
BEGIN
    OPEN p_cursor FOR
    SELECT column_name, data_type
    FROM all_tab_columns
    WHERE table_name = p_table_name
    AND owner = p_owner;
end;
/

CREATE OR REPLACE PROCEDURE GetTableData(
    p_table_name IN VARCHAR2,
    p_owner IN VARCHAR2,
    p_cursor OUT SYS_REFCURSOR
)
IS
BEGIN
    OPEN p_cursor FOR 
    'SELECT * FROM ' || p_owner || '.' || p_table_name;
end;
/

CREATE OR REPLACE PROCEDURE GetSessionInfo(
    p_cursor OUT SYS_REFCURSOR
)
IS
    v_sql VARCHAR2(1000);
BEGIN
    v_sql := 'SELECT sid, serial#, username, program FROM v$session WHERE STATUS != ''KILLED''';
    OPEN p_cursor FOR v_sql;
END GetSessionInfo;
/





CREATE OR REPLACE PROCEDURE GetSessionProcesses(
    p_sid IN NUMBER,
    p_serial IN NUMBER,
    p_cursor OUT SYS_REFCURSOR
)
IS
    v_sql VARCHAR2(1000);
BEGIN
    v_sql := 'SELECT pid, spid, program, module FROM v$process WHERE addr IN (SELECT paddr FROM v$session WHERE sid = :sid AND serial# = :serial)';
    
    OPEN p_cursor FOR v_sql USING p_sid, p_serial;
END GetSessionProcesses;
/

CREATE OR REPLACE PROCEDURE GetAllUsers(
    p_cursor OUT SYS_REFCURSOR
)
IS
BEGIN
    OPEN p_cursor FOR
    SELECT username
    from dba_users
    order by username;
END GetAllUsers;
/

CREATE OR REPLACE PROCEDURE get_user_tablespaces (
    p_username IN VARCHAR2 DEFAULT NULL,
    p_tablespaces OUT SYS_REFCURSOR
)
AS
BEGIN
    IF p_username IS NULL THEN
        OPEN p_tablespaces FOR
            SELECT DISTINCT tablespace_name
            FROM dba_tablespaces;
    ELSE
        open p_tablespaces for
            SELECT DISTINCT ts.tablespace_name
            FROM dba_tablespaces ts
            INNER JOIN dba_segments seg ON ts.tablespace_name = seg.tablespace_name
            INNER JOIN dba_users u ON seg.owner = u.username
            WHERE u.username = p_username;
    END IF;
END get_user_tablespaces;
/

CREATE OR REPLACE PROCEDURE get_datafile_info(p_cursor OUT SYS_REFCURSOR)
AS
BEGIN
    OPEN p_cursor FOR
        SELECT file_id, tablespace_name, file_name
        FROM dba_data_files;
END;
/


CREATE OR REPLACE TYPE datafile_info AS OBJECT (
    datafile_name VARCHAR2(100),
    datafile_path VARCHAR2(255),
    datafile_size VARCHAR2(20),
    autoextend VARCHAR2(10),
    autoextend_size VARCHAR2(20),
    maxsize VARCHAR2(20)
);
/

CREATE OR REPLACE TYPE DATAFILE_INFO_ARRAY AS TABLE OF DATAFILE_INFO;

select * from all_types where owner = 'ADMIN1';

CREATE OR REPLACE PROCEDURE create_tablespace (
    p_tablespace_name IN VARCHAR2,
    p_datafile_options IN datafile_info_array
)
AS
    v_sql VARCHAR2(1000);
BEGIN
    v_sql := 'CREATE TABLESPACE ' || p_tablespace_name || ' ';

    FOR i IN 1 .. p_datafile_options.COUNT LOOP
        v_sql := v_sql || 'DATAFILE ''' || p_datafile_options(i).datafile_name || ''' ';

        IF p_datafile_options(i).autoextend IS NOT NULL THEN
            v_sql := v_sql || 'AUTOEXTEND ' || p_datafile_options(i).autoextend || ' ';

            IF p_datafile_options(i).autoextend_size IS NOT NULL THEN
                v_sql := v_sql || 'NEXT ' || p_datafile_options(i).autoextend_size || ' ';
            END IF;

            IF p_datafile_options(i).maxsize IS NOT NULL THEN
                v_sql := v_sql || 'MAXSIZE ' || p_datafile_options(i).maxsize || ' ';
            END IF;
        END IF;

        IF i < p_datafile_options.COUNT THEN
            v_sql := v_sql || ', ';
        END IF;
    END LOOP;

    EXECUTE IMMEDIATE v_sql;
END create_tablespace;
/

CREATE OR REPLACE PROCEDURE get_tablespaces(p_cursor OUT SYS_REFCURSOR)
IS
BEGIN
    OPEN p_cursor FOR
        SELECT tablespace_name FROM dba_tablespaces;
END;
/

CREATE OR REPLACE PROCEDURE KillOtherSession(
    p_username     IN VARCHAR2,
    p_application  IN VARCHAR2
) IS
BEGIN
    FOR r IN (
        SELECT s.sid, s.serial#
        FROM v$session s
        JOIN v$process p ON s.paddr = p.addr
        WHERE s.username = UPPER(p_username)
          AND s.program = p_application
          AND s.sid <> (SELECT sid FROM v$mystat WHERE rownum = 1)
    )
    LOOP
        EXECUTE IMMEDIATE 'ALTER SYSTEM KILL SESSION ''' || r.sid || ',' || r.serial# || ''' IMMEDIATE';
    END LOOP;
END;
/

CREATE OR REPLACE PROCEDURE admin1.get_user_info (
    p_username IN VARCHAR2,
    p_cursor   OUT SYS_REFCURSOR
) AS
BEGIN
    OPEN p_cursor FOR
    SELECT
        username,
        created,
        expiry_date,
        account_status,
        last_login,
        profile
    FROM
        dba_users
    WHERE
        username = UPPER(p_username);
END;
/

CREATE OR REPLACE PROCEDURE admin1.get_last_login (
    p_username IN VARCHAR2,
    p_last_login OUT DATE
) AS
BEGIN
    SELECT last_login INTO p_last_login
    FROM dba_users
    WHERE username = UPPER(p_username);
END;
/

CREATE OR REPLACE PROCEDURE get_policies(p_cursor OUT SYS_REFCURSOR) AS
BEGIN
  open p_cursor for
    SELECT policy_name, object_name, object_owner FROM dba_policies;
END;
/

BEGIN
    DBMS_RLS.ADD_POLICY(
        object_schema => 'ADMIN1',
        object_name => 'BAILAM',
        policy_name => 'RESTRICT_BAILAM_ACCESS',
        function_schema => 'ADMIN1',
        policy_function => 'RESTRICT_BAILAM_ACCESS_FN',
        statement_types => 'SELECT',
        update_check => FALSE,
        enable => TRUE
    );
end;
/

CREATE OR REPLACE FUNCTION ADMIN1.RESTRICT_BAILAM_ACCESS_FN (
    schema_name IN VARCHAR2,
    object_name IN VARCHAR2
) RETURN VARCHAR2 AS
    v_predicate VARCHAR2(4000);
BEGIN
    IF SYS_CONTEXT('USERENV', 'SESSION_USER') IN ('DBA', 'ADMIN1') THEN
        v_predicate := '1=1';
    else
        v_predicate := 'UPPER(NGUOILAMBAI) = SYS_CONTEXT(''USERENV'', ''SESSION_USER'')';
    END IF;
    RETURN v_predicate;
END;
/

CREATE OR REPLACE PROCEDURE get_all_audit_trail(p_cursor OUT SYS_REFCURSOR)
IS
BEGIN
    OPEN p_cursor FOR
        SELECT * FROM DBA_AUDIT_TRAIL ORDER BY TIMESTAMP desc;
end;
/

audit select,update, insert on admin1.bailam;
audit select on admin1.nguoidung


select * from v$session where username = 'ADMIN1'
select * from bailam;
SELECT * FROM DBA_AUDIT_TRAIL WHERE OBJ_NAME = 'BAILAM' ORDER BY TIMESTAMP desc;

commit
select * from admin_role

SELECT * FROM admin1.admin_role where username='ADMIN1'

CREATE PROFILE manager_profile LIMIT
    SESSIONS_PER_USER UNLIMITED
    CPU_PER_SESSION UNLIMITED
    CPU_PER_CALL UNLIMITED
    CONNECT_TIME UNLIMITED
    IDLE_TIME UNLIMITED
    LOGICAL_READS_PER_SESSION UNLIMITED
    LOGICAL_READS_PER_CALL UNLIMITED
    COMPOSITE_LIMIT UNLIMITED
    PRIVATE_SGA UNLIMITED
    FAILED_LOGIN_ATTEMPTS 5
    PASSWORD_LIFE_TIME 180
    PASSWORD_REUSE_TIME 730
    PASSWORD_REUSE_MAX 5
    PASSWORD_VERIFY_FUNCTION NULL
    PASSWORD_LOCK_TIME 2/24
    PASSWORD_GRACE_TIME 15;


SELECT *
FROM DBA_PROFILES



CREATE OR REPLACE PROCEDURE GetProfileInfo(
    p_cursor OUT SYS_REFCURSOR
)
IS
BEGIN
    OPEN p_cursor FOR
    SELECT DISTINCT *
    FROM DBA_PROFILES;
END GetProfileInfo;



CREATE OR REPLACE PROCEDURE ThongTinProfile(
p_cursor OUT SYS_REFCURSOR) 
IS
BEGIN
    OPEN p_cursor FOR
    SELECT DISTINCT resource_name
    FROM DBA_PROFILES;
END ThongTinProfile;


CREATE OR REPLACE PROCEDURE AddNewProfile(
    p_profile_name IN VARCHAR2,
    p_password_life_time IN NUMBER,
    p_password_grace_time IN NUMBER,
    p_password_reuse_max IN NUMBER,
    p_password_reuse_time IN NUMBER,
    p_failed_login_attempts IN NUMBER,
    p_password_lock_time IN NUMBER
)
IS
BEGIN
    EXECUTE IMMEDIATE '
        CREATE PROFILE ' || p_profile_name || ' LIMIT
        PASSWORD_LIFE_TIME ' || p_password_life_time || '
        PASSWORD_GRACE_TIME ' || p_password_grace_time || '
        PASSWORD_REUSE_MAX ' || p_password_reuse_max || '
        PASSWORD_REUSE_TIME ' || p_password_reuse_time || '
        FAILED_LOGIN_ATTEMPTS ' || p_failed_login_attempts || '
        PASSWORD_LOCK_TIME ' || p_password_lock_time || ' ';
END;
/


DECLARE
BEGIN
    AddNewProfile(
        p_profile_name => 'TEST_PROFILE',
        p_usage_time => 30,
        p_password_change_limit => 60,
        p_max_login_attempts => 5,
        p_lockout_duration => 1
    );
END;
/
SELECT * FROM DBA_PROFILES WHERE PROFILE = 'TEST_PROFILE';






CREATE USER user2 IDENTIFIED BY 123 DEFAULT TABLESPACE users TEMPORARY TABLESPACE TEMP PROFILE PROFILE1;

SELECT username, profile, default_tablespace, temporary_tablespace
FROM dba_users

--CREATE OR REPLACE PROCEDURE GetUsersWithProfiles(
--    p_cursor OUT SYS_REFCURSOR
--) AS
--BEGIN
  --  OPEN p_cursor FOR
    --SELECT username, profile, default_tablespace, temporary_tablespace
   -- FROM dba_users;
--END;
--/


CREATE OR REPLACE PROCEDURE GetUsersWithProfiles(
    p_cursor OUT SYS_REFCURSOR
) AS
BEGIN
    OPEN p_cursor FOR
    SELECT username, profile, default_tablespace, temporary_tablespace, password
    FROM dba_users;
END;
/






SELECT username, profile
FROM dba_users
WHERE username = 'user2';

SELECT * FROM DBA_TABLESPACES;


--Xoa profile
CREATE OR REPLACE PROCEDURE DeleteProfile(
    p_profile_name IN VARCHAR2
)
IS
BEGIN
    EXECUTE IMMEDIATE 'DROP PROFILE ' || p_profile_name || ' CASCADE';
    DBMS_OUTPUT.PUT_LINE('Profile ' || p_profile_name || ' dropped successfully with CASCADE.');
EXCEPTION
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('Error dropping profile ' || p_profile_name || ': ' || SQLERRM);
END DeleteProfile;
/


DECLARE
BEGIN
    DeleteProfile('PROFILE22');
END;
/

SELECT * FROM DBA_PROFILES WHERE PROFILE = 'PROFILE22';

CREATE OR REPLACE PROCEDURE UpdateUserWithProfile (
    p_username IN VARCHAR2,
    p_new_password IN VARCHAR2,
    p_new_profile IN VARCHAR2
) IS
BEGIN
    -- Th?c hi?n câu l?nh SQL ?? s?a thông tin c?a user
    EXECUTE IMMEDIATE 'ALTER USER ' || p_username || 
                      ' IDENTIFIED BY "' || p_new_password || '"';
    
    -- Th?c hi?n câu l?nh SQL ?? thay ??i profile c?a user
    EXECUTE IMMEDIATE 'ALTER USER ' || p_username || ' PROFILE ' || p_new_profile;
    
    -- In ra thông báo hoàn thành
    DBMS_OUTPUT.PUT_LINE('User ' || p_username || ' has been updated successfully.');
EXCEPTION
    WHEN OTHERS THEN
        -- X? lý ngo?i l?, in ra l?i n?u có
        DBMS_OUTPUT.PUT_LINE('Error: ' || SQLERRM);
END UpdateUserWithProfile;

select * from dba_users where u?
CREATE OR REPLACE PROCEDURE DeleteUser(
    p_username IN VARCHAR2
)
IS
BEGIN
    EXECUTE IMMEDIATE 'DROP USER ' || p_username || ' CASCADE';
    DBMS_OUTPUT.PUT_LINE('User ' || p_username || ' deleted successfully.');
EXCEPTION
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('Error: ' || SQLERRM);
END DeleteUser;

CREATE OR REPLACE PROCEDURE GetCauHoiInfo(
    p_cursor OUT SYS_REFCURSOR
)
IS
BEGIN
    OPEN p_cursor FOR
    SELECT macauhoi, noidung, hinhanh, dapandung, dapansai1, dapansai2, dapansai3
    FROM cauhoi;
END GetCauHoiInfo;

Select * from cauhoi

CREATE DIRECTORY IMAGES AS 'D:\images';
GRANT READ,WRITE ON DIRECTORY IMAGES TO ADMIN1;

CREATE OR REPLACE PROCEDURE AddCauHoi(
    p_macauhoi IN NUMBER,
    p_noidung IN NVARCHAR2,
    p_hinhanh_filename IN VARCHAR2,
    p_dapandung IN NVARCHAR2,
    p_dapansai1 IN NVARCHAR2,
    p_dapansai2 IN NVARCHAR2,
    p_dapansai3 IN NVARCHAR2
)
IS
    l_bfile BFILE;
    l_blob BLOB;
    l_dest_offset INTEGER := 1;
    l_src_offset INTEGER := 1;
    l_lobmaxsize CONSTANT INTEGER := DBMS_LOB.LOBMAXSIZE;
BEGIN
    -- Thêm câu h?i v?i tr??ng hình ?nh là empty_blob()
    INSERT INTO cauhoi (macauhoi, noidung, hinhanh, dapandung, dapansai1, dapansai2, dapansai3)
    VALUES (p_macauhoi, p_noidung, empty_blob(), p_dapandung, p_dapansai1, p_dapansai2, p_dapansai3)
    RETURNING hinhanh INTO l_blob;
    
    -- M? file BFILE cho hình ?nh
    l_bfile := BFILENAME('IMAGES', p_hinhanh_filename);
    DBMS_LOB.fileopen(l_bfile, DBMS_LOB.file_readonly);
    
    -- Load d? li?u hình ?nh t? file vào BLOB
    DBMS_LOB.loadblobfromfile(l_blob, l_bfile, l_lobmaxsize, l_dest_offset, l_src_offset);
    
    -- ?óng file BFILE
    DBMS_LOB.fileclose(l_bfile);
    
    -- Hi?n th? kích th??c c?a hình ?nh
    DBMS_OUTPUT.PUT_LINE('Size of the Image is: ' || DBMS_LOB.GETLENGTH(l_blob));
    
    -- L?u các thay ??i
    COMMIT;
EXCEPTION
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('Error: ' || SQLERRM);
        ROLLBACK;
END AddCauHoi;



BEGIN
    AddCauHoi(
        p_macauhoi => 78,
        p_noidung => 'Câu h?i m?u?',
        p_hinhanh_filename => '3.jpg',
        p_dapandung => '?áp án ?úng',
        p_dapansai1 => '?áp án sai 1',
        p_dapansai2 => '?áp án sai 2',
        p_dapansai3 => '?áp án sai 3'
    );
END;
Select * from cauhoi where macauhoi=78
Select macauhoi from cauhoi
delete from cauhoi where macauhoi=5
INSERT INTO cauhoi (macauhoi, noidung, dapandung, dapansai1, dapansai2, dapansai3)
VALUES (6, 'cau hoi', 'dap an dung', 'dap an sai 1', 'dap an sai 2', 'dap an sai 3');



select * from dba_profiles

CREATE OR REPLACE PROCEDURE ChangeProfileAttribute(
    p_profile_name IN VARCHAR2,
    p_attribute_name IN VARCHAR2,
    p_new_value IN VARCHAR2
)
IS
BEGIN
    EXECUTE IMMEDIATE 'ALTER PROFILE ' || p_profile_name || ' LIMIT ' || p_attribute_name || ' ' || p_new_value;
    
    -- N?u không có l?i, thông báo thành công
    DBMS_OUTPUT.PUT_LINE('Thu?c tính c?a profile ' || p_profile_name || ' ?ã ???c thay ??i thành công.');
EXCEPTION
    WHEN OTHERS THEN
        -- N?u có l?i, hi?n th? thông báo l?i
        DBMS_OUTPUT.PUT_LINE('L?i: ' || SQLERRM);
END;


BEGIN
    ChangeProfileAttribute('HGVJCRK', 'SESSIONS_PER_USER', '1');
END;
/
--  p_password_verify_function => 'DEFAULT',
select * from dba_profiles where profile='HGVJCRK'

drop USER_CREATION_JOB



BEGIN
    DBMS_SCHEDULER.create_job (
        job_name        => 'USER_CREATION_JOB',
        job_type        => 'PLSQL_BLOCK',
        job_action      => 'BEGIN ProcessUserCreationQueue; END;',
        start_date      => SYSTIMESTAMP,
        repeat_interval => 'FREQ=MINUTELY; INTERVAL=1', -- Th?c hi?n m?i phút
        enabled         => TRUE
    );
END;

BEGIN
    DBMS_SCHEDULER.DROP_JOB('USER_CREATION_JOB');
END;
/
create user an identified by an
drop user an


-- Ki?m tra ng??i dùng m?i ?ã ???c t?o hay ch?a
SELECT * FROM DBA_USERS WHERE USERNAME = 'GB';
SELECT * FROM DBA_PROFILES WHERE PROFILE='FGHJK'
DROP PROFILE FGHJK CASCADE;

SELECT *  FROM DBA_TABLES WHERE OWNER='ADMIN1'

SELECT * FROM ADMIN_ROLE
SELECT * FROM BAITHI
SELECT * FROM BAILAM
SELECT * FROM NGUOIDUNG
SELECT * FROM CAUHOI
SELECT * FROM CHITIETBAILAM
SELECT * FROM CHITIETBAITHI


DELETE FROM baithi WHERE mabaithi = 1

CREATE OR REPLACE TRIGGER CheckThoiGianLamBai
BEFORE INSERT OR UPDATE ON baithi
FOR EACH ROW
BEGIN
    IF :NEW.thoigianlambai < 0 THEN
        RAISE_APPLICATION_ERROR(-20001, 'Th?i gian làm bài không ???c phép âm.');
    END IF;
END;
/



CREATE OR REPLACE TRIGGER restrict_logon_on_sunday
AFTER LOGON ON DATABASE
DECLARE
    v_day VARCHAR2(20);
BEGIN
    -- L?y ngày hi?n t?i
    SELECT TO_CHAR(SYSDATE, 'Day') INTO v_day FROM DUAL;

    -- Ki?m tra n?u ngày hi?n t?i là ch? nh?t (Sunday) thì ng?n ch?n ??ng nh?p
    IF TRIM(v_day) = 'Sunday' THEN
        RAISE_APPLICATION_ERROR(-20002, '??ng nh?p không ???c phép vào ngày ch? nh?t.');
    END IF;
END;
/
CREATE OR REPLACE PROCEDURE create_user_safely (
    p_username IN VARCHAR2,
    p_password IN VARCHAR2,
    p_profile  IN VARCHAR2
) IS
    v_day VARCHAR2(20);
BEGIN
    -- L?y ngày hi?n t?i
    SELECT TO_CHAR(SYSDATE, 'Day') INTO v_day FROM DUAL;

    -- Ki?m tra n?u ngày hi?n t?i là ch? nh?t (Sunday) thì ng?n ch?n t?o ng??i dùng
    IF TRIM(v_day) = 'Sunday' THEN
        RAISE_APPLICATION_ERROR(-20003, 'Không th? t?o ng??i dùng vào ngày ch? nh?t.');
    ELSE
        EXECUTE IMMEDIATE 'CREATE USER ' || p_username || 
                          ' IDENTIFIED BY "' || p_password || '"' ||
                          ' DEFAULT TABLESPACE users' ||
                          ' TEMPORARY TABLESPACE temp' ||
                          ' PROFILE ' || p_profile;
        EXECUTE IMMEDIATE 'GRANT CONNECT TO ' || p_username;
        EXECUTE IMMEDIATE 'GRANT RESOURCE TO ' || p_username;
    END IF;
END;
/

BEGIN
    create_user_safely('user91', '123', 'DEFAULT');
END;
/
select * from dba_users where username='USER91'



CREATE OR REPLACE PROCEDURE GetBaiThiInfo(
    p_cursor OUT SYS_REFCURSOR
)
IS
BEGIN
    OPEN p_cursor FOR
    SELECT *
    FROM BAITHI;
END GetBaiThiInfo;



CREATE OR REPLACE PROCEDURE AddBaiThi(
    p_mabaithi IN NUMBER,
    p_tenbaithi IN NVARCHAR2,
    p_mota IN NVARCHAR2,
    p_thoigianlambai IN NUMBER,
    p_nguoitao IN VARCHAR2,
    p_ngaytao IN DATE
) IS
BEGIN
    INSERT INTO baithi (mabaithi,tenbaithi,mota,thoigianlambai,nguoitao,ngaytao) 
    VALUES (p_mabaithi,p_tenbaithi, p_mota, p_thoigianlambai, p_nguoitao,p_ngaytao );

    COMMIT;
END AddBaiThi;
/

DELETE FROM baithi WHERE mabaithi = 5
-- Thêm b?n ghi vào b?ng baithi, v?i mabaithi b?t ??u t? 5
INSERT INTO baithi (mabaithi, tenbaithi, mota, thoigianlambai, nguoitao, ngaytao) VALUES
(4, 'BÃ i thi 2', 'MÃ´ táº£ bÃ i thi 4', 90, 'user2', TO_DATE('2023-06-10', 'YYYY-MM-DD'));
INSERT INTO baithi (mabaithi, tenbaithi, mota, thoigianlambai, nguoitao, ngaytao) VALUES
(5, 'BÃ i thi 2', 'MÃ´ táº£ bÃ i thi 5', 90, 'user2', TO_DATE('2023-06-15', 'YYYY-MM-DD'));
INSERT INTO baithi (mabaithi, tenbaithi, mota, thoigianlambai, nguoitao, ngaytao) VALUES
(6, 'BÃ i thi 2', 'MÃ´ táº£ bÃ i thi 6', -90, 'user2', TO_DATE('2023-06-15', 'YYYY-MM-DD'));
select * from chitietbaithi
INSERT INTO chitietbaithi (mactbt, mabaithi, macauhoi, thutucauhoi, dapandung) VALUES
(7, 3, 1, 1, 'A');
INSERT INTO chitietbaithi (mactbt, mabaithi, macauhoi, thutucauhoi, dapandung) VALUES
(6, 2, 2, 1, 'B');
commit
--xo?a mô?t ba?i thi thi chi tiet ba?i cung xo?a
CREATE OR REPLACE TRIGGER trg_delete_chitietbaithi
BEFORE DELETE ON baithi
FOR EACH ROW
BEGIN
    DELETE FROM chitietbaithi
    WHERE mabaithi = :OLD.mabaithi;
END;
/


drop TRIGGER delete_chitietbaithi_trigger
-- Xóa các b?n ghi trong b?ng chitietbaithi có mabaithi = 2
DELETE FROM chitietbaithi WHERE mabaithi = 2;
rollback
-- Ti?p theo, th?c hi?n xóa b?n ghi trong b?ng baithi có mabaithi = 2
-- Xóa m?t bài thi có mã bài thi là 1
DELETE FROM baithi WHERE mabaithi = 4;

-- Sau ?ó ki?m tra xem các b?n ghi trong chitietbaithi có mã bài thi là 1 ?ã b? xóa ch?a
SELECT * FROM chitietbaithi WHERE mabaithi = 4;



CREATE OR REPLACE PROCEDURE XoaBaiThi (
    p_mabaithi IN NUMBER
)
IS
BEGIN
    -- Xóa bài thi chính
    DELETE FROM baithi WHERE mabaithi = p_mabaithi;
    COMMIT; -- Xác nh?n các thay ??i
EXCEPTION
    WHEN OTHERS THEN
        ROLLBACK; 
        DBMS_OUTPUT.PUT_LINE('L?i: ' || SQLERRM);
END XoaBaiThi;
/
