﻿using LibraryManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
namespace LibraryManager.Infrastructure.Configurations
{
    public class LoanConfigurations : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .HasOne(p => p.Book)
                .WithMany(p => p.Loans)
                .HasForeignKey(p => p.IdBook);

            builder
                .HasOne(p => p.User)
                .WithMany(p => p.Loans)
                .HasForeignKey(p => p.IdUser);
        }
    }
}
