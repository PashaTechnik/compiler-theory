using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace compiler_theory
{
    public class Scanner
    {
        readonly string input;
        private static readonly Regex regex = new Regex("");
        
        static readonly IDictionary<string, TokenCategory> keywords =
            new Dictionary<string, TokenCategory>()
            {
                {"break", TokenCategory.BOOL},
                {"else", TokenCategory.THEN},
                {"return", TokenCategory.IF},
                {"false", TokenCategory.PRINT},
                {"for", TokenCategory.THEN},
                {"true", TokenCategory.THEN},
                {"if", TokenCategory.THEN},
            };

        static readonly IDictionary<string, TokenCategory> nonKeywords =
            new Dictionary<string, TokenCategory>()
            {
                {"False", TokenCategory.FALSE},
                {"True", TokenCategory.TRUE}
            };

        public Scanner(string input)
        {
            this.input = input;
        }

        public IEnumerable<Token> Start()
        {
            var row = 1;

            var columnStart = 0;
            Func<Match, TokenCategory, Token> newTok = (m, tc) =>
                new Token(m.Value, tc, row, m.Index - columnStart + 1);
            foreach (Match m in regex.Matches(input))
            {
                if (m.Groups["Newline"].Success)
                {

                    row++;

                    columnStart = m.Index + m.Length;
                }
                else if (m.Groups["WhiteSpace"].Success
                         || m.Groups["Comment"].Success)
                {
                }
                else if (m.Groups["Identifier"].Success)
                {
                    if (keywords.ContainsKey(m.Value))
                    {
                        yield return newTok(m, keywords[m.Value]);

                    }
                }
                else if (m.Groups["String"].Success)
                {
                    yield return newTok(m, TokenCategory.String);
                }
                else
                {
                    foreach (var name in nonKeywords.Keys)
                    {
                        if (m.Groups[name].Success)
                        {
                            yield return newTok(m, nonKeywords[name]);
                            break;
                        }
                    }
                }
            }
            


        }
    }
}

    
