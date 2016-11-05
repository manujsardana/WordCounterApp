using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace TextFormatter
{
    /// <summary>
    /// Interface for formatting the unique words and their count to desired format to display.
    /// </summary>
    public interface ITextFormatter
    {
        /// <summary>
        /// Method to Format the text.
        /// </summary>
        /// <param name="inputData">Input data to format.</param>
        /// <returns>Out string in the desired format.</returns>
        string FormatText(IEnumerable<Word> inputData);
    }
}
