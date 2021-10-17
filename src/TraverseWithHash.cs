using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CodingSchool.Tests
{
    public class TraverseWithHash
    {
        [Fact]
        public void Test()
        {
            string[][] paths = {
                new []{"A", "B"},
                new []{"A", "C"},
                new []{"B", "K"},
                new []{"C", "K"},
                new []{"E", "L"},
                new []{"F", "G"},
                new []{"J", "M"},
                new []{"E", "F"},
                new []{"G", "H"},
                new []{"G", "I"},
                new []{"C", "G"}
            };

            var result = FindEndRoutes(paths);

            foreach (var ret in result)
                Console.WriteLine("{0}: {1}", ret[TraverseWithHash.ORIGIN], ret[TraverseWithHash.DEST]);
        }

        public const int ORIGIN = 0;
        public const int DEST = 1;

        public static string[][] FindEndRoutes(string[][] paths)
        {
            var rootRoutes = paths.Where(x => !paths.Select(y => y[TraverseWithHash.DEST]).Contains(x[TraverseWithHash.ORIGIN]))
                .GroupBy(x => x[TraverseWithHash.ORIGIN])
                .ToDictionary(g => g.Key, g => g.Select(kvp => kvp[1]).ToList());

            var hashOfRoutes = paths.GroupBy(x => x[TraverseWithHash.ORIGIN])
                .ToDictionary(g => g.Key, g => g.Select(kvp => kvp[1]).ToList());

            var routes = new List<string[]>();

            foreach (var rootRoute in rootRoutes)
            {
                Console.WriteLine("## {0}: {1}", rootRoute.Key, string.Join(",", rootRoute.Value));
                routes.Add(Traverse(rootRoute.Key, hashOfRoutes));
            }

            return routes.ToArray();
        }

        public static string[] Traverse(string root, Dictionary<string, List<string>> hashOfRoutes)
        {
            var stack = new Stack<string>();
            stack.Push(root);

            List<string> result = new List<string>();

            while (stack.Count > 0)
            {
                var current = stack.Pop();

                hashOfRoutes.TryGetValue(current, out List<string> children);

                if (children is null)
                {
                    result.Add(current);
                }
                else
                {
                    foreach (var child in children)
                    {
                        stack.Push(child);
                    }
                }
            }

            return new string[] { root, string.Join(",", result.Distinct().ToArray()) };
        }
    }
}