using CorviknightCalk.PokemonEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CorviknightCalk
{
    /// <summary>
    /// Interaktionslogik für PokemonTeamUI.xaml
    /// </summary>
    public partial class PokemonUI
    {
        public ParticularPokemon PPokemon { get; set; }
        public String PkmnTypeIcon1 { get; set; }
        public String PkmnTypeIcon2 { get; set; }
        public String PkmnImage { get; set; }

        public PokemonUI(ParticularPokemon pPokemon)
        {
            this.PPokemon = pPokemon;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
         => MessageBox.Show("Yeah! This is still Work in Progress");//Create a Editor window and link it to here
        //Ich sollte dem neuen fenster mit this dieses Hier übergeben, sodass ich von dort so die sachen verändern kann.

    }

    public class PokemonDesigner
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
