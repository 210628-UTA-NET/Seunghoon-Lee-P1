using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seunghoon_Lee_P1.Models.DataLayer.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        //Pass db context
        private P1Context context { get; set; }
        private DbSet<T> dbSet { get; set; }
        public Repository(P1Context p_context)
        {
            context = p_context;
            dbSet = context.Set<T>();
        }

        //Number of retreived entities
        private int? count;
        public int Count => count ?? dbSet.Count();

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T Get(QueryOptions<T> options)
        {
            throw new NotImplementedException();
        }

        public T Get(int id)
        {
            throw new NotImplementedException();
        }

        public T Get(string id)
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> List(QueryOptions<T> options)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
        
        //Helper method to build query expression
        private IQueryable<T> BuildQuery(QueryOptions<T> options)
        {
            IQueryable<T> query = dbSet;
            foreach(string include in options.GetIncludes())
            {
                query = query.Include(include);
            }
            if(options.HasWhere)
            {
                foreach(var clause in options.WhereClauses)
                {
                    query = query.Where(clause);
                }
                count = query.Count();
            }
            if(options.HasOrderBy)
            {
                if(options.OrderByDirection == "asc")
                    query = query.OrderBy(options.OrderBy);
                else
                    query = query.OrderByDescending(options.OrderBy);
            }
            if (options.HasPaging)
                query = query.PageBy(options.PageNumber, options.PageSize);
            
            return query;
        }
    }
}
