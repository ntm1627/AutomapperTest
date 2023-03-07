using AutomapperTest.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutomapperTest
{
    public class ChildConfiguration : IEntityTypeConfiguration<Child>
    {
        public void Configure(EntityTypeBuilder<Child> builder)
        {
            _ = builder.HasData
            (
                     new Child
                     {
                         Id = 1,
                         FirstName = "Luke",
                         LastName = "Alex",
                         SchoolName = "S1",
                     },
                    new Child
                    {
                        Id = 2,
                        FirstName = "Eric",
                        LastName = "David",
                        SchoolName = "S2",
                    },
                    new Child
                    {
                        Id = 3,
                        FirstName = "Sara",
                        LastName = "Matew",
                        SchoolName = "S3",
                    }
             );
        }
    }
}