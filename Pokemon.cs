using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonConsole
{
    internal class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Height { get; set;  }
        public int Weight { get; set; }
        public IList<PokemonType> Types { get; set; }
    }
}
