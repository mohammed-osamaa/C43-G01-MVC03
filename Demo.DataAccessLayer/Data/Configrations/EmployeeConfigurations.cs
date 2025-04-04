using Demo.DataAccessLayer.Models.EmployeesModel;
using Demo.DataAccessLayer.Models.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccessLayer.Data.Configrations
{
    internal class EmployeeConfigurations : BaseEntityConfiguration<Employee> , IEntityTypeConfiguration<Employee>
    {
        public new void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(E => E.Name).IsRequired().HasColumnType("varchar(50)");
            builder.Property(E => E.Address).HasColumnType("varchar(120)");
            builder.Property(E => E.Salary).HasColumnType("decimal(10,2)");
            builder.Property(E => E.Gender).HasConversion((GenderInDB) => GenderInDB.ToString(),
                (GenderInCode) => (Gender)Enum.Parse(typeof(Gender), GenderInCode));
            builder.Property(E => E.EmployeeType).HasConversion((TypeInDB) => TypeInDB.ToString(),
                (TypeInCode) => (EmployeeType)Enum.Parse(typeof(EmployeeType), TypeInCode));

            base.Configure(builder);
        }
    }
}
