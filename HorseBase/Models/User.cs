using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HorseBase.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }

    }
}
