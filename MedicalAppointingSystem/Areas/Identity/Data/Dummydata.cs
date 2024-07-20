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
                var diagnoses = new Diagnosis[]     // There are 30 dummy datas for the Diagnosis table //
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
                        new Diagnosis { DiagnosisName = "Hyperthyroidism", Symptoms = "Weight loss, rapid heartbeat" },
                        new Diagnosis { DiagnosisName = "Osteoporosis", Symptoms = "Bone density loss, fractures" },
                        new Diagnosis { DiagnosisName = "Chronic Fatigue Syndrome", Symptoms = "Extreme tiredness, muscle pain" },
                        new Diagnosis { DiagnosisName = "COPD", Symptoms = "Chronic bronchitis, emphysema" },
                        new Diagnosis { DiagnosisName = "Lupus", Symptoms = "Fatigue, joint pain" },
                        new Diagnosis { DiagnosisName = "Parkinson's Disease", Symptoms = "Tremors, stiffness" },
                        new Diagnosis { DiagnosisName = "Epilepsy", Symptoms = "Seizures, confusion" },
                        new Diagnosis { DiagnosisName = "Celiac Disease", Symptoms = "Digestive discomfort, anemia" },
                        new Diagnosis { DiagnosisName = "Psoriasis", Symptoms = "Skin rashes, itching" },
                        new Diagnosis { DiagnosisName = "Multiple Sclerosis", Symptoms = "Numbness, vision problems" },
                        new Diagnosis { DiagnosisName = "Gout", Symptoms = "Sudden, severe joint pain" },
                        new Diagnosis { DiagnosisName = "Anemia", Symptoms = "Fatigue, pale skin" },
                        new Diagnosis { DiagnosisName = "Bipolar Disorder", Symptoms = "Mood swings, energy shifts" },
                        new Diagnosis { DiagnosisName = "Schizophrenia", Symptoms = "Hallucinations, delusions" },
                        new Diagnosis { DiagnosisName = "Chronic Kidney Disease", Symptoms = "Fatigue, swelling" },
                        new Diagnosis { DiagnosisName = "Crohn's Disease", Symptoms = "Abdominal pain, diarrhea" },
                        new Diagnosis { DiagnosisName = "Ulcerative Colitis", Symptoms = "Abdominal pain, bleeding" },
                        new Diagnosis { DiagnosisName = "Hyperlipidemia", Symptoms = "High cholesterol, no symptoms" },
                        new Diagnosis { DiagnosisName = "Tuberculosis", Symptoms = "Cough, weight loss" },
                        new Diagnosis { DiagnosisName = "Dementia", Symptoms = "Memory loss, confusion" },
                        new Diagnosis { DiagnosisName = "Hyperglycemia", Symptoms = "High blood sugar, frequent urination" },
                };
                Context.Diagnosis.AddRange(diagnoses);
                Context.SaveChanges();

                var hospitals = new Hospital[]     // There are 30 dummy datas for the Hospital table //
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
                        new Hospital { HospitalName = "Hawke's Bay Hospital", Address = "Hastings" },
                        new Hospital { HospitalName = "North Shore Hospital", Address = "Auckland" },
                        new Hospital { HospitalName = "Manukau SuperClinic", Address = "Manukau" },
                        new Hospital { HospitalName = "Hutt Valley Hospital", Address = "Lower Hutt" },
                        new Hospital { HospitalName = "Waitakere Hospital", Address = "Waitakere" },
                        new Hospital { HospitalName = "Counties Manukau Health", Address = "South Auckland" },
                        new Hospital { HospitalName = "Nelson Marlborough Health", Address = "Nelson" },
                        new Hospital { HospitalName = "Southern Cross Hospital", Address = "Auckland" },
                        new Hospital { HospitalName = "MercyAscot Hospital", Address = "Auckland" },
                        new Hospital { HospitalName = "Auckland DHB", Address = "Auckland" },
                        new Hospital { HospitalName = "Canterbury DHB", Address = "Christchurch" },
                        new Hospital { HospitalName = "Capital & Coast DHB", Address = "Wellington" },
                        new Hospital { HospitalName = "Taranaki Base Hospital", Address = "New Plymouth" },
                        new Hospital { HospitalName = "Southland Hospital", Address = "Invercargill" },
                        new Hospital { HospitalName = "Wairarapa Hospital", Address = "Masterton" },
                        new Hospital { HospitalName = "Lakes DHB", Address = "Rotorua" }
                };
                Context.Hospital.AddRange(hospitals);
                Context.SaveChanges();

                var Patients = new Patient[]     // There are 30 dummy datas for the Patient table //
                {
                        new Patient { FirstName = "William", LastName = "Bob", Phone = "02404483987", Email = "WilliamBob@gmail.school.nz", Address = "Avondale College", DiagnosisId = 1},
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
                        new Patient { FirstName = "Liam", LastName = "Adams", Phone = "02234567890", Email = "liam.adams@gmail.com", Address = "123 K Road, Auckland", DiagnosisId = 16 },
                        new Patient { FirstName = "Lucas", LastName = "Carter", Phone = "02198765432", Email = "lucas.carter@gmail.com", Address = "456 Dominion Road, Wellington", DiagnosisId = 17 },
                        new Patient { FirstName = "Charlotte", LastName = "Bell", Phone = "02712345678", Email = "charlotte.bell@gmail.com", Address = "789 Queen Street, Christchurch", DiagnosisId = 18 },
                        new Patient { FirstName = "Mason", LastName = "Wood", Phone = "02098765432", Email = "mason.wood@gmail.com", Address = "123 Main Street, Hamilton", DiagnosisId = 19 },
                        new Patient { FirstName = "Amelia", LastName = "Parker", Phone = "02234567891", Email = "amelia.parker@gmail.com", Address = "456 High Street, Dunedin", DiagnosisId = 20 },
                        new Patient { FirstName = "Henry", LastName = "Wright", Phone = "02198765431", Email = "henry.wright@gmail.com", Address = "789 Elm Street, Tauranga", DiagnosisId = 21 },
                        new Patient { FirstName = "Evelyn", LastName = "Turner", Phone = "02712345677", Email = "evelyn.turner@gmail.com", Address = "123 Oak Street, Napier", DiagnosisId = 22 },
                        new Patient { FirstName = "Oscar", LastName = "Walker", Phone = "02098765433", Email = "oscar.walker@gmail.com", Address = "456 Willow Street, Nelson", DiagnosisId = 23 },
                        new Patient { FirstName = "Sophie", LastName = "Ward", Phone = "02234567892", Email = "sophie.ward@gmail.com", Address = "789 Pine Street, Whangarei", DiagnosisId = 24 },
                        new Patient { FirstName = "Logan", LastName = "Campbell", Phone = "02198765434", Email = "logan.campbell@gmail.com", Address = "123 Cedar Street, Rotorua", DiagnosisId = 25 },
                        new Patient { FirstName = "Isabella", LastName = "Mitchell", Phone = "02712345676", Email = "isabella.mitchell@gmail.com", Address = "456 Birch Street, Invercargill", DiagnosisId = 26 },
                        new Patient { FirstName = "Lucas", LastName = "Hughes", Phone = "02098765434", Email = "lucas.hughes@gmail.com", Address = "789 Spruce Street, Gisborne", DiagnosisId = 27 },
                        new Patient { FirstName = "Emily", LastName = "Evans", Phone = "02234567893", Email = "emily.evans@gmail.com", Address = "123 Ash Street, Timaru", DiagnosisId = 28 },
                        new Patient { FirstName = "Ella", LastName = "Morgan", Phone = "02198765435", Email = "ella.morgan@gmail.com", Address = "456 Fir Street, Hastings", DiagnosisId = 29 },
                        new Patient { FirstName = "James", LastName = "Thompson", Phone = "02712345675", Email = "james.thompson@gmail.com", Address = "789 Poplar Street, Blenheim", DiagnosisId = 30 }
                };
                Context.Patient.AddRange(Patients);
                Context.SaveChanges();

                var Doctors = new Doctor[]     // There are 30 dummy datas for the Doctor table //
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
                        new Doctor { FirstName = "Lily", LastName = "White", Phone = "02187654321", Email = "lily.white@gmail.com", HospitalId = 16 },
                        new Doctor { FirstName = "Jack", LastName = "Harris", Phone = "02123456784", Email = "jack.harris@gmail.com", HospitalId = 17 },
                        new Doctor { FirstName = "Grace", LastName = "Roberts", Phone = "02798765744", Email = "grace.roberts@gmail.com", HospitalId = 18 },
                        new Doctor { FirstName = "Ethan", LastName = "Lewis", Phone = "02234567870", Email = "ethan.lewis@gmail.com", HospitalId = 19 },
                        new Doctor { FirstName = "Mia", LastName = "Walker", Phone = "02765543211", Email = "mia.walker@gmail.com", HospitalId = 20 },
                        new Doctor { FirstName = "Oliver", LastName = "Hall", Phone = "02187655433", Email = "oliver.hall@gmail.com", HospitalId = 21 },
                        new Doctor { FirstName = "Ava", LastName = "King", Phone = "02255678902", Email = "ava.king@gmail.com", HospitalId = 22 },
                        new Doctor { FirstName = "Lucas", LastName = "Wright", Phone = "02754321068", Email = "lucas.wright@gmail.com", HospitalId = 23 },
                        new Doctor { FirstName = "Emily", LastName = "Lopez", Phone = "02198769544", Email = "emily.lopez@gmail.com", HospitalId = 24 },
                        new Doctor { FirstName = "Ella", LastName = "Scott", Phone = "02284567891", Email = "ella.scott@gmail.com", HospitalId = 25 },
                        new Doctor { FirstName = "Benjamin", LastName = "Green", Phone = "02776543622", Email = "benjamin.green@gmail.com", HospitalId = 26 },
                        new Doctor { FirstName = "Sofia", LastName = "Adams", Phone = "02187654383", Email = "sofia.adams@gmail.com", HospitalId = 27 },
                        new Doctor { FirstName = "Aiden", LastName = "Baker", Phone = "02254321868", Email = "aiden.baker@gmail.com", HospitalId = 28 },
                        new Doctor { FirstName = "Abigail", LastName = "Perez", Phone = "02798765844", Email = "abigail.perez@gmail.com", HospitalId = 29 },
                        new Doctor { FirstName = "Henry", LastName = "Carter", Phone = "02123456789", Email = "henry.carter@gmail.com", HospitalId = 30 }
                };
                Context.Doctor.AddRange(Doctors);
                Context.SaveChanges();

                var AppointmentTimes = new Appointment[]     // There are 30 dummy datas for the Appointment table //
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
                        new Appointment { Date = new DateTime(2024, 8, 7, 9, 15, 0), PatientId = 16, DoctorId = 16 },
                        new Appointment { Date = new DateTime(2024, 8, 8, 10, 0, 0), PatientId = 17, DoctorId = 17 },
                        new Appointment { Date = new DateTime(2024, 8, 9, 11, 30, 0), PatientId = 18, DoctorId = 18 },
                        new Appointment { Date = new DateTime(2024, 8, 10, 9, 15, 0), PatientId = 19, DoctorId = 19 },
                        new Appointment { Date = new DateTime(2024, 8, 11, 13, 45, 0), PatientId = 20, DoctorId = 20 },
                        new Appointment { Date = new DateTime(2024, 8, 12, 8, 30, 0), PatientId = 21, DoctorId = 21 },
                        new Appointment { Date = new DateTime(2024, 8, 13, 14, 0, 0), PatientId = 22, DoctorId = 22 },
                        new Appointment { Date = new DateTime(2024, 8, 14, 15, 15, 0), PatientId = 23, DoctorId = 23 },
                        new Appointment { Date = new DateTime(2024, 8, 15, 10, 45, 0), PatientId = 24, DoctorId = 24 },
                        new Appointment { Date = new DateTime(2024, 8, 16, 12, 0, 0), PatientId = 25, DoctorId = 25 },
                        new Appointment { Date = new DateTime(2024, 8, 17, 16, 30, 0), PatientId = 26, DoctorId = 26 },
                        new Appointment { Date = new DateTime(2024, 8, 18, 9, 0, 0), PatientId = 27, DoctorId = 27 },
                        new Appointment { Date = new DateTime(2024, 8, 19, 11, 0, 0), PatientId = 28, DoctorId = 28 },
                        new Appointment { Date = new DateTime(2024, 8, 20, 13, 30, 0), PatientId = 29, DoctorId = 29 },
                        new Appointment { Date = new DateTime(2024, 8, 21, 14, 45, 0), PatientId = 30, DoctorId = 30 }
                };
                Context.AppointmentTime.AddRange(AppointmentTimes);
                Context.SaveChanges();
            }
        }
    }
}
