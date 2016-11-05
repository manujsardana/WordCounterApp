using FileParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using WordCounterAlgo;
using TextFormatter;
using System.IO.Abstractions;

namespace WordCounterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string fileText = string.Empty;
                Console.WriteLine("Please enter the file to parse with the complete path");
                string filePath = Console.ReadLine();
                Console.WriteLine("Parsing File");
                IFileParser fileParser = new TextFileParser(new FileSystem());
                fileText = fileParser.ParseFile(filePath);
                Console.WriteLine("File parsed. Counting the number of words");
                IWordCounter wordCounter = new WordCounterLogic();
                var wordCounterOutput = wordCounter.CountWord(fileText);
                ITextFormatter textFormatter = new TextFormatter.TextFormatter();
                Console.WriteLine("Here is the output");
                Console.WriteLine(textFormatter.FormatText(wordCounterOutput));
                Console.Read();
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FileFormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                //Ideally we should not catch the Base exception class and should not allow the application to run
                //since in case of OutOfMemory or StackOverFlowexception the application/system might not be in a position to run/
                //The Application might be in a corrupted state and should not be allowed to run.
                Console.WriteLine(ex.Message);
            }
        }

    }
}
