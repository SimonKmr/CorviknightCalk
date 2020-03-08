
using PokeCalk.PokemonTypeTable;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;
using CorviknightCalk.PokemonEntity;
using System.Collections.Generic;

namespace CorviknightCalk
{
    class EntitiesT
    {
        // this class is responsible for calculating damage modifires based on pokemon types
        List<GeneralE> pokemons { get; set; } = new List<GeneralE>();

        public EntitiesT()
        {
            LoadList(new FileInfo(Assembly.GetEntryAssembly().Location).Directory.ToString() + @"\PokemonTables");
        }
        public EntitiesT(string path)
        {
            LoadList(path);
        }
        private void LoadList(string path)
        {
            //loads the typeTable
            string[] files = Directory.GetFiles(path);
            List<string> pokemonListPaths = new List<string>();
            foreach (var file in files)
            {
                if (file.EndsWith(".json"))
                    pokemonListPaths.Add(file);
            }

            foreach (var pokemonListPath in pokemonListPaths)
            {
                List<GeneralE> temp = new List<GeneralE>();
                string json = string.Empty;
                using (StreamReader sr = new StreamReader(pokemonListPath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        json += line;
                    }
                    temp = JsonConvert.DeserializeObject<List<GeneralE>>(json);
                }
                foreach (var pokemon in temp)
                {
                    pokemons.Add(pokemon);
                }
            }
        }
        public void ClearList()
        {
            pokemons.Clear();
        }
        public bool IsEmpty()
        {
            if (pokemons.Count == 0)
                return true;
            else
                return false;
        }

        public List<string> GetNames()
        {
            List<string> result = new List<string>();
            foreach(var pokemon in pokemons)
            {
                result.Add(pokemon.Name);
            }
            return result;
        }

        public GeneralE GetPokemon(int iD, int regionID)
        {
            for (int i = 0; i < pokemons.Count; i++)
                if (pokemons[i].ID == iD && pokemons[i].RegionID == regionID)
                    return pokemons[i];
            return new GeneralE();
        }

        public GeneralE GetPokemon(string Name)
        {
            for (int i = 0; i < pokemons.Count; i++)
                if (pokemons[i].Name == Name)
                    return pokemons[i];
            return new GeneralE();
        }
    }
}
