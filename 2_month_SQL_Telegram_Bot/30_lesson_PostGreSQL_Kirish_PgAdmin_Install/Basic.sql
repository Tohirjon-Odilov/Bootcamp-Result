 select * from studenT
 where dept_name = 'Finance'

 select * from student
 where name like 'F%' and tot_cred < 10

 select * from student
 where tot_cred = 15 or name like 'M%'

 --select * from student
 --where tot_cred > 100 and name Ilike '%ma%'

 --update

 --insert

 --delete

 --1) History departmentda o'qiydigan talabalarga bayram munosabati bilan 3 kreditdan qo'shing

 --update student
 --set tot_cred = tot_cred - 3
 --where dept_name = 'History'
 --returning *
 -- ikkis bir xil ishlaydi
 --update student
 --set tot_cred = tot_cred - 3
 --where dept_name = 'History'

 --select * from university
 --where dept_name = 'History'

 --select distinct dept_name from department

 --delete from student 
 --where dept_name ilike 'a%'
 --returning *;

 --select distinct dept_name from student;

-- begin; --tranzaksiyani boshlash
-- rollback; --barchasini qaytarish
-- commit; --o'zgarishlarni birlashtirish
-- agar tranzaksiya ichida hatolik chiqsa unda rollback qlib ishlatiladi

-- sql injection nima?
-- ddl nima