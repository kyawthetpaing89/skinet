using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Infrastructure;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class GenericRepository<T>(StoreContext context) : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _context = context;
        public async Task<T> GetByIdAsync(int id)
        {
            var dbSet = _context.Set<T>() ??
                throw new InvalidOperationException($"The DbSet for type '{typeof(T).Name}' could not be found in the context.");

            var entity = await dbSet.FindAsync(id) ??
                throw new KeyNotFoundException($"Entity of type '{typeof(T).Name}' with ID {id} was not found.");

            return entity;
        }
        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            var dbSet = _context.Set<T>() ??
                throw new InvalidOperationException($"The DbSet for type '{typeof(T).Name}' could not be found in the context.");

            var entity = await dbSet.ToListAsync() ??
                throw new KeyNotFoundException($"Entity of type '{typeof(T).Name}' was not found.");

            return entity;
        }

        public async Task<T?> GetEntityWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvalutor<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }
    }
}