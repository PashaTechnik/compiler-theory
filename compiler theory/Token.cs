namespace compiler_theory
{
    public class Token
    {
        readonly string lexeme;
        readonly TokenCategory category;
        readonly int row;
        readonly int column;

        public string Lexeme
        {
            get { return lexeme; }
        }

        public TokenCategory Category
        {
            get { return category; }
        }

        public int Row
        {
            get { return row; }
        }

        public int Column
        {
            get { return column; }
        }

        public Token(string lexeme,
            TokenCategory category,

            int row,
            int column)
        {
            this.lexeme = lexeme;
            this.category = category;
            this.row = row;
            this.column = column;
        }

        public override string ToString()
        {
            return string.Format("{{{0}, \"{1}\", @({2}, {3})}}",
                category, lexeme, row, column);
        }
    }

    public enum TokenCategory
    {
    FLIP,
    BINOMIAL,
    BOOL,
    NORMAL,
    UNIFORM,
    String,
    FALSE,
    ELSE,
    IF,
    INT,
    TRUE,
    THEN,
    POISSON,
    BERNOULLI,
    locLaplace,
    intLaplace,
    FACT,
    PRINT
    }
}