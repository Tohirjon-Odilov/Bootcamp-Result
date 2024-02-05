create table customer_order_details(
	customer_order_detail_id serial primary key,
	customer_order_id int,
	product_id int,
	price money,
	price_with_discount money,
	product_amount int
);

create table customer_orders(
	customer_order_id serial primary key,
	operation_time timestamp,
	supermarket_location_id int,
	customer_id int
);

create table shop_products(
	product_id serial primary key,
	product_title_id int,
	product_manufacturer_id int,
	product_supplier_id int,
	unit_price money,
	comment text
);

create table product_manufacturers(
	manufacturer_id serial primary key,
	manufacturer_name varchar(255)
);

create table product_suppliers(
	supplier_id serial primary key,
	supplier_name varchar(255)
);

create table product_titles(
	product_title_id serial primary key,
	product_title varchar(255),
	product_category_id int
);

create table product_categories(
	category_id serial primary key,
	category_name varchar(255)
);

create table supermarket_locations(
	supermarket_location_id serial primary key,
	supermarket_id int,
	location_id int
);

create table locations(
	location_id serial primary key,
	location_address varchar(255),
	location_city_id int
);

create table supermarkets(
	supermarket_id serial primary key,
	supermarket_name varchar(255)
);

create table location_city(
	city_id serial primary key,
	city varchar(255),
	country varchar(255)
);


CREATE TABLE person_contacts(
    person_contact_id SERIAL primary key,
    person_id int,
  contact_type_id int,
  contact_value text 
);


CREATE TABLE persons(
    person_id SERIAL primary key,
    person_first_name varchar(255),
  person_last_name varchar(255),
  person_birth_date date
);

CREATE TABLE customers(
    customer_id SERIAL primary key,
     card_number char(16),
  discount int
  
);

CREATE TABLE contact_types(
    contact_type_id SERIAL primary key,
    contact_type_name text
);

CREATE TABLE person_contacts(
    person_contact_id SERIAL primary key,
    person_id int,
  contact_type_id int,
  contact_value text 
);


ALTER TABLE ONLY public.customer_order_details
    ADD CONSTRAINT customer_order_details_customer_order_id_fkey FOREIGN KEY (customer_order_id) REFERENCES public.customer_orders(customer_order_id);

ALTER TABLE ONLY public.customer_order_details
    ADD CONSTRAINT customer_order_details_product_id_fkey FOREIGN KEY (product_id) REFERENCES public.shop_products(product_id);

ALTER TABLE ONLY public.customer_orders
    ADD CONSTRAINT customer_orders_customer_id_fkey FOREIGN KEY (customer_id) REFERENCES public.customers(customer_id);

ALTER TABLE ONLY public.customer_orders
    ADD CONSTRAINT customer_orders_supermarket_location_id_fkey FOREIGN KEY (supermarket_location_id) REFERENCES public.supermarket_locations(supermarket_location_id);

ALTER TABLE ONLY public.customers
    ADD CONSTRAINT customers_customer_id_fkey FOREIGN KEY (customer_id) REFERENCES public.persons(person_id);

ALTER TABLE ONLY public.locations
    ADD CONSTRAINT locations_location_city_id_fkey FOREIGN KEY (location_city_id) REFERENCES public.location_city(city_id);

ALTER TABLE ONLY public.person_contacts
    ADD CONSTRAINT person_contacts_contact_type_id_fkey FOREIGN KEY (contact_type_id) REFERENCES public.contact_types(contact_type_id);

ALTER TABLE ONLY public.person_contacts
    ADD CONSTRAINT person_contacts_person_id_fkey FOREIGN KEY (person_id) REFERENCES public.persons(person_id);

ALTER TABLE ONLY public.product_titles
    ADD CONSTRAINT product_titles_product_category_id_fkey FOREIGN KEY (product_category_id) REFERENCES public.product_categories(category_id);

ALTER TABLE ONLY public.shop_products
    ADD CONSTRAINT shop_products_product_manufacturer_id_fkey FOREIGN KEY (product_manufacturer_id) REFERENCES public.product_manufacturers(manufacturer_id);

ALTER TABLE ONLY public.shop_products
    ADD CONSTRAINT shop_products_product_supplier_id_fkey FOREIGN KEY (product_supplier_id) REFERENCES public.product_suppliers(supplier_id);

ALTER TABLE ONLY public.shop_products
    ADD CONSTRAINT shop_products_product_title_id_fkey FOREIGN KEY (product_title_id) REFERENCES public.product_titles(product_title_id);

ALTER TABLE ONLY public.supermarket_locations
    ADD CONSTRAINT supermarket_locations_location_id_fkey FOREIGN KEY (location_id) REFERENCES public.locations(location_id);

ALTER TABLE ONLY public.supermarket_locations
    ADD CONSTRAINT supermarket_locations_supermarket_id_fkey FOREIGN KEY (supermarket_id) REFERENCES public.supermarkets(supermarket_id);

