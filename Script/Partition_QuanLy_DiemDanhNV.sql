
-- PARTITION CHO BẢNG ĐIỂM DANH

-- Create filegroup for database
ALTER DATABASE HYT ADD FILEGROUP FileGroup_DiemDanh_1_2020
ALTER DATABASE HYT ADD FILEGROUP FileGroup_DiemDanh_2_2020
ALTER DATABASE HYT ADD FILEGROUP FileGroup_DiemDanh_3_2020
ALTER DATABASE HYT ADD FILEGROUP FileGroup_DiemDanh_4_2020
ALTER DATABASE HYT ADD FILEGROUP FileGroup_DiemDanh_5_2020
ALTER DATABASE HYT ADD FILEGROUP FileGroup_DiemDanh_6_2020
ALTER DATABASE HYT ADD FILEGROUP FileGroup_DiemDanh_7_2020
ALTER DATABASE HYT ADD FILEGROUP FileGroup_DiemDanh_8_2020
ALTER DATABASE HYT ADD FILEGROUP FileGroup_DiemDanh_9_2020
ALTER DATABASE HYT ADD FILEGROUP FileGroup_DiemDanh_10_2020
ALTER DATABASE HYT ADD FILEGROUP FileGroup_DiemDanh_11_2020
ALTER DATABASE HYT ADD FILEGROUP FileGroup_DiemDanh_12_2020
ALTER DATABASE HYT ADD FILEGROUP FileGroup_DiemDanh_1_2021
ALTER DATABASE HYT ADD FILEGROUP FileGroup_DiemDanh_2_2021
ALTER DATABASE HYT ADD FILEGROUP FileGroup_DiemDanh_3_2021
ALTER DATABASE HYT ADD FILEGROUP FileGroup_DiemDanh_4_2021
ALTER DATABASE HYT ADD FILEGROUP FileGroup_DiemDanh_5_2021
ALTER DATABASE HYT ADD FILEGROUP FileGroup_DiemDanh_6_2021
ALTER DATABASE HYT ADD FILEGROUP FileGroup_DiemDanh_7_2021
ALTER DATABASE HYT ADD FILEGROUP FileGroup_DiemDanh_8_2021
ALTER DATABASE HYT ADD FILEGROUP FileGroup_DiemDanh_9_2021
ALTER DATABASE HYT ADD FILEGROUP FileGroup_DiemDanh_10_2021
ALTER DATABASE HYT ADD FILEGROUP FileGroup_DiemDanh_11_2021
ALTER DATABASE HYT ADD FILEGROUP FileGroup_DiemDanh_12_2021
GO

