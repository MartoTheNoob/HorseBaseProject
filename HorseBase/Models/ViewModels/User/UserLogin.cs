using System.ComponentModel.DataAnnotations;

namespace HorseBase.Models.ViewModels.User
{
    public class UserLogin
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
