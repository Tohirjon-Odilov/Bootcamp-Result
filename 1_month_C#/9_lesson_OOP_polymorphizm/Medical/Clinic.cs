using System.Collections;

namespace _9_lesson_OOP_polymorphizm.Medical
{
    public class Clinic
    {
        //Patient person = new Patient("Husnigul", "Ortiqboyeva", 1111, Gender.Famale);
        public static List<Person> Persons = new List<Person>();
        public static List<Doctor> Doctors = new List<Doctor>();
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

        public string? assignPatientToDoctor(int patientSsn, int doctorId)
        {
            //Doctor? doctor = GetDoctor(doctorId);
            bool isDoctorFound = true;
            bool isPatientFound  = true;
            foreach (Doctor nurse in Doctors)
            {
                if(nurse.Id == doctorId)
                {
                    isDoctorFound = false;
                    Person.PatientDoctor = nurse;
                    //Person.GetDoctor(nurse);
                    Console.WriteLine("Done");
                }
            }
            foreach (Person item in Persons)
            {
                if(item.Ssn == patientSsn)
                {
                    //Person.GetDoctor(item);
                    isPatientFound = false;
                    Console.WriteLine("Done");
                }
            }


            if (isDoctorFound) { return "NoSuchDoctor"; }
            else if (isPatientFound) { return "NoSuchPatient"; }
            return "Assigned succesfully :)";
        }
            //Random rand = new Random();
            //int randomIndex = rand.Next(0, Doctors.Count);
            //return Doctors[randomIndex].Name;
        
    }
}
