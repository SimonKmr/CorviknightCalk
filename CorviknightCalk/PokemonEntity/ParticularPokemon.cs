using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorviknightCalk.PokemonEntity
{
    public class ParticularPokemon : GeneralPokemon
    {
        public int ItemID { get; set; }
        public int AbilityID { get; set; }
        public new ParticularPokemonStats Stats { get; set; }

        public GeneralPokemon General2ParticularPkmn(ParticularPokemon pokemon)
        {
            GeneralPokemon generalPokemon = new GeneralPokemon();



            return generalPokemon;
        }
    }

    public class ParticularPokemonStats
    {
        enum Stats { Hp, Atk, Def, SpAtk, SpDef, Speed }
        public Stat[] Stat { get; set; }
    }

    public class Stat
    {
        public int BaseValue { get; set; }
        public int DeterminantValue { get; set; }
        public int EffortValues { get; set; }
    }
}
