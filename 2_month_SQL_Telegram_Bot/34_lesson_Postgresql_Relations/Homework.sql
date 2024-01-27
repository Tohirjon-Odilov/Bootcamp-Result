--Task-1

--a) 
select title from course where dept_name = 'Comp. Sci.' and credits = 3;

--b)
select distinct student.ID from student join takes using(ID) join teaches using(course_id,sec_id,semester,year)  join instructor on teaches.id = instructor.id where instructor.name != 'Einstein'

--c) 
select salary from instructor where salary >= (select max(salary) from instructor)

--d) 
select * from instructor where salary >= (select max(salary) from instructor)

--e)
select course_id || ', ' || sec_id as "course_id, sec_id",  count(*) from takes where year = 2007 and semester ='Fall'
group by (course_id, sec_id);

--f)
select max(enrollment) from (select count(ID) as enrollment from section join takes using(course_id,sec_id,semester,year)where section.semester = 'Autumn' and section.year = 2007 group by course_id,sec_id)

--Task-2

--a) 
update instructor 
set salary = salary+(salary/100*10)
where dept_name = 'Comp. Sci.' 

--b)
delete from course where course_id not in (select course_id from section)

--c) 
insert into instructor (ID,name,dept_name, salary) select ID,name,dept_name, 10000 from student where tot_cred > 100