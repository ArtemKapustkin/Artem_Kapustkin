using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicKnowledge
{
    public class Task2
    {
        public static char FirstNonRepeatingLetter(string input)
        {
            if (input == null)
            {
                return '\0';
            }
            Console.WriteLine("Input line: " + input);
            // Convert input to lowercase to ignore case
            string lowercaseInput = input.ToLower();
            Console.WriteLine("Lower case input line: " + lowercaseInput);
            // Use a dictionary to count the occurrences of each letter
            var counts = new Dictionary<char, int>();
            foreach (char c in lowercaseInput)
            {
                if (counts.ContainsKey(c))
                {
                    counts[c]++;
                }
                else
                {
                    counts[c] = 1;
                }
            }

            // Find the first non-repeating letter in the input
            foreach (char c in input)
            {
                int count;
                counts.TryGetValue(char.ToLower(c), out count);
                if (count == 1)
                {
                    Console.WriteLine("Result: "+c);
                    return c;
                }
            }

            // If all letters repeat, return null
            return '\0';
        }

    }
}
