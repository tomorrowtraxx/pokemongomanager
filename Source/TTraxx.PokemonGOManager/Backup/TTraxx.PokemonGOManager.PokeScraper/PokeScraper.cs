using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTraxx.PokemonGOManagr.PokeScraper
{
    public class PokeScraper
    {
        private HtmlDocument _doc;

        public PokeScraper()
        {
            _doc = new HtmlDocument();
            LoadPage("https://bulbapedia.bulbagarden.net/wiki/List_of_Pok%C3%A9mon_by_National_Pok%C3%A9dex_number");
        }

        private void LoadPage(string url)
        {
            try
            {
                _doc.LoadHtml(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        public LoadPokemon()
    }
}
