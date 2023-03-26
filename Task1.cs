using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicKnowledge
{
    public class Task1
    {
        public static List<int> GetIntegersFromList(List<object> inputList)
        {
            List<int> outputList = new List<int>();
            foreach (object item in inputList)
            {
                if (item is int)
                {
                    outputList.Add((int)item);
                }
            }
            return outputList;
        }
    }
}
