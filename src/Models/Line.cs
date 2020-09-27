namespace CodingSchool.Models
{
    public abstract class Line
    {
        protected readonly int _index;
        protected readonly string _code;

        public Line(int index, string code)
        {
            _index = index;
            _code = code;
        }
    }
}