using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CodingSchool.Tests
{
    public class CoinChange
    {
        [Fact]
        public void Tests()
        {                          //0  1  2   3
            var coins = new int[ ] { 1, 5, 10, 25 };
            var amount = 33;

            int remaining = amount;
            Dictionary<int, int> change = new Dictionary<int, int>();

            int coin = coins.Length - 1;
            while(coin >= 0)
            {
                var result = Int32.MaxValue;
                while (result > 0)
                {
                    result = remaining - coins[coin];
                    var coinIncrease = 0;

                    if (result >= 0)
                    {
                        coinIncrease = 1;
                        remaining = result;
                    }

                    if (change.ContainsKey(coins[coin]))
                    {
                        change[coins[coin]] += coinIncrease;
                    }
                    else
                    {
                        change.Add(coins[coin], coinIncrease);
                    }
                }
                coin--;
            }

            foreach(var ret in change)
                Console.WriteLine("{0}-{1}", ret.Key, ret.Value);
        }
    }
}