using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTraxx.PokemonGOManager.Data;
using TTraxx.PokemonGOManager.Entities;

namespace TTraxx.PokemonGOManager.Business
{
    public class PokemonBL
    {
        private PokemonDAL _pokemonDAL;

        public PokemonBL()
        {
            _pokemonDAL = new PokemonDAL();
        }

        public List<Pokemon> GetAvailablePokemon()
        {
            return _pokemonDAL.GetAvailablePokemon();
        }
    }
}
