namespace _9_lesson_OOP_polymorphizm.Medical
{
    public class Patient
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int Ssn { get; set; }
        public Enum Gender {  get; set; }

        public Patient(string name, string surname, int ssn, Enum gender)
        {
            Name = name;
            Surname = surname;
            Ssn = ssn;
            Gender = gender;
        }
    }
}
