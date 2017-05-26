namespace AnalyticAlways.AngularTest.Reads.Filters
{
    public class Filter
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public string PagingClause => BuildPagingClause();

        private string BuildPagingClause()
        {
            var pageSize = PageSize == default(int) ? 10 : PageSize;
            return $"OFFSET({PageIndex} * {pageSize}) ROWS FETCH NEXT {pageSize} ROWS ONLY";
        }
    }
}
