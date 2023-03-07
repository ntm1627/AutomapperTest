using AutomapperTest.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutomapperTest
{
    public class ParentConfiguration : IEntityTypeConfiguration<Parent>
    {
        public void Configure(EntityTypeBuilder<Parent> builder)
        {
            _ = builder.HasData
            (
                     new Parent
                     {
                         Id = 1,
                         FirstName = "Nehemiah",
                         LastName = "Alex",
                         PhoneNumber = "111",
                     },
                    new Parent
                    {
                        Id = 2,
                        FirstName = "Eric",
                        LastName = "David",
                        PhoneNumber = "222",
                    },
                    new Parent
                    {
                        Id = 3,
                        FirstName = "Sara",
                        LastName = "Matew",
                        PhoneNumber = "333",
                    }
             );
        }
    }
}