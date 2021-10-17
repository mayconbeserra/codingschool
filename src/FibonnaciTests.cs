using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace CodingSchool.Tests
{
    public class FibonnaciTests
    {

        [Fact]
        public void Test()
        {
            var number = 5;

            var result = FibonnaciWithMemoization(number);

            result.Should().Be(5);
        }

        /*

         f(5)
      4       3
    3   2   2   1
  2  2 1 0 1
 1 0 1 0

          f(5)
      4       3
    3   2   2   1
        10

f(0) = 0
f(1) = 1
f(2) = 1
f(3) = f2 + f1 = 2
f(4) = f3 + f2 = 3
f(5) = f4 + f3 = 5

Time Complexity: O(n)
Space Complexity: O(n)
        */

        public int Fibonnaci(int number)
        {
            Console.WriteLine(number);
            if (number <= 1) return number;

            return Fibonnaci(number -1) + Fibonnaci(number -2);
        }

        public int FibonnaciWithMemoization(int number)
        {
            if (number <= 1) return number;

            int[] memo = new int[number];
            memo[0] = 0;
            memo[1] = 1;

            for(int index = 2; index < number; index++)
            {
                memo[index] = memo[index - 1] + memo[index - 2];
            }

            return memo[number - 1] + memo[number -2];
        }
    }
}