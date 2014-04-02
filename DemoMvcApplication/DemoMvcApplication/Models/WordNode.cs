using System;
using System.Collections.Generic;
using System.Linq;

namespace WordChangeSolverMvc.Models
{
    public class WordNode
    {
        string _word;
        // neighbor words are those that differ by one letter (i.e. ball - call)
        List<WordNode> _neighborWords = new List<WordNode>();

        public WordNode(string word) { _word = word; }
        internal void AddNeighbor(WordNode neighbor) { _neighborWords.Add(neighbor); }
        public IEnumerable<WordNode> NeighborWords
        {
            get
            {
                return _neighborWords.OrderBy<WordNode, string>(p => p.ToString());
            }
        }

        public override string ToString() { return _word; }
    }
}