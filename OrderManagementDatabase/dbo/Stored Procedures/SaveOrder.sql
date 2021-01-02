CREATE PROCEDURE SaveOrder
(
@Id INT,
@UserId INT,
@Status NVARCHAR(50),
@OrderItems TVP_OrderItems READONLY
)
AS
BEGIN
	DECLARE @StatusId INT, @InsertedOrderId INT
	SELECT @StatusId = Id FROM CodeLists WHERE Text = @Status
	INSERT INTO Orders(StatusId, UserId) VALUES(@StatusId,@UserId)
	 SET @InsertedOrderId = SCOPE_IDENTITY()

	 INSERT INTO OrderItems(Quantity,OrderId,ProductId) SELECT OI.Quantity,@InsertedOrderId,OI.ProductId FROM @OrderItems OI

END