using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Comments
    {
        [Key]
        public int IdComment { get; set; }

        [ForeignKey("Games")]
        public int IdGame { get; set; }

        [Required]
        public string Comment { get; set; }

    }
}
