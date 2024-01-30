
---- comment 

--create or replace function add_to_numbers(num1 real, num2 real)
--returns real
--language plpgsql
--AS $$
--BEGIN
--  return num1 + num2;
--END
--$$;

--create or replace procedure add_to_numbers_prcedure(num1 real, num2 real)
--language plpgsql
--AS $$
--declare 
--summa real;
--BEGIN
--  summa:= num1+num2;
--  raise notice 'summa = %',  summa;
--END
--$$;

--call add_to_numbers_prcedure(123, 45)

--select add_to_numbers(23, 45)

--go => bitta ma bitta ketma get run qilish

-- -- alohida block da ishlatvolish
--do 
--$$
--declare
--summa int;
--begin 
-- summa := 15;
-- raise notice '%  %', summa, summa+2;
--end;
--$$;



--CREATE OR REPLACE FUNCTION my_function_return_table(brand1 varchar, model1 varchar, year1 int)
--RETURNS TABLE(brand varchar, model varchar, year int) AS $$
--BEGIN
--    -- Ma'lumotlarni `students` jadvaliga qo'shish
--    INSERT INTO cars(brand, model, year)
--    VALUES (brand1, model1, year1);

--    -- Qo'shilgan ma'lumotlarni qaytarish
--    RETURN QUERY 
--    SELECT *
--    FROM cars;
----     WHERE some_condition;  -- Shartlarni moslashtiring
--END;
--$$ LANGUAGE plpgsql;

--select my_function_return_table('Mers', 'G56', 2024)

------------------------ create table -----------------------------

-- create table cars(
-- 	brand varchar, model varchar, year int
-- )

------------------------ table'dagi oxirgi row'ni olish --------------------------

-- CREATE OR REPLACE FUNCTION my_function_return_table(brand1 varchar, model1 varchar, year1 int)
-- RETURNS TABLE(brand varchar, model varchar, year int) AS $$
-- BEGIN
-- 	-- ma'lumotlarni cars jadvaliga qo'shish
-- 	INSERT INTO cars(brand, model, year)
--     VALUES (brand1, model1, year1);

-- 	-- table'ni qaytaryapmiz
--     RETURN QUERY 
--     SELECT * FROM cars
-- 	offset (select count(*) -1 from cars);
-- END;
-- $$ LANGUAGE plpgsql;

-- select my_function_return_table('nima', 'G33', 2020)
