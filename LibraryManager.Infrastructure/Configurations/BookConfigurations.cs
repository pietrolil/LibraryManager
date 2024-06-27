using LibraryManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Infrastructure.Configurations
{
    public class BookConfigurations : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .HasOne(p => p.Client)
                .WithOne(u => u.Book)
                .HasForeignKey<Book>(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