--- Create Data files in respective filegroup
--- Phan filename cua tung file nho doi lai dia chi tao file
Alter Database HYT
 ADD File 
 (
 Name = N'FileGroup_DiemDanh_1_2020',
 FileName = N'C:\Program Files\Microsoft SQL Server\MSSQL15.NAT\MSSQL\DATA\FileGroup_DiemDanh_1_2020.ndf',
	SIZE = 80MB,
	MAXSIZE = 2200,
	FILEGROWTH = 1024MB 
 )
 To FileGroup FileGroup_DiemDanh_1_2020;
 GO
 
 Alter Database HYT
 ADD File 
 (
 Name = N'FileGroup_DiemDanh_2_2020',
 FileName = N'C:\Program Files\Microsoft SQL Server\MSSQL15.NAT\MSSQL\DATA\FileGroup_DiemDanh_2_2020.ndf',
	SIZE = 80MB,
	MAXSIZE = 2200,
	FILEGROWTH = 1024MB 
 )
 To FileGroup FileGroup_DiemDanh_2_2020;
 GO

 Alter Database HYT
 ADD File 
 (
 Name = N'FileGroup_DiemDanh_3_2020',
 FileName = N'C:\Program Files\Microsoft SQL Server\MSSQL15.NAT\MSSQL\DATA\FileGroup_DiemDanh_3_2020.ndf',
	SIZE = 80MB,
	MAXSIZE = 2200,
	FILEGROWTH = 1024MB 
 )
 To FileGroup FileGroup_DiemDanh_3_2020;
 GO

 Alter Database HYT
 ADD File 
 (
 Name = N'FileGroup_DiemDanh_4_2020',
 FileName = N'C:\Program Files\Microsoft SQL Server\MSSQL15.NAT\MSSQL\DATA\FileGroup_DiemDanh_4_2020.ndf',
	SIZE = 80MB,
	MAXSIZE = 2200,
	FILEGROWTH = 1024MB 
 )
 To FileGroup FileGroup_DiemDanh_4_2020;
 GO

 Alter Database HYT
 ADD File 
 (
 Name = N'FileGroup_DiemDanh_5_2020',
 FileName = N'C:\Program Files\Microsoft SQL Server\MSSQL15.NAT\MSSQL\DATA\FileGroup_DiemDanh_5_2020.ndf',
	SIZE = 80MB,
	MAXSIZE = 2200,
	FILEGROWTH = 1024MB 
 )
 To FileGroup FileGroup_DiemDanh_5_2020;
 GO

 Alter Database HYT
 ADD File 
 (
 Name = N'FileGroup_DiemDanh_6_2020',
 FileName = N'C:\Program Files\Microsoft SQL Server\MSSQL15.NAT\MSSQL\DATA\FileGroup_DiemDanh_6_2020.ndf',
	SIZE = 80MB,
	MAXSIZE = 2200,
	FILEGROWTH = 1024MB 
 )
 To FileGroup FileGroup_DiemDanh_6_2020;
 GO

 Alter Database HYT
 ADD File 
 (
 Name = N'FileGroup_DiemDanh_7_2020',
 FileName = N'C:\Program Files\Microsoft SQL Server\MSSQL15.NAT\MSSQL\DATA\FileGroup_DiemDanh_7_2020.ndf',
	SIZE = 80MB,
	MAXSIZE = 2200,
	FILEGROWTH = 1024MB 
 )
 To FileGroup FileGroup_DiemDanh_7_2020;
 GO

 Alter Database HYT
 ADD File 
 (
 Name = N'FileGroup_DiemDanh_8_2020',
 FileName = N'C:\Program Files\Microsoft SQL Server\MSSQL15.NAT\MSSQL\DATA\FileGroup_DiemDanh_8_2020.ndf',
	SIZE = 80MB,
	MAXSIZE = 2200,
	FILEGROWTH = 1024MB 
 )
 To FileGroup FileGroup_DiemDanh_8_2020;
 GO

 Alter Database HYT
 ADD File 
 (
 Name = N'FileGroup_DiemDanh_9_2020',
 FileName = N'C:\Program Files\Microsoft SQL Server\MSSQL15.NAT\MSSQL\DATA\FileGroup_DiemDanh_9_2020.ndf',
	SIZE = 80MB,
	MAXSIZE = 2200,
	FILEGROWTH = 1024MB 
 )
 To FileGroup FileGroup_DiemDanh_9_2020;
 GO

 Alter Database HYT
 ADD File 
 (
 Name = N'FileGroup_DiemDanh_10_2020',
 FileName = N'C:\Program Files\Microsoft SQL Server\MSSQL15.NAT\MSSQL\DATA\FileGroup_DiemDanh_10_2020.ndf',
	SIZE = 80MB,
	MAXSIZE = 2200,
	FILEGROWTH = 1024MB 
 )
 To FileGroup FileGroup_DiemDanh_10_2020;
 GO

 Alter Database HYT
 ADD File 
 (
 Name = N'FileGroup_DiemDanh_11_2020',
 FileName = N'C:\Program Files\Microsoft SQL Server\MSSQL15.NAT\MSSQL\DATA\FileGroup_DiemDanh_11_2020.ndf',
	SIZE = 80MB,
	MAXSIZE = 2200,
	FILEGROWTH = 1024MB 
 )
 To FileGroup FileGroup_DiemDanh_11_2020;
 GO

 Alter Database HYT
 ADD File 
 (
 Name = N'FileGroup_DiemDanh_12_2020',
 FileName = N'C:\Program Files\Microsoft SQL Server\MSSQL15.NAT\MSSQL\DATA\FileGroup_DiemDanh_12_2020.ndf',
	SIZE = 80MB,
	MAXSIZE = 2200,
	FILEGROWTH = 1024MB 
 )
 To FileGroup FileGroup_DiemDanh_12_2020;
 GO


