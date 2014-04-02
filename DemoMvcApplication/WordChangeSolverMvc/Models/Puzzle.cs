using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WordChangeSolverMvc.Models
{
    public class Puzzle
    {
        EnglishDictionary _dict;

        public Puzzle(EnglishDictionary dict)
        {
            _dict=dict;
        }

        public string StartWord { get; set; }
        public string EndWord { get; set; }

        public IEnumerable<string> Solve()
        {
            var foundWordToPredecessor = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(StartWord) &&
                _dict.ContainsKey(StartWord) &&
                !string.IsNullOrEmpty(EndWord) &&
                _dict.ContainsKey(EndWord))
            {
                foundWordToPredecessor.Add(StartWord, null);
                var nodesToTest = new Queue<WordNode>();
                nodesToTest.Enqueue(_dict[StartWord]);

                while (nodesToTest.Count > 0)
                {
                    WordNode nextWord = nodesToTest.Dequeue();
                    if (nextWord.ToString() == EndWord) break;

                    foreach (WordNode neighborWord in nextWord.NeighborWords)
                    {
                        if (foundWordToPredecessor.ContainsKey(neighborWord.ToString())) continue;
                        foundWordToPredecessor.Add(neighborWord.ToString(), nextWord.ToString());
                        nodesToTest.Enqueue(neighborWord);
                    }
                }
            }
            var result = new Stack<string>(foundWordToPredecessor.Count);
            if (foundWordToPredecessor.ContainsKey(EndWord))
            {
                string predecessorWord = EndWord;
                while (predecessorWord != null)
                {
                    result.Push(predecessorWord);
                    predecessorWord = foundWordToPredecessor[predecessorWord];
                } 
            }
            return result;
        }
    }
}