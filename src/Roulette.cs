using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CodingSchool.Tests
{
    public class Tests
    {
        [Fact]
        public void RouletteTests()
        {
            // Roulette game = new Roulette();

            // for(int i = 0; i < 4; i++)
            // {
            //     game.MakeBet(new Bet(0));
            //     game.Play();
            // }

            // Console.WriteLine(game.HasWon);

            //LargestPalindrome("racecarsracing");
            LargestPal("racecarsracing", 0, new List<string>());
        }

        public List<string> LargestPal(string text, int pointer, List<string> validPalid)
        {
            if (pointer == text.Length)
            {
                return validPalid;
            }
            else
            {
                for (int i = pointer; i < text.Length; i++)
                {
                    if (IsPalindrome(text, pointer, i))
                    {
                        string snippet = text[pointer..(i + 1)];
                        validPalid.Add(snippet);

                        LargestPal(text, pointer + 1, validPalid);
                    }
                }
            }

            return validPalid;
        }

        public bool IsPalindrome(string s, int low, int high)
        {
            while (low < high) {
                if (s[low++] != s[high--]) {
                    return false;
                }
            }

            return true;
        }

        public List<string> LargestPalindrome(string text)
        {
            /*
                racecarsracing
            r =>
            */

            var result = new List<string>();
            int maxLength = 0;
            int start = 0;

            for(int index = 0; index < text.Length; index ++)
            {
                for (int subIndex = text.Length - 1; subIndex > index; subIndex--)
                {
                    int flag = 1;
                    // Check palindrome
                    for (int k = 0; k < (subIndex - index + 1) / 2; k++)
                        if (text[index + k] != text[subIndex - k])
                            flag = 0;

                    // Palindrome
                    if (flag!=0 && (subIndex - index + 1) > maxLength) {
                        start = index;
                        maxLength = subIndex - index + 1;
                        //result.Add(text[])
                    }
                }
            }

            return result;
        }

        public class Roulette
        {
            private RouletteWheel _wheel = new RouletteWheel();
            private Bet _bet;
            public int CurrentMoney {get; private set; } = 50;

            public bool HasWon { get { return CurrentMoney >= 100; }}

            public void MakeBet(Bet bet)
            {
                _bet = bet;
            }

            public void Play()
            {
                // perform some validation
                _wheel.Spin();

                if (_wheel.Number == _bet.Color) // black
                {
                    CurrentMoney += 25;
                }
                else
                {
                    CurrentMoney -= 25;
                }

                _bet = null;
            }
        }

        public class RouletteWheel
        {
            public int Number {get; private set;}
            public void Spin()
            {
                Random rnd = new Random();
                Number = rnd.Next(1);
            }
        }

        public class Bet
        {
            public int Color {get; private set;}
            public Bet(int blackOrRed)
            {
                Color = blackOrRed;
            }
        }

    }
}