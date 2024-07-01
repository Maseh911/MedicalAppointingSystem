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
                var Patients = new Patient[]
                {
                    new Patient { FirstName = "Maseh", LastName = "Essa", Phone = "0240489487", Email = "ac121658@avcol.school.nz", Address = "Avondale College", DoctorId = 1, DiagnosisId = 1},
                };
                Context.Patient.AddRange(Patients);
                Context.SaveChanges();

                var Doctors = new Doctor[]
                {
                    new Doctor { FirstName = "Homer", LastName = "Simpson", Phone = "02184739203", Email = "HomerSimpson@gmail.com"},
                };
                Context.Doctor.AddRange(Doctors);
                Context.SaveChanges();

                var AppointmentTimes = new AppointmentTime[]
                {
                    new AppointmentTime { AppointedTime = new DateTime(2024, 7, 23, 9, 15, 0), PatientId = 2},
                };
                Context.AppointmentTime.AddRange(AppointmentTimes);
                Context.SaveChanges();

                var Hospitals = new Hospital[]
                {
                    new Hospital { HospitalName = "Auckland Hospital", Address = "Auckland"}
                };
                Context.Hospital.AddRange(Hospitals);
                Context.SaveChanges();

                var Diagnosis = new Diagnosis[]
                {
                    new Diagnosis { Diagnosis_Name = "ADHD"}
                };
                Context.Diagnosis.AddRange(Diagnosis);
                Context.SaveChanges();
            }
        }
    }
}