-- 2021
Alter Database HYT
 ADD File 
 (
 Name = N'FileGroup_DiemDanh_1_2021',
 FileName = N'C:\Program Files\Microsoft SQL Server\MSSQL15.NAT\MSSQL\DATA\FileGroup_DiemDanh_1_2021.ndf',
	SIZE = 80MB,
	MAXSIZE = 2200,
	FILEGROWTH = 1024MB 
 )
 To FileGroup FileGroup_DiemDanh_1_2021;
 GO
 
 Alter Database HYT
 ADD File 
 (
 Name = N'FileGroup_DiemDanh_2_2021',
 FileName = N'C:\Program Files\Microsoft SQL Server\MSSQL15.NAT\MSSQL\DATA\FileGroup_DiemDanh_2_2021.ndf',
	SIZE = 80MB,
	MAXSIZE = 2200,
	FILEGROWTH = 1024MB 
 )
 To FileGroup FileGroup_DiemDanh_2_2021;
 GO

 Alter Database HYT
 ADD File 
 (
 Name = N'FileGroup_DiemDanh_3_2021',
 FileName = N'C:\Program Files\Microsoft SQL Server\MSSQL15.NAT\MSSQL\DATA\FileGroup_DiemDanh_3_2021.ndf',
	SIZE = 80MB,
	MAXSIZE = 2200,
	FILEGROWTH = 1024MB 
 )
 To FileGroup FileGroup_DiemDanh_3_2021;
 GO

 Alter Database HYT
 ADD File 
 (
 Name = N'FileGroup_DiemDanh_4_2021',
 FileName = N'C:\Program Files\Microsoft SQL Server\MSSQL15.NAT\MSSQL\DATA\FileGroup_DiemDanh_4_2021.ndf',
	SIZE = 80MB,
	MAXSIZE = 2200,
	FILEGROWTH = 1024MB 
 )
 To FileGroup FileGroup_DiemDanh_4_2021;
 GO

 Alter Database HYT
 ADD File 
 (
 Name = N'FileGroup_DiemDanh_5_2021',
 FileName = N'C:\Program Files\Microsoft SQL Server\MSSQL15.NAT\MSSQL\DATA\FileGroup_DiemDanh_5_2021.ndf',
	SIZE = 80MB,
	MAXSIZE = 2200,
	FILEGROWTH = 1024MB 
 )
 To FileGroup FileGroup_DiemDanh_5_2021;
 GO

 Alter Database HYT
 ADD File 
 (
 Name = N'FileGroup_DiemDanh_6_2021',
 FileName = N'C:\Program Files\Microsoft SQL Server\MSSQL15.NAT\MSSQL\DATA\FileGroup_DiemDanh_6_2021.ndf',
	SIZE = 80MB,
	MAXSIZE = 2200,
	FILEGROWTH = 1024MB 
 )
 To FileGroup FileGroup_DiemDanh_6_2021;
 GO

 Alter Database HYT
 ADD File 
 (
 Name = N'FileGroup_DiemDanh_7_2021',
 FileName = N'C:\Program Files\Microsoft SQL Server\MSSQL15.NAT\MSSQL\DATA\FileGroup_DiemDanh_7_2021.ndf',
	SIZE = 80MB,
	MAXSIZE = 2200,
	FILEGROWTH = 1024MB 
 )
 To FileGroup FileGroup_DiemDanh_7_2021;
 GO

 Alter Database HYT
 ADD File 
 (
 Name = N'FileGroup_DiemDanh_8_2021',
 FileName = N'C:\Program Files\Microsoft SQL Server\MSSQL15.NAT\MSSQL\DATA\FileGroup_DiemDanh_8_2021.ndf',
	SIZE = 80MB,
	MAXSIZE = 2200,
	FILEGROWTH = 1024MB 
 )
 To FileGroup FileGroup_DiemDanh_8_2021;
 GO

 Alter Database HYT
 ADD File 
 (
 Name = N'FileGroup_DiemDanh_9_2021',
 FileName = N'C:\Program Files\Microsoft SQL Server\MSSQL15.NAT\MSSQL\DATA\FileGroup_DiemDanh_9_2021.ndf',
	SIZE = 80MB,
	MAXSIZE = 2200,
	FILEGROWTH = 1024MB 
 )
 To FileGroup FileGroup_DiemDanh_9_2021;
 GO

 Alter Database HYT
 ADD File 
 (
 Name = N'FileGroup_DiemDanh_10_2021',
 FileName = N'C:\Program Files\Microsoft SQL Server\MSSQL15.NAT\MSSQL\DATA\FileGroup_DiemDanh_10_2021.ndf',
	SIZE = 80MB,
	MAXSIZE = 2200,
	FILEGROWTH = 1024MB 
 )
 To FileGroup FileGroup_DiemDanh_10_2021;
 GO

 Alter Database HYT
 ADD File 
 (
 Name = N'FileGroup_DiemDanh_11_2021',
 FileName = N'C:\Program Files\Microsoft SQL Server\MSSQL15.NAT\MSSQL\DATA\FileGroup_DiemDanh_11_2021.ndf',
	SIZE = 80MB,
	MAXSIZE = 2200,
	FILEGROWTH = 1024MB 
 )
 To FileGroup FileGroup_DiemDanh_11_2021;
 GO

 Alter Database HYT
 ADD File 
 (
 Name = N'FileGroup_DiemDanh_12_2021',
 FileName = N'C:\Program Files\Microsoft SQL Server\MSSQL15.NAT\MSSQL\DATA\FileGroup_DiemDanh_12_2021.ndf',
	SIZE = 80MB,
	MAXSIZE = 2200,
	FILEGROWTH = 1024MB 
 )
 To FileGroup FileGroup_DiemDanh_12_2021;
 GO



 --- Create partition function
 USE HYT
 CREATE PARTITION FUNCTION DiemDanh_PartitionFunction (DATE)
 AS RANGE RIGHT FOR VALUES ('2020-1-1', '2020-2-1', '2020-3-1', '2020-4-1', '2020-5-1', '2020-6-1', '2020-7-1', '2020-8-1', '2020-9-1', '2020-10-1', '2020-11-1', '2020-12-1',
  '2021-1-1', '2021-2-1', '2021-3-1', '2021-4-1', '2021-5-1', '2021-6-1', '2021-7-1', '2021-8-1', '2021-9-1', '2021-10-1', '2021-11-1', '2021-12-1')
