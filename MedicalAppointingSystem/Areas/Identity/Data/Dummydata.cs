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
                    new Patient { FirstName = "Maseh", LastName = "Essa", Phone = "0240489487", Email = "ac121658@avcol.school.nz", Address = "Avondale College"},
                };
                Context.Patient.AddRange(Patients);
                Context.SaveChanges();


            }
        }
    }
}