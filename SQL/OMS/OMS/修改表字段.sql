--修改订单留言长度
alter Table orders
alter column OrderNote nvarchar(800)

alter Table SaleAccount
Add  PlatformCode nvarchar(100)

alter Table OrderGoods
add ItemDesc Nvarchar(200)

alter Table GoodsCoefficient
add Description Nvarchar(200)