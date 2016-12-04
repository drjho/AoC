using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Puzzles
{
    class D4
    {
        static string path = Path.GetFullPath(@"..\..\Data\D4.txt");

        public D4()
        {
            OneAndTwo();
        }

        void OneAndTwo()
        {
            var inputs = File.ReadAllLines(path);
            int sum = 0;
            foreach (var str in inputs)
            {
                var counts = new int[26];
                var nPos = str.LastIndexOf('-');
                var cPos = str.IndexOf('[');

                var name = str.Substring(0, nPos);
                //Console.WriteLine(name);
                var id = str.Substring(nPos + 1, cPos - nPos - 1);
                //Console.WriteLine(id);
                var checksum = str.Substring(str.Length - 6, 5);
                //Console.WriteLine(checksum);

                foreach (var c in name)
                {
                    if (c != '-')
                        counts[c - 'a']++;
                }

                //foreach (var c in checksum)
                //{
                //    Console.WriteLine(c + ":" + counts[c - 'a']);
                //}

                var res = "";
                int max = counts.Max();
                for (int i = counts.Max(); i > 0 && res.Length < 5; i--)
                {
                    for (int j = 0; j < counts.Length && res.Length < 5; j++)
                    {
                        if (counts[j] == i)
                        {
                            res += (char)('a' + j);
                        }
                    }
                }
                //Console.WriteLine(res.ToString());
                if (res == checksum)
                {
                    var sid = int.Parse(id);
                    sum += sid;
                    var shift = sid % 26;

                    var n = "";
                    foreach (var c in name)
                    {
                        if (c == '-')
                            n += ' ';
                        else
                            n += (char)('a' + (c - 'a' + shift) % 26);
                    }
                    if (n.Contains("north"))
                        Console.WriteLine(n + ": " + id);
                }

                //Console.WriteLine(string.Join(",", counts));

                //break;
            }
            Console.WriteLine(sum);
        }
    }
}
