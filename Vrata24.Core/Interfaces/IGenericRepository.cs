using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vrata24.Core.Entities;
using Vrata24.Core.Specifications;

namespace Vrata24.Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
        Task<int> CountAsync(ISpecification<T> spec);
    }
}