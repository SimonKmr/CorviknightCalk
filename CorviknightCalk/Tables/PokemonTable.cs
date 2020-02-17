
using PokeCalk.PokemonTypeTable;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;
using CorviknightCalk.PokemonEntity;
using System.Collections.Generic;

namespace CorviknightCalk
{
    class PokemonTable
    {
        // this class is responsible for calculating damage modifires based on pokemon types
        List<GeneralPokemon> pokemons { get; set; } = new List<GeneralPokemon>();

        public PokemonTable()
        {
            LoadList();
        }
        public void LoadList()
        {
            //loads the typeTable
            string[] files = Directory.GetFiles(new FileInfo(Assembly.GetEntryAssembly().Location).Directory.ToString()+@"\PokemonTables");
            List<string> pokemonListPaths = new List<string>();
            foreach(var file in files)
            {
                if (file.EndsWith(".json"))
                    pokemonListPaths.Add(file);
            }

            foreach(var pokemonListPath in pokemonListPaths)
            {
                List<GeneralPokemon> temp = new List<GeneralPokemon>();
                string json = string.Empty;
                using (StreamReader sr = new StreamReader(pokemonListPath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        json += line;
                    }
                    temp = JsonConvert.DeserializeObject<List<GeneralPokemon>>(json);
                }
                foreach(var pokemon in temp)
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


        public GeneralPokemon GetPokemon(int iD, int regionID)
        {
            for (int i = 0; i < pokemons.Count; i++)
                if (pokemons[i].ID == iD && pokemons[i].RegionID == regionID)
                    return pokemons[i];
            return new GeneralPokemon();
        }

        public GeneralPokemon GetPokemon(string Name)
        {
            for (int i = 0; i < pokemons.Count; i++)
                if (pokemons[i].Name == Name)
                    return pokemons[i];
            return new GeneralPokemon();
        }
    }
}
