namespace CodingSchool.Models
{
    public static class Comments
    {
        public const string RegexBlockComments = @"(/\*.*?\*/)";
        public const string RegexLineComments = "(//.*)";

        public static string RemoveComment(string code, string search)
        {
            int position = code.IndexOf(search);
            if (position < 0) return code;

            var ret = code.Substring(0, position).Trim() + code.Substring(position + search.Length);

            return ret;
        }
    }
}