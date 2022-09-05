using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public enum Championship
    {
        Women2019,
        Men2018
    }

    public enum Language
    {
        English,
        Croatian
    }

    public enum ScreenResolution
    {
        full,
        maxi,
        midi,
        mini

    }

    public class Settings
    {
        public Championship Championship { get; set; }

        public Language Language { get; set; }

        public ScreenResolution? Screen { get; set; }

        public override string ToString() => $"{Championship}, {Language}, {Screen}";

        public Settings()
        {

        }

        public Settings(Championship championship, Language language)
        {
            Championship = championship;
            Language = language;
        }

        public Settings(Championship championship, Language language, ScreenResolution screen)
        {
            Championship = championship;
            Language = language;
            Screen = screen;
        }
    }
}
