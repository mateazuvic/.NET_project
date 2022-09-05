using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Team
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("goals")]
        public int Goals { get; set; }

        [JsonProperty("penalties")]
        public int Penalties { get; set; }

        public override string ToString() => $"{Country.ToUpper()} ({Code.ToUpper()})";

        public override bool Equals(object obj) => obj is Team other ? Country == other.Country : false;

        public override int GetHashCode() => Country.GetHashCode();

    }
}
