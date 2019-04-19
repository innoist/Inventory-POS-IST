





CREATE view [dbo].[SalesSummaryView] as
--
Select  *, (GrossSale- Discount)  as NetSale, ((GrossSale- Discount)-ItemsCost) as Profit,(((GrossSale- Discount)-ItemsCost)/ItemsCost)*100 as ProfitPercentage    from (
select isnull(ROW_NUMBER() 
        OVER (ORDER BY CAST(RecCreatedDate AS DATE)),-1) AS RowNo,
		CAST(RecCreatedDate AS DATE) as SaleDate, 
		Sum(SalePrice*Quantity) as GrossSale,
		Sum(discount) as Discount,
		Sum(PurchasePrice*Quantity) as ItemsCost
from OrderItems
group by CAST(RecCreatedDate AS DATE)) a