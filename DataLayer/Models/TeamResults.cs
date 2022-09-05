using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class TeamResults
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("alternate_name")]
        public object AlternateName { get; set; }

        [JsonProperty("fifa_code")]
        public string FifaCode { get; set; }

        [JsonProperty("group_id")]
        public int GroupId { get; set; }

        [JsonProperty("group_letter")]
        public string GroupLetter { get; set; }

        [JsonProperty("wins")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Wins { get; set; }

        [JsonProperty("draws")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Draws { get; set; }

        [JsonProperty("losses")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Losses { get; set; }

        [JsonProperty("games_played")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long GamesPlayed { get; set; }

        [JsonProperty("points")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Points { get; set; }

        [JsonProperty("goals_for")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long GoalsFor { get; set; }

        [JsonProperty("goals_against")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long GoalsAgainst { get; set; }

        [JsonProperty("goal_differential")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long GoalDifferential { get; set; }

        public override string ToString() => $"{Country.ToUpper()} ({FifaCode})";

        public override bool Equals(object obj) => obj is TeamResults other ? Country == other.Country : false;

        public override int GetHashCode() => Country.GetHashCode();
        



    }

}
