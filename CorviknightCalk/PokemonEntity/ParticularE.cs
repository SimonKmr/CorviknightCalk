using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorviknightCalk.PokemonEntity
{
    public class ParticularE : GeneralE, INotifyPropertyChanged
    {
        public int ItemID { get; set; }
        public new int AbilityIDs { get; set; }
        public new ObservableCollection<int> MoveIDs { get; set; } = new ObservableCollection<int>();
        public new ObservableCollection<ParticularEStats> Stats { get; set; } = new ObservableCollection<ParticularEStats>();

        //Implementing that they get set by their ID counterparts
        public string ItemName { get; set; }
        public string AbilityName { get; set; } = string.Empty;
        public string[] MoveNames { get; set; }

        public void ImportGeneralE(GeneralE pokemon)
        {
            Name = pokemon.Name;
            ID = pokemon.ID;
            RegionID = pokemon.RegionID;
            TypeIDs = pokemon.TypeIDs;
            Height = pokemon.Height;
            Weight = pokemon.Weight;

            Stats.Clear();
            for(int i = 0; i < pokemon.Stats.Count; i++)
                Stats.Add(new ParticularEStats() {BaseValue = pokemon.Stats[i].BaseValue});
        }
        public SaveE ExportSaveE()
        {
            var result = new SaveE()
            {
                ID = this.ID,
                AbilityID = this.AbilityIDs,
                ItemID = this.ItemID,
            };
            Stats.Clear();
            for(int i = 0; i < this.Stats.Count; i++)
            {

                result.Stats[i] = new ESaveStats() { 
                    DeterminantValue = this.Stats[i].DeterminantValue, 
                    EffortValues = this.Stats[i].EffortValues };
            }
            for (int i = 0; i < MoveIDs.Count; i++) MoveIDs = this.MoveIDs;
            return result;
        }
        public void ImportSaveE(SaveE pokemon)
        {
            var result = new ParticularE();

            this.ID = pokemon.ID;
            this.AbilityIDs = pokemon.AbilityID;
            this.ItemID = pokemon.ItemID;

            this.MoveIDs = new ObservableCollection<int>();
            this.Stats = new ObservableCollection<ParticularEStats>();

            pokemon.MoveIDs = new int[this.MoveIDs.Count];
            pokemon.Stats = new ESaveStats[this.Stats.Count];

            for (int i = 0; i < pokemon.MoveIDs.Length; i++) this.MoveIDs[i] = pokemon.MoveIDs[i];
            for (int i = 0; i < pokemon.Stats.Length; i++) 
            { 
                this.Stats[i].DeterminantValue = pokemon.Stats[i].DeterminantValue;
                this.Stats[i].EffortValues = pokemon.Stats[i].EffortValues;
            }

            EntitiesT ptable = new EntitiesT();
            ImportGeneralE(ptable.GetPokemon(pokemon.ID, 0));
        }
        public void ImportSaveE(SaveE pokemon, string tablePath)
        {
            var result = new ParticularE();

            this.ID = pokemon.ID;
            this.AbilityIDs = pokemon.AbilityID;
            this.ItemID = pokemon.ItemID;

            for (int i = 0; i < pokemon.MoveIDs.Length; i++) this.MoveIDs[i] = pokemon.MoveIDs[i];
            for (int i = 0; i < pokemon.Stats.Length; i++)
            {
                this.Stats[i].DeterminantValue = pokemon.Stats[i].DeterminantValue;
                this.Stats[i].EffortValues = pokemon.Stats[i].EffortValues;
            }

            EntitiesT ptable = new EntitiesT(tablePath);
            ImportGeneralE(ptable.GetPokemon(pokemon.ID, 0));
        }
    }

    public class ParticularEStats : INotifyPropertyChanged
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