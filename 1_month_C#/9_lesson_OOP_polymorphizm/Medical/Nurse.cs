namespace _9_lesson_OOP_polymorphizm.Medical
{
    public class Nurse
    {
        public Nurse()
        {
            
        }
        public string Name { get; set; }
        public string surname { get; set; }
        public int Ssn { get; set; }
        public Guid Id { get; } = Guid.NewGuid();
        public string expert {  get; set; }


    }
}
