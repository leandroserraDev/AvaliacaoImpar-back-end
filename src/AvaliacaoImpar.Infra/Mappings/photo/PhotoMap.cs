using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaliacaoImpar.Domain.Entities.photo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvaliacaoImpar.Infra.Mappings.photo
{
    public class PhotoMap : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.ToTable("Photo");

            builder.HasKey(obj => obj.Id);

            builder.Property(obj => obj.Base64)
                .IsRequired()
                .HasColumnType("NVARCHAR(MAX)");

                
        }
    }
}
