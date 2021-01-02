CREATE PROCEDURE GetOrders
AS
BEGIN
	SELECT O.Id[OrderId]
	 ,OI.Quantity
	 ,U.Name[BuyerName]
	 ,U.MobileNumber
	 ,CA.City
	 ,CA.State
	 ,CA.Country
	 ,CA.PinCode
	 FROM Orders O
	INNER JOIN OrderItems OI ON OI.OrderId = O.Id
	INNER JOIN Users U ON U.Id = O.UserId
	INNER JOIN ContactAddress CA ON CA.Id = U.ContactAddressId
	INNER JOIN UserRoles UR ON UR.Id = U.RoleId
	WHERE UR.Id = 1 OR UR.Id = 0
END