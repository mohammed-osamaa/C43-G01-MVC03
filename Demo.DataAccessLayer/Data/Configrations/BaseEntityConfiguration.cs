using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccessLayer.Data.Configrations
{
    internal class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(T => T.CreatedOn).HasDefaultValueSql("GETDATE()");
            builder.Property(T => T.LastModifiedOn).HasComputedColumnSql("GETDATE()");
        }
    }
}
