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


CREATE PROCEDURE Pro_GetAllService
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
  FROM Room
  WHERE NameRoom LIKE N'%' + @searchValue + '%'
    OR Status LIKE N'%' + @searchValue + '%'
    OR RoomTypeId  LIKE N'%' + @searchValue + '%'
END
GO

