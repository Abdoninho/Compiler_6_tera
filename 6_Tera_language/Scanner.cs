using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _6_Tera_language
{
    public class Scanner
    {
        public List<Token> Scan(string input)
        {
            List<Token> tokens = new List<Token>();
            string[] lines = input.Split('\n');
            int lineNumber = 1;

            foreach (string line in lines)
            {
                string[] parts = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string part in parts)
                {
                    string type = GetTokenType(part);
                    tokens.Add(new Token(part, type, lineNumber));
                }

                lineNumber++;
            }

            return tokens;
        }

        private string GetTokenType(string value)
        {
            if (Regex.IsMatch(value, @"^\d+$"))
                return "number";
            if (value == "int" || value == "real" || value == "void" )
                return "datatype";
            if (value == "=")
                return "assignment operator";
            if (value == "+" || value == "-" || value == "*" || value == "/")
                return "arithmetic operator";
            if (value == ";")
                return "semicolon";
            if (Regex.IsMatch(value, @"^[a-zA-Z_][a-zA-Z0-9_]*$"))
                return "identifier";

            if (value == "if" || value == "else" || value == "while" || value == "return")
                return "keyword";

            if (value == "==" || value == "!=" || value == "<=" || value == ">=" || value == "<" || value == ">")
                return "comparison operator";
            if (value == "(" || value == ")")
                return "parenthesis";
            if (value == "{" || value == "}")
                return "curly brace";
            if (value == "," || value == "[")
                return "punctuation";

            return "unknown";
        }
    }
}
