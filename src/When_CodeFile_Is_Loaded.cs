using System;
using System.Linq;
using CodingSchool.Models;
using FluentAssertions;
using Xunit;

namespace CodingSchool
{
    public class When_CodeFile_Is_Loaded
    {
        private readonly string _completeCSharpFile;
        private readonly string _only2Comments;

        public When_CodeFile_Is_Loaded()
        {
            _completeCSharpFile = System.IO.File.ReadAllText("./Examples/CompleteCSharpFile.cs");
            _only2Comments = System.IO.File.ReadAllText("./Examples/Only2Comments.cs");
        }

        [Fact]
        public void Then_It_Should_Not_Allow_EmptyFile()
        {
            Action act = () => new CodeFile(string.Empty);

            act.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData("System.Console.Writeline(\" Content \")", 1, 0, 0, 0)]
        [InlineData("System.Console.Writeline(\" Content \") // Single Comment", 1, 1, 0, 0)]
        [InlineData("System.Console./* Block comment */Writeline(\" Content \")", 1, 0, 1, 0)]
        [InlineData("System.Console.Writeline(\" Content \") \n\n", 1, 0, 0, 1)]
        public void Then_It_Should_Match_Basic_Criterias(
                   string code,
                   int expectedLOC,
                   int expectedSingleComments,
                   int expectedBlockComments,
                   int expectedEmptyOrWhitespaceLines)
        {
            // Arrange / Act
            var codeFile = new CodeFile(code);

            // Assert
            codeFile.Lines.OfType<CodeLine>().Should().HaveCount(expectedLOC);
            codeFile.Lines.OfType<CommentLine>().Should().HaveCount(expectedSingleComments);
            codeFile.Lines.OfType<BlockComment>().Should().HaveCount(expectedBlockComments);
            codeFile.Lines.OfType<EmptyOrWhiteSpaceLine>().Should().HaveCount(expectedEmptyOrWhitespaceLines);
        }

        [Fact]
        public void Then_It_Should_Extract_Lines()
        {
            new CodeFile(_completeCSharpFile)
                .Lines
                .Count
                    .Should()
                    .Be(9);
        }

        [Fact]
        public void Then_It_Should_Count_CodeLines()
        {
            new CodeFile(_completeCSharpFile)
                .Lines.OfType<CodeLine>()
                .Count()
                    .Should()
                    .Be(6);
        }

        [Fact]
        public void It_Should_Count_BlockComments()
        {
            new CodeFile(_completeCSharpFile)
                .Lines.OfType<BlockComment>()
                .Count()
                    .Should()
                    .Be(1);
        }

        [Fact]
        public void Then_It_Should_Count_Only_Comments()
        {
            var codeFile = new CodeFile(_only2Comments);

            codeFile.Lines.Count.Should().Be(2);
            codeFile.Lines.OfType<CommentLine>().Should().HaveCount(2);
        }
    }
}
