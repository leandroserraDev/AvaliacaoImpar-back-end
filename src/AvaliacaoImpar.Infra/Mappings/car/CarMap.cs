using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaliacaoImpar.Domain.Entities.car;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvaliacaoImpar.Infra.Mappings.car
{
    public class CarMap : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Car");

            builder.HasKey(c => c.Id);

            builder.Property(obj => obj.Name)
                .HasMaxLength(35)
                .IsRequired();

            builder.Property(obj => obj.PhotoId)
                .IsRequired();

            builder.HasOne(obj => obj.Photo)
                .WithMany()
                .HasForeignKey(obj => obj.PhotoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
