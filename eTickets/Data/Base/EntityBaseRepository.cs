﻿
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace eTickets.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly ApplicationDbContext _context;
        public EntityBaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = await _context.Set<T>().ToListAsync();
            return result;
        }
        public async Task AddAsync(T entity)
        {
           await _context.Set<T>().AddAsync(entity);
           await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(p => p.Id == id);
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;

			await _context.SaveChangesAsync();
		}


        public async Task<T> GetByIdAsync(int id)
        {
            var result = await _context.Set<T>().FirstOrDefaultAsync(m => m.Id == id);
            try
            {
                if (result != null)
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return result;

        }

        public async Task UpdateAsync(int id, T entity)
        {
           EntityEntry entityEntry = _context.Entry<T>(entity);
           entityEntry.State = EntityState.Modified;

			await _context.SaveChangesAsync(); 
            
            
        }

		public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeproperty)
		{
            IQueryable<T> query = _context.Set<T>();
            query = includeproperty.Aggregate(query, (current, includeproperty) => current.Include(includeproperty));
            return await query.ToListAsync();

		}
	}
}
