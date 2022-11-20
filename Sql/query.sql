select
	p.Id as ProdId,
	p.Name as ProdName,
	cpc.Id as CatId,
	cpc.Name as CatName
from
	Product p
left join (
	select
		c.Id,
		c.Name,
		pc.ProductId
	from
		Category c
	inner join ProductCategory pc on
		c.Id = pc.CategoryId) cpc on
	p.Id = cpc.ProductId
