using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SAV.Models.Auth
{
    public class ApplicationUser : IdentityUser
    {
        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }
    }
}
