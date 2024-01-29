--CREATE OR REPLACE FUNCTION MYFUNC_FOR_TRIGGER() 
--RETURNS TRIGGER 
--LANGUAGE PLPGSQL 
--AS $$
--BEGIN
---- logic
--IF OLD. brand NEW.brand THEN
--insert into archive _ cars( brand, model, car _ year,
--values (OLD. brand, OLD.model, OLD. year, now( ) ) ;
--END IF;
--return NEW;
--END

--create or replace function myfunc_for_trigger( )
--returns trigger
--language PLPGSQL
--AS $$ 
--BEGIN 
----LOGIC 
--IF OLD. BRAND <> NEW. BRAND THEN CHANGED_ON )
--INSERT
--VALUES END IF;

--RETURN END INTO ARCHIVE_CARS(BRAND,
--	MODEL, (OLD. BRAND,
--			OLD.MODEL,
--			OLD. YEAR,
--			OLD; CAR _ YEAR,
--			NOW()) ;

--CHANGED_ON )
--CREATE TRIGGER TRIGGER_FOR_CARS_WTTH_UPDATE
--BEFORE
--UPDATE ON CARS
--FOR EACH ROW EXECUTE PROCEDURE MYFUNC_FOR_TRIGGER() ;


--CREATE TRIGGER TRIGGER_FOR_CARS_WITH_AFTER AFTER
--UPDATE ON CARS
--FOR EACH ROW EXECUTE PROCEDURE MYFUNC_FOR_TRIGGER() ;

----DELETE
--CREATE OR REPLACE TRIGGER TRIGGER_FOR_CARS_WITH_DELETE AFTER
--DELETE ON CARS
--FOR EACH ROW EXECUTE PROCEDURE MYFUNC_FOR_TRIGGER();


--UPDATE CARS
--SET BRAND = 'Brabus',
--	MODEL =
--WHERE MODEL = 'Monza'
--	DELETE
--	FROM CARS WHERE BRAND = 'KIA
--select * from cars
--select * from archive cars;
--insert into cars(brand, model, year)
--values( KIA',2024), ( 'KIA' ,
--	CREATE TABLE ARCHIVE_CARS(ID serial, BRAND VARCHAR(40),
--										MODEL VARCHAR(40),
--										CAR _ YEAR int, CHANGED_ON text 2024), (• BMW' , 2023)


CREATE TABLE "subject"(
    "id" BIGINT NOT NULL,
    "Name" VARCHAR(255) NOT NULL
);
ALTER TABLE
    "subject" ADD PRIMARY KEY("id");
CREATE TABLE "student"(
    "id" BIGINT NOT NULL,
    "Fullname" VARCHAR(255) NOT NULL,
    "Age" BIGINT NOT NULL,
    "Group_Id" BIGINT NOT NULL
);
ALTER TABLE
    "student" ADD PRIMARY KEY("id");
CREATE TABLE "Guruh"(
    "id" BIGINT NOT NULL,
    "Name" VARCHAR(255) NOT NULL
);
ALTER TABLE
    "Guruh" ADD PRIMARY KEY("id");
CREATE TABLE "bridge"(
    "Student_id" BIGINT NOT NULL,
    "Subject_id" BIGINT NOT NULL
);
ALTER TABLE
    "bridge" ADD CONSTRAINT "bridge_subject_id_foreign" FOREIGN KEY("Subject_id") REFERENCES "subject"("id");
ALTER TABLE
    "bridge" ADD CONSTRAINT "bridge_student_id_foreign" FOREIGN KEY("Student_id") REFERENCES "student"("id");
ALTER TABLE
    "student" ADD CONSTRAINT "student_group_id_foreign" FOREIGN KEY("Group_Id") REFERENCES "Guruh"("id");



CREATE OR REPLACE FUNCTION trigger_function_subject() 
   RETURNS TRIGGER 
   LANGUAGE PLPGSQL
AS $$
BEGIN

   INSERT INTO subject_archive(id, Name, changed_on)
   VALUES(OLD.id, OLD.Name, now());

   RETURN NEW;
END;
$$

CREATE TRIGGER trigger_for_subject_update
BEFORE UPDATE
ON subject
FOR EACH ROW
EXECUTE PROCEDURE trigger_function_subject()




CREATE OR REPLACE FUNCTION trigger_function_student() 
   RETURNS TRIGGER 
   LANGUAGE PLPGSQL
AS $$
BEGIN

   INSERT INTO student_archive(id, Name, changed_on)
   VALUES(OLD.id, OLD.Fullname, OLD.Age, OLD.Group_Id, now());

   RETURN NEW;
END;
$$

CREATE TRIGGER trigger_for_student_update
BEFORE UPDATE
ON student
FOR EACH ROW
EXECUTE PROCEDURE trigger_function_student()



CREATE OR REPLACE FUNCTION trigger_function_bridge() 
   RETURNS TRIGGER 
   LANGUAGE PLPGSQL
AS $$
BEGIN

   INSERT INTO bridge_archive(Student_id, Subject_id, changed_on)
   VALUES(OLD.Student_id, OLD.Subject_id, now());

   RETURN NEW;
END;
$$

CREATE TRIGGER trigger_for_bridge_update
BEFORE UPDATE
ON bridge
FOR EACH ROW
EXECUTE PROCEDURE trigger_function_bridge()



CREATE OR REPLACE FUNCTION trigger_function_guruh() 
   RETURNS TRIGGER 
   LANGUAGE PLPGSQL
AS $$
BEGIN

   INSERT INTO guruh_archive(id, Name, changed_on)
   VALUES(OLD.id, OLD.Name, now());

   RETURN NEW;
END;
$$

CREATE TRIGGER trigger_for_guruh_update
BEFORE UPDATE
ON guruh
FOR EACH ROW
EXECUTE PROCEDURE trigger_function_guruh()
