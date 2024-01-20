using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Policy;

namespace AnimalsBotApp
{
    /// <summary> AnimalCsv class. </summary>
    internal sealed class AnimalCsv
    {
        /// <summary> The map </summary>
        private readonly Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();

        /// <summary> Gets the URL. </summary>
        /// <param name="tag"> The tag. </param>
        /// <returns> </returns>
        public string[] GetUrl(string tag)
        {
            return !map.ContainsKey(tag) ? Array.Empty<string>() : map[tag].ToArray();
        }

        /// <summary> Loads the specified path. </summary>
        /// <param name="path"> The path. </param>
        public void Load(string path)
        {
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                string[] s = line.Split(',');
                if (s.Length != 2)
                {
                    continue;
                }

                if (!map.ContainsKey(s[0]))
                {
                    map[s[0]] = new List<string>();
                }
                map[s[0]].Add(s[1]);
            }

            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Csv {map.Count} items.");
        }
    }
}
