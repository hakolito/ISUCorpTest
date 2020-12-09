using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ISUCorp.Reservation.Data.Interfaces.Framework
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

        Task<TEntity> GetById(int id);

        Task<int> Create(TEntity entity);

        Task<int> Update(TEntity entity);

        Task<int> Delete(int id);

        IEnumerable<TEntity> Filter(Func<TEntity, bool> predicate);

        IEnumerable<TEntity> Where(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

       
    }
}
