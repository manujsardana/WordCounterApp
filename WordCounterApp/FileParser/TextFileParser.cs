using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser
{
    /// <summary>
    /// Text Parser implementatio for the IFile Parser interface.
    /// </summary>
    public class TextFileParser : IFileParser
    {
        #region Private Fields

        private readonly IFileSystem _fileSystem;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes an instance of the TextFileParser class.
        /// </summary>
        /// <param name="fileSystem">Input File System. This is useful since we can mock the interface in the unit test cases.</param>
        public TextFileParser(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Method to Parse the Text File.
        /// </summary>
        /// <param name="filePath">Input File Path.</param>
        /// <returns>Returns the parsed string.</returns>
        public string ParseFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException("File Path is null or Empty");
            else if (!filePath.Contains(".txt"))
                throw new FileFormatException("File is not a valid text file");
            else if (!_fileSystem.File.Exists(filePath))
                throw new FileNotFoundException("File does not exists");
            else
            {
                string fileText = _fileSystem.File.ReadAllText(filePath);
                return EnrichText(fileText);               
            }
        }

        #endregion

        #region Private Methods

        private string EnrichText(string fileText)
        {
            if (string.IsNullOrEmpty(fileText))
                throw new ArgumentException("File does not have any text");
            fileText = fileText.Replace(",", "");
            return fileText;
        }

        #endregion
    }
}
