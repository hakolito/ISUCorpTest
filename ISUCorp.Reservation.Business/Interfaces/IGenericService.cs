using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ISUCorp.Reservation.Business.Interfaces
{
    public interface IGenericService<T,DTO>
    {
        IEnumerable<DTO> GetAll();

        Task<DTO> GetById(int id);

        Task<int> Create(DTO entity);

        Task<int> Update(DTO entity);

        Task<int> Delete(int id);
                
    }
}
