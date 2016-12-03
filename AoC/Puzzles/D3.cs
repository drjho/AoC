using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC.Puzzles
{
    class D3
    {
        static string path = Path.GetFullPath(@"..\..\Data\D3.txt");

        public D3()
        {
            var inputs = File.ReadAllLines(path);
            //Console.WriteLine(inputs.Length);
            int count = 0;
            foreach (var i in inputs)
            {
                var nums = Regex.Split(i.Trim(), @"\D+").Select(e => int.Parse(e)).OrderBy(e => e).ToArray();
                if (nums[0] + nums[1] > nums[2])
                    ++count;
            }
            Console.WriteLine(count);
        }
    }
}
