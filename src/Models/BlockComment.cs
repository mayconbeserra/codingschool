namespace CodingSchool.Models
{
    public class BlockComment : Line
    {
        public BlockComment(int index, string code) : base(index, code) { }

        public BlockComment AppendComment(string code)
        {
            return new BlockComment(this._index, this._code + code);
        }
    }
}