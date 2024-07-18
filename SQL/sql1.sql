-- @sys
CREATE USER admin1 identified BY "Orcl1234";
grant dba to admin1;
grant all privileges to admin1;
grant select any dictionary to admin1;
--nay loi
insert into admin_role values ('admin1');

create user user1 identified by "Orcl1234";
grant create session to user1;
------
grant select on admin1.bailam to user1;
select * from admin1.admin_role
-- @admin1
create tablespace testtablespace
DATAFILE 'testtblsp.dbf'
size 100M
autoextend off;

create table admin_role (
  username varchar2(100) primary key
) tablespace testtablespace;

insert into admin_role values ('ADMIN1');

create table nguoidung (
  tendangnhap varchar(50) primary key,
  hoten nvarchar2(255) not null,
  ngaysinh date,
  email nchar(255)
) tablespace TestTablespace;

create table cauhoi (
  macauhoi number primary key,
  noidung nvarchar2(1000),
  hinhanh blob,
  dapandung nvarchar2(1000),
  dapansai1 nvarchar2(1000),
  dapansai2 nvarchar2(1000),
  dapansai3 nvarchar2(1000)
) tablespace testtablespace;

create table baithi (
  mabaithi number primary key,
  tenbaithi nvarchar2(255),
  mota nvarchar2(400),
  thoigianlambai number,
  nguoitao varchar(50),
  ngaytao date,
  constraint fk_baithi_nguoitao foreign key(nguoitao) references nguoidung(tendangnhap)
) tablespace testtablespace;

create table bailam (
  mabailam number primary key,
  nguoilambai varchar(50),
  mabaithi number,
  ngaylam date,
  constraint fk_bailam_nguoilambai foreign key(nguoilambai) references nguoidung(tendangnhap),
  constraint fk_bailam_baithi foreign key(mabaithi) references baithi(mabaithi)
) tablespace TestTablespace;

create table chitietbailam(
  mactbl number primary key,
  mabailam number,
  thutucauhoi number,
  dapandachon char(1),
  constraint fk_chitietbailam_bailam foreign key(mabailam) references bailam(mabailam)
) tablespace TestTablespace;

create table chitietbaithi(
  mactbt number primary key,
  mabaithi number,
  macauhoi number,
  thutucauhoi number,
  dapandung char(1),
  constraint fk_chitietbaithi_baithi foreign key(mabaithi) references baithi(mabaithi),
  constraint fk_chitietbaithi_cauhoi foreign key(macauhoi) references cauhoi(macauhoi)
) tablespace testtablespace;
-- sys
DROP DIRECTORY IMAGES;

CREATE DIRECTORY IMAGES AS 'D:\images';
GRANT READ,WRITE ON DIRECTORY IMAGES TO ADMIN1;
select * from cauhoi

-- admin1
INSERT INTO nguoidung (tendangnhap, hoten, ngaysinh, email) VALUES
('user1', 'NgÆ°á»?i dÃ¹ng 1', TO_DATE('2000-01-01', 'YYYY-MM-DD'), 'user1@example.com');
INSERT INTO nguoidung (tendangnhap, hoten, ngaysinh, email) VALUES
('user2', 'NgÆ°á»?i dÃ¹ng 2', TO_DATE('1995-05-10', 'YYYY-MM-DD'), 'user2@example.com');
INSERT INTO nguoidung (tendangnhap, hoten, ngaysinh, email) VALUES
('user3', 'NgÆ°á»?i dÃ¹ng 3', TO_DATE('1988-11-15', 'YYYY-MM-DD'), 'user3@example.com');
INSERT INTO nguoidung (tendangnhap, hoten, ngaysinh, email) VALUES
('user4', 'NgÆ°á»?i dÃ¹ng 4', TO_DATE('1992-03-20', 'YYYY-MM-DD'), 'user4@example.com');
INSERT INTO nguoidung (tendangnhap, hoten, ngaysinh, email) VALUES
('user5', 'NgÆ°á»?i dÃ¹ng 5', TO_DATE('1997-07-25', 'YYYY-MM-DD'), 'user5@example.com');

INSERT INTO cauhoi (macauhoi, noidung, dapandung, dapansai1, dapansai2, dapansai3)
VALUES (1, 'Ná»™i dung cÃ¢u há»?i 1', 'Ä?Ã¡p Ã¡n Ä‘Ãºng cho cÃ¢u há»?i 1', 'Ä?Ã¡p Ã¡n sai 1 cho cÃ¢u há»?i 1', 'Ä?Ã¡p Ã¡n sai 2 cho cÃ¢u há»?i 1', 'Ä?Ã¡p Ã¡n sai 3 cho cÃ¢u há»?i 1');

//ko dc   da chay ?c
select * from cauhoi
DECLARE
  l_bfile BFILE;
  l_blob BLOB;
  l_dest_offset INTEGER := 1;
  l_src_offset INTEGER := 1;
  l_lobmaxsize CONSTANT INTEGER := DBMS_LOB.LOBMAXSIZE;
BEGIN
  -- Xác ??nh câu h?i c?n c?p nh?t
  UPDATE cauhoi
  SET hinhanh = empty_blob()
  WHERE macauhoi = 1
  RETURNING hinhanh INTO l_blob;
  l_bfile := BFILENAME('IMAGES', '3.jpg');
  DBMS_LOB.fileopen(l_bfile, DBMS_LOB.file_readonly);
  
  -- N?p d? li?u hình ?nh t? file vào BLOB
  DBMS_LOB.loadblobfromfile(l_blob, l_bfile, l_lobmaxsize, l_dest_offset, l_src_offset);
  
  -- ?óng file
  DBMS_LOB.fileclose(l_bfile);
  DBMS_OUTPUT.PUT_LINE('Size of the Image is: ' || DBMS_LOB.GETLENGTH(l_blob));
  COMMIT;
