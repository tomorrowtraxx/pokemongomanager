using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTraxx.PokemonGOManager.Entities;

namespace TTraxx.PokemonGOManager.PokeScraper.Mappers
{
    public sealed class CalcyIV_CSV_ClassMap : CsvClassMap<PokemonStats>
    {
        public CalcyIV_CSV_ClassMap()
        {
            Map(m => m.PokedexId).Name("Nr");
            Map(m => m.Name).Name("Nickname");
            Map(m => m.MinIV).Name("min IV%").TypeConverterOption(CultureInfo.InvariantCulture);
            Map(m => m.MaxIV).Name("max IV%").TypeConverterOption(CultureInfo.InvariantCulture);
            Map(m => m.Gender).Name("Gender");
            Map(m => m.CP).Name("CP");
            Map(m => m.Level).Name("Level").TypeConverterOption(CultureInfo.InvariantCulture); ;
            Map(m => m.FastMove).Name("Fast move");
            Map(m => m.SpecialMove).Name("Special move");
        }
    }
}

