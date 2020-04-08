using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HelpingHand.Library.Models;

namespace HelpingHand.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<Organization> Organizations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        base.OnModelCreating(builder);
        builder.Entity<IdentityRole>()
            .HasData(new IdentityRole
            {
                Id = "63f5608d-ee63-47bb-b28a-e19df3176a1e",
                ConcurrencyStamp = "019e9155-bef1-4fe2-ac03-ae6d642dc869",
                Name = "Donor",
                NormalizedName = "DONOR"
            });
        builder.Entity<IdentityRole>()
            .HasData(new IdentityRole
            {
                Id = "ffa519d6-987c-4cf8-82b6-0c648a9d778a",
                ConcurrencyStamp = "9d56beee-fa4f-4cfe-9449-0ada54ce389a",
                Name = "Organization",
                NormalizedName = "ORGANIZATION"
            });
            builder.Entity<IdentityRole>()
                .HasData(new IdentityRole
                {
                    //Id = "",
                    //ConcurrencyStamp = "",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                });

            //builder.Entity<DonorOrganization>()
            //    .HasKey(xy => new { xy.DonorId, xy.OrganizationId });
            //builder.Entity<DonorOrganization>()
            //    .HasOne(xy => xy.Donor)
            //    .WithMany(x => x.DonorOrganizations)
            //    .HasForeignKey(xy => xy.DonorId);
            //builder.Entity<DonorOrganization>()
            //    .HasOne(xy => xy.Organization)
            //    .WithMany(z => z.DonorOrganizations)
            //    .HasForeignKey(xy => xy.OrganizationId);

            builder.Entity<DonorKeyword>()
                .HasKey(xy => new { xy.DonorId, xy.KeywordId });
            builder.Entity<DonorKeyword>()
                .HasOne(xy => xy.Donor)
                .WithMany(x => x.DonorKeywords)
                .HasForeignKey(xy => xy.DonorId);
            builder.Entity<DonorKeyword>()
                .HasOne(xy => xy.Keyword)
                .WithMany(y => y.DonorKeywords)
                .HasForeignKey(xy => xy.KeywordId);

            builder.Entity<OrganizationKeyword>()
                .HasKey(xy => new { xy.OrganizationId, xy.KeywordId });
            builder.Entity<OrganizationKeyword>()
                .HasOne(xy => xy.Organization)
                .WithMany(x => x.OrganizationKeywords)
                .HasForeignKey(xy => xy.OrganizationId);
            builder.Entity<OrganizationKeyword>()
                .HasOne(xy => xy.Keyword)
                .WithMany(y => y.OrganizationKeywords)
                .HasForeignKey(xy => xy.KeywordId);



        }
    }
}