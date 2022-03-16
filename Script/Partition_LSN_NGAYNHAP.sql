-- PARTITION CHO BẢNG ĐIỂM DANH

-- Create filegroup for database
ALTER DATABASE HYT ADD FILEGROUP FileGroup_LSN_2020
ALTER DATABASE HYT ADD FILEGROUP FileGroup_LSN_2021

--- Create Data files in respective filegroup
--- Phan filename cua tung file nho doi lai dia chi tao file
Alter Database HYT
 ADD File 
 (
 Name = N'FileGroup_LSN_2020',
 FileName = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\FileGroup_LSN_2020.ndf',
	SIZE = 80MB,
	MAXSIZE = 2200,
	FILEGROWTH = 1024MB 
 )
 To FileGroup FileGroup_LSN_2020;
 GO
 
 Alter Database HYT
 ADD File 
 (
 Name = N'FileGroup_LSN_2021',
 FileName = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\FileGroup_LSN_2021.ndf',
	SIZE = 80MB,
	MAXSIZE = 2200,
	FILEGROWTH = 1024MB 
 )
 To FileGroup FileGroup_LSN_2021;
 GO
  --- Create partition function
 USE HYT
 CREATE PARTITION FUNCTION LSN_PartitionFunction (DATE)
 AS RANGE RIGHT FOR VALUES ('2021-1-1')
GO

-- Create partition schema
CREATE PARTITION SCHEME LSN_PartitionSchema
AS PARTITION LSN_PartitionFunction TO ( [PRIMARY],FileGroup_LSN_2020,
FileGroup_LSN_2021, [PRIMARY])
GO


 -- Check if the partition was setup correctly
--SELECT ps.name As [Name of PS], pf.name As [Name of PF], prf.boundary_id, prf.value
--FROM sys.partition_schemes ps
--INNER JOIN sys.partition_functions pf ON pf.function_id = ps.function_id
--INNER JOIN sys.partition_range_values prf ON pf.function_id = prf.function_id
GO

-- Create clustered index on partition schema

-- Đầu tiên là phải xóa index dc SQL tạo tự động trước
ALTER TABLE dbo.LICHSUNHAP DROP PK_LSN

-- Sau đó mới chạy đoạn script sau
--CREATE CLUSTERED INDEX [PK_LSN]
--ON  [dbo].[LICHSUNHAP](NGAYNHAP)
--ON  [LSN_PartitionSchema](NGAYNHAP)
GO 




