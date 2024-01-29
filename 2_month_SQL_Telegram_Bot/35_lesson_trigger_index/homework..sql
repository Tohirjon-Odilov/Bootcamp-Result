-- CREATE TABLE "student_access"(
--     "student_id" BIGINT NOT NULL,
--     "subject_id" BIGINT NOT NULL
-- );
-- ALTER TABLE
--     "student_access" ADD PRIMARY KEY("student_id");
-- CREATE TABLE "student"(
--     "id" bigserial NOT NULL,
--     "full_name" VARCHAR(255) NOT NULL,
--     "age" INTEGER NOT NULL,
--     "grade" INTEGER NOT NULL,
--     "group_id" BIGINT NOT NULL
-- );
-- ALTER TABLE
--     "student" ADD PRIMARY KEY("id");
-- CREATE TABLE "student_of_group"(
--     "id" bigserial NOT NULL,
--     "name" VARCHAR(255) NOT NULL,
--     "count" INTEGER NOT NULL
-- );
-- ALTER TABLE
--     "student_of_group" ADD PRIMARY KEY("id");
-- CREATE TABLE "subject"(
--     "id" bigserial NOT NULL,
--     "name" VARCHAR(255) NOT NULL,
--     "room_number" INTEGER NOT NULL,
--     "category" VARCHAR(255) NOT NULL
-- );
-- ALTER TABLE
--     "subject" ADD PRIMARY KEY("id");
-- ALTER TABLE
--     "student_access" ADD CONSTRAINT "student_access_subject_id_foreign" FOREIGN KEY("subject_id") REFERENCES "subject"("id");
-- ALTER TABLE
--     "student_access" ADD CONSTRAINT "student_access_student_id_foreign" FOREIGN KEY("student_id") REFERENCES "student"("id");
-- ALTER TABLE
--     "student" ADD CONSTRAINT "student_group_id_foreign" FOREIGN KEY("group_id") REFERENCES "student_of_group"("id");

-- ------- ####### o'zgargan ma'lumotlar logs'ga kelib tushadi #######-------
-- CREATE TABLE "logs"
-- (
--     id bigserial NOT NULL,
--     table_name character varying(40) NOT NULL,
--     row_id bigint NOT NULL,
--     action character varying(20) NOT NULL,
--     old_data text,
--     new_data text
-- );

--------------- add data --------------
---------------- group ---------------------
-- insert into student_of_group (name, count) values ('Universidad Cuauhtémoc', 25);
-- insert into student_of_group (name, count) values ('Pontificia Universidade Católica do Paraná', 33);
-- insert into student_of_group (name, count) values ('Physical Education Academy "Jozef Pilsudski" in Warsaw', 24);
-- insert into student_of_group (name, count) values ('Ural State Forestry Technical Academy', 25);
-- insert into student_of_group (name, count) values ('Fourah Bay College, University of Sierra Leone', 26);
-- insert into student_of_group (name, count) values ('Takhatmal Shrivallabh Homoeopathic Medical College', 21);
-- insert into student_of_group (name, count) values ('Anhui Medical University', 30);
-- insert into student_of_group (name, count) values ('Universidad de Antofagasta', 17);

