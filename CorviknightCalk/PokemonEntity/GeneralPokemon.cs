using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CorviknightCalk.PokemonEntity
{
    public class GeneralPokemon : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public int RegionID { get; set; }
        public int GenderID { get; set; }
        public int[] TypeIDs { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public GeneralPokemonStats Stats { get; set; }



        private string name;
        public string Name
        {
            get { return this.name; }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    this.NotifyPropertyChanged("Name");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }

    public class GeneralPokemonStats
    {
        enum Stats { Hp, Atk, Def, SpAtk, SpDef, Speed}
        public int[] Stat { get; set; }
    }
}
