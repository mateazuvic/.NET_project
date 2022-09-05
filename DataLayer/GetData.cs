using DataLayer.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataLayer
{
    public class GetData
    {
        private const char DEL = ',';
        private const char DEL2 = '(';


        private static readonly string dir = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string configFile = Path.Combine(dir, @"..\..\..\Appconfig.txt");
        private static readonly string configPath = Path.GetFullPath(configFile);


        //askinkrono dohvacanje s API-ja
        public static async Task<List<T>> FromUrlAsync<T>(string url)
        {

            try
            {
                var webRequest = WebRequest.Create(url) as HttpWebRequest;
                if (webRequest == null)
                {
                    return default;
                }

                webRequest.ContentType = "application/json";
                webRequest.UserAgent = "Nothing";

                using (var webResponse = await webRequest.GetResponseAsync())
                {
                    using (var sr = new StreamReader(webResponse.GetResponseStream()))
                    {
                       
                        var contributors = ParseFromJson<T>(sr.ReadToEnd());
                        return contributors;
                        
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "GREŠKA1!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return default;

            }

        }


       


        //dohvacanje iz JSON file-a
        public static List<T> ReadFromFile<T>(string path)
        {
            List<T> collection = new List<T>();
            try
            {
                using (StreamReader r = new StreamReader(path))
                {
                    while (!r.EndOfStream)
                    {
                        collection = ParseFromJson<T>(r.ReadLine());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "GREŠKA2!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return collection;

           

        }

        // parsiranje json objekata
        private static List<T> ParseFromJson<T>(string jsonData)
        {
            var data = JsonConvert.DeserializeObject<List<T>>(jsonData);
            return data;
        }


        //zapisi u file 
        public static void WriteInFile<T>(T obj, string path)
        {
            try
            {
                CreateFileIfNotExists(path, dir);

                File.WriteAllText(path, obj.ToString());
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "GREŠKA3!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private static void CreateFileIfNotExists(string path, string dir)
        {
            Directory.CreateDirectory(dir);
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
        }



        //za ucitat jezik i prventsvo
        public static Settings LoadFromFile(string path)
        {
            Settings s = new Settings();

            try
            {
                using (StreamReader r = new StreamReader(path))
                {
                    while (!r.EndOfStream)
                    {
                        s = Parse(r.ReadLine());
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "GREŠKA4!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return s;


        }

        private static Settings Parse(string line)
        {
            string[] details = line.Split(DEL);
            return new Settings
            {
                Championship = (Championship)Enum.Parse(typeof(Championship), details[0]),
                Language = (Language)Enum.Parse(typeof(Language), details[1]),
                Screen = details.Length > 2 && details[2] != " " ? (ScreenResolution)Enum.Parse(typeof(ScreenResolution), details[2]) : ScreenResolution.midi
            };
        }


        //ucitaj iz file-a Fav team
        public static FavouriteTeam LoadFromFileFavTeam(string path)
        {
            FavouriteTeam ft = new FavouriteTeam();

            try
            {
                using (StreamReader r = new StreamReader(path))
                {
                    while (!r.EndOfStream)
                    {
                        ft = Parse2(r.ReadLine());

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "GREŠKA4!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
            }

            return ft;


        }

        private static FavouriteTeam Parse2(string line)
        {
            string[] details = line.Split(DEL2);
            return new FavouriteTeam
            {
                Country = details[0].Remove(details[0].Length - 1, 1),
                Code = details[1].Remove(3, details[1].Length-3),
                SelectedIndex = int.Parse(details[1].Remove(0, 6))
            };
            
        }


        // procitaj Appconfig.txt
        public static string ReadConfig()
        {
            string content = "";

            try
            {
                using (StreamReader r = new StreamReader(configPath))
                {
                    while (!r.EndOfStream)
                    {
                        content = r.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "GREŠKA5!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return content;
           
        }

        //zapisi kolekciju u file
        public static void WriteInFileList<T>(ICollection<T> list, string filePath)
        {
            try
            {
                CreateFileIfNotExists(filePath, dir);

                File.WriteAllLines(filePath, list.Select(o => FormatForFileLine<T>(o)));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "GREŠKA9!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private static string FormatForFileLine<T>(T o)
        {
            return $"{o}";
        }

        //iz datoteke procitaj putanje
        public static List<Image> LoadFromTxtImages(string path)
        {
            List<Image> paths = new List<Image>();

            try
            {
                using (StreamReader r = new StreamReader(path))
                {
                    while (!r.EndOfStream)
                    {
                        paths.Add(ParsePath(r.ReadLine()));

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "GREŠKA10!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return paths;


        }

        private static Image ParsePath(string line)
        {
            string[] details = line.Split(DEL);
            return new Image
            {
                Path = details.Length > 0 ? details[0] : string.Empty,
                ShirtNbr = details.Length > 1 ? int.Parse(details[1]) : int.MinValue
            };
        }

        //ucitaj iz file-a Fav playere
        public static List<StartingEleven> LoadFromFileFavPlayers(string path)
        {
            List<StartingEleven> lse = new List<StartingEleven>();
            StartingEleven fp = new StartingEleven();

            try
            {
                using (StreamReader r = new StreamReader(path))
                {
                    while (!r.EndOfStream)
                    {

                        fp = ParsePlayer(r.ReadLine());
                        lse.Add(fp);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "GREŠKA11!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            return lse;


        }

        private static StartingEleven ParsePlayer(string line)
        {
            string[] details = line.Split(DEL);
            return new StartingEleven
            {
                Name = details[0],
                Captain = bool.Parse(details[1]),
                ShirtNumber = int.Parse(details[2]),
                Position = (Position)Enum.Parse(typeof(Position), details[3])

            };
        }


        public static void SetCulture(string language)
        {
            var currCulture = new CultureInfo(language);

            Thread.CurrentThread.CurrentUICulture = currCulture;
            Thread.CurrentThread.CurrentCulture = currCulture;

        }

        //za load animaciju
        public static int IncreasePercentage(int percentage, int value)
        {
            return percentage += value;
        }
    }

    



}
