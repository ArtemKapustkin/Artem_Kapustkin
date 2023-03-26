using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicKnowledge
{
    public class Task7
    {
        public static string UIntToIPAddress(uint num)
        {
            // Convert the uint to a binary string of 32 bits
            string binary = Convert.ToString(num, 2).PadLeft(32, '0');

            // Split the binary string into 4 octets of 8 bits each
            string[] octets = new string[4];
            for (int i = 0; i < 4; i++)
            {
                octets[i] = binary.Substring(i * 8, 8);
            }

            // Convert each octet from binary to decimal
            int[] decimalOctets = new int[4];
            for (int i = 0; i < 4; i++)
            {
                decimalOctets[i] = Convert.ToInt32(octets[i], 2);
            }

            // Join the decimal octets into a string separated by periods
            return string.Join(".", decimalOctets);
        }
    }
}
