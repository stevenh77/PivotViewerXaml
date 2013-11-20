using System;
using System.Collections.ObjectModel;

namespace PivotViewerXaml
{
    public class Trade
    {
        public decimal Amount { get; set; }
        public Currency Currency { get; set; }
        public DateTime DealDate { get; set; }
        public Sector Sector { get; set; }
        public string Underlying { get; set; }

        //public override int GetHashCode()
        //{
        //    int hash = 13;
        //    hash = (hash * 7) + Amount.GetHashCode();
        //    hash = (hash * 7) + Currency.GetHashCode();
        //    hash = (hash * 7) + DealDate.GetHashCode();
        //    hash = (hash * 7) + Sector.GetHashCode();
        //    hash = (hash * 7) + Underlying.GetHashCode();
        //    return hash;
        //}

        public static ObservableCollection<Trade> CreateTrades()
        {
            return new ObservableCollection<Trade>
            {
                new Trade { Amount = 100, Currency = new Currency("CHF"), DealDate = DateTime.Today.AddDays(-7), Sector = Sector.Finance, Underlying = "Credit Suisse" },
                new Trade { Amount = 200, Currency = new Currency("EUR"), DealDate = DateTime.Today.AddDays(-10), Sector = Sector.Finance, Underlying = "Deutsche Bank" },
                new Trade { Amount = 300, Currency = new Currency("USD"), DealDate = DateTime.Today.AddDays(-4), Sector = Sector.Finance, Underlying = "Bank of America" },
                new Trade { Amount = 400, Currency = new Currency("EUR"), DealDate = DateTime.Today.AddDays(-6), Sector = Sector.Finance, Underlying = "RBS" },
                new Trade { Amount = 500, Currency = new Currency("CHF"), DealDate = DateTime.Today.AddDays(-6), Sector = Sector.Communications, Underlying = "UPC" },
                new Trade { Amount = 600, Currency = new Currency("EUR"), DealDate = DateTime.Today.AddDays(-6), Sector = Sector.HealthCare, Underlying = "Glaxo" },
                new Trade { Amount = 700, Currency = new Currency("EUR"), DealDate = DateTime.Today.AddDays(-6), Sector = Sector.Technology, Underlying = "IBM" },
                new Trade { Amount = 100, Currency = new Currency("CHF"), DealDate = DateTime.Today.AddDays(-7), Sector = Sector.Communications, Underlying = "British Telecom" },
                new Trade { Amount = 200, Currency = new Currency("EUR"), DealDate = DateTime.Today.AddDays(-10), Sector = Sector.HealthCare, Underlying = "NHS" },
                new Trade { Amount = 300, Currency = new Currency("USD"), DealDate = DateTime.Today.AddDays(-4), Sector = Sector.Technology, Underlying = "Apple" },
                new Trade { Amount = 300, Currency = new Currency("USD"), DealDate = DateTime.Today.AddDays(-4), Sector = Sector.Technology, Underlying = "Google" },
                new Trade { Amount = 300, Currency = new Currency("USD"), DealDate = DateTime.Today.AddDays(-4), Sector = Sector.Technology, Underlying = "Microsoft" },
                
            };
        }
    }
}
