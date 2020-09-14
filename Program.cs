using System;
using System.Collections.Generic;
using System.Linq;

namespace digitsum
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong startNum = 5;
            ulong endNum = 50000000;
            ulong maxKey = 0;
            ulong maxValue = 0;
            // ulong result = 0;
            Dictionary<ulong, ulong> tokens = new Dictionary<ulong, ulong>();

            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            for (ulong i = startNum; i < endNum + 1; i++)
            {
                ulong ds = 0;
                ds = DigitSumMath(i);
                if (tokens.ContainsKey(ds))
                {
                    tokens[ds]++;
                }
                else
                {
                    tokens.Add(ds, 1);
                }
            }
            maxKey = tokens.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
            maxValue = tokens.Values.Max();
            watch.Stop();
            Console.WriteLine($"Digitsum {maxKey} has the highest frequency of {maxValue}, taking a total of {watch.ElapsedMilliseconds} ms");
        }
        static ulong DigitSumString(ulong ds)
        {
            string digitsString = ds.ToString();
            // Create an array of individual digits of ds
            ulong[] digitsList = digitsString.Select(q => UInt64.Parse(new string(q, 1))).ToArray();
            ulong sum = 0;

            // Obtain sum of digits
            foreach (var digit in digitsList)
            {
                sum += digit;
            }
            return sum;
        }

        static ulong DigitSumMath(ulong ds)
        {
            ulong sum = 0;
            while (ds != 0)
            {
                sum += ds % 10;
                ds /= 10;
            }
            return sum;
        }
    }
}
