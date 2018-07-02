namespace Server.Infrastructure
{
    /// <summary>
    /// Conteins value and currency type
    /// </summary>
    public struct Money
    {
        public decimal MoneyValue { get; set; }
        public CurrencyType CurrencyType { get; private set; }

        public Money(decimal moneyValue, CurrencyType currencyType)
        {
            MoneyValue = moneyValue;
            CurrencyType = currencyType;
        }
    }
}