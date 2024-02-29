using GCall.Application.Repositories;
using GCall.Domain.Entities.Common;
using GCall.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GCall.Persistence.Repositories
{
    public class ReadRepository<DC, T> : IReadRepository<T> where T : BaseEntity where DC : DbContext
    {
        readonly DC _context;
        public ReadRepository(DC context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            return query;
        }

        public IQueryable<T> GetAllDeletedStatus(bool tracking = true, bool isDeleted = false)
        {
            var query = Table.Where(x => x.IsDeleted == isDeleted).AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            return query;
        }

        public IQueryable<T> GetAllIncluding(Expression<Func<T, object>>[] includeExpressions, bool tracking = true)
        {
            var query = Table.Where(x => x.IsDeleted == false).AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            if (includeExpressions != null && includeExpressions.Any())
            {
                foreach (var includeExpression in includeExpressions)
                {
                    query = query.Include(includeExpression);
                }
            }

            return query;
        }

        public IQueryable<T> GetAllDeletedStatusIncluding(Expression<Func<T, object>>[] includeExpressions, bool tracking = true, bool isDeleted = false)
        {
            var query = Table.Where(x => x.IsDeleted == isDeleted).AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            if (includeExpressions != null && includeExpressions.Any())
            {
                foreach (var includeExpression in includeExpressions)
                {
                    query = query.Include(includeExpression);
                }
            }

            return query;
        }

        public IQueryable<T> GetAllDescending(bool tracking = true)
        {
            var query = Table.OrderByDescending(x => x.CreatedDate).AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            return query;
        }

        public IQueryable<T> GetAllDeletedStatusDescending(bool tracking = true, bool isDeleted = false)
        {
            var query = Table.Where(x => x.IsDeleted == isDeleted).OrderByDescending(x => x.CreatedDate).AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            return query;
        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        }

        public async Task<T> GetByIdAsyncIncluding(Expression<Func<T, object>>[] includeExpressions, string id, bool tracking = true)
        {
            var query = Table.Where(x => x.IsDeleted == false).AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            if (includeExpressions != null && includeExpressions.Any())
            {
                foreach (var includeExpression in includeExpressions)
                {
                    query = query.Include(includeExpression);
                }
            }

            return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync(method);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);
            if (!tracking)
                query = query.AsNoTracking();

            return query;
        }
    }
}
