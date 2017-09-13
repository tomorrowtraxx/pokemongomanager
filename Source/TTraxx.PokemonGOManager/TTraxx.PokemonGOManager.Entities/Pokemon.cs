using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TTraxx.PokemonGOManager.Entities
{
    [DataContract]
    public class Pokemon
    {
        public enum enuTypes : byte
        {
            Normal = 0,
            Fire = 1,
            Water = 2,
            Electric = 3,
            Grass = 4,
            Ice = 5,
            Fighting = 6,
            Poison = 7,
            Ground = 8,
            Flying = 9,
            Psychic = 10,
            Bug = 11,
            Rock = 12,
            Ghost = 13,
            Dragon = 14,
            Dark = 15,
            Steel = 16,
            Fairy = 17
        }

        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public int PokedexId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public enuTypes PrimaryTypeId { get; set; }

        [DataMember]
        public enuTypes? SecundaryTypeId { get; set; }

        //Extended
        public string ImageUrl
        {
            get { return $"{PokedexId.ToString("000")}MS.png";  }
        }

        public string PrimaryType
        {
            get { return Enum.GetName(typeof(enuTypes), PrimaryTypeId); }
        }

        public string SecundaryType
        {
            get { return SecundaryTypeId.HasValue ? Enum.GetName(typeof(enuTypes), SecundaryTypeId.Value) : null; }
        }

        private bool _isActive = false;
        public bool IsActive {
            get { return _isActive; }
            set { _isActive = value; }
        }

        public List<PokemonStats> Stats;

        public double? MinIV
        {
            get { return (Stats != null && Stats.Count > 0 ? Stats.OrderByDescending(s => s.MinIV).First().MinIV : (double?)null); }
        }

        public double? MaxIV
        {
            get { return (Stats != null && Stats.Count > 0 ? Stats.OrderByDescending(s => s.MinIV).First().MaxIV : (double?)null); }
        }

        public string IV
        {
            get { return (MinIV.HasValue && MaxIV.HasValue ? (MinIV.Value == MaxIV.Value ? $"{(int)Math.Round(MinIV.Value)}" : $"{(int)Math.Round(MinIV.Value)}-{(int)Math.Round(MaxIV.Value)}"):null); }
        }

        public string CP
        {
            get { return (Stats != null && Stats.Count > 0 ? Stats.OrderByDescending(s => s.MinIV).First().CP.ToString() : null); }
        }

        public char? Gender
        {
            get {
                if (Stats != null && Stats.Count > 0)
                {
                    var gender = Stats.OrderByDescending(s => s.MinIV).First().Gender;
                    return (gender.HasValue && gender.Value == '?' ? null : gender);
                }

                return null;
            }
        }

        public bool HasBeenCaught
        {
            get { return (Stats != null ? Stats.Count > 0 : false); }
        }

    }
}
