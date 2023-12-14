using _7_lesson_oop_davomi;

#if amaliyot
#region amaliyot
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
#endregion
#endif
#region vazifa

Console.Write("Engine: ");
string engine = Console.ReadLine()!;
Console.Write("Time: ");
DateOnly date = DateOnly.Parse(Console.ReadLine()!);
Console.Write("Wings: ");
string wings = Console.ReadLine()!;
Console.Write("Wheel: ");
string wheel = Console.ReadLine()!;

Console.WriteLine("Journey by airplane");
Airplane plane = new Airplane(engine, date, wings);
plane.StartEngine("Contact");
plane.TakeOff("Taking off");
plane.Drive("Flying");
plane.Land("Landing");
plane.StopEngine("Whirr");

Console.WriteLine("Journey by car");
Car car = new Car(engine, date, wheel);
car.StartEngine("Brm brm");
car.Accelerate("Accelerating");
car.Drive("Motoring");
car.Brake("Braking");
car.StopEngine("Phut Phut");
#endregion