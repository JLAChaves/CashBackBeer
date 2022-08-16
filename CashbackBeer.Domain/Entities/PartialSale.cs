using System.Text.Json.Serialization;

namespace CashbackBeer.Domain.Entities
{
    public sealed class PartialSale
    {
        public int Id { get; private set; }
        public int Amount { get; private set; }        
        public double? ValuePartialSale { get; private set; }
        public double? CashbackPercentage { get; private set; }
        public double? CashbackValue { get; private set; }
        public DateTime DateSale { get; private set; }
        public int FinalSaleId { get; set; }
        public FinalSale? FinalSale { get; set; }
        public int BeerId { get; set; }
        public Beer? Beer { get; set; }

        [JsonConstructor]
        public PartialSale(int amount, int beerId)
        {
            Amount = amount;
            BeerId = beerId;
            DateSale = DateTime.Now;
        }

        public PartialSale(int id, int amount, int beerId)
        {
            Id = id;
            Amount = amount;
            BeerId = beerId;
            DateSale = DateTime.Now;
        }

        public PartialSale PartialValue(int amount, double valueBeer)
        {
            ValuePartialSale = Math.Round(amount * valueBeer, 2);
            return this;
        }   

        public PartialSale CashbackSale(Beer beer)
        {
            int date = (int) DateSale.DayOfWeek;

            if (date == 0)
            {
                CashbackPercentage = beer.SundayCashback;
                return this;
            }
            if (date == 1)
            {
                CashbackPercentage = beer.MondayCashback;
                return this;
            }
            if (date == 2)
            {
                CashbackPercentage = beer.TuesdayCashback;
                return this;
            }
            if (date == 3)
            {
                CashbackPercentage = beer.WednesdayCashback;
                return this;
            }
            if (date == 4)
            {
                CashbackPercentage = beer.ThursdayCashback;
                return this;
            }
            if (date == 5)
            {
                CashbackPercentage = beer.FridayCashback;
            }
            if (date == 6)
            {
                CashbackPercentage = beer.SaturdayCashback;
                return this;
            }

            return this;
        }

        public PartialSale CashBackValue()
        {
            double value = (double)(ValuePartialSale * CashbackPercentage);
            CashbackValue = Math.Round(value, 2);
            return this;
        }
    }
}
