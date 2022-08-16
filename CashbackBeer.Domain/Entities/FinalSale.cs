using System.Globalization;

namespace CashbackBeer.Domain.Entities
{
    public sealed class FinalSale
    {
        public int Id { get; private set; }
        public double? TotalSaleValue { get; private set; }
        public double? TotalCashback { get; private set; }
        public double? TotalCashbackValue { get; private set; }        

        public DateTime DateSale { get; private set; }
        public List<PartialSale> PartialSales { get; set; } = new List<PartialSale>();

        public FinalSale(int id)
        {
            Id = id;
            DateSale = DateTime.Now;
        }

        public FinalSale TotalValue()
        {
            double? value = 0;
            foreach (var item in PartialSales)
            {
                value += item.ValuePartialSale;
            }
            TotalSaleValue = value;
            return this;
        }

        public FinalSale SetTotalCashback()
        {
            double? value = 0;
            foreach (var item in PartialSales)
            {
                value += item.CashbackValue;
            }
            
            TotalCashback = Math.Round((double)(value / TotalSaleValue)!, 4);
            return this;
        }

        public FinalSale SetTotalCashbackValue()
        {
            double? value = 0;
            foreach (var item in PartialSales)
            {
                value += item.CashbackValue;
            }
            TotalCashbackValue = Math.Round((double)(value), 2);
            return this;
        }
    }
}
