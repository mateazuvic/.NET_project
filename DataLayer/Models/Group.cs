using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Group
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("letter")]
        public string Letter { get; set; }

        [JsonProperty("ordered_teams")]
        public List<OrderedTeam> OrderedTeams { get; set; }

        public override string ToString() => $" {Id}, Group {Letter}->   {string.Join("\t\t", OrderedTeams)}";
    }
}
