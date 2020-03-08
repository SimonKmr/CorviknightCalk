using CorviknightCalk.PokemonEntity;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
        private ParticularE[] Pokemon;
        public TeamPage(ParticularE[] pokemon)
        {
            Pokemon = pokemon;
            InitializeComponent();

            StackPanel stackPanel = new StackPanel();
            PokemonPreviewUC[] userControls = new PokemonPreviewUC[6];
            for (int i = 0; i < 6; i++)
            {
                userControls[i] = new PokemonPreviewUC(Pokemon[i]);

                if (i % 2 == 0) StackPanelLeft.Children.Add(userControls[i]);
                else StackPanelRight.Children.Add(userControls[i]);


            }
            this.pokemonTeamGrid.Children.Add(stackPanel);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = " Team files(*.ccTeam) |*.ccTeam| json files(*.json) |*.json| All files(*.*) | *.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.ShowDialog();
            saveFileDialog.Tag = "ccTeam";

            string path = saveFileDialog.FileName;

            //SAVE POKEMON
            SaveE[] saveE = new SaveE[Pokemon.Length];
            for (int i = 0; i < Pokemon.Length; i++) saveE[i] = Pokemon[i].ExportSaveE();

            var json = JsonConvert.SerializeObject(saveE);
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(json);
            }
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = " Team files(*.ccTeam) |*.ccTeam| json files(*.json) |*.json| All files(*.*) |*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.ShowDialog();

            string path = openFileDialog.FileName;
            if (openFileDialog.CheckFileExists && openFileDialog.CheckPathExists && !path.Equals(String.Empty))
            {
                //LOAD POKEMON

                using (StreamReader sr = new StreamReader(path))
                {
                    var content = sr.ReadToEnd();
                    var loadedPkmn = JsonConvert.DeserializeObject<SaveE[]>(content);

                    for (int i = 0; i < loadedPkmn.Length; i++)
                    {
                        // muss umgeschrieben werden (ist nur ein test)
                        EntitiesT pokemonTable = new EntitiesT();
                        var temp = new GeneralE();
                        //Importiert das generelle Pokemon
                        Pokemon[i].ImportSaveE(loadedPkmn[i]);
                    }
                }
            }
        }
    }
}
