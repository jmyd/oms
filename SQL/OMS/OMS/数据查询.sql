
select * from Orders
select * from  OrderGoods
select * from [Buyers]
select * from  Package
select * from  PackageGoods
--¼ì²éÖØ¸´
SELECT       OrderExNo  FROM [OMSTest].[dbo].[Orders] group by OrderExNo having COUNT(1)>1


