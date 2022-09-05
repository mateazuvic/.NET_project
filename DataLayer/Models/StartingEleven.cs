using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class StartingEleven
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("captain")]
        public bool Captain { get; set; }

        [JsonProperty("shirt_number")]
        public int ShirtNumber { get; set; }

        [JsonProperty("position")]
        public Position Position { get; set; }

        public string Picture { get; set; }

        public int NbrOfGoals { get; set; }

        public int NbrOfYellowCards { get; set; }

        public StartingEleven()
        {
        }


        public StartingEleven(string name, int nbrOfGoals, int nbrOfYellowCards)
        {
            Name = name;
            NbrOfGoals = nbrOfGoals;
            NbrOfYellowCards = nbrOfYellowCards;
        }

        public StartingEleven(string name, bool captain, int shirtNumber, Position position)
        {
            Name = name;
            Captain = captain;
            ShirtNumber = shirtNumber;
            Position = position;
        }

       

        public override string ToString() => $"{Name}, {Captain}, {ShirtNumber}, {Position}";
        
    }
}
