namespace TextProcessing
{
    public abstract class TextComponent
    {
        private readonly string Data;

        public TextComponent(string data) => Data = data;

        public override string ToString() => Data.ToString();
    }
}
