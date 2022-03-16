USE HYT

---- Cài partition cho bảng DONHANG
ALTER DATABASE HYT ADD FILEGROUP FileGroup_DonHang_NgayNhap_1
ALTER DATABASE HYT ADD FILEGROUP FileGroup_DonHang_NgayNhap_2
ALTER DATABASE HYT ADD FILEGROUP FileGroup_DonHang_NgayNhap_3
ALTER DATABASE HYT ADD FILEGROUP FileGroup_DonHang_NgayNhap_4
ALTER DATABASE HYT ADD FILEGROUP FileGroup_DonHang_NgayNhap_5
ALTER DATABASE HYT ADD FILEGROUP FileGroup_DonHang_NgayNhap_6
ALTER DATABASE HYT ADD FILEGROUP FileGroup_DonHang_NgayNhap_7
ALTER DATABASE HYT ADD FILEGROUP FileGroup_DonHang_NgayNhap_8
ALTER DATABASE HYT ADD FILEGROUP FileGroup_DonHang_NgayNhap_9
ALTER DATABASE HYT ADD FILEGROUP FileGroup_DonHang_NgayNhap_10
ALTER DATABASE HYT ADD FILEGROUP FileGroup_DonHang_NgayNhap_11


Alter Database HYT
 ADD File 
 (
 Name = N'FileGroup_DonHang_NgayNhap_1',
 FileName = N'C:\Program Files\Microsoft SQL Server\MSSQL15.NAT\MSSQL\DATA\FileGroup_DonHang_NgayNhap_1.ndf',
	SIZE = 80MB,
	MAXSIZE = 2200,
	FILEGROWTH = 1024MB 
 )
 To FileGroup  FileGroup_DonHang_NgayNhap_1;
 GO


