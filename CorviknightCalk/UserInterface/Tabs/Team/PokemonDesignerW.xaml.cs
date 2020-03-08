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
    public partial class SettingsWindow : Window
    {
        public ParticularE particularP { get; set; }
        EntitiesT pokemonTable;

        public SettingsWindow(ParticularE ppokemon)
        {
            pokemonTable = new EntitiesT();
            particularP = ppokemon;

            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            InitializeComponent();
            cbPokemonSelection.ItemsSource = pokemonTable.GetNames();
            if (particularP.ID != 0) cbPokemonSelection.SelectedIndex = particularP.ID-1;

            StackPanel stackPanel = new StackPanel();
            stackPanel.HorizontalAlignment = HorizontalAlignment.Center;
            stackPanel.VerticalAlignment = VerticalAlignment.Center;

            MainGrid.Children.Add(stackPanel);
            cbPokemonSelection.SelectionChanged += new SelectionChangedEventHandler(OnMyComboBoxChanged);
        }

        private void OnMyComboBoxChanged(object sender, SelectionChangedEventArgs e)
        {
            particularP.ImportGeneralE(pokemonTable.GetPokemon((sender as ComboBox).SelectedIndex + 1, 0));
        }
    }
}
