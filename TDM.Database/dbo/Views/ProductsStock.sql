

CREATE view [dbo].[ProductsStock] as
--
select p.*,isnull(o.Quantity,0) as SoldQty,isnull((p.PurchasedQty)-isnull(o.Quantity,0),0) as AvailableQty from 
(
select p.ProductId, p.Name,p.PurchasePrice, p.SalePrice, SUM(i.Quantity) as PurchasedQty
from Products p
left join InventoryItems i on i.ProductId=p.ProductId
group by p.productid, p.Name,p.purchaseprice, p.saleprice


)p
left join
(
	select oi.ProductId, sum(isnull(oi.Quantity,0)) as Quantity 
	from Orders o 
	inner join OrderItems OI on o.OrderId = OI.OrderId 
	where o.IsDeleted = 'false' OR o.IsDeleted is null 
	group by oi.ProductId
	

)o
on o.ProductId = p.ProductId


--select p.ProductId, p.Name,p.PurchasePrice, p.SalePrice, SUM(i.Quantity) as PurchasedQty,
--SUM(isnull(o.Quantity,0)) as SoldQty,isnull((SUM(i.Quantity)-SUM(isnull(o.Quantity,0))),0) as AvailableQty

--from Products p
--left join InventoryItems i on i.ProductId=p.ProductId
--left join
--(
--	select oi.ProductId, isnull(oi.Quantity,0) as Quantity 
--	from Orders o 
--	inner join OrderItems OI on o.OrderId = OI.OrderId 
--	where o.IsDeleted = 'false' OR o.IsDeleted is null
--)o
--on o.ProductId = p.ProductId
--group by p.productid, p.Name,p.purchaseprice, p.saleprice