using CsvHelper;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TTraxx.PokemonGOManager.Entities;
using TTraxx.PokemonGOManager.PokeScraper.Mappers;

namespace TTraxx.PokemonGOManager.PokeScraper
{
    public class PokeScraper
    {
        private HtmlDocument _doc;

        public PokeScraper()
        {
            _doc = new HtmlDocument();
        }

        private bool LoadPage(string url)
        {
            try
            {
                var httpsWebClient = new HttpsWebClient();
                httpsWebClient.Encoding = Encoding.UTF8;
                var htmldata = httpsWebClient.DownloadString(url);

                _doc.LoadHtml(htmldata);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(url);
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            return false;
        }

        private List<Pokemon> LoadPokemon()
        {
            var pokemonList = new List<Pokemon>();

            if (LoadPage("https://bulbapedia.bulbagarden.net/wiki/List_of_Pok%C3%A9mon_by_National_Pok%C3%A9dex_number"))
            {
                var tableNodes = _doc.GetElementbyId("mw-content-text").Elements("table");

                foreach (HtmlNode tableNode in tableNodes.Skip(1))
                {
                    foreach (HtmlNode trNode in tableNode.Elements("tr"))
                    {
                        var tdCollection = trNode.Elements("td").ToList();

                        if (tdCollection.Count >= 5)
                        {
                            int pokedexNr;
                            if (!string.IsNullOrEmpty(tdCollection[1].InnerText) && int.TryParse(tdCollection[1].InnerText.Substring(2, 3), out pokedexNr) && !pokemonList.Exists(x => x.PokedexId == pokedexNr))
                            {
                                var pokemon = new Pokemon();

                                pokemon.Id = Guid.NewGuid();
                                pokemon.PokedexId = pokedexNr;
                                pokemon.Name = tdCollection[3].InnerText.Trim();
                                pokemon.PrimaryTypeId = (Pokemon.enuTypes)Enum.Parse(typeof(Pokemon.enuTypes), tdCollection[4].InnerText.Trim());
                                if (tdCollection.Count >= 6)
                                    pokemon.SecundaryTypeId = (Pokemon.enuTypes)Enum.Parse(typeof(Pokemon.enuTypes), tdCollection[5].InnerText.Trim());

                                pokemonList.Add(pokemon);
                            }
                        }
                    }
                }
            }

            return pokemonList;
        }

        private List<PokemonStats> LoadPokemonStats()
        {
            var pokemonStatsList = new List<PokemonStats>();

            var strReader = File.OpenText(@"C:\CalcyIV_Files\history_20170822_003409.csv");
            //var strReader = File.OpenText(@"C:\CalcyIV_Files\history_20170714_004015.csv");

            using (CsvReader csv = new CsvReader(strReader))
            {
                csv.Configuration.RegisterClassMap<CalcyIV_CSV_ClassMap>();

                return csv.GetRecords<PokemonStats>().ToList();
            }
        }

        private bool LoadSpriteFile(string url)
        {
            try
            {
                var httpsWebClient = new HttpsWebClient();
                //httpsWebClient.Encoding = Encoding.UTF8;
                //httpsWebClient.DownloadFile($"https:{url}", $@"C:\PokemonFiles\{Path.GetFileName(url)}");
                Directory.CreateDirectory("pokedex");
                httpsWebClient.DownloadFile($"https:{url}", Path.Combine("pokedex", $"{Path.GetFileNameWithoutExtension(url).Substring(0, 3)}MS{Path.GetExtension(url)}"));
                
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(url);
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            return false;
        }

        public List<string> LoadSprites(List<Pokemon> pokemonList)
        {
            var spriteUrls = new List<string>();

            var replaceMapper = new Dictionary<int, string>();
            replaceMapper.Add(487, "Altered");
            replaceMapper.Add(492, "Land");
            replaceMapper.Add(585, "Spring");
            replaceMapper.Add(586, "Spring");
            replaceMapper.Add(741, "Baile");
            replaceMapper.Add(746, "Solo");

            foreach (var pokemon in pokemonList)
            {
                if (LoadPage($"https://bulbapedia.bulbagarden.net/wiki/File:{pokemon.PokedexId.ToString("000")}{pokemon.Name.Trim('♀', '♂', '.').Replace(" ", "_")}{(replaceMapper.ContainsKey(pokemon.PokedexId) ? $"-{replaceMapper[pokemon.PokedexId]}" : string.Empty)}.png"))
                {
                    var requestedDivNode = _doc.DocumentNode.SelectSingleNode($"//div[@class='fullImageLink']");

                    var url = requestedDivNode.SelectSingleNode($"a").GetAttributeValue("href", "?");

                    spriteUrls.Add(url);
                }
            }

            foreach (var url in spriteUrls)
            {
                LoadSpriteFile(url);
            }

            return spriteUrls;
        }

        public bool ScrapePokedex()
        {
            try
            {
                var pokemonList = LoadPokemon();

                var json = new JsonSerializer();
                json.Formatting = Formatting.Indented;

                Directory.CreateDirectory(@"C:\Pokemon\");

                using (StreamWriter sw = new StreamWriter(@"C:\Pokemon\pokedex.json", false))
                using (JsonWriter writer = new JsonTextWriter(sw)) { json.Serialize(writer, pokemonList); }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ScrapeCurrentPokemon()
        {
            try
            {
                var pokemonStatsList = LoadPokemonStats();

                var json = new JsonSerializer();
                json.Formatting = Formatting.Indented;

                Directory.CreateDirectory(@"C:\Pokemon\");

                using (StreamWriter sw = new StreamWriter(@"C:\Pokemon\pokemonStats.json", false))
                using (JsonWriter writer = new JsonTextWriter(sw)) { json.Serialize(writer, pokemonStatsList); }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
