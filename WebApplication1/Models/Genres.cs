using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models

{
    public class Genres
    {
        [Key]    
        public int IdGenre { get; set; }

        [Required]
        [Column("Description")]
        [Display(Name = "Descripción")]
        public string Description { get; set; }

        public ICollection<GamesGenres> GamesGenres { get; set; }
    }
}
