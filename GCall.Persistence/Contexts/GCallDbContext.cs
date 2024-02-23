using GCall.Domain.Entities.Common;
using GCall.Domain.Entities.Definitions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GCall.Persistence.Contexts
{
    public class GCallDbContext : DbContext
    {
        public GCallDbContext(DbContextOptions options) : base(options)
        {
        }

        #region Definitions
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Company> Companies { get; set; }
        #endregion

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            #region Tüm entitylerde ortak değişiklikler
            //ChangeTracker entitiy üzerinde yapılan değişiklikleri yakalar.


            var datas = ChangeTracker.Entries<BaseEntity>(); //tip base entitiy olarak giren tüm modelleri yakala

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    //TODO: Id added esnasında eklenecek.
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
