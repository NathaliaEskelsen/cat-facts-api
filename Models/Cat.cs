using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;

namespace CatFacts.Models
{

    public class Cat
    {
        [Key]
        public int Id { get; set; }

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