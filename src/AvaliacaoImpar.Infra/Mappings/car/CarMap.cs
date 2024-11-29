using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaliacaoImpar.Domain.Entities.car;
using AvaliacaoImpar.Domain.Entities.photo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvaliacaoImpar.Infra.Mappings.car
{
    public class CarMap : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.ToTable("Car");

            builder.HasKey(c => c.Id);

            builder.Property(obj => obj.Name)
                .HasMaxLength(35)
                .IsRequired();

            builder.HasOne(obj => obj.Photo)
                .WithOne(obj => obj.Card)
                .HasForeignKey<Photo>(obj => obj.IdCard)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
