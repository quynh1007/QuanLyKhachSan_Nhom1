---RoomType

CREATE PROCEDURE SP_RoomType_GetAll
AS
BEGIN
  SELECT *
  FROM RoomType
END
GO

CREATE PROCEDURE SP_RoomType_Insert
  @NameType NVARCHAR(100),
  @Price int
AS
BEGIN
  INSERT INTO RoomType
    (NameType, Price)
  VALUES(@NameType, @Price)
END
GO

CREATE PROCEDURE SP_RoomType_Delete
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

CREATE PROCEDURE SP_RoomType_Update
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

CREATE PROCEDURE SP_RoomType_Search
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


---Room

CREATE PROCEDURE SP_Room_GetAll
AS
BEGIN
  SELECT *
  FROM Room
END
GO

CREATE PROCEDURE SP_Room_Insert
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

CREATE PROCEDURE SP_Room_Delete
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

CREATE PROCEDURE SP_Room_Update
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

CREATE PROCEDURE SP_Room_Search
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


CREATE PROCEDURE Proc_GetAllService
AS
BEGIN
  SELECT *
  FROM Service
END
GO

CREATE PROCEDURE Proc_InsertService
  @nameService NVARCHAR(100),
  @price int
AS
BEGIN
  INSERT INTO Service
    (NameService,Price)
  VALUES(@nameService, @price )
END
GO

CREATE PROCEDURE Proc_DeleteService
  @serviceId INT
AS
BEGIN
Delete from BillInfo where ServiceId = @serviceId
Delete from Service where ServiceId = @serviceId
END
GO

CREATE PROCEDURE Proc_UpdateService
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

CREATE PROCEDURE Proc_SearchService
  @searchValue NVARCHAR(200)
AS
BEGIN
  SELECT *
  FROM Service
  WHERE NameService LIKE N'%' + @searchValue + '%'
    OR Price LIKE N'%' + @searchValue + '%'
END
GO


CREATE PROCEDURE Proc_GetAllBill
AS
BEGIN
  SELECT *
  FROM Bill
END
GO

CREATE PROCEDURE Proc_InsertBill
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

CREATE PROCEDURE Proc_DeleteBill
  @billId int
AS
BEGIN
Delete from Bill where BillId = @billId
END
GO

CREATE PROCEDURE Proc_UpdateBill
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

CREATE PROCEDURE Proc_SearchBill
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

CREATE PROCEDURE Proc_GetAllCustomer
AS
BEGIN
  SELECT *
  FROM Customer
END
GO
--Long
--Thêm billinfo mới sau khi thêm bill
CREATE TRIGGER AddNewBillInfo
ON Bill AFTER INSERT
AS
BEGIN
	DECLARE @BillId INT;
	SET @BillId=(SELECT BillId FROM INSERTED)
	
	DECLARE @RoomId INT;
	SET @RoomId=(SELECT RoomId FROM INSERTED)

	Declare @RoomPrice int;
	Set @RoomPrice=(Select Price from RoomType as rt,Room as r where RoomId=@RoomId and r.RoomTypeId=rt.RoomTypeId)

	Insert into BillInfo(BillId,IntCount,DateService)
	values(@BillId,@RoomPrice,GETDATE())
END
GO

--update tong tien khi thay doi service
CREATE TRIGGER UpdateIntCount
ON BillInfo instead of Update
AS
BEGIN
	DECLARE @ServicePriceAfter INT;
	SET @ServicePriceAfter=(SELECT Price FROM INSERTED as ist,Service as sv where ist.ServiceId=sv.ServiceId)
	
	DECLARE @ServicePriceBefore INT;
	SET @ServicePriceBefore=(SELECT Price FROM deleted as del,Service as sv where del.ServiceId=sv.ServiceId)

	Declare @ServiceId int;
	set @ServiceId=(Select ServiceId from inserted)
	Declare @BillInfoId int;
	set @BillInfoId=(Select BillInfoId from inserted)
	Declare @DateService date;
	set @DateService=(Select DateService from inserted)

	update BillInfo
	set
	serviceId = @ServiceId,
	dateService= @DateService,
	IntCount=IntCount+(@ServicePriceAfter-@ServicePriceBefore)
	where BillInfoId=@BillInfoId
END
GO
--Lấy tất cả billInfo
CREATE PROCEDURE Proc_GetAllBillInfo
AS
BEGIN
  SELECT *
  FROM BillInfo
END
GO
--Cập nhật billinfo
CREATE PROCEDURE Proc_UpdateBillInfo
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
--Tìm kiếm billinfo
CREATE PROCEDURE Proc_SearchBillInfo
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