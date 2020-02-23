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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CorviknightCalk.UserInterface.Tabs.Team
{
    /// <summary>
    /// Interaktionslogik für TeamPage.xaml
    /// </summary>
    public partial class TeamPage : UserControl
    {
        public TeamPage(ParticularPokemon[] pokemon)
        {
            InitializeComponent();

            StackPanel stackPanel = new StackPanel();
            PokemonPreviewUC[] userControls = new PokemonPreviewUC[6];
            for (int i = 0; i < 6; i++)
            {
                userControls[i] = new PokemonPreviewUC(new ParticularPokemon());

                if (i % 2 == 0) StackPanelLeft.Children.Add(userControls[i]);
                else StackPanelRight.Children.Add(userControls[i]);
            }
            this.pokemonTeamGrid.Children.Add(stackPanel);
        }
    }
}
