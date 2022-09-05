using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class FavouriteTeam
    {
        public string Country { get; set; }
        public string Code { get; set; }

        public int SelectedIndex { get; set; }

        public int Goals { get; set; }

        public List<OpponentTeam> Opponents { get; set; }

        public FavouriteTeam()
        {
        }

        public FavouriteTeam(string country)
        {
            Country = country;
        }

        public FavouriteTeam(string country, string code)
        {
            Country = country;
            Code = code;
        }

        public FavouriteTeam(string country, int selectedIndex)
        {
            Country = country;
            SelectedIndex = selectedIndex;
        }

        public FavouriteTeam(string country, int selectedIndex, int goals) : this(country, selectedIndex)
        {
            Goals = goals;
        }

        public override string ToString() => $"{Country}, {SelectedIndex}";
        


    }
}
