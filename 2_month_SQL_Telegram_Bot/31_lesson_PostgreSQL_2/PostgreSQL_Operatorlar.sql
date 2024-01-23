-- select * from persons
-- where age between 20 and 40

-- select * from persons
-- where age <= 60 and gender not in ('Male', 'Female')

-- select * from persons
-- where first_name Ilike 'n%' and last_name Ilike 'k%' -- pattern yozsak bo'ladi

-- select first_name as "First Name", last_name as "Last Name", phone_number as "Phone Number", ip_address as "Ip Address" from persons
-- where yil between '1970' and '2020' and age between 18 and 45 and length(email) > 10 and length(parol) > 10 and ip_address is not null

-- faqatgina 18, 20, 25, 30 yoshdagilarni chiqarib beradi
-- select first_name as "First Name", last_name as "Last Name", gender as "Gender", age as "Age" from persons
-- where age in (18, 20, 25, 30) -- qavs ichiga xohlagancha qiymat bera olamiz

--distinct bu -> faqatgina unikallarini chiqarib beradi
-- select count(distinct age) from persons

-- order by asc bu sortlab beradi past yuqoriga
-- select first_name as "First Name", age as "Age" from persons
-- order by age

-- order by desc bu sortlab beradi yuqoridan pastga
-- select first_name as "First Name", age as "Age" from persons
-- order by age desc

---- alias

---- count()

---- min()

---- max()

---- avg()
-- select avg(age) as "O'rtacha yosh" from persons

---- like "pattern"
-- select last_name as "Second name" from persons
-- where last_name like 'A__%a%___%'

---- sum()
-- select sum(age)

---- limit 20

---- limit 20 offset 40 -> bunda 20dan boshlab 20 ta oladi

---- numberic
-- select avg(age)::numeric(10,1) as "O'rtacha yosh" from persons

select * from customers
where id in (select customer_id from orders)
