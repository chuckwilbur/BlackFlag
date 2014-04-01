using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WordChangeSolverMvc.Models
{
    public class Puzzle
    {
        EnglishDictionary _dict;
        // Initial array size sets the maximum number
        // of steps that will be tried
        string[] _bestResult;

        public Puzzle(EnglishDictionary dict)
        {
            _dict=dict;
        }

        public string StartWord { get; set; }
        public string EndWord { get; set; }

        public IEnumerable<string> Solve(int depth)
        {
            // array size is depth +1 for the start word
            // +1 to make this one larger than we want
            // the final result to be at most
            _bestResult = new string[depth + 2];

            var result = new Stack<string>();
            if (!string.IsNullOrEmpty(StartWord) &&
                _dict.ContainsKey(StartWord))
            {
                result.Push(StartWord);

                if (!string.IsNullOrEmpty(EndWord) &&
                    _dict.ContainsKey(EndWord))
                {
                    Solve(result);
                }
            }
            return _bestResult[0] == StartWord ? _bestResult : new string[0];
        }

        private void Solve(Stack<string> result)
        {
            if (_bestResult.Length > 0 && result.Count >= _bestResult.Length - 1) return;
            WordNode startWord;
            if (!_dict.TryGetValue(result.Peek(), out startWord)) return;

            foreach (WordNode nextWord in startWord.NeighborWords)
            {
                if (result.Contains(nextWord.ToString())) continue;
                result.Push(nextWord.ToString());

                if (nextWord.ToString() == EndWord)
                {
                    _bestResult = result.Reverse<string>().ToArray();
                }
                else Solve(result);

                result.Pop();
            }
        }
    }
}