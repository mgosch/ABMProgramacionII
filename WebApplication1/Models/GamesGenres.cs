using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class GamesGenres
    {
        [Key]
        public int idGameGenre { get; set; }

        [ForeignKey("Games")]
        public int idGame { get; set; }

        [ForeignKey("Genres")]
        public int idGenre { get; set; }
    }
}
