namespace _9_lesson_OOP_polymorphizm.Medical
{
    public partial class Run
    {
        Doctor doctor1 = new Doctor("Jamshid", "Jamshidov", 101, 301, Gender.Male, "Oculist");
        Doctor doctor2 = new Doctor("Muzaffar", "Jamshidov", 102, 302, Gender.Male, "Nurse");
        Doctor doctor3 = new Doctor("Alisher", "Jamshidov", 103, 303, Gender.Male, "Oculist");
        Doctor doctor4 = new Doctor("Jamshid", "Jamshidov", 104, 304, Gender.Male, "Nurse");
        Doctor doctor5 = new Doctor("Olima", "Jamshidova", 105, 305, Gender.Female, "Nurse");
        Doctor doctor6 = new Doctor("Moxira", "Mirpo'latova", 106, 306, Gender.Female, "Professor");

        Person person1 = new Person("Odiljon", "Tohirov", 201, Gender.Male);
        Person person2 = new Person("Homidjon", "Sobirov", 202, Gender.Male);
        Person person3 = new Person("Alisher", "Husanov", 203, Gender.Male);
        Person person4 = new Person("Jabbor", "Husanov", 204, Gender.Male);
        Person person5 = new Person("Jolid", "Yigitaliyev", 205, Gender.Male);
        Person person6 = new Person("Jolida", "Yigitaliyeva", 206, Gender.Female);
    }
}
