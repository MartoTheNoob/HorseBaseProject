using System.ComponentModel.DataAnnotations;

namespace HorseBase.Data
{
    public class Breed
    {
        public int Id { get; set; }

        [Required, Display(Name = "Название")]
        public string name { get; set; }

        [DataType(DataType.ImageUrl)]
        [Required, Display(Name = "Връзка")]
        public string url { get; set; }

        ICollection<Horse> horses { get; set; }
    }
}
