using GCall.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCall.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model);

        Task<bool> AddRangeAsync(List<T> datas);

        bool Remove(T model);

        bool SoftDelete(T model);

        bool RemoveRange(List<T> datas);

        bool SoftDeleteRange(List<T> datas);

        Task<bool> RemoveAsync(string id);

        Task<bool> SoftDeleteAsync(string id);

        bool Update(T model);

        bool UpdateRange(List<T> model);

        Task<int> SaveAsync();
    }
}
