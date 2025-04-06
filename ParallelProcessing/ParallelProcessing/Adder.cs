using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelProcessing
{
    public class Adder(int startValue, int endValue)
    {
        public long Sum { get; set; }

        public void Run()
        {
            for (int i = startValue; i < endValue; i++)
            {
                Sum += i;
            }
        }
    }
}
