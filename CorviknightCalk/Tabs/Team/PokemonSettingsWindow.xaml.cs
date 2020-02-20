using CorviknightCalk.PokemonEntity;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace CorviknightCalk.Tabs.Team
{
    /// <summary>
    /// Interaktionslogik für PokemonSettingsWindow.xaml
    /// </summary>
    public partial class PokemonSettingsWindow : Window
    {
        public ParticularPokemon PPokemon { get; set; }
        public ImageSources PPokemonSources { get; set; }
        PokemonTable pokemonTable;

        ComboBox cbPokemonSelection = new ComboBox();
        public PokemonSettingsWindow(ParticularPokemon ppokemon)
        {
            pokemonTable = new PokemonTable();
            PPokemon = ppokemon;
            PPokemonSources = ppokemon.ImgSource;

            InitializeComponent();
            cbPokemonSelection.ItemsSource = pokemonTable.GetNames();
            cbPokemonSelection.Height = 20;
            cbPokemonSelection.Width = 100;
            if (PPokemon.ID != 0) cbPokemonSelection.SelectedIndex = PPokemon.ID-1;

            StackPanel stackPanel = new StackPanel();
            stackPanel.HorizontalAlignment = HorizontalAlignment.Center;
            stackPanel.VerticalAlignment = VerticalAlignment.Center;
            stackPanel.Children.Add(cbPokemonSelection);

            MainGrid.Children.Add(stackPanel);
            cbPokemonSelection.SelectionChanged += new SelectionChangedEventHandler(OnMyComboBoxChanged);
        }

        private void OnMyComboBoxChanged(object sender, SelectionChangedEventArgs e)
        {
            PPokemon.General2ParticularPkmn(pokemonTable.GetPokemon((sender as ComboBox).SelectedIndex + 1, 0));
        }
    }
}
