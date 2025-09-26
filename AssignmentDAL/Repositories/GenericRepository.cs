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
    public class GenericRepository<TEntity>(CompanyDbContext dbContext) : IRepository<TEntity> where TEntity :  BaseEntity
    {
        protected DbSet<TEntity> _dbSet = dbContext.Set<TEntity>();

        public virtual int Add(TEntity TEntity)
        {
            _dbSet.Add(TEntity);
            return dbContext.SaveChanges();
        }

        public virtual int Delete(TEntity TEntity)
        {
            TEntity.IsDeleted = true;
            _dbSet.Update(TEntity);
            return dbContext.SaveChanges();
        }

        public virtual IEnumerable<TEntity> GetAll(bool trackChanges = false) =>
             trackChanges ?
                _dbSet.ToList() :
                _dbSet.AsNoTracking()
            .ToList();


        public virtual TEntity GetById(int id)
        {
            _dbSet.Find(id);
            return _dbSet.Find(id);
        }

        public virtual int Update(TEntity TEntity)
        {
            _dbSet.Update(TEntity);
            return dbContext.SaveChanges();
        }
    }
}
