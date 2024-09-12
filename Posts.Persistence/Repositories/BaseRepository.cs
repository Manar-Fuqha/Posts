using Microsoft.EntityFrameworkCore;
using Posts.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posts.Persistence.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        private readonly PostDBContext dBContext;

        public BaseRepository(PostDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await dBContext.Set<T>().AddAsync(entity);
            await dBContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            dBContext.Set<T>().Remove(entity);
            await dBContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await dBContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await dBContext.Set<T>().ToListAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
           dBContext.Set<T>().Update(entity);
            await dBContext.SaveChangesAsync();
            return entity;
        }
    }
}
