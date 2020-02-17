using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CorviknightCalk.PokemonEntity;
using CorviknightCalk.Tabs;

namespace CorviknightCalk
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TeamBuilder Team = new TeamBuilder();
        public MainWindow()
        {
            
            InitializeComponent();
            ParticularPokemon[] pokemon = new ParticularPokemon[6];
            PokemonUI[] userControls = new PokemonUI[6];
            StackPanel stackPanel = new StackPanel();

            for (int i = 0; i < 6; i++)
            {
                userControls[i] = new PokemonUI(new ParticularPokemon() { Name = "Simon" });

                if (i % 2 == 0) StackPanelLeft.Children.Add(userControls[i]);
                else StackPanelRight.Children.Add(userControls[i]);
            }
            Team.Pokemon = userControls;
            this.pokemonTeamGrid.Children.Add(stackPanel);
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
            =>Close();

        private void btnTeam_Click(object sender, RoutedEventArgs e)
        {
            tcMainPage.SelectedIndex = 0;
            Team.Pokemon[0].PPokemon.Name = "Monty";
        }
        private void btnTypes_Click(object sender, RoutedEventArgs e)
            => tcMainPage.SelectedIndex = 1;
        private void btnMatchups_Click(object sender, RoutedEventArgs e)
            => tcMainPage.SelectedIndex = 2;

        private void headerThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Left = Left + e.HorizontalChange;
            Top = Top + e.VerticalChange;
        }
    }
}
