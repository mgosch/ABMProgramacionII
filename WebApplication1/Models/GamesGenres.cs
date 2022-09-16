﻿using MessagePack;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class GamesGenres
    {

        [Key]
        public int Id { get; set; }

        [ForeignKey("Games")]
        public int GamesID { get; set; }

        [Required]

       public int GenresId { get; set; }
    }
}