-- ---------------- student ---------------------
-- insert into student (full_name, age, grade, group_id) values ('Thorstein Osipenko', 60, 5, 2);
-- insert into student (full_name, age, grade, group_id) values ('Kinsley Eate', 70, 5, 2);
-- insert into student (full_name, age, grade, group_id) values ('Skippie Filippazzo', 73, 4, 1);
-- insert into student (full_name, age, grade, group_id) values ('Aurelea Vineall', 68, 3, 1);
-- insert into student (full_name, age, grade, group_id) values ('Glyn Kliesl', 20, 4, 1);
-- insert into student (full_name, age, grade, group_id) values ('Sutton Arundell', 60, 1, 1);
-- insert into student (full_name, age, grade, group_id) values ('Gayle Baggallay', 24, 4, 1);
-- insert into student (full_name, age, grade, group_id) values ('Skipper McAleese', 71, 5, 2);
-- insert into student (full_name, age, grade, group_id) values ('Theodoric Ferrer', 45, 1, 1);
-- insert into student (full_name, age, grade, group_id) values ('Der Szymanski', 85, 1, 2);
-- insert into student (full_name, age, grade, group_id) values ('Alisun Garmey', 87, 3, 2);
-- insert into student (full_name, age, grade, group_id) values ('Vladamir Houten', 78, 1, 1);
-- insert into student (full_name, age, grade, group_id) values ('Adelle Gaynor', 86, 1, 2);
-- insert into student (full_name, age, grade, group_id) values ('Thelma Franklen', 58, 3, 2);
-- insert into student (full_name, age, grade, group_id) values ('Thatch Wardel', 19, 5, 1);
-- insert into student (full_name, age, grade, group_id) values ('Britteny Carverhill', 31, 2, 2);
-- insert into student (full_name, age, grade, group_id) values ('Carolee Dallimare', 21, 1, 1);
-- insert into student (full_name, age, grade, group_id) values ('Ezechiel MacMeekan', 79, 4, 1);
-- insert into student (full_name, age, grade, group_id) values ('Walsh Bohike', 62, 4, 2);
-- insert into student (full_name, age, grade, group_id) values ('Prue Horlick', 59, 2, 1);
-- insert into student (full_name, age, grade, group_id) values ('Marieann Spens', 45, 2, 1);
-- insert into student (full_name, age, grade, group_id) values ('Burty Farnan', 50, 2, 1);
-- insert into student (full_name, age, grade, group_id) values ('Idalina Nayer', 28, 3, 1);
-- insert into student (full_name, age, grade, group_id) values ('Syman Ebbett', 57, 5, 1);
-- insert into student (full_name, age, grade, group_id) values ('Kaitlin Mapp', 29, 5, 1);
-- insert into student (full_name, age, grade, group_id) values ('Tabby Hardistry', 40, 5, 2);
-- insert into student (full_name, age, grade, group_id) values ('Sheilakathryn Elam', 73, 5, 2);
-- insert into student (full_name, age, grade, group_id) values ('Quillan Trodd', 81, 3, 2);
-- insert into student (full_name, age, grade, group_id) values ('Wanids Antonietti', 28, 5, 1);
-- insert into student (full_name, age, grade, group_id) values ('Benson Hafford', 72, 1, 1);
-- insert into student (full_name, age, grade, group_id) values ('Sally Ourry', 61, 4, 1);
-- insert into student (full_name, age, grade, group_id) values ('Sawyere Brozsset', 19, 1, 2);
-- insert into student (full_name, age, grade, group_id) values ('Curran Alexandrescu', 56, 4, 1);
-- insert into student (full_name, age, grade, group_id) values ('Barris Botterman', 56, 3, 1);
-- insert into student (full_name, age, grade, group_id) values ('Sid Knagges', 81, 4, 1);
-- insert into student (full_name, age, grade, group_id) values ('Rutter Filipic', 59, 3, 2);
-- insert into student (full_name, age, grade, group_id) values ('Earvin Liffey', 72, 1, 2);
-- insert into student (full_name, age, grade, group_id) values ('Brewer Waith', 22, 3, 2);
-- insert into student (full_name, age, grade, group_id) values ('Cammi Station', 62, 3, 2);
-- insert into student (full_name, age, grade, group_id) values ('Marian Laverack', 18, 1, 2);
-- insert into student (full_name, age, grade, group_id) values ('Holly Bazek', 63, 1, 1);
-- insert into student (full_name, age, grade, group_id) values ('Galvan Tarpey', 72, 1, 2);
-- insert into student (full_name, age, grade, group_id) values ('Israel Bostock', 68, 1, 1);
-- insert into student (full_name, age, grade, group_id) values ('Hendrik Petrolli', 69, 1, 1);
-- insert into student (full_name, age, grade, group_id) values ('Frank Portal', 79, 4, 1);
-- insert into student (full_name, age, grade, group_id) values ('Carie Duffit', 29, 1, 1);
-- insert into student (full_name, age, grade, group_id) values ('Karin Bleythin', 83, 5, 1);
-- insert into student (full_name, age, grade, group_id) values ('Judith Fuke', 66, 2, 2);
-- insert into student (full_name, age, grade, group_id) values ('Panchito Fones', 65, 4, 1);
-- insert into student (full_name, age, grade, group_id) values ('Bengt Gasgarth', 51, 1, 1);

