using MessagePack;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace WebApplication1.Models
{
    public class Games
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Games")]
        public int GamesID { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public double Amount { get; set; }
        public double Percent_Rent { get; set; }
        public double Reward_Cooler_Coins { get; set; }
        public string Image { get; set; }

    }
}
