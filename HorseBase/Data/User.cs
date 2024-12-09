using System.ComponentModel.DataAnnotations;

namespace HorseBase.Data
{
    public class User
    {
        public int Id { get; set; }

        [Required, Display(Name = "Название")]
        public string username { get; set; }

        [Required, Display(Name = "Парола")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required, Display(Name = "Собствено име")]
        public string firstName { get; set; }

        [Required, Display(Name = "Бащино име")]
        public string middleName { get; set; }

        [Required, Display(Name = "Фамилно име")]
        public string lastName { get; set; }

        [Required, Display(Name = "Телефонен номер")]
        [DataType(DataType.PhoneNumber)]
        public string phoneNumber { get; set; }

        [Required, Display(Name = "Имейл")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        public bool isActive { get; set; }

        public bool isAdmin { get; set; } = false;
    }
}
