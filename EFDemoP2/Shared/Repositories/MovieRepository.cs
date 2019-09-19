using Shared.Data;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Shared.Repositories
{
    public class MovieRepository
    {
        private Context _context;

        public MovieRepository(Context context)
        {
            _context = context;
        }

        public List<Movie> GetList()
        {
            return GetList(m => m.Title);
        }

        public List<Movie> GetList(Expression<Func<Movie, object>> orderPredicate)
        {
            return _context.Movies
                .Include(m => m.Director)
                .OrderBy(orderPredicate)
                .ToList();
        }

        public Movie GetSingle(int id)
        {
            return GetSingle(m => m.Id == id);
        }

        public Movie GetSingle(Expression<Func<Movie, bool>> wherePredicate)
        {
            return _context.Movies
                .Where(wherePredicate)
                .SingleOrDefault();
        }
    }
}
