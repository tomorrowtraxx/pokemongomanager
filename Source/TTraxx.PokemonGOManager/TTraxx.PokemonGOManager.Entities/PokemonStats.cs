using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TTraxx.PokemonGOManager.Entities
{
    [DataContract]
    public class PokemonStats
    {
        //public enum enuTypes : byte
        //{
        //    Normal = 0,
        //    Fire = 1,
        //    Water = 2,
        //    Electric = 3,
        //    Grass = 4,
        //    Ice = 5,
        //    Fighting = 6,
        //    Poison = 7,
        //    Ground = 8,
        //    Flying = 9,
        //    Psychic = 10,
        //    Bug = 11,
        //    Rock = 12,
        //    Ghost = 13,
        //    Dragon = 14,
        //    Dark = 15,
        //    Steel = 16,
        //    Fairy = 17
        //}

        public PokemonStats()
        {
            Id = Guid.NewGuid();
        }

        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public int PokedexId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public char? Gender { get; set; }

        [DataMember]
        public double Level { get; set; }

        [DataMember]
        public int CP { get; set; }

        [DataMember]
        public double MinIV { get; set; }

        [DataMember]
        public double MaxIV { get; set; }

        [DataMember]
        public string FastMove { get; set; }

        [DataMember]
        public string SpecialMove { get; set; }

        //Extended
        public double AvgIV
        {
            get { return (MinIV + MaxIV) / 2; }
        }

    }
}
