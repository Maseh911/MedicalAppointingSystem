using MedicalAppointingSystem.Areas.Identity.Data;
using MedicalAppointingSystem.Models;

namespace MedicalAppointingSystem.Data
{
    public class DatabaseStartup
    {
        public static void StartUp(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var Context = serviceScope.ServiceProvider.GetService<MedicalAppointingDbContext>();
                Context.Database.EnsureCreated();

                if (Context.Patient.Any() || Context.Doctor.Any() || Context.AppointmentTime.Any() || Context.Hospital.Any() || Context.Diagnosis.Any())
                {
                    return;
                }
                var diagnoses = new Diagnosis[]
                {
                        new Diagnosis { DiagnosisName = "Depression", Symptoms = "Sadness, lack of energy" },
                        new Diagnosis { DiagnosisName = "Anxiety", Symptoms = "Excessive worry, panic attacks" },
                        new Diagnosis { DiagnosisName = "Diabetes", Symptoms = "High blood sugar, frequent urination" },
                        new Diagnosis { DiagnosisName = "Hypertension", Symptoms = "High blood pressure" },
                        new Diagnosis { DiagnosisName = "Asthma", Symptoms = "Shortness of breath, wheezing" },
                        new Diagnosis { DiagnosisName = "Arthritis", Symptoms = "Joint pain, stiffness" },
                        new Diagnosis { DiagnosisName = "Migraine", Symptoms = "Severe headaches, sensitivity to light" },
                        new Diagnosis { DiagnosisName = "Obesity", Symptoms = "Excessive weight gain" },
                        new Diagnosis { DiagnosisName = "Heart Disease", Symptoms = "Chest pain, shortness of breath" },
                        new Diagnosis { DiagnosisName = "Insomnia", Symptoms = "Difficulty sleeping" },
                        new Diagnosis { DiagnosisName = "Cancer", Symptoms = "Abnormal growth of cells" },
                        new Diagnosis { DiagnosisName = "Eczema", Symptoms = "Skin inflammation, itching" },
                        new Diagnosis { DiagnosisName = "Gastritis", Symptoms = "Stomach inflammation, pain" },
                        new Diagnosis { DiagnosisName = "Allergies", Symptoms = "Sneezing, itching, congestion" },
                        new Diagnosis { DiagnosisName = "Hyperthyroidism", Symptoms = "Weight loss, rapid heartbeat" }
                };
                Context.Diagnosis.AddRange(diagnoses);
                Context.SaveChanges();

                var hospitals = new Hospital[]
                {
                        new Hospital { HospitalName = "Wellington Hospital", Address = "Wellington" },
                        new Hospital { HospitalName = "Christchurch Hospital", Address = "Christchurch" },
                        new Hospital { HospitalName = "Waikato Hospital", Address = "Hamilton" },
                        new Hospital { HospitalName = "Dunedin Hospital", Address = "Dunedin" },
                        new Hospital { HospitalName = "Middlemore Hospital", Address = "Auckland" },
                        new Hospital { HospitalName = "Palmerston North Hospital", Address = "Palmerston North" },
                        new Hospital { HospitalName = "North Shore Hospital", Address = "Auckland" },
                        new Hospital { HospitalName = "Tauranga Hospital", Address = "Tauranga" },
                        new Hospital { HospitalName = "Nelson Hospital", Address = "Nelson" },
                        new Hospital { HospitalName = "Whangarei Hospital", Address = "Whangarei" },
                        new Hospital { HospitalName = "Rotorua Hospital", Address = "Rotorua" },
                        new Hospital { HospitalName = "Invercargill Hospital", Address = "Invercargill" },
                        new Hospital { HospitalName = "Gisborne Hospital", Address = "Gisborne" },
                        new Hospital { HospitalName = "Timaru Hospital", Address = "Timaru" },
                        new Hospital { HospitalName = "Hawke's Bay Hospital", Address = "Hastings" }
                };
                Context.Hospital.AddRange(hospitals);
                Context.SaveChanges();

                var Patients = new Patient[]
                {
                        new Patient { FirstName = "William", LastName = "Bob", Phone = "0240448987", Email = "WilliamBob@gmail.school.nz", Address = "Avondale College", DiagnosisId = 1},
                        new Patient { FirstName = "John", LastName = "Doe", Phone = "02123454678", Email = "Johndoe@gmail.com", Address = "123 Main St, Auckland", DiagnosisId = 2 },
                        new Patient { FirstName = "Jane", LastName = "Smith", Phone = "02798476543", Email = "JaneSmith@gmail.com", Address = "456 Queen St, Wellington", DiagnosisId = 3 },
                        new Patient { FirstName = "Michael", LastName = "Brown", Phone = "02423456789", Email = "MichaelBrown@gmail.com", Address = "789 King St, Christchurch", DiagnosisId = 4 },
                        new Patient { FirstName = "Sarah", LastName = "Wilson", Phone = "02764543210", Email = "Sarahwilson@gmail.com", Address = "987 George St, Dunedin", DiagnosisId = 5 },
                        new Patient { FirstName = "David", LastName = "Taylor", Phone = "02185765432", Email = "DavidTaylor@gmail.com", Address = "234 High St, Hamilton", DiagnosisId = 6 },
                        new Patient { FirstName = "Emma", LastName = "Thomas", Phone = "02256578901", Email = "EmmaThomas@gmail.com", Address = "345 Broadway Ave, Palmerston North", DiagnosisId = 7 },
                        new Patient { FirstName = "Christopher", LastName = "Martinez", Phone = "02755432167", Email = "ChristopherMartinez@gmail.com", Address = "456 Victoria Rd, Tauranga", DiagnosisId = 8 },
                        new Patient { FirstName = "Jessica", LastName = "Garcia", Phone = "02198676543", Email = "JessicaGarcia@gmail.com", Address = "567 Beach Rd, Nelson", DiagnosisId = 9 },
                        new Patient { FirstName = "Daniel", LastName = "Lopez", Phone = "02245647890", Email = "DanielLopez@gmail.com", Address = "678 Hillside Ave, Whangarei", DiagnosisId = 10 },
                        new Patient { FirstName = "Sophia", LastName = "Young", Phone = "02776524321", Email = "SophiaYoung@gmail.com", Address = "789 Lake Rd, Rotorua", DiagnosisId = 11 },
                        new Patient { FirstName = "William", LastName = "Harris", Phone = "02187565432", Email = "WilliamHarris@gmail.com", Address = "890 Park St, Invercargill", DiagnosisId = 12 },
                        new Patient { FirstName = "Olivia", LastName = "Clark", Phone = "02254362167", Email = "OliviaClark@gmail.com", Address = "123 Forest Ave, Gisborne", DiagnosisId = 13 },
                        new Patient { FirstName = "Alexander", LastName = "Lewis", Phone = "02779876543", Email = "AlexanderLewis@gmail.com", Address = "234 River Rd, Timaru", DiagnosisId = 14 },
                        new Patient { FirstName = "Mia", LastName = "Lee", Phone = "02123455678", Email = "MiaLee@gmail.com", Address = "345 Pine St, Hastings", DiagnosisId = 15 },
                };
                Context.Patient.AddRange(Patients);
                Context.SaveChanges();

                var Doctors = new Doctor[]
                {
                        new Doctor { FirstName = "Steve", LastName = "Jobs", Phone = "02184733920", Email = "Stevejobs@gmail.com", HospitalId = 1},
                        new Doctor { FirstName = "Emily", LastName = "Johnson", Phone = "02123456783", Email = "EmilyJohnson@gmail.com", HospitalId = 2 },
                        new Doctor { FirstName = "James", LastName = "Williams", Phone = "02798765743", Email = "JamesWilliams@gmail.com", HospitalId = 3 },
                        new Doctor { FirstName = "Sophia", LastName = "Brown", Phone = "02234567869", Email = "SophiaBrown@gmail.com", HospitalId = 4 },
                        new Doctor { FirstName = "Alexander", LastName = "Jones", Phone = "02765543210", Email = "AlexanderJones@gmail.com", HospitalId = 5 },
                        new Doctor { FirstName = "Olivia", LastName = "Garcia", Phone = "02187655432", Email = "OliviaGarcia@gmail.com", HospitalId = 6 },
                        new Doctor { FirstName = "Jacob", LastName = "Martinez", Phone = "02255678901", Email = "JacobMartinez@gmail.com", HospitalId = 7 },
                        new Doctor { FirstName = "Ava", LastName = "Lopez", Phone = "02754321067", Email = "AvaLopez@gmail.com", HospitalId = 8 },
                        new Doctor { FirstName = "Michael", LastName = "Young", Phone = "02198769543", Email = "MichaelYoung@gmail.com", HospitalId = 9 },
                        new Doctor { FirstName = "Charlotte", LastName = "Harris", Phone = "02284567890", Email = "CharlotteHarris@gmail.com", HospitalId = 10 },
                        new Doctor { FirstName = "Noah", LastName = "Clark", Phone = "02776543621", Email = "NoahClark@gmail.com", HospitalId = 11 },
                        new Doctor { FirstName = "Grace", LastName = "Lewis", Phone = "02187654382", Email = "GraceLewis@gmail.com", HospitalId = 12 },
                        new Doctor { FirstName = "Benjamin", LastName = "Lee", Phone = "02254321867", Email = "BenjaminLee@gmail.com", HospitalId = 13 },
                        new Doctor { FirstName = "Sofia", LastName = "Walker", Phone = "02798765843", Email = "SofiaWalker@gmail.com", HospitalId = 14 },
                        new Doctor { FirstName = "William", LastName = "Hall", Phone = "02123456788", Email = "WilliamHall@gmail.com", HospitalId = 15 },
                };
                Context.Doctor.AddRange(Doctors);
                Context.SaveChanges();

                var AppointmentTimes = new Appointment[]
                {
                        new Appointment { Date = new DateTime(2024, 7, 23, 9, 15, 0), PatientId = 1, DoctorId = 1 },
                        new Appointment { Date = new DateTime(2024, 7, 24, 10, 0, 0), PatientId = 2, DoctorId = 2 },
                        new Appointment { Date = new DateTime(2024, 7, 25, 11, 30, 0), PatientId = 3, DoctorId = 3 },
                        new Appointment { Date = new DateTime(2024, 7, 26, 9, 15, 0), PatientId = 4, DoctorId = 4 },
                        new Appointment { Date = new DateTime(2024, 7, 27, 13, 45, 0), PatientId = 5, DoctorId = 5 },
                        new Appointment { Date = new DateTime(2024, 7, 28, 8, 30, 0), PatientId = 6, DoctorId = 6 },
                        new Appointment { Date = new DateTime(2024, 7, 29, 14, 0, 0), PatientId = 7, DoctorId = 7 },
                        new Appointment { Date = new DateTime(2024, 7, 30, 15, 15, 0), PatientId = 8, DoctorId = 8 },
                        new Appointment { Date = new DateTime(2024, 7, 31, 10, 45, 0), PatientId = 9, DoctorId = 9 },
                        new Appointment { Date = new DateTime(2024, 8, 1, 12, 0, 0), PatientId = 10, DoctorId = 10 },
                        new Appointment { Date = new DateTime(2024, 8, 2, 16, 30, 0), PatientId = 11, DoctorId = 11 },
                        new Appointment { Date = new DateTime(2024, 8, 3, 9, 0, 0), PatientId = 12, DoctorId = 12 },
                        new Appointment { Date = new DateTime(2024, 8, 4, 11, 0, 0), PatientId = 13, DoctorId = 13 },
                        new Appointment { Date = new DateTime(2024, 8, 5, 13, 30, 0), PatientId = 14, DoctorId = 14 },
                        new Appointment { Date = new DateTime(2024, 8, 6, 14, 45, 0), PatientId = 15, DoctorId = 15 },
                };
                Context.AppointmentTime.AddRange(AppointmentTimes);
                Context.SaveChanges();
            }
        }
    }
}
