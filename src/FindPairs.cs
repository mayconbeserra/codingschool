using Xunit;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System;

namespace CodingSchool.Tests
{
    public class FindPairsTests
    {
        [Fact]
        public void FindIt()
        {
            string[][] studentCoursePairs1 = {
                new string[] {"58", "Linear Algebra"},
                new string[] {"94", "Art History"},
                new string[] {"17", "Software Design"},
                new string[] {"58", "Mechanics"},
                new string[] {"58", "Economics"},
                new string[] {"17", "Linear Algebra"},
                new string[] {"17", "Political Science"},
                new string[] {"94", "Economics"},
                new string[] {"25", "Economics"},
                new string[] {"58", "Software Design"},
            };

            string[][] studentCoursePairs2 = {
                new string[] {"42", "Software Design"},
                new string[] {"0", "Advanced Mechanics"},
                new string[] {"9", "Art History"},
            };

            var result = FindPairs(studentCoursePairs1);

            foreach(var entry in result)
            {
                Console.WriteLine("Pair Students: {0} - Shared Courses: {1}", string.Join(",", entry.Key), string.Join(",", entry.Value));
            }
        }

        public List<KeyValuePair<int[], string[]>> FindPairs(string [][] studentCoursePairs)
        {
            // var studentMap = studentCoursePairs
            //     .Select(course => new KeyValuePair<string, string>(course[0], course[1]))
            //     .GroupBy(selector => selector.Key)
            //     .ToDictionary(group => group.Key, group => group.Select(kvp => kvp.Value).ToList());
            var studentMap = studentCoursePairs
                .Select(course => new KeyValuePair<string, string>(course[0], course[1]))
                .GroupBy(selector => selector.Key)
                .ToDictionary(group => group.Key, group => group.Select(x => x.Value).ToList());

            //find pairs
            var result = new List<KeyValuePair<int[], string[]>>();
            var students = studentMap.Keys.ToArray();

            for (int index = 0; index < students.Length; index++)
            {
                for (int subIndex = index + 1; subIndex < students.Length; subIndex++)
                {
                    var studentPair = new int[]
                    {
                        int.Parse(students[index]),
                        int.Parse(students[subIndex])
                    };

                    var commonCourses = studentMap[students[index]]
                        .Intersect(studentMap[students[subIndex]])
                        .ToArray();

                    result.Add(new KeyValuePair<int[], string[]>(studentPair, commonCourses));
                }
            }

            var ret = result.Select(x => new string[] { string.Join(",", x.Key) , string.Join(",", x.Value) }).ToArray();

            return result;
        }
    }
}