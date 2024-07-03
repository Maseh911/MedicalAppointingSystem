using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MedicalAppointingSystem.Areas.Identity.Data;
using MedicalAppointingSystem.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MedicalAppointingDbContextConnection") ?? throw new InvalidOperationException("Connection string 'MedicalAppointingDbContextConnection' not found.");

builder.Services.AddDbContext<MedicalAppointingDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<MedicalAppointingUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<MedicalAppointingDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

DatabaseStartup.StartUp(app);

app.Run();


