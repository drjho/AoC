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
            //One();
            Two();
        }

        void One()
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


        void Two()
        {
            var inputs = File.ReadAllLines(path);
            int count = 0;
            var list = new List<int[]>();
            for (int i = 0; i < inputs.Length; i += 3)
            {
                var n1 = new int[3];
                var n2 = new int[3];
                var n3 = new int[3];
                for (int j = 0; j < 3; j++)
                {

                    var nums = Regex.Split(inputs[i + j].Trim(), @"\D+").Select(e => int.Parse(e)).ToArray();
                    n1[j] = nums[0];
                    n2[j] = nums[1];
                    n3[j] = nums[2];

                }
                list.Add(n1);
                list.Add(n2);
                list.Add(n3);
                break;
            }
            foreach (var nums in list)
            {
                Array.Sort(nums);
                //Console.WriteLine(string.Join(",", nums));
                if (nums[0] + nums[1] > nums[2])
                    ++count;
            }
            Console.WriteLine(count);
        }
    }
}
