namespace AnalyticAlways.AngularTest.Reads.Filters
{
    public class GetAllStoresFilter : Filter
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string IdFilter => $"%{Id}%";

        public string NameFilter => $"%{Name}%";

        public string CityFilter => $"%{City}%";
    }
}
