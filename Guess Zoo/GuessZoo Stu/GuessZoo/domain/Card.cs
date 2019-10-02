namespace GuessZoo.domain
{
    public class Card
    {
        public string Color { get; set; }
        public string Animal { get; set; }
        public string Adjective { get; set; }

        public override string ToString()
        {
            return $"Color: {Color}, Animal:{Animal}, Adjective: {Adjective}";
        }
    }
}