using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WordChangeSolverMvc.Models
{
    public class EnglishDictionary
    {
        Dictionary<string, WordNode> _dictionary = null;

        public EnglishDictionary(string[] words)
        {
            _dictionary = new Dictionary<string, WordNode>(words.Length);

            foreach (string line in words.Select<string, string>(p => p.ToLower()))
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