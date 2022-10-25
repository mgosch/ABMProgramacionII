using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.CoolerViewModels
{
    public class GamesIndexData
    {
        public IEnumerable<Games> Games { get; set; }
        public IEnumerable<Genres> Genres { get; set; }
    }
}