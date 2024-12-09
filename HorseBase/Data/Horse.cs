using System.ComponentModel.DataAnnotations;

namespace HorseBase.Data
{
    public class Horse
    {
        public int Id { get; set; }

        [Required, Display(Name = "Номер")]
        public int number { get; set; }

        [Required, Display(Name = "Порода")]
        public Breed breed { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d M yyyy}")]
        [Required, Display(Name = "Година на раждане")]
        public DateTime birhtYear { get; set; }

        [Required, Display(Name = "Пол")]
        public bool gender { get; set; }

        [Required, Display(Name = "Височина")]
        public int height { get; set; }

        [DataType(DataType.Currency)]
        [Required, Display(Name = "Цена")]
        public double price { get; set; }

        [Display(Name = "Снимки")]
        public string? photoPath { get; set; }
    }
}
