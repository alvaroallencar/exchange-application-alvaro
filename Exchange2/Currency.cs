namespace Exchange2
{
    public abstract class Currency
    {
        public string Name { get; set; }
        public decimal ExchangeRate { get; set; }
    }
}