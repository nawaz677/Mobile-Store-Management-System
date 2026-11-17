SELECT * 
FROM sales.orders;

INSERT INTO sales.orders (customer_id,
order_date)
VALUES (3, SYSDATETIME())

INSERT INTO sales.order_details (order_id,
product_id, quantity, unit_price)
VALUES (2, 1, 2, 800000)

SELECT * FROM sales.order_details

SELECT 
	   od.order_id,
	   c.first_name,     
	   p.model, 
	   od.quantity, 
	   od.unit_price, 
	   od.quantity * od.unit_price AS total_amount,
	   o.order_date
FROM sales.order_details od 
JOIN sales.orders o 
ON od.order_id = o.order_id
JOIN production.customers c 
ON o.customer_id = c.customer_id 
JOIN production.products p 
ON od.product_id = p.product_id


