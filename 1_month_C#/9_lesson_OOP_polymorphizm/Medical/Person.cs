namespace _9_lesson_OOP_polymorphizm.Medical
{
    public class Person
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int Ssn { get; set; }
        public Enum Gender { get; set; }
        public static Doctor? PatientDoctor;

        public static Doctor GetDoctor(Doctor doctor)
        {
            return doctor;
        }

        public Person(string name, string surname, int ssn, Enum gender)
        {
            Name = name;
            Surname = surname;
            Ssn = ssn;
            Gender = gender;
        }
    }
}
