﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace Solutions
{
    public class Day5 : BaseSolution
    {
        string input;
        public Day5(string fileName, string name) : base(fileName, name)
        {
            input = utils.ReadFileAsStringArray()[0];
        }

        public override string PartOne()
        {
            string input = this.input;
            return RemovePairs(input).Length.ToString();
        }

        //this needs to be refactored
        private string RemovePairs(string input){

            Stack<char> unparsed = new Stack<char>(input.ToCharArray());
            Stack<char> parsed = new Stack<char>();

            parsed.Push(unparsed.Pop());

            while (unparsed.Count > 0)
            {
                char unparsedChar = unparsed.Pop();

                char parsedChar = '0';
                if (parsed.Count == 0 && unparsed.Count > 0)
                {
                    parsedChar = unparsed.Pop();
                }
                else if (parsed.Count > 0)
                {
                    parsedChar = parsed.Pop();
                }
                if (parsedChar != '0')
                {
                    if (char.IsUpper(unparsedChar) && char.IsLower(parsedChar) && char.ToLower(unparsedChar) == parsedChar)
                    {

                    }
                    else if (char.IsLower(unparsedChar) && char.IsUpper(parsedChar) && char.ToUpper(unparsedChar) == parsedChar)
                    {

                    }
                    else
                    {
                        parsed.Push(parsedChar);
                        parsed.Push(unparsedChar);
                    }
                }
            }
            return string.Join("", parsed);

            //OLD SOLUTION, IS CRAP

            //bool noMatches = true;
            //while (noMatches)
            //{
            //    int index = 0;
            //    while (index + 1 < input.Length)
            //    {
            //        char thisChar = input[index];
            //        char nextChar = input[index + 1];

            //        if (char.IsLower(thisChar) && char.IsUpper(nextChar) && char.ToLower(nextChar) == thisChar)
            //        {
            //            input = input.Remove(index, 2);
            //            break;
            //        }
            //        else if (char.IsLower(nextChar) && char.IsUpper(thisChar) && char.ToLower(thisChar) == nextChar)
            //        {
            //            input = input.Remove(index, 2);
            //            break;
            //        }

            //        index++;
            //    }
            //    if (index + 1 == input.Length) noMatches = false;
            //}

            //return input;
        }

        public override string PartTwo()
        {

            string input = this.input;

            char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            Dictionary<char, int> withExceptCharC = new Dictionary<char, int>();

            foreach (char c in alphabet)
            {
                var tempInput = input.Replace(c.ToString(), string.Empty);
                tempInput = tempInput.Replace(char.ToLower(c).ToString(), string.Empty);
                withExceptCharC.Add(c, RemovePairs(tempInput).Count());
            }

            KeyValuePair<char, int> lowestPair = withExceptCharC.First();

            foreach (var item in withExceptCharC)
            {
                if (item.Value < lowestPair.Value)
                {
                    lowestPair = item;
                }
            }

            return lowestPair.Value.ToString();
        }
    }
}
