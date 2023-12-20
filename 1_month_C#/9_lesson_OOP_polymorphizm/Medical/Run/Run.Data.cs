namespace _9_lesson_OOP_polymorphizm.Medical
{
    public partial class Run
    {
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
    }
}
