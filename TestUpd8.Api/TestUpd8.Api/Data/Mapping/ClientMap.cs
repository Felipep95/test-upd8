using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TestUpd8.Api.Entities;
using TestUpd8.Api.Enums;

namespace TestUpd8.Api.Data.Mapping
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Clients");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasConversion(x => x.ToString(), x => x)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("varchar(255)");

            builder.Property(x => x.Cpf)
                .HasConversion(x => x.ToString(), x => x)
                .IsRequired()
                .HasColumnName("Cpf")
                .HasColumnType("varchar(14)");

            builder.Property(x => x.Gender)
                .HasConversion(x => x.ToString(), x => (EGender)Enum.Parse(typeof(EGender), x))
                .IsRequired()
                .HasColumnName("Gender");

            builder.Property(x => x.Address)
                .HasConversion(x => x.ToString(), x => x)
                .IsRequired()
                .HasColumnName("Address")
                .HasColumnType("varchar(255)");

            builder.Property(x => x.State)
                .HasConversion(x => x.ToString(), x => x)
                .IsRequired()
                .HasColumnName("State")
                .HasColumnType("varchar(255)");

            builder.Property(x => x.City)
                .HasConversion(x => x.ToString(), x => x)
                .IsRequired()
                .HasColumnName("City")
                .HasColumnType("varchar(255)");

            builder.Property(x => x.BirthDate)
               .IsRequired()
               .HasColumnName("BirthDate")
               .HasColumnType("Datetime");
        }
    }
}
