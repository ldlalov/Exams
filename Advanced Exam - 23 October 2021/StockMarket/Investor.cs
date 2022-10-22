using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        private List<Stock> portfolio = new List<Stock>();
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
        }
        public IReadOnlyCollection<Stock> Portfolio => portfolio;
        public int Count => portfolio.Count;
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }
        
        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && MoneyToInvest>=stock.PricePerShare)
            {
                portfolio.Add(stock);
                MoneyToInvest -= stock.PricePerShare;
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            if (portfolio.FirstOrDefault(x => x.CompanyName == companyName) == null)
            {
                return $"{companyName} does not exist.";
            }
            if (portfolio.FirstOrDefault(x => x.CompanyName == companyName).PricePerShare > sellPrice)
            {
                return $"Cannot sell {companyName}.";
            }
            portfolio.RemoveAll(x => x.CompanyName == companyName);
            return $"{companyName} was sold.";
        }

        public Stock FindStock(string companyName)
        {
            var stock = portfolio.FirstOrDefault(x => x.CompanyName == companyName);
            return stock;
        }

        public Stock FindBiggestCompany()
        {
            return portfolio.OrderByDescending(x => x.MarketCapitalization).FirstOrDefault();
        }

        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");
            foreach (var stock in portfolio)
            {
                sb.AppendLine($"{stock.ToString()}");

            }
            return sb.ToString().TrimEnd();
        }
    }
}
