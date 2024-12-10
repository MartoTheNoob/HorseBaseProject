using System.ComponentModel.DataAnnotations;

namespace HorseBase.Models
{
    public class Breed
    {
        public int Id { get; set; }

        [Required, Display(Name = "Название")]
        public string Name { get; set; }

        [DataType(DataType.ImageUrl)]
        [Required, Display(Name = "Връзка")]
        public string Url { get; set; }

        ICollection<Horse> Horses { get; set; }
    }
}
