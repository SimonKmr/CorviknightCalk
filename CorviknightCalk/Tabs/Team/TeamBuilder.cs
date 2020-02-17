using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorviknightCalk.PokemonEntity;

namespace CorviknightCalk.Tabs
{
    public class TeamBuilder : TabLayout
    {
        public PokemonUI[] Pokemon { get; set; } = new PokemonUI[6];
        public TeamBuilder()
        {
            PageName = "Team";
        }
        
    }
}
