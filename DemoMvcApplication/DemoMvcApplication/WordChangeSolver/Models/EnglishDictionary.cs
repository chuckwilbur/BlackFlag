using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoMvcApplication.WordChangeSolver.Models
{
    public class EnglishDictionary
    {
        Dictionary<string, WordNode> _dictionary;

        public EnglishDictionary(string wordFile)
        {
            string[] lines = System.IO.File.ReadAllLines(wordFile);
            _dictionary = new Dictionary<string, WordNode>(lines.Length);

            foreach (string line in lines.Select<string, string>(p => p.ToLower()))
            {
                if (line.Contains('\'')) continue;
                if (_dictionary.ContainsKey(line)) continue;

                WordNode lineNode = new WordNode(line);

                for (int iChar = 0; iChar < line.Length; ++iChar)
                {
                    for (char a = 'a'; a <= 'z'; ++a)
                    {
                        string test = string.Format("{0}{1}{2}",
                            line.Substring(0, iChar), a,
                            line.Substring(iChar + 1, line.Length - iChar - 1));

                        WordNode neighborNode;
                        if (_dictionary.TryGetValue(test, out neighborNode))
                        {
                            neighborNode.AddNeighbor(lineNode);
                            lineNode.AddNeighbor(neighborNode);
                        }
                    }
                }

                _dictionary.Add(line, lineNode);
            }
        }

        public bool ContainsKey(string key) { return _dictionary.ContainsKey(key); }

        public bool TryGetValue(string key, out WordNode value)
        {
            return _dictionary.TryGetValue(key, out value);
        }
    }
}