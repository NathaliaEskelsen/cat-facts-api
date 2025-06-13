using System.ComponentModel.DataAnnotations;

namespace CatFacts.Dtos
{

    public class CatUpdateDto
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Breed { get; set; } 

        public string Color { get; set; }
      
    }
}