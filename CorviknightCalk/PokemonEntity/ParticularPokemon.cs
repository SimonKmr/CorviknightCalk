using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public new ParticularPokemonStats Stats { get; set; } = new ParticularPokemonStats();

        public void General2ParticularPkmn(GeneralPokemon pokemon)
        {
            Name = pokemon.Name;
            ID = pokemon.ID;
            RegionID = pokemon.RegionID;
            TypeIDs = pokemon.TypeIDs;
            Height = pokemon.Height;
            Weight = pokemon.Weight;
            Stats.BaseValue = pokemon.Stats.BaseValues;
        }
    }

    public class ParticularPokemonStats
    {
        enum Stats { Hp, Atk, Def, SpAtk, SpDef, Speed }
        public ObservableCollection<int> BaseValue { get; set; }
        public ObservableCollection<int> DeterminantValue { get; set; }
        public ObservableCollection<int> EffortValues { get; set; }
    }
}
