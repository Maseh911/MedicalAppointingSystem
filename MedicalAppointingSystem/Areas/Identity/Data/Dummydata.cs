using MedicalAppointingSystem.Models;

namespace MedicalAppointingSystem.Areas.Identity.Data
{
    public class Dummydata
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var Context = serviceScope.ServiceProvider.GetService<MedicalAppointingDbContext>();

                //The if statement ensures that if there is any existing data in any of the models, the method will return to prevent the data being added again//


                if (Context.Patient.Any() || Context.Doctor.Any() || Context.Diagnosis.Any() || Context.Hospital.Any() || Context.AppointmentTime.Any())
                    }
