using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousCache
{
    class AnonymousCache
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var sets = new Dictionary<string, Dictionary<string, long>>();
            var cache = new Dictionary<string, Dictionary<string, long>>();
            while (input != "thetinggoesskrra")
            {
                if (input.Contains("|"))
                {
                    input = input.Replace("|", "");
                    input = input.Replace("->", "");
                    var inputSplited = input.Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries);
                    var dataSet = inputSplited[2];
                    var dataKey = inputSplited[0];
                    var dataSize = long.Parse(inputSplited[1]);

                    if (sets.ContainsKey(dataSet))
                    {
                        sets[dataSet][dataKey] = dataSize;
                    }
                    else
                    {
                        if (cache.ContainsKey(dataSet))
                        {
                            cache[dataSet][dataKey] = dataSize;
                        }
                        else
                        {
                            cache[dataSet] = new Dictionary<string, long>() { { dataKey, dataSize } };
                        }
                    }

                }
                else
                {
                    var dataSet = input;
                    if (cache.ContainsKey(dataSet))
                    {
                        sets[dataSet] = cache[dataSet];
                    }
                    else
                        sets[dataSet] = new Dictionary<string, long>();
                }

                input = Console.ReadLine();
            }
            var sortedSets = sets.OrderByDescending(x => x.Value.Values.Sum());

            foreach (var set in sortedSets)
            {
                Console.WriteLine($"Data Set: {set.Key}, Total Size: {set.Value.Values.Sum()}");
                foreach (var datakey in set.Value)
                {
                    Console.WriteLine($"$.{datakey.Key}");
                }
                break;
            }
        }
    }
}
