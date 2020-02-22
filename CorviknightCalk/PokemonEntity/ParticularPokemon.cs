using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorviknightCalk.PokemonEntity
{
    public class ParticularPokemon : GeneralPokemon, INotifyPropertyChanged
    {
        public int ItemID { get; set; }
        public new ObservableCollection<int> AbilityIDs { get; set; }
        public new ObservableCollection<ParticularPokemonStats> Stats { get; set; } = new ObservableCollection<ParticularPokemonStats>();
        public ObservableCollection<string> AbilityName { get; set; }
        public string ItemName { get; set; }

        public void General2ParticularPkmn(GeneralPokemon pokemon)
        {
            Name = pokemon.Name;
            ID = pokemon.ID;
            RegionID = pokemon.RegionID;
            TypeIDs = pokemon.TypeIDs;
            Height = pokemon.Height;
            Weight = pokemon.Weight;

            Stats.Clear();
            for(int i = 0; i < pokemon.Stats.Count; i++)
                Stats.Add(new ParticularPokemonStats() {BaseValue = pokemon.Stats[i].BaseValue});
        }
    }

    public class ParticularPokemonStats : INotifyPropertyChanged
    {
        private int baseValue;
        public int BaseValue
        {
            get { return baseValue; }
            set
            {
                this.baseValue = value;
                this.NotifyPropertyChanged("BaseValue");
            }
        }

        public int DeterminantValue { get; set; }
        public int EffortValues { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
