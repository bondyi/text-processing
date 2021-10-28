using TextProcessing.TextItems.Enums;

namespace TextProcessing.TextItems
{
    public class Symbol
    {
        private readonly char _symbol;

        public TypeSymbol Type { get; protected set; }

        internal Symbol(char symbol)
        {
            _symbol = symbol;
            Type = GetType();
        }

        new protected TypeSymbol GetType()
        {
            switch (_symbol)
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

        public override string ToString() => _symbol.ToString();
    }
}
