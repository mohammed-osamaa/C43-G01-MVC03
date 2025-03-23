using Demo.DataAccessLayer.Models.DepartmentsModel;

namespace Demo.DataAccessLayer.Data.Configrations
{
    internal class DepartmentConfigration : BaseEntityConfiguration<Department> , IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(D => D.Id).UseIdentityColumn(10,10);
            builder.Property(D => D.Name).HasColumnType("varchar(20)");
            builder.Property(D => D.Code).HasColumnType("varchar(20)");

            // Configure DateTime for CreatedOn (Default Value) , LastModifiedOn (Calculated) in SQl

            //builder.Property(D => D.CreatedOn).HasDefaultValueSql("GETDATE()"); // Not Change , Execute within Insertion only
            //builder.Property(D => D.LastModifiedOn).HasComputedColumnSql("GETDATE()"); // Change once Modified Record
             base.Configure(builder);
        }
    }

}