-- ------------------ subject ---------------------
-- insert into subject (name, room_number, category) values ('Hog / Sausage Casing - Pork', 70, 'Malaysia');
-- insert into subject (name, room_number, category) values ('Lighter - Bbq', 59, 'Ethiopia');
-- insert into subject (name, room_number, category) values ('Chocolate - White', 16, 'Philippines');
-- insert into subject (name, room_number, category) values ('Ecolab Silver Fusion', 81, 'Peru');
-- insert into subject (name, room_number, category) values ('Cheese - Brick With Onion', 84, 'Indonesia');
-- insert into subject (name, room_number, category) values ('Coconut - Shredded, Unsweet', 35, 'Papua New Guinea');
-- insert into subject (name, room_number, category) values ('Duck - Legs', 63, 'Czech Republic');
-- insert into subject (name, room_number, category) values ('Arctic Char - Fillets', 95, 'Brazil');
-- insert into subject (name, room_number, category) values ('Pineapple - Golden', 27, 'Indonesia');
-- insert into subject (name, room_number, category) values ('Veal - Sweetbread', 68, 'Eritrea');
-- insert into subject (name, room_number, category) values ('Fiddlehead - Frozen', 37, 'China');
-- insert into subject (name, room_number, category) values ('Fork - Plastic', 84, 'Indonesia');
-- insert into subject (name, room_number, category) values ('Wine - Alicanca Vinho Verde', 49, 'Russia');
-- insert into subject (name, room_number, category) values ('Rice - Aborio', 26, 'Peru');
-- insert into subject (name, room_number, category) values ('Duck - Legs', 76, 'Russia');
-- insert into subject (name, room_number, category) values ('Salmon - Sockeye Raw', 71, 'South Korea');
-- insert into subject (name, room_number, category) values ('Towels - Paper / Kraft', 14, 'Afghanistan');
-- insert into subject (name, room_number, category) values ('Bread - Petit Baguette', 9, 'Japan');
-- insert into subject (name, room_number, category) values ('Five Alive Citrus', 4, 'Poland');
-- insert into subject (name, room_number, category) values ('Quail - Jumbo Boneless', 78, 'Indonesia');


----------------------------------------------------------------------------------------------
---------------Student-------------------

-- CREATE FUNCTION student_trigger()
--     RETURNS trigger
--     LANGUAGE 'plpgsql'
-- AS $$
-- begin
-- 	insert into logs ("table_name","row_id","action", "old_data", "new_data")
-- 	values ('student', OLD.id, 'update', OLD, NEW);
-- 	return new;
-- end
-- $$;


-- CREATE OR REPLACE TRIGGER student_changes
--     BEFORE UPDATE 
--     ON student
--     FOR EACH ROW
--     EXECUTE FUNCTION student_trigger();

-- select * from logs
-- select * from student

-- update student
-- set age = 45
-- where id = 3;

-- --------------group--------------------------

-- CREATE FUNCTION group_trigger()
--     RETURNS trigger
--     LANGUAGE 'plpgsql'
-- AS $$
-- begin
-- 	insert into logs ("table_name","row_id","action", "old_data", "new_data")
-- 	values ('group', OLD.id, 'update', OLD, NEW);
-- 	return new;
-- end
-- $$;

-- CREATE OR REPLACE TRIGGER group_changes
--     BEFORE UPDATE 
--     ON student_of_group
--     FOR EACH ROW
--     EXECUTE FUNCTION group_trigger();

-- select * from logs
-- select * from student_of_group

-- update student_of_group
-- set count = 1
-- where count = 33


-- --------------subject--------------------------

-- CREATE FUNCTION subject_trigger()
--     RETURNS trigger
--     LANGUAGE 'plpgsql'
-- AS $$
-- begin
-- 	insert into logs ("table_name","row_id","action", "old_data", "new_data")
-- 	values ('subject', OLD.id, 'update', OLD, NEW);
-- 	return new;
-- end
-- $$;
	
-- CREATE OR REPLACE TRIGGER subject_changes
--     BEFORE UPDATE 
--     ON subject
--     FOR EACH ROW
--     EXECUTE FUNCTION subject_trigger();

-- select * from logs
-- select * from subject

-- update subject
-- set category = 'Uzbekistan'
-- where id = 2
