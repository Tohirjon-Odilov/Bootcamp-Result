
#region lesson txt
// polymorthizm (
// overloading, overriding) 
// interace => interfeys faqat interfeysdan vorish oladi. bir nechta interface'ni ichida bir-xil method ochilsa voris olingan classda har bir inreface'ni methodini ishlatish uchun anashu interfaceni nomini yozib method chaqirialdi lekin u methdi boshqa classlarda ishlata olmaymiz olingan objectdayam
// 
// partial
// enum
// struct
#endregion

#region Calculator
using _9_lesson_OOP_polymorphizm;
using _9_lesson_OOP_polymorphizm.Calculator;
using _9_lesson_OOP_polymorphizm.Medical;
using System.Collections;

//CalculatorService<int> calculator = new CalculatorService<int>(2, 3);
#endregion

#region Clinic
Doctor doctor1 = new Doctor("Jamshid", "Jamshidov", 321, 333, Gender.Male, "Oculist");
Doctor doctor2 = new Doctor("Muzaffar", "Jamshidov", 322, 334, Gender.Male, "Nurse");
Doctor doctor3 = new Doctor("Alisher", "Jamshidov", 323, 335, Gender.Male, "Oculist");
Doctor doctor4 = new Doctor("Jamshid", "Jamshidov", 324, 336, Gender.Male, "Nurse");
Doctor doctor5 = new Doctor("Olima", "Jamshidova", 325, 337, Gender.Female, "Nurse");
Doctor doctor6 = new Doctor("Moxira", "Mirpo'latova", 326, 338, Gender.Female, "Professor");

Person person1 = new Person("Odiljon", "Tohirov", 123, Gender.Male);
Person person2 = new Person("Homidjon", "Sobirov", 124, Gender.Male);
Person person3 = new Person("Alisher", "Husanov", 125, Gender.Male);
Person person4 = new Person("Jabbor", "Husanov", 126, Gender.Male);
Person person5 = new Person("Jolid", "Yigitaliyev", 127, Gender.Male);
Person person6 = new Person("Jolida", "Yigitaliyeva", 128, Gender.Female);

Clinic klinika = new Clinic();

klinika.AddDoctor(doctor1);
klinika.AddDoctor(doctor2);
klinika.AddDoctor(doctor3);
klinika.AddDoctor(doctor4);
klinika.AddDoctor(doctor5);
klinika.AddDoctor(doctor6);

klinika.AddPatient(person1);
klinika.AddPatient(person2);
klinika.AddPatient(person3);
klinika.AddPatient(person4);
klinika.AddPatient(person5);
klinika.AddPatient(person6);

Console.WriteLine(klinika.assignPatientToDoctor(person1.Ssn, doctor5.Id));

//ArrayList Patients = new ArrayList();
//Patients.Add(person);

//foreach (Patient item in Patients)
//{
//    Console.WriteLine(item.Gender);
//}

#endregion

#region Lesson files

//MyGenerics<string, int> generics = new MyGenerics<string, int>("Tohirjon", 2003, 08, 19);
//Console.WriteLine(generics.About());

#endregion