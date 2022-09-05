using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class OpponentTeam : FavouriteTeam
    {
        public OpponentTeam()
        {
        }

        public OpponentTeam(string country, string code) : base(country, code)
        {
        }

        public OpponentTeam(string country, string code, int goals) : base(country, goals)
        {
            Code = code;
        }

        public override string ToString() => $"{Country} ({Code})";

        public override bool Equals(object obj) => obj is Match other ? Country == other.AwayTeam.Country.ToUpper() : false;

        public override int GetHashCode() => Country.GetHashCode();

    }
}
