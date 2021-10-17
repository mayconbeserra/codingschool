using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace CodingSchool.Tests
{
    public class Solution
    {
        [Fact]
        public void Test()
        {
            LetterCombinations("292");
        }

        private IList<string> LetterCombinations(string digits)
        {
            /*
            alphaCodes Dictionary = 1 (empty), 2 (abc), 3 (def), 4 (ghi)...
            Result Hash = AlphaCodes list


            | 1        | 2 (abc) | 3 (def) |
            | 4 (ghi)  | 5 (jkl) | 6 (mno) |
            | 7 (pqrs) | 8 (tuv) | 9 (wxyz)|

            23 => [a]
            1. [a, a, a]
            2. [b, b, b]
            3. [c, c, c]
            4. [ad, ae, af]
            5. [bd, be, bf]
            6. [cd, ce, cf]

            23

            2
        a   b   c
        |   |   |
        3   3   3
    def    def   def
     |      |     |
     4      4     4
    ghi     ghi   ghi


    ad,ae,af / bd,be,bf

    DictionaryAlphaCodes = 2:abc/ 3:def
    Result Combination = ad,ae,af

    Time Complexity: O(4^n)
    Space Complexity: O(n)
             */

            List<string> result = new List<string>();

            if (digits == null || digits.Length == 0)
                return result;

            var alphaCodes = new Dictionary<int, string[]>
            {
                { 0, new string[] { "" } },
                { 1, new string[] { "" } },
                { 2, new string[] { "a", "b", "c" } },
                { 3, new string[] { "d", "e", "f" } },
                { 4, new string[] { "g", "h", "i" } },
                { 5, new string[] { "j", "k", "l" } },
                { 6, new string[] { "m", "n", "o" } },
                { 7, new string[] { "p", "q", "r", "s" } },
                { 8, new string[] { "t", "u", "v" } },
                { 9, new string[] { "w", "x", "y", "z" } }
            };

            RecursionWithStack(result, digits, "", 0, alphaCodes);

            return result;
        }


        public void RecursionWithStack(List<string> result, string digits, string current, int index, Dictionary<int, string[]> mappings)
        {
            var stack = new Stack<string>();

            foreach (var st in mappings[digits[0] - '0'])
                stack.Push(st);

            while (stack.Count > 0)
            {
                var element = stack.Pop();
                var digitIndex = element.Length;

                if (digitIndex == digits.Length)
                {
                    result.Add(element);
                }
                else
                {
                    var otherLetters = mappings[digits[digitIndex] - '0'];
                    Console.WriteLine("Element: {0}, length: {1}, digits: {2}, mapping element: {3}", element, element.Length, digits[element.Length] - '0', string.Join(",", mappings[digits[element.Length] - '0']));

                    foreach (var other in otherLetters)
                    {
                        Console.WriteLine(element + other);
                        stack.Push(element + other);
                    }
                }
            }
        }
    }
}