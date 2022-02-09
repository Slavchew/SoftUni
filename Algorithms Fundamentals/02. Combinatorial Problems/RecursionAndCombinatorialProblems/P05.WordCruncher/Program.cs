using System;
using System.Collections.Generic;

namespace P05.WordCruncher
{
    internal class Program
    {
        private static string target;
        private static string current;
        private static Dictionary<int, List<string>> wordsByLen;
        private static Dictionary<string, int> occurances;
        private static List<string> selectedWords;
        private static HashSet<string> results;

        static void Main(string[] args)
        {
            var words = Console.ReadLine().Split(", ");
            target = Console.ReadLine();

            wordsByLen = new Dictionary<int, List<string>>();
            occurances = new Dictionary<string, int>();
            selectedWords = new List<string>();
            results = new HashSet<string>();

            foreach (var word in words)
            {
                if (!target.Contains(word))
                {
                    continue;
                }

                var len = word.Length;
                if (!wordsByLen.ContainsKey(len))
                {
                    wordsByLen[len] = new List<string>();
                }

                if (occurances.ContainsKey(word))
                {
                    occurances[word]++;
                }
                else
                {
                    occurances[word] = 1;
                }

                wordsByLen[len].Add(word);
            }

            current = string.Empty;
            GenSolutions(target.Length);

            Console.WriteLine(string.Join(Environment.NewLine, results));
        }

        private static void GenSolutions(int len)
        {
            if (len == 0)
            {
                if (current == target)
                {
                    results.Add(string.Join(" ", selectedWords));
                }
                return;
            }

            foreach (var kvp in wordsByLen)
            {
                if (kvp.Key > len)
                {
                    continue;
                }

                foreach (var word in kvp.Value)
                {
                    if (occurances[word] > 0)
                    {
                        current += word;

                        if (IsMatch(target, current))
                        {
                            occurances[word]--;
                            selectedWords.Add(word);
                            GenSolutions(len - word.Length);
                            selectedWords.RemoveAt(selectedWords.Count - 1);
                            occurances[word]++;

                        }

                        current = current.Remove(current.Length - word.Length, word.Length);
                    }
                }
            }
        }

        private static bool IsMatch(string expected, string actual)
        {

            for (int i = 0; i < actual.Length; i++)
            {
                if (expected[i] != actual[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
