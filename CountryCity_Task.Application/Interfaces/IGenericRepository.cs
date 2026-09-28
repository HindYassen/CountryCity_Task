using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CountryCity_Task.Application.Interfaces
{

    public interface IGenericRepository<T> where T : class
    {
        Task CreateAsync(T entity);

        Task<T?> GetByIdAsync(int id);

        void Update(T entity);

        void Delete(T entity);
    }
}
