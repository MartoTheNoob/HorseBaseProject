using System.ComponentModel.DataAnnotations;

namespace HorseBase.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        [Required, Display(Name = "Потребител")]
        public User User { get; set; }

        [Required, Display(Name = "Кон")]
        public Horse Horse { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d/M/yyyy - H:mm}")]
        [Required, Display(Name = "Дата и час на вземане")]
        public DateTime TakeHour { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d/M/yyyy - H:mm}")]
        [Required, Display(Name = "Дата и час на връщане")]
        public DateTime ReturnHour { get; set; }

        [DataType(DataType.Currency)]
        [Required, Display(Name = "Цена")]
        public double Price { get; set; }
    }
}
