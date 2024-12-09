using System.ComponentModel.DataAnnotations;

namespace HorseBase.Data
{
    public class Reservation
    {
        public int Id { get; set; }

        [Required, Display(Name = "Потребител")]
        public User user { get; set; }

        [Required, Display(Name = "Кон")]
        public Horse horse {  get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d/M/yyyy - H:mm}")]
        [Required, Display(Name = "Дата и час на вземане")]
        public DateTime takeHour { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d/M/yyyy - H:mm}")]
        [Required, Display(Name = "Дата и час на връщане")]
        public DateTime returnHour { get; set; }

        [DataType(DataType.Currency)]
        [Required, Display(Name = "Цена")]
        public double price { get; set; }
    }
}