END;




DECLARE
  l_bfile BFILE;
  l_blob BLOB;
  l_dest_offset INTEGER := 1;
  l_src_offset INTEGER := 1;
  l_lobmaxsize CONSTANT INTEGER := DBMS_LOB.LOBMAXSIZE;
BEGIN
  insert into cauhoi (macauhoi, noidung, hinhanh, dapandung, dapansai1, dapansai2, dapansai3)
  VALUES (100, 'Ná»™i dung cÃ¢u há»?i 2', empty_blob(), 'Ä?Ã¡p Ã¡n Ä‘Ãºng 2', 'Ä?Ã¡p Ã¡n sai 1 cho cÃ¢u há»?i 2', 'Ä?Ã¡p Ã¡n sai 2 cho cÃ¢u há»?i 2', 'Ä?Ã¡p Ã¡n sai 3 cho cÃ¢u há»?i 2')
  RETURNING hinhanh INTO l_blob;
  
  l_bfile := BFILENAME('IMAGES', '1.jpg');
  DBMS_LOB.fileopen(l_bfile, DBMS_LOB.file_readonly);
  DBMS_LOB.loadblobfromfile(l_blob, l_bfile, l_lobmaxsize, l_dest_offset, l_src_offset);
  DBMS_LOB.fileclose(l_bfile);
  DBMS_OUTPUT.PUT_LINE('Size of the Image is: ' || DBMS_LOB.GETLENGTH(l_blob));
  COMMIT;
end;




DECLARE
  l_bfile BFILE;
  l_blob BLOB;
  l_dest_offset INTEGER := 1;
  l_src_offset INTEGER := 1;
  l_lobmaxsize CONSTANT INTEGER := DBMS_LOB.LOBMAXSIZE;
BEGIN
  insert into cauhoi (macauhoi, noidung, hinhanh, dapandung, dapansai1, dapansai2, dapansai3)
  VALUES (2, 'N?i dung câu h?i 2', empty_blob(), '?áp án ?úng 2', '?áp án sai 1 cho câu h?i 2', '?áp án sai 2 cho câu h?i 2', '?áp án sai 3 cho câu h?i 2')
  RETURNING hinhanh INTO l_blob;
  
  l_bfile := BFILENAME('IMAGES', '2.jpg');
  DBMS_LOB.fileopen(l_bfile, DBMS_LOB.file_readonly);
  DBMS_LOB.loadblobfromfile(l_blob, l_bfile, l_lobmaxsize, l_dest_offset, l_src_offset);
  DBMS_LOB.fileclose(l_bfile);
  DBMS_OUTPUT.PUT_LINE('Size of the Image is: ' || DBMS_LOB.GETLENGTH(l_blob));
  COMMIT;
END;

//den day

INSERT INTO baithi (mabaithi, tenbaithi, mota, thoigianlambai, nguoitao, ngaytao) VALUES
(1, 'BÃ i thi 1', 'MÃ´ táº£ bÃ i thi 1', 60, 'user1', TO_DATE('2023-05-01', 'YYYY-MM-DD'));
INSERT INTO baithi (mabaithi, tenbaithi, mota, thoigianlambai, nguoitao, ngaytao) VALUES
(2, 'BÃ i thi 2', 'MÃ´ táº£ bÃ i thi 2', 90, 'user2', TO_DATE('2023-06-15', 'YYYY-MM-DD'));
INSERT INTO baithi (mabaithi, tenbaithi, mota, thoigianlambai, nguoitao, ngaytao) VALUES
(3, 'BÃ i thi 2', 'MÃ´ táº£ bÃ i thi 2', -90, 'user2', TO_DATE('2023-06-15', 'YYYY-MM-DD'));

INSERT INTO bailam (mabailam, nguoilambai, mabaithi, ngaylam) VALUES
(1, 'user3', 1, TO_DATE('2023-05-02', 'YYYY-MM-DD'));
INSERT INTO bailam (mabailam, nguoilambai, mabaithi, ngaylam) VALUES
(2, 'user4', 2, TO_DATE('2023-06-16', 'YYYY-MM-DD'));
insert into bailam (mabailam, nguoilambai, mabaithi, ngaylam) values
(3, 'user1', 2, TO_DATE('2023-06-16', 'YYYY-MM-DD'));

//ko dc
INSERT INTO chitietbaithi (mactbt, mabaithi, macauhoi, thutucauhoi, dapandung) VALUES
(1, 1, 1, 1, 'A');
INSERT INTO chitietbaithi (mactbt, mabaithi, macauhoi, thutucauhoi, dapandung) VALUES
(2, 1, 2, 2, 'B');
INSERT INTO chitietbaithi (mactbt, mabaithi, macauhoi, thutucauhoi, dapandung) VALUES
(3, 2, 1, 1, 'A');
INSERT INTO chitietbaithi (mactbt, mabaithi, macauhoi, thutucauhoi, dapandung) VALUES
(4, 2, 2, 2, 'B');
//den day
commit


INSERT INTO chitietbailam (mactbl, mabailam, thutucauhoi, dapandachon) VALUES
(1, 1, 1, 'A');
INSERT INTO chitietbailam (mactbl, mabailam, thutucauhoi, dapandachon) VALUES
(2, 1, 2, 'C');
INSERT INTO chitietbailam (mactbl, mabailam, thutucauhoi, dapandachon) VALUES
(3, 2, 1, 'B');
INSERT INTO chitietbailam (mactbl, mabailam, thutucauhoi, dapandachon) VALUES
(4, 2, 2, 'A');
commit