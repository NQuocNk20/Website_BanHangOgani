using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BanHangOgani.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    [PersonalData]
    [Column(TypeName = "varchar(50)")]
    public string? FirstName { get; set; }
    [PersonalData]
    [Column(TypeName = "varchar(50)")]
    public string? LastName { get; set; }
    [PersonalData]
    [Column(TypeName = "varchar(50)")]
    public string? Address { get; set; }

}