-- 13 orbit
--UPDATE SHOP_PRODUCTS
--SET UNIT_PRICE = UNIT_PRICE + ((UNIT_PRICE / 100) * 10)
--WHERE PRODUCT_TITLE_ID IN
--		(SELECT PRODUCT_TITLE_ID
--			FROM PRODUCT_TITLES
--			INNER JOIN PRODUCT_CATEGORIES AS PC ON PRODUCT_CATEGORY_ID = CATEGORY_ID
--			WHERE PC.CATEGORY_NAME = 'grocery')
--	AND PRODUCT_MANUFACTURER_ID =
--		(SELECT MANUFACTURER_ID
--			FROM PRODUCT_MANUFACTURERS
--			WHERE MANUFACTURER_NAME = 'Orbit')

--14-savol
--select person_first_name || '   ' || person_last_name as fullname,avg((price_with_discount::decimal)*product_amount) as avg_sum from customer_order_details
--inner join customer_orders using(customer_order_id)
--inner join customers using(customer_id)
--inner join persons on customers.customer_id=persons.person_id
--group by person_id
--having avg((price_with_discount::decimal)*product_amount)>200000
--order by avg((price_with_discount::decimal)*product_amount) desc,fullname asc

-- 15
--select persons.person_first_name,persons.person_last_name,product_titles.product_title from customer_order_details
--inner join customer_orders  using(customer_order_id) 
--inner join product_titles on product_id=product_title_id
--inner join customers on customer_orders.customer_order_id=customers.customer_id
--inner join persons on customers.customer_id=persons.person_id
--where  persons.person_birth_date between '01-01-2000' and '01-01-2005'

--17-savol
--insert into product_categories(category_id,category_name) values(19,'unusual')

--insert into product_titles(product_title_id,product_title,product_category_id) values(365,'zor narsa bu',19)

--insert into product_suppliers(supplier_id,supplier_name) values(27,'Elyor')

--insert into product_manufacturers(manufacturer_id,manufacturer_name) values(39,'Sirdaryolik')

--insert into shop_products(product_id,product_title_id,product_manufacturer_id,product_supplier_id,unit_price,comment) 
--values(99001,365,39,27,'$200000','menimcha qoshildi')

 --18
--SELECT
--  product_title_id,
--  comment,
--  CASE
--    WHEN unit_price::decimal < 300 THEN 'very cheap'
--    WHEN unit_price::decimal >= 300 AND unit_price::decimal <= 750 THEN 'affordable'
--    ELSE 'expensive'
--  END AS type
--FROM  shop_products;

--19-savol
--select supermarket_id,supermarket_name,count(distinct product_id)
--from supermarkets
--join supermarket_locations using(supermarket_id)
--join customer_orders using(supermarket_location_id)
--join customer_order_details using(customer_order_id)
--group by(supermarket_id)


--20
--CREATE or replace FUNCTION GETPRODUCTLISTBYOPERATIONDATE11(OPERATIONDATE date) RETURNS TABLE (P VARCHAR(255)) LANGUAGE PlpgSql AS $$
--begin
--return query select product_titles.product_title from customer_order_details
--inner join customer_orders using(customer_order_id)
--inner join product_titles on product_titles.product_title_id= customer_order_details.product_id
--where DATE(operation_time)=operationDate;
--end;$$;
--select * from GETPRODUCTLISTBYOPERATIONDATE11('2011-03-24');

--21
--CREATE or replace FUNCTION getCustomerListForManufacturer1(manufacturer_name1 varchar) RETURNS TABLE (P VARCHAR(255)) LANGUAGE PlpgSql AS $$
--begin
--return query select product_titles.product_title from product_manufacturers
--inner join shop_products on product_manufacturer_id=manufacturer_id
--inner join product_titles on shop_products.product_title_id=product_titles.product_title_id
--where manufacturer_name=manufacturer_name1;
--end;$$;

--select * from getCustomerListForManufacturer1('OFS Capital Corporation');

--23
--create view Checkout as
--select pe.person_first_name|| ' ' || pe.person_last_name as customer_full_name, pt.product_title, cos.price_with_discount, 
--cos.product_amount, cos.price_with_discount/cos.product_amount as for_per_product from customer_order_details as 
--cos inner join customer_orders as co on cos.customer_order_id = co.customer_order_id
--inner join persons as pe on pe.person_id = co.customer_id 
--inner join shop_products as sp on sp.product_id=cos.product_id
--inner join product_titles as pt on pt.product_title_id = sp.product_title_id where cos.product_amount > 1

--24
--create view product_details  as
--select pt.product_title, pc.category_name, sup.supplier_name, pm.manufacturer_name  
--from shop_products as sp inner join product_titles as pt
--on sp.product_title_id=pt.product_title_id inner join product_categories as pc
--on pt.product_category_id = pc.category_id inner join product_suppliers as sup on 
--sp.product_supplier_id=sup.supplier_id inner join product_manufacturers as pm on
--sp.product_manufacturer_id = pm.manufacturer_id

--25
--create view Customer_details as
--select person_first_name|| ' ' || person_last_name as Full_name,
--person_birth_date, cu.card_number
--from persons inner join customers as cu on person_id=customer_id
