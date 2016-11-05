using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace TextFormatter
{
    /// <summary>
    /// Class implementation for ITextFormatter interface.
    /// </summary>
    public class TextFormatter : ITextFormatter
    {
        /// <summary>
        /// Method to Format the text.
        /// </summary>
        /// <param name="inputData">Input data to format.</param>
        /// <returns>Out string in the desired format.</returns>
        public string FormatText(IEnumerable<Word> inputData)
        {
            StringBuilder outputText = new StringBuilder();
            if (inputData != null && inputData.Count() > 0)
            {
                foreach(var word in inputData)
                {
                    outputText.Append(word.WordCount + ":" + word.WordString);
                    outputText.Append(Environment.NewLine);
                }
                return outputText.ToString();
            }
            else
                return "File does not have any text";
        }
    }
}
