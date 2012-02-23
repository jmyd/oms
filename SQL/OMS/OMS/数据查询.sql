
select * from Orders
select * from  OrderGoods
select * from [Buyers]
select * from  Package
select * from  PackageGoods
select * from OrderPrintRecord
select * from GoodsCoefficient
--检查重复
SELECT       OrderExNo  FROM [OMSTest].[dbo].[Orders] group by OrderExNo having COUNT(1)>1
--包裹单查询
select o.NowOrderType,(select COUNT(1) from PackageGoods where PackageGoods.PackageNo=p.PackageNo ) as GCount,
p.PackageNo,o.TxnId,o.UserNameForm,o.OrderNo,o.OrderAmount,o.OrderCurrencyCode,o.OrderForm,o.OrderNote,p.LogisticsMode,
pg.Sku,pg.ItemQty,o.NowOrderType,b.*,g.ItemName
 from Package p 
left join BuyerAddress b on o.AddressId=b.Id
left join PackageGoods pg on p.PackageNo=pg.PackageNo
left join Goods g on pg.Sku=g.ItemSkuleft join Orders o on p.OrderID=o.Id

where o.IsPrint=0 and o.PrintNum=0 and o.ShippedStatus <> '已发货' and p.PackageStatus='未发货' and o.CreateOn between GETDATE() and GETDATE() and o.Enabled=0 order by GCount,ItemSku

--可以打印的订单查询

select id from Orders where IsPrint=0 and PrintNum=0 and ShippedStatus <> '已发货' and Enabled=0





