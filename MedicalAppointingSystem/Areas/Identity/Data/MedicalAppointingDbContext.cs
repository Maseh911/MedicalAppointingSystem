using MedicalAppointingSystem.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
}

public class PatientUserEntityConfiguration : IEntityTypeConfiguration<MedicalAppointingUser>
{
    public void Configure(EntityTypeBuilder<MedicalAppointingUser> builder)
    {
        builder.Property(u => u.FirstName).HasMaxLength(255);
        builder.Property(u => u.LastName).HasMaxLength(255);
    }
}
