using System;

namespace AndreMarcondesTeixeira
{
    public partial struct Money
    {
        public static Money operator + (Money a, Money b)
        {
            ThrowArgumentExceptionIfCurrenciesAreNotTheSame(a, b);
            return new Money(a.Amount + b.Amount, a.Currency);
        }

        public static Money operator + (Money money)
        {
            return new Money(money.Amount, money.Currency);
        }

        public static Money operator - (Money a, Money b)
        {
            ThrowArgumentExceptionIfCurrenciesAreNotTheSame(a, b);
            return new Money(a.Amount - b.Amount, a.Currency);
        }

        public static Money operator - (Money money)
        {
            return new Money(money.Amount * (-1), money.Currency);
        }

        public static Money operator * (Money money, decimal factor)
        {
            return new Money(money.Amount * factor, money.Currency);
        }

        public static Money operator * (decimal factor, Money money)
        {
            return new Money(money.Amount * factor, money.Currency);
        }

        public static Money operator / (Money money, decimal factor)
        {
            return new Money(money.Amount / factor, money.Currency);
        }

        public static Money operator / (decimal factor, Money money)
        {
            return new Money(factor / money.Amount, money.Currency);
        }

        public static bool operator == (Money a, Money b)
        {
            return AreEquivalent(a, b);
        }

        public static bool operator != (Money a, Money b)
        {
            ThrowArgumentExceptionIfCurrenciesAreNotTheSame(a, b);
            return a.Currency != b.Currency || a.Amount != b.Amount;
        }

        public static bool operator > (Money a, Money b)
        {
            ThrowArgumentExceptionIfCurrenciesAreNotTheSame(a, b);
            return a.Amount > b.Amount;
        }

        public static bool operator < (Money a, Money b)
        {
            ThrowArgumentExceptionIfCurrenciesAreNotTheSame(a, b);
            return a.Amount < b.Amount;
        }

        public static bool operator >= (Money a, Money b)
        {
            ThrowArgumentExceptionIfCurrenciesAreNotTheSame(a, b);
            return a.Amount >= b.Amount;
        }

        public static bool operator <= (Money a, Money b)
        {
            ThrowArgumentExceptionIfCurrenciesAreNotTheSame(a, b);
            return a.Amount <= b.Amount;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return AreEquivalent(this, (Money) obj);
        }

        private static bool AreEquivalent(Money a, Money b)
        {
            ThrowArgumentExceptionIfCurrenciesAreNotTheSame(a, b);
            return a.Amount == b.Amount;
        }

        private static void ThrowArgumentExceptionIfCurrenciesAreNotTheSame(Money a, Money b)
        {
            if (a.Currency != b.Currency)
            {
                throw new ArgumentException("Currencies must be the same");
            }
        }
    }
}