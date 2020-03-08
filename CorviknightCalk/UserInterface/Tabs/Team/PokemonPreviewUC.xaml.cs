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
    public partial class PokemonPreviewUC
    {
        public ParticularE PPokemon { get; set; }

        public PokemonPreviewUC(ParticularE pPokemon)
        {
            this.PPokemon = pPokemon;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow pokemonSettingsWindow = new SettingsWindow(PPokemon);
            pokemonSettingsWindow.Show();
        }
    }
}
