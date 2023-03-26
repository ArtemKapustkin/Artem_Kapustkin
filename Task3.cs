using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicKnowledge
{
    public class Task3
    {
        public static int DigitalRoot(int n)
        {
            // Calculate the sum of the digits of n
            int sum = 0;
            while (n > 0)
            {
                sum += n % 10;
                n /= 10;
            }

            // If the sum has more than one digit, call digital_root recursively
            if (sum >= 10)
            {
                return DigitalRoot(sum);
            }
            else
            {
                return sum;
            }
        }
    }
}