GO


-- Create partition schema
CREATE PARTITION SCHEME DiemDanh_PartitionSchema
AS PARTITION DiemDanh_PartitionFunction TO ( [PRIMARY], FileGroup_DiemDanh_1_2020, FileGroup_DiemDanh_2_2020, FileGroup_DiemDanh_3_2020, FileGroup_DiemDanh_4_2020, FileGroup_DiemDanh_5_2020, FileGroup_DiemDanh_6_2020, FileGroup_DiemDanh_7_2020, FileGroup_DiemDanh_8_2020, FileGroup_DiemDanh_9_2020, FileGroup_DiemDanh_10_2020, FileGroup_DiemDanh_11_2020, FileGroup_DiemDanh_12_2020,
	FileGroup_DiemDanh_1_2021, FileGroup_DiemDanh_2_2021, FileGroup_DiemDanh_3_2021, FileGroup_DiemDanh_4_2021, FileGroup_DiemDanh_5_2021, FileGroup_DiemDanh_6_2021, FileGroup_DiemDanh_7_2021, FileGroup_DiemDanh_8_2021, FileGroup_DiemDanh_9_2021, FileGroup_DiemDanh_10_2021, FileGroup_DiemDanh_11_2021, FileGroup_DiemDanh_12_2021, [PRIMARY])
GO


 -- Check if the partition was setup correctly
--SELECT ps.name As [Name of PS], pf.name As [Name of PF], prf.boundary_id, prf.value
--FROM sys.partition_schemes ps
--INNER JOIN sys.partition_functions pf ON pf.function_id = ps.function_id
--INNER JOIN sys.partition_range_values prf ON pf.function_id = prf.function_id
GO

-- Create clustered index on partition schema

-- Đầu tiên là phải xóa index dc SQL tạo tự động trước
ALTER TABLE dbo.DIEMDANH DROP PK_DD

-- Sau đó mới chạy đoạn script sau
CREATE CLUSTERED INDEX [PK_DiemDanhDate]
ON  [dbo].[DIEMDANH](NGAY)
ON  [DiemDanh_PartitionSchema](NGAY)
GO 

DECLARE @test INT
SET @test = 10
-- Truy vấn thử ( Nó để lỗi vậy thui chứ truy vấn chạy bình thường)

SELECT *
From dbo.DIEMDANH
WHERE $Partition.[DiemDanh_PartitionFunction] (NGAY) IN (@test);

USE HYT