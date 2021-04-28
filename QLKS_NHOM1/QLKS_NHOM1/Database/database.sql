CREATE DATABASE QuanLyKhachSan
GO

USE QuanLyKhachSan
GO 

-------------------- Tạo bảng ----------------------

-----Tạo Bảng Account------
CREATE TABLE Account
(
	UserName nchar(100) NOT NULL PRIMARY KEY,
	DisplayName nvarchar(100) NOT NULL DEFAULT N' ',
	PassWord nchar(1000) NOT NULL,
	Type int NOT NULL, -----1: Admin, 0: Staff----------
)
GO

----Tạo Bảng Loại Phòng--------
CREATE	TABLE RoomType
(
	id INT IDENTITY PRIMARY KEY,
	NameType nvarchar(100) NOT NULL,
	Price INT NOT NULL,
)
GO

--Tạo Bảng Phòng------
CREATE TABLE Room
(
	id INT IDENTITY PRIMARY KEY,
	NameRoom nvarchar(100) NOT NULL,
	Status int NOT NULL,
	idRoomType INT NOT NULL,
	FOREIGN KEY(idRoomType) REFERENCES RoomType (id)
)
GO

-------Tạo Bảng Dịch Vụ---------
CREATE TABLE Service
(
	id INT IDENTITY PRIMARY KEY,
	NameService nvarchar(100) NOT NULL,
	Price int NOT NULL,
)
GO

-------------Tạo bảng Khách hàng--------
CREATE TABLE Customer
(
	id INT IDENTITY PRIMARY KEY,
	NameCustomer nvarchar(100) NOT NULL,
	DateTimeCustomer Date NOT NULL,
	GenderCustomer nvarchar(3) NOT NULL,
	AddressCustomer nvarchar(100),
	idCardCustomer nchar(15) NOT NULL,
	PhoneNumber Nchar(10)
)
GO

-----Tạo Bảng Bill-----
CREATE TABLE Bill
(
	id INT IDENTITY PRIMARY KEY,
	idCustomer int NOT NULL,
	DateCheckIn Date NOT NULL DEFAULT GETDATE(),
	DateCheckOut Date ,
	idRoom int NOT NULL,
	Status int NOT NULL, ------1: Đã Thanh Toán, 0: Chưa Thanh Toán.
	FOREIGN KEY (idRoom) REFERENCES Room(id),
	FOREIGN KEY (idCustomer) REFERENCES Customer(id),
)
GO
----Tạo Bảng BillInfo-------
CREATE TABLE BillInfo
(
	id INT IDENTITY PRIMARY KEY,
	idBill int NOT NULL,
	idService int NOT NULL,
	intCount INT NOT NULL,
	DateService DATE NOT NULL DEFAULT GETDATE(),
	FOREIGN KEY (idBill) REFERENCES Bill (id),
	FOREIGN KEY (idService) REFERENCES Service (id)
)
GO