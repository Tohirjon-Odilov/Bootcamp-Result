namespace _47_lesson_entity_fremwork.Models
{
    public record Teacher
    {
        public int teacher_id { get; set; }
        public string full_name { get; set; }
        public int age { get; set; }
        public string salary { get; set; }
        public string phone { get; set; }
        public int groups_count { get; set; }
        public int experience { get; set; }
    }
}
/*
 create table course (
	course_id serial, 
	course_name varchar(30),
	teacher_id int,
	duration varchar(30),
	price money,
	description text,
	students_count int
)

create table student (
	student_id serial,
	first_name varchar(30),
	second_name varchar(30),
	age int,
	course_id int,
	phone varchar(30),
	parent_phone varchar(30),
	shot_number money
)

create table teacher (
	teacher_id serial,
	first_name varchar(30)
)



*/
