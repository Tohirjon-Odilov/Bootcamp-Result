using System.Collections;

namespace _9_lesson_OOP_polymorphizm.Medical
{
    public class Clinic
    {
        //Patient person = new Patient("Husnigul", "Ortiqboyeva", 1111, Gender.Famale);
        public static ArrayList Persons = new ArrayList();
        public static ArrayList Doctors = new ArrayList();
        public Clinic()
        {
            
        }

        public string AddPatient(Person person) { 
            Persons.Add(person);
            return "Person added succesfully :)"; 
        }

        public Person? GetPatient(int Ssn) {
            foreach (Person person in Persons)
            {
                if (person.Ssn == Ssn) return person;
            }
            return null;
        }

        public string AddDoctor(Doctor nurse) 
        {
            Doctors.Add(nurse);
            return "Added succesfully :)";
        }
        public Doctor? GetDoctor(int Id) 
        {
            foreach (Doctor nurse in Doctors)
            {
                if (nurse.Id == Id) return nurse;
            }
            return null;
        }
    }
}
