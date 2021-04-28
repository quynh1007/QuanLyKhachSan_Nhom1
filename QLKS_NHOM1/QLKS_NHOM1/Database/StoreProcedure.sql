use QuanLyKhachSan
go
-----------------------Thiep Customer------------------------
CREATE PROCEDURE SP_Customer_GetAll
AS
BEGIN
  SELECT *
  FROM Customer
END
GO

CREATE PROCEDURE SP_Customer_Insert
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

CREATE PROCEDURE SP_Customer_Delete
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

CREATE PROCEDURE SP_Customer_Update
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

CREATE PROCEDURE SP_Customer_Search
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
