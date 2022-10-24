using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace WebApplication1.Models
{
    public class Games
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdGame { get; set; }

        [Required]
        [Column("Name")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [Column("Description")]
        [Display(Name = "Descripcion")]
        public string Description { get; set; }

        [Column("State")]
        [Display(Name = "Estado")]
        public string State { get; set; }

        [Required]
        [Column("Amount")]
        [Display(Name = "Importe")]
        public decimal Amount { get; set; }

        [Required]
        [Column("Percent_Rent")]
        [Display(Name = "Porcentaje Alquiler")]
        public decimal Percent_Rent { get; set; }

        [Required]
        [Column("Reward_Cooler_Coins")]
        [Display(Name = "Cooler Coins")]
        public decimal Reward_Cooler_Coins { get; set; }

        [Required]
        [Column("Image")]
        [Display(Name = "Imagen")]
        public string Image { get; set; }

        public ICollection<GamesGenres> GamesGenres { get; set; }

        public ICollection<Comments> Comments { get; set; }

    }
}
