using CorviknightCalk.PokemonEntity;
using CorviknightCalk.Tabs.Team;
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
    public partial class PokemonUIPanel
    {
        public ParticularPokemon PPokemon { get; set; }


        public String PkmnTypeIcon1 { get; set; }
        public String PkmnTypeIcon2 { get; set; }

        public PokemonUIPanel(ParticularPokemon pPokemon)
        {
            this.PPokemon = pPokemon;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PokemonSettingsWindow pokemonSettingsWindow = new PokemonSettingsWindow(PPokemon);
            pokemonSettingsWindow.Show();
        }
    }
}
