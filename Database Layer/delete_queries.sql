DELETE FROM sales.order_details
WHERE order_details_id IN (SELECT order_details_id FROM sales.order_details);

DELETE FROM sales.orders
WHERE order_id IN (SELECT order_id FROM sales.orders);