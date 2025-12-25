using AssignmentDAL.Context;
using AssignmentDAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentDAL.Repositories
{
    public class GenericRepository<TEntity>(CompanyDbContext dbContext) : IRepository<TEntity > where TEntity :  BaseEntity
    {
        protected DbSet<TEntity> _dbSet = dbContext.Set<TEntity>();

        public virtual void Add(TEntity TEntity)
        {
            _dbSet.Add(TEntity);
           
        }

        public virtual void Delete(TEntity TEntity)
        {
            TEntity.IsDeleted = true;
            _dbSet.Update(TEntity);
          
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(bool trackChanges = false) =>
             trackChanges ?
               await _dbSet 
            .Where(x=>!x.IsDeleted)
            .ToListAsync() :
               await _dbSet
            .AsNoTracking()
            .Where(x => !x.IsDeleted)
            .ToListAsync();


        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            await _dbSet.FindAsync(id);
            return await _dbSet.FindAsync(id);
        }

        public virtual void Update(TEntity TEntity)
        {
            _dbSet.Update(TEntity);
           
        }
    }
}
