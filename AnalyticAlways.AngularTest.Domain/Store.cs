namespace AnalyticAlways.AngularTest.Domain
{
    public class Store
    {
        protected Store()
        { }

        public Store(string name, string city)
        {
            Name = name;
            City = city;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public string City { get; private set; }
    }
}
