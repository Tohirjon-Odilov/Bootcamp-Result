﻿namespace _9_lesson_OOP_polymorphizm.Medical
{
    public partial class Run
    {
        Clinic klinika = new Clinic();
        public bool isRun = true;
        public string? userSelect;
        public int doctorId = 307;
        private int doctorSsn = 107;
        private int patientSsn = 207;
        public void addPersons()
        {
            klinika.AddDoctor(doctor1);
            klinika.AddDoctor(doctor2);
            klinika.AddDoctor(doctor3);
            klinika.AddDoctor(doctor4);
            klinika.AddDoctor(doctor5);
            klinika.AddDoctor(doctor6);

            klinika.AddPatient(person1);
            klinika.AddPatient(person2);
            klinika.AddPatient(person3);
            klinika.AddPatient(person4);
            klinika.AddPatient(person5);
            klinika.AddPatient(person6);
        }
    }
}
