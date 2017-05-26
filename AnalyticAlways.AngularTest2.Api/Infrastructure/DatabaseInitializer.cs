using AnalyticAlways.AngularTest.Domain;
using AnalyticAlways.AngularTest.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnalyticAlways.AngularTest2.Api.Infrastructure
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly AngularTestContext _context;

        public DatabaseInitializer(AngularTestContext context)
        {
            _context = context;
        }

        public void Initialize()
        {
            _context.Database.Migrate();

            if (!_context.Articles.Any())
            {
                var articles = GetArticles();
                _context.Articles.AddRange(articles);
            }

            if (!_context.Stores.Any())
            {
                var stores = GetStores();
                _context.Stores.AddRange(stores);
            }

            _context.SaveChanges();
        }

        private Article[] GetArticles()
        {
            return Enumerable.Range(1, 100)
                .Select(x => new Article($"Description {x}", (x * 100) / 2))
                .ToArray();
        }

        private Store[] GetStores()
        {
            return Enumerable.Range(1, 50)
                .Select(x => new Store($"Store { x }", $"City {x}"))
                .ToArray();
        }
    }
}
