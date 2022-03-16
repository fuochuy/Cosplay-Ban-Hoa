--use master
USE HYT
GO

INSERT INTO TAIKHOAN
VALUES
	('1','KH','123',1,'0123456789','KH@GMAIL.COM',N'21/2 Trần Phú, Phường 3, Quận 3, TP.HCM'),
	('2','QT','123',0,'0125456789','QT@GMAIL.COM',N'2 Nguyễn Văn Cừ, Phường 9, Quận 12, TP.HCM'),
	('3','QL','123',4,'0123456788','QL@GMAIL.COM',N'1 Trương Công Định, Phường Linh Trung, TP. Thủ Đức, TP.HCM'),
	('4','NV','123',2,'0134456789','NV@GMAIL.COM','123 Nguyễn Văn Cừ, Phường 3, Quận 5, TP.HCM'),
	('5','NS','123',3,'0789789789','NS@GMAIL.COM','21/2 Trần Phú, Phường 3, Quận 1, TP.HCM'),
	('6','TX','123',3,'0712312389','TX@GMAIL.COM','21/2 LÊ DUẨN, Phường 12, Quận 10, TP.HCM')
GO

INSERT INTO CHINHANH
VALUES
	('CN1',N'Chi nhánh Quận 1',N'Phường Đa Kao',N'TP.HCM',N'Q1'),
	('CN2',N'Chi nhánh Thủ Đức',N'Phường Linh Trung',N'TP.HCM',N'TP. Thủ Đức'),
	('CN3',N'Chi nhánh Quận 3',N'Phường 3',N'TP.HCM',N'Q3'),
	('CN4',N'Chi nhánh Quận 4',N'Phường 4',N'TP.HCM',N'Q4'),
	('CN5',N'Chi nhánh Quận 5',N'Phường 5',N'TP.HCM',N'Q5')
GO

INSERT INTO NHANVIEN(MANV,ID, TENNV, LOAINV, CHINHANHLV)
VALUES
	('NV1','4',N'Kim Jisoo',1,'CN1'),
	('NV2','5',N'Kim Jennie',2,'CN2'),
	('NV3','3',N'Park Chaeyoung',0,'CN3')
GO

INSERT INTO SANPHAM
VALUES
	('SP1',N'SNOW DROP',N'hoa hồng','https://www.pinterest.com/pin/756956649877065867/',N'HOA SIU DEP',150000,N'999 bong hwa hong',0,999),
	('SP2',N'lovesick girls',N'hoa hướng dương','https://www.pinterest.com/pin/68742994984/',N'HOA SIU DEP',150000,N'doi hwa mat troi',0,10),
	('SP3',N'stay',N'hoa tulip','https://www.pinterest.com/pin/443393525823105628/',N'HOA SIU DEP',10000,N'doi hwa mat troi',0,1),
	('SP4',N'2AM',N'hoa ly','https://www.pinterest.com/pin/422281206039061/',N'HOA SIU DEP',50000,N'hoa tang nguoi yeu cu',10,7),
	('SP5',N'Hoa biet ly',N'hoa ly','https://www.pinterest.com/pin/35043703341935787/',N'HOA SIU thom',1500000,N'hoa dep hoa thom hoa so 1',15,15)
GO

INSERT INTO SANPHAM_CHINHANH
VALUES
	('SP1','CN1'),
	('SP2','CN2'),
	('SP3','CN3'),
	('SP4','CN4'),
	('SP5','CN5')
GO

INSERT INTO LUUVETGIA
VALUES
	('SP1','12/27/2021',170000),
	('SP2','12/27/2021',200000),
	('SP3','12/27/2021',70000),
	('SP4','12/27/2021',1700000),
	('SP5','12/27/2021',2000000)
GO

INSERT INTO CHUDE
VALUES 
	('CD1','Hoa sinh nhật'),
	('CD2','Hoa chúc mừng'),
	('CD3','Hoa khai trương'),
	('CD4','Hoa tình yêu'),
	('CD5','Hoa mừng tốt nghiệp')
GO

INSERT INTO CHUDE_SANPHAM
VALUES 
	('CD1','SP1'),
	('CD2','SP2'),
	('CD3','SP3'),
	('CD4','SP4'),
	('CD5','SP5')
GO

INSERT INTO GIAMGIA
VALUES
	('SP1',10000,'12/20/2021','12/25/2021'),
	('SP2',10000,'12/20/2021','12/25/2021'),
	('SP3',10000,'12/20/2021','12/25/2021'),
	('SP4',10000,'12/20/2021','12/25/2021'),
	('SP5',10000,'12/20/2021','12/25/2021')
GO

INSERT INTO KHACHHANG
VALUES
	('KH1','1',N'Monkey D. Luffy','30001505'),
	('KH2','1',N'Roronoa Zoro','14785269'),
	('KH3','1',N'Vinsmoke Sanji','1425973'),
	('KH4','1',N'Tony Tony Chopper','31541505'),
	('KH5','1',N'Donquixote Doflamingo','999999')
GO

INSERT INTO DONHANG
VALUES
	('DH1','KH1','NV1',N'Peter Parker',N'1 Đường 1, Phường Đa Kao, Quận 1, TP.HCM','012458633',30000,0,'12/29/2021','12/28/2021',2,0),
	('DH2','KH2','NV2',N'Tony Stark',N'2 Đường 2, Phường 2, Quận 2, TP.HCM','0141123633',30000,0,'12/30/2021','12/28/2021',0,0)
GO

INSERT INTO CT_DONHANG
VALUES
	('DH2','SP3',10,150000),
	('DH1','SP3',15,150000),
	('DH1','SP4',10,150000),
	('DH1','SP5',2,150000),
	('DH1','SP1',1,150000),
	('DH2','SP1',1,150000),
	('DH2','SP2',1,150000)
GO

INSERT INTO DIEMDANH
VALUES
	('NV1','12/28/2021'),
	('NV2','12/24/2021'),
	('NV3','12/26/2021')
GO

INSERT INTO LUONG
VALUES
	('NV1','12/28/2021',5000000),
	('NV2','12/24/2021',7000000),
	('NV3','12/26/2021',10000000)
GO

INSERT INTO TAIXE
VALUES
	('TX1','6','GDragon','251210088',N'Quận 1, TPHCM','01212121','51F1-12345'),
	('TX2','6','MTP','251219922',N'Quận 2, TPHCM','01154231','51F1-65789'),
	('TX3','6','TOP','25121458',N'Quận 10, TPHCM','0145871','51F1-66666')
GO

INSERT INTO XULI_DONHANG
VALUES
	('DH1','TX1','12/28/2021',NULL),
	('DH2',NULL,NULL,NULL)
GO

INSERT INTO LICHSUNHAP
VALUES
	('SP1','12/12/2021','NV1',1000,110000),
	('SP1','12/20/2021','NV1',1000,100000),
	('SP2','12/20/2021','NV2',10,100000),
	('SP3','12/20/2021','NV1',10,5000),
	('SP4','12/20/2021','NV1',50,30000),
	('SP5','12/20/2021','NV3',30,500000)