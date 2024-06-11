using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MedicalAppointingSystem.Areas.Identity.Data;

// Add profile data for application users by adding properties to the MedicalAppointingUser class
public class MedicalAppointingUser : IdentityUser
{
    // FirstName for the custom field //
    public string FirstName { get; set; }
    // LastName for the custom field //
    public string LastName { get; set; }
}

