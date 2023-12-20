namespace _9_lesson_OOP_polymorphizm.Medical
{
    public class Doctor : Person
    {
        public Doctor(string name, string surname, int ssn, int id, Enum gender, string expert)
            : base(name, surname, ssn, gender)
        {
            Id = id;
            Expert = expert;
        }
        // Doctor'ning yagona id'si
        private int id; 
        public static List<Person> attachedPatients = new List<Person>();
        // Id'ni olish va id'ga qiymat berish
        public int Id {
            get
            {
                //foreach (Doctor item in Clinic.Doctors)
                //{
                //    if(item.Id == id)
                //    {
                //        return item.Id;
                //    }
                //}
                return id;
            }
            set
            {
                id = value;
            } 
        }
        // Doctorninng mutahasisligi
        public string Expert {  get; set; }

        // Shifokorga biriktirilgan bemorlar ro'yhatini olish
        public List<Person> getPatients(Person person)
        {
            return attachedPatients;
        }
    }
}
