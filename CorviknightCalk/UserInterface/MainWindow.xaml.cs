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
using CorviknightCalk.Tabs.Team;
using CorviknightCalk.UserInterface.Tabs.Team;

namespace CorviknightCalk
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
            ParticularE[] pokemon = new ParticularE[6];
            for (int i = 0; i < pokemon.Length; i++) pokemon[i] = new ParticularE();

            //sollte ich noch umbennen das "btn am anfang könnte verwirren"
            //Sets the button Icons
            Icon_btnExit.Source = new BitmapImage(new Uri("https://raw.githubusercontent.com/SimonKmr/CorviknightCalk/master/Icons/Icon_Exit.png"));
            Icon_btnTeam.Source = new BitmapImage(new Uri("https://raw.githubusercontent.com/SimonKmr/CorviknightCalk/master/Icons/Icon_Team.png"));
            Icon_btnTypes.Source = new BitmapImage(new Uri("https://raw.githubusercontent.com/SimonKmr/CorviknightCalk/master/Icons/Icon_Types.png"));
            Icon_btnMatchups.Source = new BitmapImage(new Uri("https://raw.githubusercontent.com/SimonKmr/CorviknightCalk/master/Icons/Icon_Matchups.png"));
            TeamDP.Children.Add(new TeamPage(pokemon));
        }

        //Exit Button
        private void btnExit_Click(object sender, RoutedEventArgs e)
            =>Close();

        //Sidebar menu control 
        private void btnTeam_Click(object sender, RoutedEventArgs e)
            => tcMainPage.SelectedIndex = 0;
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
