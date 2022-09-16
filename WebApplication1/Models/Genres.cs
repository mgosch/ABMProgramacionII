using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models

{
    public class Genres
{
    [Key]    
    public int Id { get; set; }


    [ForeignKey("Games")]
    public int GamesID { get; set; }

    [Required]

    public string Description { get; set; }
    }
}
