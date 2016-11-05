using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounterAlgo
{
    /// <summary>
    /// Class that encapsulates the Word Counting Logic/Algo.
    /// </summary>
    public class WordCounterLogic : IWordCounter
    {
        /// <summary>
        /// Method to count the unique occurrences of the word.
        /// </summary>
        /// <param name="inputString">Input string which is to be processed.</param>
        /// <returns>Returns the Data representation for the output.</returns>
        public IEnumerable<Word> CountWord(string inputString)
        {
            if (!string.IsNullOrEmpty(inputString))
            {
                string[] array = inputString.Split(null);
                return array.GroupBy(x => x).Select(x => new Word { WordString = x.Key, WordCount = x.Count() });
            }
            else
            {
                return Enumerable.Empty<Word>();
            }
        }
    }
}
