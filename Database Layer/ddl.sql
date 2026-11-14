USE master ;
GO 


IF EXISTS (SELECT 1 FROM SYS.DATABASES WHERE NAME = 'mobile_store')
BEGIN	
	ALTER DATABASE mobile_store SET SINGLE_USER WITH ROLLBACK IMMEDIATE ;
	DROP DATABASE mobile_store ;	
END


CREATE DATABASE mobile_store ;
GO

USE mobile_store ;
GO

CREATE SCHEMA production ;
GO 
CREATE SCHEMA sales ;
GO 


DROP TABLE IF EXISTS production.products ;
CREATE TABLE production.products(
product_id INT IDENTITY(1, 1) NOT NULL , 
company VARCHAR(50), 
series VARCHAR(50), 
model VARCHAR(50),
stock_quantity INT,
current_price DECIMAL
PRIMARY KEY(product_id) )


DROP TABLE IF EXISTS production.customers ;
CREATE TABLE production.customers(
customer_id INT IDENTITY(1, 1) NOT NULL, 
first_name VARCHAR(50), 
last_name VARCHAR(50),
age INT, 
phone_number VARCHAR(50), 
address VARCHAR(50) 
PRIMARY KEY(customer_id) )


DROP TABLE IF EXISTS sales.orders ;
CREATE TABLE sales.orders( 
order_id INT NOT NULL, 
customer_id INT, 
order_date DATETIME 

PRIMARY KEY(order_id) 
CONSTRAINT fk_customers_orders FOREIGN KEY(customer_id)
REFERENCES production.customers(customer_id) )


DROP TABLE IF EXISTS sales.order_details ;
CREATE TABLE sales.order_details( 
order_details_id INT NOT NULL, 
order_id INT, 
product_id INT, 
quantity INT, 
unit_price DECIMAL 

PRIMARY KEY (order_details_id) 
CONSTRAINT fk_orders_order_details FOREIGN KEY(order_id)
REFERENCES sales.orders (order_id), 
CONSTRAINT fk_products_order_details FOREIGN KEY(product_id)
REFERENCES production.products (product_id) )

