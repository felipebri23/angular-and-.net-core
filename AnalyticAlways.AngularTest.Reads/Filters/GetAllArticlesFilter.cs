namespace AnalyticAlways.AngularTest.Reads.Filters
{
    public class GetAllArticlesFilter : Filter
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public string Price { get; set; }

        public string IdFilter => $"%{Id}%";

        public string DescriptionFilter => $"%{Description}%";

        public string PriceFilter => $"%{Price}%";
    }
}
