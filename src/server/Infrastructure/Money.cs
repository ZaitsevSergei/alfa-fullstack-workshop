namespace Server.Infrastructure
{
    /// <summary>
    /// Contains value and currency type
    /// </summary>
    public class Money
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