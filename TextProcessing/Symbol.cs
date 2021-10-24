namespace TextProcessing
{
    public class Symbol
    {
        private readonly char Data;
        public TypeSymbol Type { get; protected set; }

        public Symbol(char symbol)
        {
            Data = symbol;
            Type = GetType();
        }

        new protected TypeSymbol GetType()
        {
            switch (Data)
            {
                case ' ': return TypeSymbol.WhiteSpace;
                case '.': return TypeSymbol.Point;
                case ',': return TypeSymbol.Comma;
                case '-': return TypeSymbol.Dash;
                case ':': return TypeSymbol.Colon;
                case ';': return TypeSymbol.Semicolon;
                case '!': return TypeSymbol.ExclamationPoint;
                case '?': return TypeSymbol.QuestionPoint;
                default: return TypeSymbol.Standart;
            }
        }

        public override string ToString() => Data.ToString();
    }
}
