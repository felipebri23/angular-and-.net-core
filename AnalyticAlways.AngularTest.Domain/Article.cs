namespace AnalyticAlways.AngularTest.Domain
{
    public class Article
    {
        protected Article()
        { }

        public Article(string description, double price)
        {
            Description = description;
            Price = price;
        }

        public int Id { get; private set; }

        public string Description { get; private set; }

        public double Price { get; private set; }
    }
}
