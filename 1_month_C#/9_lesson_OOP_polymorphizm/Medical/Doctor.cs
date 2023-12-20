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
        private int id; 
        public int Id {
            get
            {
                foreach (Doctor item in Clinic.Doctors)
                {
                    if(item.Id == id)
                    {
                        return item.Id;
                    }
                }
                return id;
            }
            set
            {
                id = value;
            } 
        }
        public string Expert {  get; set; }
    }
}
