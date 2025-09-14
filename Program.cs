using System;
using System.Collections.Generic;
using System.Text;

namespace T4L_Assesment
{
    /* In the programming language of your choice, write a program that parses a sentence and replaces each word with the following: 
    * first letter, number of distinct characters between first and last character, and last letter. For example, Smooth would become S3h. 
    * Words are separated by spaces or non-alphabetic characters and these separators should be maintained in their original form and location in the answer. */
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter a sentence!");
            string sentence = Console.ReadLine();

            string result = ProcessSentence(sentence);
            Console.WriteLine("\nHere's your processed sentence! :D");
            Console.WriteLine(result);
        }

        static string ProcessSentence(string sentence)
        {
            StringBuilder result = new StringBuilder();
            StringBuilder currentWord = new StringBuilder();

            foreach (char c in sentence)
            {
                if (char.IsLetter(c))
                {
                    currentWord.Append(c);
                }
                else
                {
                    if (currentWord.Length > 0)
                    {
                        result.Append(CompressWord(currentWord.ToString()));
                        currentWord.Clear();
                    }
                    result.Append(c);
                }
            }

            if (currentWord.Length > 0)
            {
                result.Append(CompressWord(currentWord.ToString()));
            }

            return result.ToString();
        }

        static string CompressWord(string word)
        {
            if (word.Length <= 2)
            {
                return word;
            }

            char first = word[0];
            char last = word[word.Length - 1];

            HashSet<char> middleChars = new HashSet<char>();
            for (int i = 1; i < word.Length - 1; i++)
            {
                middleChars.Add(word[i]);
            }

            int count = middleChars.Count;
            return first + count.ToString() + last;
        }
    }
}
