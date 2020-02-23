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

namespace CorviknightCalk.UserInterface.Team
{
    /// <summary>
    /// Interaktionslogik für TeamPage.xaml
    /// </summary>
    public partial class TeamView2 : UserControl
    {
        public TeamView2(ParticularPokemon[] pokemon)
        {
            InitializeComponent();
            StackPanel stackPanel = new StackPanel();
            PokemonUIPanel[] userControls = new PokemonUIPanel[6];
            for (int i = 0; i < 6; i++)
            {
                pokemon[i] = new ParticularPokemon();
                userControls[i] = new PokemonUIPanel(pokemon[i]);

                if (i % 2 == 0) StackPanelLeft.Children.Add(userControls[i]);
                else StackPanelRight.Children.Add(userControls[i]);
            }
        }
    }
}
