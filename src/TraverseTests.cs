using Xunit;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System;
using System.Diagnostics.CodeAnalysis;

namespace CodingSchool.Tests
{
    public class TraverseTests
    {
        [Fact]
        public void TestFunc()
        {
            string[][] prereqCourses = {
                new string[] {"Foundations of Computer Science", "Operating Systems"},
                new string[] {"Data Structures", "Algorithms"},
                new string[] {"Computer Networks", "Computer Architecture"},
                new string[] {"Algorithms", "Foundations of Computer Science"},
                new string[] {"Computer Architecture", "Data Structures"},
                new string[] {"Software Design", "Computer Networks"}
            };

            var result = prereqCourses.Select(e =>
            {
                return new RequirementCourse()
                {
                    PreRequirement = e[0],
                    Course = e[1]
                };
            });

            var ret = result.FirstOrDefault(x => !result.Select(y => y.Course).Contains(x.PreRequirement));

            var finalList = ret.Traverse(result);

            var nextCourse = finalList.TakeLast((prereqCourses.Length / 2)).FirstOrDefault();

            Console.WriteLine(nextCourse.PreRequirement);
        }

        public IEnumerable<int> GetSingleDigitNumbers()
        {
            yield return 0;
            yield return 1;
            yield return 2;
            yield return 3;
            yield return 4;
            yield return 5;
            yield return 6;
            yield return 7;
            yield return 8;
            yield return 9;
        }
    }

    public static class Ext
    {
        public static IEnumerable<RequirementCourse> Traverse2(this RequirementCourse root, IEnumerable<RequirementCourse> elements, string searchValue)
        {
            var stack = new Stack<RequirementCourse>();
            stack.Push(root);

            int index = 0;
            while(stack.Count > 0)
            {
                var current = stack.Pop();

                var children = elements.Where(e => e.PreRequirement == current.Course);
                foreach(var child in children)
                    stack.Push(child);

                if (current.Course.Equals(searchValue))
                {
                    stack.Clear();
                }

                index++;

                yield return current;
            }
        }

        public static IEnumerable<RequirementCourse> Traverse(this RequirementCourse root, IEnumerable<RequirementCourse> list)
        {
            var stack = new Stack<RequirementCourse>();
            var halfway = list.Count()  / 2;
            var index = -1;
            stack.Push(root);

            var ret = new List<RequirementCourse>();

            while(stack.Count > 0)
            {
                var current = stack.Pop();

                var children = list.Where(x => current.Course == x.PreRequirement).ToList();
                foreach(var child in children)
                    stack.Push(child);

                index++;

                ret.Add(current);

                // yield return current;
            }

            return ret.AsEnumerable();
        }
    }

    /*

    0. Software Design - add to stack
    1. Pop Software design from stack
    2. Get children
    2.1 add to the stack, Computer networks
    21. add the first

    */

    public class RequirementCourse
    {
        public string PreRequirement {get;set;}
        public string Course {get;set;}
    }
}