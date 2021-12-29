using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Colors.Domain.Common.ModelConstants;

namespace Infrastructure.Persistence.Configurations
{
    internal class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.FirstName)
                .HasMaxLength(NameMaxLength)
                .IsRequired();

            builder
                .Property(c => c.LastName)
                .HasMaxLength(NameMaxLength)
                .IsRequired();

            builder
                .Property(c => c.Zipcode)
                .HasMaxLength(ZipcodeMaxLength)
                .IsRequired();

            builder
                .Property(c => c.City)
                .HasMaxLength(CityMaxLength)
                .IsRequired();

            builder
                .Property(c => c.Id)
                .HasColumnType("int")
                .IsRequired();

        }
    }
}
