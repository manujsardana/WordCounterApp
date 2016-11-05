using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser
{
    /// <summary>
    /// Interface for File Parser.
    /// </summary>
    public interface IFileParser
    {
        /// <summary>
        /// Method to Parse the File.
        /// </summary>
        /// <param name="filePath">Input file path.</param>
        /// <returns>Returns the Parsed text.</returns>
        string ParseFile(string filePath);
    }
}
