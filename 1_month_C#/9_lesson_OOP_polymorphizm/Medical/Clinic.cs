using System.Collections;

namespace _9_lesson_OOP_polymorphizm.Medical
{
    public class Clinic
    {
        //Patient person = new Patient("Husnigul", "Ortiqboyeva", 1111, Gender.Famale);
        private ArrayList Patients = new ArrayList();
        private ArrayList Nurses = new ArrayList();
        public Clinic()
        {
            
        }

        public string AddPatient(Patient person) { 
            Patients.Add(person);
            return "Person added succesfully :)"; 
        }

        public Patient? GetPatient(int Ssn) {
            foreach (Patient person in Patients)
            {
                if (person.Ssn == Ssn) return person;
            }
            return null;
        }

        public string AddPatient(Nurse nurse) 
        {
            Nurses.Add(nurse);
            return "Added succesfully :)";
        }
    }
}
