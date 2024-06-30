using MedicalAppointingSystem.Areas.Identity.Data;
using MedicalAppointingSystem.Models;

namespace MedicalAppointingSystem
{
    public static class DbInitializer
    {
        public static void Initialize(MedicalAppointingDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any existing data.
            if (context.Patient.Any() || context.Doctor.Any() || context.AppointmentTime.Any() || context.Diagnosis.Any() || context.Hospital.Any())
            {
                return;   // DB has been seeded
            }

            var patients = new Patient[]
            {
                new Patient { FirstName = "John", LastName = "Doe", Phone = "1234567890", Email = "john.doe@example.com", Address = "123 Main St" },
                new Patient { FirstName = "Jane", LastName = "Doe", Phone = "0987654321", Email = "jane.doe@example.com", Address = "456 Elm St" },
                new Patient { FirstName = "Michael", LastName = "Brown", Phone = "1122334455", Email = "michael.brown@example.com", Address = "789 Pine St" },
                new Patient { FirstName = "Emily", LastName = "Davis", Phone = "6677889900", Email = "emily.davis@example.com", Address = "321 Birch St" },
                new Patient { FirstName = "Sarah", LastName = "Miller", Phone = "2233445566", Email = "sarah.miller@example.com", Address = "654 Oak St" }
            };
            foreach (Patient p in patients)
            {
                context.Patient.Add(p);
            }

            var doctors = new Doctor[]
            {
                new Doctor { FirstName = "Alice", LastName = "Smith", Phone = "1234567890", Email = "alice.smith@example.com" },
                new Doctor { FirstName = "Bob", LastName = "Johnson", Phone = "0987654321", Email = "bob.johnson@example.com" },
                new Doctor { FirstName = "Charlie", LastName = "Taylor", Phone = "3344556677", Email = "charlie.taylor@example.com" },
                new Doctor { FirstName = "Diana", LastName = "Lee", Phone = "4455667788", Email = "diana.lee@example.com" },
                new Doctor { FirstName = "Ethan", LastName = "Williams", Phone = "5566778899", Email = "ethan.williams@example.com" }
            };
            foreach (Doctor d in doctors)
            {
                context.Doctor.Add(d);
            }

            var appointments = new AppointmentTime[]
            {
                new AppointmentTime { AppointedTime = DateTime.Today.AddHours(9), PatientId = 1 },
                new AppointmentTime { AppointedTime = DateTime.Today.AddHours(10), PatientId = 2 },
                new AppointmentTime { AppointedTime = DateTime.Today.AddHours(11), PatientId = 3 },
                new AppointmentTime { AppointedTime = DateTime.Today.AddHours(12), PatientId = 4 },
                new AppointmentTime { AppointedTime = DateTime.Today.AddHours(13), PatientId = 5 },
                new AppointmentTime { AppointedTime = DateTime.Today.AddHours(14), PatientId = 1 },
                new AppointmentTime { AppointedTime = DateTime.Today.AddHours(15), PatientId = 2 },
                new AppointmentTime { AppointedTime = DateTime.Today.AddHours(16), PatientId = 3 },
                new AppointmentTime { AppointedTime = DateTime.Today.AddHours(17), PatientId = 4 },
                new AppointmentTime { AppointedTime = DateTime.Today.AddHours(18), PatientId = 5 }
            };
            foreach (AppointmentTime a in appointments)
            {
                context.AppointmentTime.Add(a);
            }

            var diagnoses = new Diagnosis[]
            {
                new Diagnosis { Diagnosis_Name = "Flu" },
                new Diagnosis { Diagnosis_Name = "Cold" },
                new Diagnosis { Diagnosis_Name = "COVID-19" },
                new Diagnosis { Diagnosis_Name = "Asthma" },
                new Diagnosis { Diagnosis_Name = "Allergy" },
                new Diagnosis { Diagnosis_Name = "Hypertension" },
                new Diagnosis { Diagnosis_Name = "Diabetes" },
                new Diagnosis { Diagnosis_Name = "Migraine" },
                new Diagnosis { Diagnosis_Name = "Arthritis" },
                new Diagnosis { Diagnosis_Name = "Bronchitis"}
            };
            foreach (Diagnosis d in diagnoses)
            {
                context.Diagnosis.Add(d);
            }

            var hospitals = new Hospital[]
            {
                new Hospital { HospitalName = "General Hospital", Address = "789 Maple St" },
                new Hospital { HospitalName = "City Hospital", Address = "321 Oak St" },
                new Hospital { HospitalName = "County Hospital", Address = "654 Pine St" },
                new Hospital { HospitalName = "State Hospital", Address = "987 Birch St" },
                new Hospital { HospitalName = "National Hospital", Address = "123 Cedar St" }
            };
            foreach (Hospital h in hospitals)
            {
                context.Hospital.Add(h);
            }

            context.SaveChanges();
        }
    }
}