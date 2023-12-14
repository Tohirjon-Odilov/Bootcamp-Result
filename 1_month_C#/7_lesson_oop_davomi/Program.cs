//["matematika", "ingiliz-tili", "Ona-Tili"]

using _7_lesson_oop_davomi;

var birthDate1 = new DateOnly(2003, 12, 12);
var birthDate2 = new DateOnly(2013, 11, 12);

Teacher teacher1 = new Teacher("Komiljon", birthDate1, 2000m);
Console.WriteLine(teacher1.Name);
Console.WriteLine(teacher1.DateOfBirth);
teacher1.Teach();
Student student1 = new Student("Akobir", birthDate2, true);
Console.WriteLine(student1.Name);
Console.WriteLine(student1.DateOfBirth);
student1.Learn();


