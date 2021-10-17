using Xunit;
using System.Linq;
using System.Collections;
using System.Text;

namespace CodingSchool.Tests
{
    public class CompressionTests
    {
        [Fact]
        public void Compress()
        {
            var fullText = "wwwwaaadexxxxxxywww";

            System.Console.WriteLine(Comp(fullText));
        }

        public string Comp(string text)
        {
            StringBuilder result = new StringBuilder();
            int length = text.Length;

            for (int index = 0; index < length; index++)
            {
                int count = 1;

                while (index < length -1 && text[index] == text[index + 1])
                {
                    count++;
                    index++;
                }

                result.Append(string.Format("{0}{1}", text[index], count));
            }

            return result.ToString();
        }
    }
}