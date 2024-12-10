using Microsoft.AspNetCore.Mvc.Rendering;

namespace HorseBase.Models
{
    public class HorseBreedViewModel
    {
        public List<Horse> Horses { get; set; }

        public SelectList Breeds { get; set; }

        public int BreedId { get; set; }
    }
}
