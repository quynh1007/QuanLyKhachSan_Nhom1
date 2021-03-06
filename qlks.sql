USE [master]
GO
/****** Object:  Database [QuanLyKhachSan]    Script Date: 6/29/2021 9:34:14 AM ******/
CREATE DATABASE [QuanLyKhachSan]
 CONTAINMENT = NONE
GO
ALTER DATABASE [QuanLyKhachSan] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyKhachSan].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyKhachSan] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QuanLyKhachSan] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyKhachSan] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyKhachSan] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyKhachSan] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QuanLyKhachSan] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyKhachSan] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuanLyKhachSan] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyKhachSan] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyKhachSan] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyKhachSan] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [QuanLyKhachSan]
GO
/****** Object:  StoredProcedure [dbo].[Login]    Script Date: 6/29/2021 9:34:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Login]
@username nvarchar(50), @pass nvarchar(50)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @username AND PassWord = @pass
END

GO
/****** Object:  StoredProcedure [dbo].[Proc_DeleteBill]    Script Date: 6/29/2021 9:34:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Proc_DeleteBill]
  @billId int
AS
BEGIN
Delete from Bill where BillId = @billId
END

GO
/****** Object:  StoredProcedure [dbo].[Proc_DeleteService]    Script Date: 6/29/2021 9:34:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Proc_DeleteService]
  @serviceId INT
AS
BEGIN
Delete from BillInfo where ServiceId = @serviceId
Delete from Service where ServiceId = @serviceId
END

GO
/****** Object:  StoredProcedure [dbo].[Proc_GetAllBill]    Script Date: 6/29/2021 9:34:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Proc_GetAllBill]
AS
BEGIN
  SELECT *
  FROM Bill
END

GO
/****** Object:  StoredProcedure [dbo].[Proc_GetAllBillInfo]    Script Date: 6/29/2021 9:34:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Lấy tất cả billInfo
CREATE PROCEDURE [dbo].[Proc_GetAllBillInfo]
AS
BEGIN
  SELECT *
  FROM BillInfo
END

GO
/****** Object:  StoredProcedure [dbo].[Proc_GetAllCustomer]    Script Date: 6/29/2021 9:34:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Proc_GetAllCustomer]
AS
BEGIN
  SELECT *
  FROM Customer
END

GO
/****** Object:  StoredProcedure [dbo].[Proc_GetAllService]    Script Date: 6/29/2021 9:34:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Proc_GetAllService]
AS
BEGIN
  SELECT *
  FROM Service
END

GO
/****** Object:  StoredProcedure [dbo].[Proc_InsertBill]    Script Date: 6/29/2021 9:34:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Proc_InsertBill]
  @customerId int,
  @dateCheckIn date,
  @dateCheckOut date,
  @roomId int,
  @status int
AS
BEGIN
  INSERT INTO Bill
    (CustomerId,DateCheckIn,DateCheckOut,RoomId,Status)
  VALUES(@customerId, @dateCheckIn,@dateCheckOut,@roomId,@status )
END

GO
/****** Object:  StoredProcedure [dbo].[Proc_InsertService]    Script Date: 6/29/2021 9:34:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Proc_InsertService]
  @nameService NVARCHAR(100),
  @price int
AS
BEGIN
  INSERT INTO Service
    (NameService,Price)
  VALUES(@nameService, @price )
END

GO
/****** Object:  StoredProcedure [dbo].[Proc_SearchBill]    Script Date: 6/29/2021 9:34:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Proc_SearchBill]
  @searchValue NVARCHAR(200)
AS
BEGIN
  SELECT *
  FROM Bill
  WHERE Status LIKE N'%' + @searchValue + '%'
    OR RoomId LIKE N'%' + @searchValue + '%'
	Or CustomerId LIKE N'%' + @searchValue + '%'
    OR BillId LIKE N'%' + @searchValue + '%'
END

GO
/****** Object:  StoredProcedure [dbo].[Proc_SearchBillInfo]    Script Date: 6/29/2021 9:34:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Tìm kiếm billinfo
CREATE PROCEDURE [dbo].[Proc_SearchBillInfo]
  @searchValue NVARCHAR(200)
AS
BEGIN
  SELECT *
  FROM BillInFo
  WHERE BillInfoId LIKE N'%' + @searchValue + '%'
    OR BillId LIKE N'%' + @searchValue + '%'
	Or ServiceId LIKE N'%' + @searchValue + '%'
    OR IntCount LIKE N'%' + @searchValue + '%'
	OR DateService LIKE N'%' + @searchValue + '%'
END

GO
/****** Object:  StoredProcedure [dbo].[Proc_SearchService]    Script Date: 6/29/2021 9:34:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Proc_SearchService]
  @searchValue NVARCHAR(200)
AS
BEGIN
  SELECT *
  FROM Service
  WHERE NameService LIKE N'%' + @searchValue + '%'
    OR Price LIKE N'%' + @searchValue + '%'
END

GO
/****** Object:  StoredProcedure [dbo].[Proc_UpdateBill]    Script Date: 6/29/2021 9:34:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Proc_UpdateBill]
  @billId int,
  @customerId int,
  @dateCheckIn date,
  @dateCheckOut date,
  @roomId int,
  @status int
AS
BEGIN
  UPDATE Bill
  SET CustomerId = @customerId,
  DateCheckIn = @dateCheckIn,
  DateCheckOut = @dateCheckOut,
  RoomId = @roomId,
  Status = @status
  WHERE BillId = @billId
END

GO
/****** Object:  StoredProcedure [dbo].[Proc_UpdateBillInfo]    Script Date: 6/29/2021 9:34:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Cập nhật billinfo
CREATE PROCEDURE [dbo].[Proc_UpdateBillInfo]
  @billInfoId int,
  @serviceId int,
  @dateService date
AS
BEGIN
  UPDATE BillInfo
  SET ServiceId = @serviceId,
  DateService = @dateService
  WHERE BillInFoId = @billInfoId
END

GO
/****** Object:  StoredProcedure [dbo].[Proc_UpdateService]    Script Date: 6/29/2021 9:34:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Proc_UpdateService]
@serviceId int,
@nameService NVARCHAR(100),
@price int
AS
BEGIN
  UPDATE Service
  SET NameService = @nameService,
  Price = @price
  WHERE ServiceId = @serviceId
END

GO
/****** Object:  StoredProcedure [dbo].[SP_Customer_Delete]    Script Date: 6/29/2021 9:34:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_Customer_Delete]
  @CustomerId INT
AS
BEGIN
  UPDATE Bill
  SET CustomerId = NULL
  WHERE CustomerId = @CustomerId

  DELETE Customer
  WHERE CustomerId = @CustomerId
END

GO
/****** Object:  StoredProcedure [dbo].[SP_Customer_GetAll]    Script Date: 6/29/2021 9:34:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-----------------------Thiep Customer------------------------
CREATE PROCEDURE [dbo].[SP_Customer_GetAll]
AS
BEGIN
  SELECT *
  FROM Customer
END

GO
/****** Object:  StoredProcedure [dbo].[SP_Customer_Insert]    Script Date: 6/29/2021 9:34:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_Customer_Insert]
  @NameCustomer NVARCHAR(100),
  @DateTimeCustomer DATE,
  @GenderCustomer NVARCHAR(3),
  @AddressCustomer NVARCHAR(100),
  @idCardCustomer NCHAR(15),
  @PhoneNumber NCHAR(10)
AS
BEGIN
  INSERT INTO Customer
    (NameCustomer, DateTimeCustomer, GenderCustomer, AddressCustomer, idCardCustomer, PhoneNumber)
  VALUES(@NameCustomer, @DateTimeCustomer, @GenderCustomer, @AddressCustomer, @idCardCustomer, @PhoneNumber)
END

GO
/****** Object:  StoredProcedure [dbo].[SP_Customer_Search]    Script Date: 6/29/2021 9:34:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_Customer_Search]
  @searchValue NVARCHAR(200)
AS
BEGIN
  SELECT *
  FROM Customer
  WHERE CustomerId LIKE N'%' + @searchValue + '%'
    OR  NameCustomer LIKE N'%' + @searchValue + '%'
    OR  DateTimeCustomer LIKE N'%' + @searchValue + '%'
    OR  GenderCustomer LIKE N'%' + @searchValue + '%'
    OR  AddressCustomer LIKE N'%' + @searchValue + '%'
	OR  idCardCustomer LIKE N'%' + @searchValue + '%'
    OR  PhoneNumber LIKE N'%' + @searchValue + '%'
END

GO
/****** Object:  StoredProcedure [dbo].[SP_Customer_Update]    Script Date: 6/29/2021 9:34:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_Customer_Update]
  @CustomerId INT,
  @NameCustomer NVARCHAR(100),
  @DateTimeCustomer DATE,
  @GenderCustomer NVARCHAR(3),
  @AddressCustomer NVARCHAR(100),
  @idCardCustomer NCHAR(15),
  @PhoneNumber NCHAR(10)
AS
BEGIN
  UPDATE Customer
  SET NameCustomer = @NameCustomer,
	  DateTimeCustomer = @DateTimeCustomer,
	  GenderCustomer = @GenderCustomer,
	  AddressCustomer = @AddressCustomer,
	  idCardCustomer = @idCardCustomer,
	  PhoneNumber = @PhoneNumber
  WHERE CustomerId = @CustomerId
END

GO
/****** Object:  StoredProcedure [dbo].[SP_Room_Delete]    Script Date: 6/29/2021 9:34:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_Room_Delete]
  @RoomId INT
AS
BEGIN
  UPDATE Bill
  SET RoomId = NULL
  WHERE RoomId = @RoomId

  DELETE Room
  WHERE RoomId = @RoomId
END

GO
/****** Object:  StoredProcedure [dbo].[SP_Room_GetAll]    Script Date: 6/29/2021 9:34:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


---Room

CREATE PROCEDURE [dbo].[SP_Room_GetAll]
AS
BEGIN
  SELECT *
  FROM Room
END

GO
/****** Object:  StoredProcedure [dbo].[SP_Room_Insert]    Script Date: 6/29/2021 9:34:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_Room_Insert]
  @NameRoom NVARCHAR(100),
  @Status int,
  @RoomTypeId int
AS
BEGIN
  INSERT INTO Room
    (NameRoom , Status , RoomTypeId)
  VALUES(@NameRoom, @Status ,@RoomTypeId)
END

GO
/****** Object:  StoredProcedure [dbo].[SP_Room_Search]    Script Date: 6/29/2021 9:34:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_Room_Search]
  @searchValue NVARCHAR(200)
AS
BEGIN
  SELECT *
  FROM Room
  WHERE NameRoom LIKE N'%' + @searchValue + '%'
    OR Status LIKE N'%' + @searchValue + '%'
    OR RoomTypeId  LIKE N'%' + @searchValue + '%'
END

GO
/****** Object:  StoredProcedure [dbo].[SP_Room_Update]    Script Date: 6/29/2021 9:34:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_Room_Update]
  @RoomId  int ,
  @NameRoom NVARCHAR(100),
  @Status int,
  @RoomTypeId int
AS
BEGIN
  UPDATE Room
  SET NameRoom = @NameRoom,
  Status = @Status,
  RoomTypeId = @RoomTypeId
  WHERE RoomId = @RoomId
END

GO
/****** Object:  StoredProcedure [dbo].[SP_RoomType_Delete]    Script Date: 6/29/2021 9:34:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_RoomType_Delete]
  @RoomTypeId INT
AS
BEGIN
  UPDATE Room
  SET RoomTypeId = NULL
  WHERE RoomTypeId = @RoomTypeId

  DELETE RoomType
  WHERE RoomTypeId = @RoomTypeId
END

GO
/****** Object:  StoredProcedure [dbo].[SP_RoomType_GetAll]    Script Date: 6/29/2021 9:34:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_RoomType_GetAll]
AS
BEGIN
  SELECT *
  FROM RoomType
END

GO
/****** Object:  StoredProcedure [dbo].[SP_RoomType_Insert]    Script Date: 6/29/2021 9:34:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_RoomType_Insert]
  @NameType NVARCHAR(100),
  @Price int
AS
BEGIN
  INSERT INTO RoomType
    (NameType, Price)
  VALUES(@NameType, @Price)
END

GO
/****** Object:  StoredProcedure [dbo].[SP_RoomType_Search]    Script Date: 6/29/2021 9:34:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_RoomType_Search]
  @searchValue NVARCHAR(200)
AS
BEGIN
  SELECT *
  FROM RoomType
  WHERE RoomTypeId LIKE N'%' + @searchValue + '%'
    OR NameType LIKE N'%' + @searchValue + '%'
    OR Price LIKE N'%' + @searchValue + '%'
END

GO
/****** Object:  StoredProcedure [dbo].[SP_RoomType_Update]    Script Date: 6/29/2021 9:34:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_RoomType_Update]
  @RoomTypeId int ,
  @NameType NVARCHAR(100),
  @Price int
AS
BEGIN
  UPDATE RoomType
  SET NameType = @NameType,
  Price = @Price
  WHERE RoomTypeId = @RoomTypeId
END

GO
/****** Object:  Table [dbo].[Account]    Script Date: 6/29/2021 9:34:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[UserName] [nchar](100) NOT NULL,
	[DisplayName] [nvarchar](100) NOT NULL DEFAULT (N' '),
	[PassWord] [nchar](1000) NOT NULL,
	[Type] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Bill]    Script Date: 6/29/2021 9:34:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[BillId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[DateCheckIn] [date] NOT NULL DEFAULT (getdate()),
	[DateCheckOut] [date] NULL,
	[RoomId] [int] NOT NULL,
	[Status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BillId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BillInfo]    Script Date: 6/29/2021 9:34:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillInfo](
	[BillInfoId] [int] IDENTITY(1,1) NOT NULL,
	[BillId] [int] NOT NULL,
	[ServiceId] [int] NOT NULL,
	[IntCount] [int] NOT NULL,
	[DateService] [date] NOT NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[BillInfoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 6/29/2021 9:34:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[NameCustomer] [nvarchar](100) NOT NULL,
	[DateTimeCustomer] [date] NOT NULL,
	[GenderCustomer] [nvarchar](3) NOT NULL,
	[AddressCustomer] [nvarchar](100) NULL,
	[IdCardCustomer] [nchar](15) NOT NULL,
	[PhoneNumber] [nchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Room]    Script Date: 6/29/2021 9:34:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[RoomId] [int] IDENTITY(1,1) NOT NULL,
	[NameRoom] [nvarchar](100) NOT NULL,
	[Status] [int] NOT NULL,
	[RoomTypeId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoomType]    Script Date: 6/29/2021 9:34:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomType](
	[RoomTypeId] [int] IDENTITY(1,1) NOT NULL,
	[NameType] [nvarchar](100) NOT NULL,
	[Price] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoomTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Service]    Script Date: 6/29/2021 9:34:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[ServiceId] [int] IDENTITY(1,1) NOT NULL,
	[NameService] [nvarchar](100) NOT NULL,
	[Price] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Account] ([UserName], [DisplayName], [PassWord], [Type]) VALUES (N'admin                                                                                               ', N'Trưởng Phòng', N'admin                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   ', 1)
INSERT [dbo].[Account] ([UserName], [DisplayName], [PassWord], [Type]) VALUES (N'dinh                                                                                                ', N'Trưởng Phòng', N'dinh                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    ', 0)
SET IDENTITY_INSERT [dbo].[Bill] ON 

INSERT [dbo].[Bill] ([BillId], [CustomerId], [DateCheckIn], [DateCheckOut], [RoomId], [Status]) VALUES (1, 1, CAST(N'2021-04-28' AS Date), CAST(N'2021-04-28' AS Date), 1, 0)
INSERT [dbo].[Bill] ([BillId], [CustomerId], [DateCheckIn], [DateCheckOut], [RoomId], [Status]) VALUES (2, 2, CAST(N'2021-04-28' AS Date), CAST(N'2021-04-28' AS Date), 1, 1)
SET IDENTITY_INSERT [dbo].[Bill] OFF
SET IDENTITY_INSERT [dbo].[BillInfo] ON 

INSERT [dbo].[BillInfo] ([BillInfoId], [BillId], [ServiceId], [IntCount], [DateService]) VALUES (1, 1, 1, 1, CAST(N'2021-04-28' AS Date))
INSERT [dbo].[BillInfo] ([BillInfoId], [BillId], [ServiceId], [IntCount], [DateService]) VALUES (2, 2, 6, 1, CAST(N'2021-04-28' AS Date))
INSERT [dbo].[BillInfo] ([BillInfoId], [BillId], [ServiceId], [IntCount], [DateService]) VALUES (3, 2, 3, 1, CAST(N'2021-04-28' AS Date))
INSERT [dbo].[BillInfo] ([BillInfoId], [BillId], [ServiceId], [IntCount], [DateService]) VALUES (4, 2, 2, 4, CAST(N'2021-04-28' AS Date))
INSERT [dbo].[BillInfo] ([BillInfoId], [BillId], [ServiceId], [IntCount], [DateService]) VALUES (5, 1, 2, 4, CAST(N'2021-04-28' AS Date))
INSERT [dbo].[BillInfo] ([BillInfoId], [BillId], [ServiceId], [IntCount], [DateService]) VALUES (7, 2, 7, 4, CAST(N'2021-06-29' AS Date))
INSERT [dbo].[BillInfo] ([BillInfoId], [BillId], [ServiceId], [IntCount], [DateService]) VALUES (8, 1, 2, 4, CAST(N'2021-06-29' AS Date))
SET IDENTITY_INSERT [dbo].[BillInfo] OFF
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([CustomerId], [NameCustomer], [DateTimeCustomer], [GenderCustomer], [AddressCustomer], [IdCardCustomer], [PhoneNumber]) VALUES (1, N'Nguyễn Văn B', CAST(N'1996-01-02' AS Date), N'Nam', N'Bạc Liêu', N'385758646      ', N'0964429603')
INSERT [dbo].[Customer] ([CustomerId], [NameCustomer], [DateTimeCustomer], [GenderCustomer], [AddressCustomer], [IdCardCustomer], [PhoneNumber]) VALUES (2, N'Nguyễn Văn C', CAST(N'1996-08-22' AS Date), N'Nam', N'Bạc Liêu', N'385758659      ', N'0964423435')
INSERT [dbo].[Customer] ([CustomerId], [NameCustomer], [DateTimeCustomer], [GenderCustomer], [AddressCustomer], [IdCardCustomer], [PhoneNumber]) VALUES (3, N'Nguyễn Thị Bông', CAST(N'1994-06-14' AS Date), N'Nữ', N'Bạc Liêu', N'385758634      ', N'0964234432')
INSERT [dbo].[Customer] ([CustomerId], [NameCustomer], [DateTimeCustomer], [GenderCustomer], [AddressCustomer], [IdCardCustomer], [PhoneNumber]) VALUES (4, N'Nguyễn Văn D', CAST(N'1996-01-02' AS Date), N'Nam', N'Nghe an', N'385758646      ', N'0964429603')
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[Room] ON 

INSERT [dbo].[Room] ([RoomId], [NameRoom], [Status], [RoomTypeId]) VALUES (1, N'Phòng VIP', 1, 1)
INSERT [dbo].[Room] ([RoomId], [NameRoom], [Status], [RoomTypeId]) VALUES (2, N'Phòng 10', 0, 3)
INSERT [dbo].[Room] ([RoomId], [NameRoom], [Status], [RoomTypeId]) VALUES (3, N'Phòng 11', 1, 3)
INSERT [dbo].[Room] ([RoomId], [NameRoom], [Status], [RoomTypeId]) VALUES (4, N'Phòng 31', 1, 4)
INSERT [dbo].[Room] ([RoomId], [NameRoom], [Status], [RoomTypeId]) VALUES (5, N'Phòng 32', 1, 5)
INSERT [dbo].[Room] ([RoomId], [NameRoom], [Status], [RoomTypeId]) VALUES (6, N'Phòng 33', 1, 5)
INSERT [dbo].[Room] ([RoomId], [NameRoom], [Status], [RoomTypeId]) VALUES (7, N'Phòng 101', 1, 2)
INSERT [dbo].[Room] ([RoomId], [NameRoom], [Status], [RoomTypeId]) VALUES (8, N'Phòng 102', 0, 2)
INSERT [dbo].[Room] ([RoomId], [NameRoom], [Status], [RoomTypeId]) VALUES (9, N'Phòng 103', 0, 2)
INSERT [dbo].[Room] ([RoomId], [NameRoom], [Status], [RoomTypeId]) VALUES (10, N'Phòng 104', 0, 2)
SET IDENTITY_INSERT [dbo].[Room] OFF
SET IDENTITY_INSERT [dbo].[RoomType] ON 

INSERT [dbo].[RoomType] ([RoomTypeId], [NameType], [Price]) VALUES (1, N'Phòng VIP', 720000)
INSERT [dbo].[RoomType] ([RoomTypeId], [NameType], [Price]) VALUES (2, N'Phòng thường', 120000)
INSERT [dbo].[RoomType] ([RoomTypeId], [NameType], [Price]) VALUES (3, N'Phòng thương gia', 400000)
INSERT [dbo].[RoomType] ([RoomTypeId], [NameType], [Price]) VALUES (4, N'Phòng đôi', 180000)
INSERT [dbo].[RoomType] ([RoomTypeId], [NameType], [Price]) VALUES (5, N'Phòng ba', 200000)
SET IDENTITY_INSERT [dbo].[RoomType] OFF
SET IDENTITY_INSERT [dbo].[Service] ON 

INSERT [dbo].[Service] ([ServiceId], [NameService], [Price]) VALUES (1, N'Quầy bar', 100000)
INSERT [dbo].[Service] ([ServiceId], [NameService], [Price]) VALUES (2, N'Café', 10000)
INSERT [dbo].[Service] ([ServiceId], [NameService], [Price]) VALUES (3, N'Spa', 100000)
INSERT [dbo].[Service] ([ServiceId], [NameService], [Price]) VALUES (4, N'Phòng họp', 120000)
INSERT [dbo].[Service] ([ServiceId], [NameService], [Price]) VALUES (5, N'Giặt ủi', 20000)
INSERT [dbo].[Service] ([ServiceId], [NameService], [Price]) VALUES (6, N'Dịch vụ 24/24', 200000)
INSERT [dbo].[Service] ([ServiceId], [NameService], [Price]) VALUES (7, N'Fitness centre', 10000)
SET IDENTITY_INSERT [dbo].[Service] OFF
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([RoomId])
REFERENCES [dbo].[Room] ([RoomId])
GO
ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD FOREIGN KEY([BillId])
REFERENCES [dbo].[Bill] ([BillId])
GO
ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Service] ([ServiceId])
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD FOREIGN KEY([RoomTypeId])
REFERENCES [dbo].[RoomType] ([RoomTypeId])
GO
USE [master]
GO
ALTER DATABASE [QuanLyKhachSan] SET  READ_WRITE 
GO
