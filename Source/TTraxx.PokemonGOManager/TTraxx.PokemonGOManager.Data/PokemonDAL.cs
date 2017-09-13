using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTraxx.PokemonGOManager.Entities;

namespace TTraxx.PokemonGOManager.Data
{
    public class PokemonDAL
    {
        public List<Pokemon> GetAvailablePokemon()
        {
            var json = new JsonSerializer();

            using (var sr = new StreamReader(@"C:\Pokemon\pokedex.json"))
            using (var reader = new JsonTextReader(sr))
            {
                var pokemonList = json.Deserialize<List<Pokemon>>(reader);

                foreach (var pokemon in pokemonList)
                {
                    if (pokemon.PokedexId <= 251) pokemon.IsActive = true;
                    pokemon.Stats = GetPokemonStats(pokemon.PokedexId);
                }

                return pokemonList;
            }                
        }

        public List<PokemonStats> GetPokemonStats(int pokedexId)
        {
            var json = new JsonSerializer();

            using (var sr = new StreamReader(@"C:\Pokemon\pokemonStats.json"))
            using (var reader = new JsonTextReader(sr))
            {
                var pokemonStatsList = json.Deserialize<List<PokemonStats>>(reader).Where(p => p.PokedexId == pokedexId);

                //foreach (var pokemon in pokemonList)
                //{
                //    if (pokemon.PokedexId <= 251) pokemon.IsActive = true;
                //}

                return pokemonStatsList.ToList();
            }
        }
    }
}
