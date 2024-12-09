using System.ComponentModel.DataAnnotations;

namespace HorseBase.Data
{
    public class User
    {
        public int Id { get; set; }

        [Required, Display(Name = "Название")]
        public string Username { get; set; }

        [Required, Display(Name = "Парола")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, Display(Name = "Собствено име")]
        public string FirstName { get; set; }

        [Required, Display(Name = "Бащино име")]
        public string MiddleName { get; set; }

        [Required, Display(Name = "Фамилно име")]
        public string LastName { get; set; }

        [Required, Display(Name = "Телефонен номер")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required, Display(Name = "Имейл")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public bool IsActive { get; set; }

        public bool IsAdmin { get; set; } = false;
    }
}
