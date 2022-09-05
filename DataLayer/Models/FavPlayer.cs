using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class FavPlayer
    {

        public string Name { get; set; }
        public FavPlayer(string name)
        {
            Name = name;
        }

        public override string ToString() => $"{Name}";
        
    }
}
