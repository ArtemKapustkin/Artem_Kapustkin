using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicKnowledge
{
    public class Task6
    {
        public static int NextBigger(int num)
        {
            // Convert the integer to an array of digits.
            int[] digits = num.ToString().ToCharArray().Select(c => c - '0').ToArray();

            // Starting from the right end, find the first digit that is smaller than the digit to its right.
            int i = digits.Length - 2;
            while (i >= 0 && digits[i] >= digits[i + 1])
                i--;

            if (i < 0)
                return -1; // no smaller digit found, return -1

            // Find the smallest digit to the right of A that is greater than A.
            int j = digits.Length - 1;
            while (j > i && digits[j] <= digits[i])
                j--;

            // Swap digit A and digit B.
            int temp = digits[i];
            digits[i] = digits[j];
            digits[j] = temp;

            // Reverse the digits to the right of A.
            Array.Reverse(digits, i + 1, digits.Length - i - 1);

            // Convert the array of digits back to an integer.
            int result = 0;
            foreach (int digit in digits)
                result = result * 10 + digit;

            return result;
        }
    }
}
