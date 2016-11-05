using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    /// <summary>
    /// Class which represents the Model for the Word.
    /// </summary>
    public class Word
    {
        /// <summary>
        /// The Word string which represents all the unique words read from the input.
        /// </summary>
        public string WordString
        {
            get;
            set;
        }

        /// <summary>
        /// The Count of the unique words.
        /// </summary>
        public int WordCount
        {
            get;
            set;
        }
    }
}
