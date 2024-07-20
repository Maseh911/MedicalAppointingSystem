using MedicalAppointingSystem.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MedicalAppointingSystem.Models;

namespace MedicalAppointingSystem.Areas.Identity.Data;

public class MedicalAppointingDbContext : IdentityDbContext<MedicalAppointingUser>
{
    public MedicalAppointingDbContext(DbContextOptions<MedicalAppointingDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.ApplyConfiguration(new PatientUserEntityConfiguration());
    }

public DbSet<MedicalAppointingSystem.Models.Appointment> AppointmentTime { get; set; } = default!;

public DbSet<MedicalAppointingSystem.Models.Diagnosis> Diagnosis { get; set; } = default!;

public DbSet<MedicalAppointingSystem.Models.Hospital> Hospital { get; set; } = default!;

public DbSet<MedicalAppointingSystem.Models.Doctor> Doctor { get; set; } = default!;

public DbSet<MedicalAppointingSystem.Models.Patient> Patient { get; set; } = default!;
}

public class PatientUserEntityConfiguration : IEntityTypeConfiguration<MedicalAppointingUser>   // This was implimented for my custom field, it creates a new class that impliments the IEntityTypeConfiguration type into the MedicalAppointingUser entity //
{
    public void Configure(EntityTypeBuilder<MedicalAppointingUser> builder)
    {
        builder.Property(u => u.FirstName).HasMaxLength(255);   // This will create a column for FirstName with a max length of 255 characters //
        builder.Property(u => u.LastName).HasMaxLength(255);   // This will create a column for LastName with a max length of 255 characters //
    }
}
