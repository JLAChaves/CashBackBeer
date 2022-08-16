namespace CashbackBeer.Domain.Entities
{
    public sealed class Beer
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public double Value { get; private set; }
        public double SundayCashback { get; private set; }
        public double MondayCashback { get; private set; }
        public double TuesdayCashback { get; private set; }
        public double WednesdayCashback { get; private set; }
        public double ThursdayCashback { get; private set; }
        public double FridayCashback { get; private set; }
        public double SaturdayCashback { get; private set; }

        public Beer(int id, string name, double value, double sundayCashback, double mondayCashback, double tuesdayCashback, double wednesdayCashback, double thursdayCashback, double fridayCashback, double saturdayCashback)
        {
            Id = id;
            Name = name;
            Value = value;
            SundayCashback = sundayCashback;
            MondayCashback = mondayCashback;
            TuesdayCashback = tuesdayCashback;
            WednesdayCashback = wednesdayCashback;
            ThursdayCashback = thursdayCashback;
            FridayCashback = fridayCashback;
            SaturdayCashback = saturdayCashback;
        }
        public Beer(string name, double value, double sundayCashback, double mondayCashback, double tuesdayCashback, double wednesdayCashback, double thursdayCashback, double fridayCashback, double saturdayCashback)
        {
            Name = name;
            Value = value;
            SundayCashback = sundayCashback;
            MondayCashback = mondayCashback;
            TuesdayCashback = tuesdayCashback;
            WednesdayCashback = wednesdayCashback;
            ThursdayCashback = thursdayCashback;
            FridayCashback = fridayCashback;
            SaturdayCashback = saturdayCashback;
        }  
    }
}
