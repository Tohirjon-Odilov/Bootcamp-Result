SELECT *
FROM INSTRUCTOR
WHERE SALARY = ANY
    (SELECT SALARY
      FROM INSTRUCTOR
      WHERE DEPT_NAME = 'Statistics');

create table book
(
  id serial primary key,     -- row identify qilish uchun va boshqa tablega ulash u-n
  isbn13 char(13) unique,
  title varchar(127) not null,
  published_date date check (extract(year from published_date) >= 1900),
  categories varchar(255)
);

insert into book (isbn13, title, published_date, categories)
values ('1234432112345', 'SQL intro', '2000-01-01', 'Programming, SQL, Computer Science');

insert into book (isbn13, title, published_date, categories)
values ('9123321476859', 'AI with C#', '2012-01-01', 'Programming, AI');


-- categories categorylar to'plamini bitta column saqlayapti
-- 1NF  -> columnda ma'lumotlar to'plamini saqlashi kerak emas, rowlar unique

create table category(
  id serial primary key,
  title varchar(127) unique not null
)

insert into category(title)
values ('Programming'),
     ('SQL'),
     ('Computer Science'),
     ('AI');
     
create table book_category(
  id serial primary key,
  book_id int,
  category_id int references category(id),
  foreign key (book_id) references book(id)
);

insert into book_category(book_id, category_id)
values (2, 1),
    (2, 2),
    (2, 3),
    (5, 1),
    (5, 4);
select * from book;
select * from category;
select * from book_category;

select * from book
inner join book_category on book.id = book_category.book_id
inner join category on category.id = book_category.category_id;



create table book
(
  id serial primary key,  -- primary key
  isbn13 char (13) unique,
)

--create table book
--(
--  id primary key,
--  email unique
--)

-- sql     vs      c#

-- Table      List<Person>
-- Row        elements of list
-- Column     Person class properylariga
-- Primary key  degault(reference) you can override it
-- Foreign key  navigational property
