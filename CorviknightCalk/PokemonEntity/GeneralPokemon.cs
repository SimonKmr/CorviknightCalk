using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CorviknightCalk.PokemonEntity
{
    public class GeneralPokemon : INotifyPropertyChanged
    {
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
                    ImgSource.ImgPkmn = ImgSource.ImagePkmnSource + value + ".png";
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

        public int GenderID { get; set; }

        private double height;
        public double Height
        {
            get { return this.height; }
            set
            {
                this.height = value;
                this.NotifyPropertyChanged("Height");
            }
        }

        private double weight;
        public double Weight
        {
            get { return this.weight; }
            set
            {
                this.weight = value;
                this.NotifyPropertyChanged("Weight");
            }
        }



        private ObservableCollection<int> typeIDs;
        public ObservableCollection<int> TypeIDs
        {
            get { return typeIDs; }
            set
            {
                ImgSource.ImgType.Clear();
                ImgSource.ImgType.Add(ImgSource.ImageTypeSource + value[0] + ".png");
                ImgSource.ImgType.Add(ImgSource.ImageTypeSource + value[1] + ".png");

                this.typeIDs = value;
            }
        }



        public ObservableCollection<int> AbilityIDs { get; set; }
        public ObservableCollection<int> MoveIDs { get; set; }
        public ObservableCollection<GeneralPokemonStats> Stats { get; set; }



        private ImageSources imgSource = new ImageSources();
        public ImageSources ImgSource {
            get { return this.imgSource; }
            set
            {
                this.imgSource = value;
                this.NotifyPropertyChanged("ImgSource");
            }
        }

        // -------------------- Notify Method for the non List or Arrays above --------------------

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }

    public class GeneralPokemonStats : INotifyPropertyChanged
    {
        private int baseValue;
        public int BaseValue { get { return baseValue; }
            set 
            {
                this.baseValue = value;
                this.NotifyPropertyChanged("BaseValue");
            } 
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }

    public class ImageSources : INotifyPropertyChanged
    {
        // -------------------- Contains The Image Path --------------------

        private string imgPkmn;
        public string ImgPkmn { get { return imgPkmn; }
            set 
            {
                this.imgPkmn = value;
                this.NotifyPropertyChanged("ImgPkmn");
            } 
        }

        public ObservableCollection<string> ImgType { get; set; } = new ObservableCollection<string>();

        // -------------------- Vars to direct to the Image file --------------------

        public string ImagePkmnSource { get; set; } 
            = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/";
        public string ImageTypeSource { get; set; } 
            = "https://raw.githubusercontent.com/SimonKmr/CorviknightCalk/master/Icons/IconTypes/";

        // -------------------- Notify Method for the non List or Arrays above --------------------

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
