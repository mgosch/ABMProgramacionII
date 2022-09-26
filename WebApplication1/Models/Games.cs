using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace WebApplication1.Models
{
    public class Games
    {
        [Key]
        public int IdGame { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public double Percent_Rent { get; set; }

        [Required]
        public double Reward_Cooler_Coins { get; set; }

        [Required]
        public string Image { get; set; }

    }
}
