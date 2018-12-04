using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Utils
{
    public class AoCUtils
    {
        private string fileName;
        public AoCUtils(string fileName)
        {
            this.fileName = fileName;
        }

        /// <summary>
        /// Reads a file as an array of ints
        /// </summary>
        /// <param name="fileName">name for the file, remember filetype</param>
        /// <returns>an array of ints, one int per line in the input</returns>
        public int[] ReadFileAsIntArray()
        {
            List<int> output = new List<int>();

            using (StreamReader reader = new StreamReader(GetInputPath() + $@"\{fileName}"))
            {
                string line = "";
                while((line = reader.ReadLine()) != null)
                {
                    if (int.TryParse(line, out int res))
                    {
                        output.Add(res);
                    } else
                    {
                        throw new InvalidDataException("Cannot parse string to int");
                    }
                }
            }

            return output.ToArray();
        }

        /// <summary>
        /// Writes an array to a file, useful for debugging
        /// </summary>
        /// <param name="input">array of strings</param>
        /// <param name="fileName">name of the file, remember type</param>
        public void WriteArrayToFile<T>(T[] input, string fileName)
        {
            using(StreamWriter writer = new StreamWriter(GetInputPath() + $@"\{fileName}", true))
            {
                foreach (var item in input)
                {
                    writer.WriteLine(item);
                }
            }
        }

        /// <summary>
        /// Reads an input file as an array of strings, one line per item in the array
        /// </summary>
        /// <param name="fileName">name of the file, remember file type</param>
        /// <returns>an array of strings, one item per line in the file</returns>
        public string[] ReadFileAsStringArray()
        {
            List<string> output = new List<string>();

            using(StreamReader reader = new StreamReader(GetInputPath() + $@"\{fileName}"))
            {
                string line = "";
                while((line = reader.ReadLine()) != null)
                {
                    output.Add(line);
                }
            }

            return output.ToArray();
        }

        /// <summary>
        /// Gets input path for the files in the solution folder
        /// </summary>
        /// <returns>base path for the solutions input folder</returns>
        private string GetInputPath()
        {
            //Source: https://stackoverflow.com/questions/52797/how-do-i-get-the-path-of-the-assembly-the-code-is-in
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);

            string path = Uri.UnescapeDataString(uri.Path);

            string executingPath = Path.GetDirectoryName(path);

            return Path.GetFullPath(Path.Combine(executingPath, @"..\..\..\..\Inputs")); //fix this?
        }
    }
}
