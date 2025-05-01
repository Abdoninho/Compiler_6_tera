using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace using _6_Tera_language{
public class Scanner
{
    private static readonly string[] keywords = { "int", "real", "return", "void", "if", "else", "while" };
    private static readonly string[] operators = { "==", "!=", "<=", ">=", "+", "-", "*", "/", "=", "<", ">" };
    private static readonly string[] symbols = { ";", ",", "(", ")", "{", "}", "[", "]" };

    public List<Token> Scan(string input)
    {
        var tokens = new List<Token>();
        var lines = input.Split(new[] { '\n' }, StringSplitOptions.None);

        for (int lineIndex = 0; lineIndex < lines.Length; lineIndex++)
        {
            string line = lines[lineIndex];
            var matches = Regex.Matches(line, @"==|!=|<=|>=|[=+\-*/<>(){}\[\],;]|[A-Za-z_][A-Za-z0-9_]*|\-?\d+\.\d+|\-?\d+");

            foreach (Match match in matches)
            {
                string value = match.Value;
                string type = GetTokenType(value);
                tokens.Add(new Token(value, type, lineIndex + 1));
            }
        }

        return tokens;
    }

    private string GetTokenType(string value)
    {
        if (Array.Exists(keywords, k => k == value))
            return "keyword";
        if (Array.Exists(operators, op => op == value))
            return "operator";
        if (Array.Exists(symbols, s => s == value))
            return "symbol";
        if (Regex.IsMatch(value, @"^-?\d+$"))
            return "integer";
        if (Regex.IsMatch(value, @"^-?\d+\.\d+$"))
            return "real";
        if (Regex.IsMatch(value, @"^[A-Za-z_][A-Za-z0-9_]*$"))
            return "identifier";

        return "unknown";
    }
}
}