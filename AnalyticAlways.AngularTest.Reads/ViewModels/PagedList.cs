using System;
using System.Collections.Generic;

namespace AnalyticAlways.AngularTest.Reads.ViewModels
{
    public class PagedList<T> where T: class
    {
        public int TotalCount { get; set; }

        public IEnumerable<T> Items { get; set; }

    }
}

