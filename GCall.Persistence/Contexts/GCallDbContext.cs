using GCall.Domain.Entities.Common;
using GCall.Domain.Entities.Definitions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCall.Persistence.Contexts
{
    public class GCallDbContext : DbContext
    {
        public GCallDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            #region Tüm entitylerde ortak değişiklikler
            //ChangeTracker entitiy üzerinde yapılan değişiklikleri yakalar.


            var datas = ChangeTracker.Entries<BaseEntity>(); //tip base entitiy olarak giren tüm modelleri yakala

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }
            #endregion

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
