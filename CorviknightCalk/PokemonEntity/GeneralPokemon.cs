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

        public int GenderID { get; set; }
        public double Weight { get; set; }
        public string ImgLink { get; private set; }
        public GeneralPokemonStats Stats { get; set; }



        private string name;
        public string Name
        {
            get { return this.name; }
            set
            {
                if (this.name != value)
                {
                    value = value.First().ToString().ToUpper() + value.Substring(1);
                    this.name = value;
                    this.NotifyPropertyChanged("Name");
                }
            }
        }

        private int id;
        public int ID
        {
            get { return this.id; }
            set
            {
                if (this.id != value)
                {
                    this.id = value;
                    this.NotifyPropertyChanged("Name");
                    ImgLink = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/" + value + ".png";
                    this.NotifyPropertyChanged("ImgLink");
                }
            }

        }

        private int regionID;
        public int RegionID
        {
            get { return this.regionID; }
            set
            {
                if (this.regionID != value)
                {
                    this.regionID = value;
                    this.NotifyPropertyChanged("RegionID");
                }
            }
        }

        private int[] typeIDs;
        public int[] TypeIDs { get { return this.typeIDs; }
            set
            {
                this.typeIDs = value;
                this.NotifyPropertyChanged("TypeIDs");
            } 
        }

        private double height;
        public double Height { get { return this.height; }
            set
            {
                this.height = value;
                this.NotifyPropertyChanged("Height");
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
