using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace CodingSchool.Models
{
    public class CodeFile
    {
        private readonly string _rawCode;
        private readonly IList<Line> _lines = new List<Line>();

        public CodeFile(string code)
        {
            if (string.IsNullOrEmpty(code?.Trim()))
            {
                throw new ArgumentException(nameof(code), "Invalid code");
            }

            _rawCode = code;
            DetermineLines();
        }

        public IList<Line> Lines => _lines;

        private void DetermineLines()
        {
            string tempCode = _rawCode;

            MatchCollection commentLines = Regex.Matches(tempCode, Comments.RegexLineComments, RegexOptions.Multiline);
            MatchCollection commentBlocks = Regex.Matches(tempCode, Comments.RegexBlockComments, RegexOptions.Singleline);

            var index = 0;
            foreach (Match match in commentLines)
            {
                index++;
                var comment = match.Value;
                tempCode = Comments.RemoveComment(tempCode, comment);
                Lines.Add(new CommentLine(index, comment));
            }

            index = 0;
            foreach (Group match in commentBlocks)
            {
                index++;
                var comment = match.Value;
                tempCode = Comments.RemoveComment(tempCode, comment);
                Lines.Add(new BlockComment(index, match.Value));
            }

            var codeLines = new StringReader(tempCode);
            string currentLine;

            while ((currentLine = codeLines.ReadLine()?.Trim()) != null)
            {
                index++;
                if (string.IsNullOrWhiteSpace(currentLine))
                {
                    Lines.Add(new EmptyOrWhiteSpaceLine(index, currentLine.Trim()));
                }
                else Lines.Add(new CodeLine(index, currentLine.Trim()));
            }
        }
    }
}