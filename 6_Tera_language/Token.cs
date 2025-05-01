
namespace _6_Tera_language
{
    public struct Token
    {
        public string Value;
        public string Type;
        public int LineNumber;

        public Token(string value, string type, int lineNumber)
        {
            Value = value;
            Type = type;
            LineNumber = lineNumber;
        }

        public override string ToString()
        {
            return $"[{Type}] '{Value}' (Line: {LineNumber})";
        }
    }
}