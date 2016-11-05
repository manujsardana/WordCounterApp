using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace WordCounterAlgo
{
    /// <summary>
    /// Interface which provides a method to encapsulate the Counting logic.
    /// </summary>
    public interface IWordCounter
    {
        /// <summary>
        /// Method to count the unique occurrences of the word.
        /// </summary>
        /// <param name="inputString">Input string which is to be processed.</param>
        /// <returns>Returns the Data representation for the output.</returns>
        IEnumerable<Word> CountWord(string inputString);
    }
}