Alter Database HYT
 ADD File 
 (
 Name = N'FileGroup_DonHang_NgayNhap_3',
 FileName = N'C:\Program Files\Microsoft SQL Server\MSSQL15.NAT\MSSQL\DATA\FileGroup_DonHang_NgayNhap_3.ndf',
	SIZE = 80MB,
	MAXSIZE = 2200,
	FILEGROWTH = 1024MB 
 )
 To FileGroup  FileGroup_DonHang_NgayNhap_3;
 GO


 Alter Database HYT
 ADD File 
 (
 Name = N'FileGroup_DonHang_NgayNhap_5',
 FileName = N'C:\Program Files\Microsoft SQL Server\MSSQL15.NAT\MSSQL\DATA\FileGroup_DonHang_NgayNhap_5.ndf',
	SIZE = 80MB,
	MAXSIZE = 2200,
	FILEGROWTH = 1024MB 
 )
 To FileGroup  FileGroup_DonHang_NgayNhap_5;
 GO

 Alter Database HYT
 ADD File 
 (
 Name = N'FileGroup_DonHang_NgayNhap_7',
 FileName = N'C:\Program Files\Microsoft SQL Server\MSSQL15.NAT\MSSQL\DATA\FileGroup_DonHang_NgayNhap_7.ndf',
	SIZE = 80MB,
	MAXSIZE = 2200,
	FILEGROWTH = 1024MB 
 )
 To FileGroup  FileGroup_DonHang_NgayNhap_7;
 GO

 Alter Database HYT
 ADD File 
 (
 Name = N'FileGroup_DonHang_NgayNhap_9',
 FileName = N'C:\Program Files\Microsoft SQL Server\MSSQL15.NAT\MSSQL\DATA\FileGroup_DonHang_NgayNhap_9.ndf',
	SIZE = 80MB,
	MAXSIZE = 2200,
	FILEGROWTH = 1024MB 
 )
 To FileGroup  FileGroup_DonHang_NgayNhap_9;
 GO

 Alter Database HYT
 ADD File 
 (
 Name = N'FileGroup_DonHang_NgayNhap_11',
 FileName = N'C:\Program Files\Microsoft SQL Server\MSSQL15.NAT\MSSQL\DATA\FileGroup_DonHang_NgayNhap_11.ndf',
	SIZE = 80MB,
	MAXSIZE = 2200,
	FILEGROWTH = 1024MB 
 )
 To FileGroup  FileGroup_DonHang_NgayNhap_11;
 GO

 Alter Database HYT
 ADD File 
 (
 Name = N'FileGroup_DonHang_NgayNhap_2',
 FileName = N'C:\Program Files\Microsoft SQL Server\MSSQL15.NAT\MSSQL\DATA\FileGroup_DonHang_NgayNhap_2.ndf',
	SIZE = 80MB,
	MAXSIZE = 2200,
	FILEGROWTH = 1024MB 
 )
 To FileGroup  FileGroup_DonHang_NgayNhap_2;
 GO

 Alter Database HYT
 ADD File 
 (
 Name = N'FileGroup_DonHang_NgayNhap_4',
 FileName = N'C:\Program Files\Microsoft SQL Server\MSSQL15.NAT\MSSQL\DATA\FileGroup_DonHang_NgayNhap_4.ndf',
	SIZE = 80MB,
	MAXSIZE = 2200,
	FILEGROWTH = 1024MB 
 )
 To FileGroup  FileGroup_DonHang_NgayNhap_4;
 GO

 Alter Database HYT
 ADD File 
 (
 Name = N'FileGroup_DonHang_NgayNhap_6',
 FileName = N'C:\Program Files\Microsoft SQL Server\MSSQL15.NAT\MSSQL\DATA\FileGroup_DonHang_NgayNhap_6.ndf',
	SIZE = 80MB,
	MAXSIZE = 2200,
	FILEGROWTH = 1024MB 
 )
 To FileGroup  FileGroup_DonHang_NgayNhap_6;
 GO

 Alter Database HYT
 ADD File 
 (
 Name = N'FileGroup_DonHang_NgayNhap_8',
 FileName = N'C:\Program Files\Microsoft SQL Server\MSSQL15.NAT\MSSQL\DATA\FileGroup_DonHang_NgayNhap_8.ndf',
	SIZE = 80MB,
	MAXSIZE = 2200,
	FILEGROWTH = 1024MB 
 )
 To FileGroup  FileGroup_DonHang_NgayNhap_8;
 GO

 Alter Database HYT
 ADD File 
 (
 Name = N'FileGroup_DonHang_NgayNhap_10',
 FileName = N'C:\Program Files\Microsoft SQL Server\MSSQL15.NAT\MSSQL\DATA\FileGroup_DonHang_NgayNhap_10.ndf',
	SIZE = 80MB,
	MAXSIZE = 2200,
	FILEGROWTH = 1024MB 
 )
 To FileGroup  FileGroup_DonHang_NgayNhap_10;
 GO


 USE HYT
 CREATE PARTITION FUNCTION DonHangNgayNhap_PartitionFunction (DATE)
 AS RANGE RIGHT FOR VALUES ('2021-1-1','2021-2-1','2021-3-1','2021-4-1','2021-5-1','2021-6-1','2021-7-11','2021-8-1','2021-9-1','2021-10-1','2021-11-1')
GO


CREATE PARTITION SCHEME DonHangNgayNhap_PartitionSchema
AS PARTITION DonHangNgayNhap_PartitionFunction TO ( [PRIMARY], FileGroup_DonHang_NgayNhap_1, FileGroup_DonHang_NgayNhap_2, FileGroup_DonHang_NgayNhap_3, FileGroup_DonHang_NgayNhap_4, FileGroup_DonHang_NgayNhap_5, FileGroup_DonHang_NgayNhap_6, FileGroup_DonHang_NgayNhap_7, FileGroup_DonHang_NgayNhap_8, FileGroup_DonHang_NgayNhap_9, FileGroup_DonHang_NgayNhap_10,FileGroup_DonHang_NgayNhap_11,[PRIMARY] )


CREATE NONCLUSTERED INDEX [PK_NgayNhapDonHang]
ON  [dbo].[DONHANG](NGAYLAP)
ON  [DonHangNgayNhap_PartitionSchema](NGAYLAP)
GO