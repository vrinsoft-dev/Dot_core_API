using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace SafiCodeAPI.Modal.Modal
{
    public partial class SafiCodeContext : DbContext
    {

       
        public SafiCodeContext()
        {
        }

        public SafiCodeContext(DbContextOptions<SafiCodeContext> options)
            : base(options)
        {

        }

        public virtual DbSet<TblUserContacts> TblUserContacts { get; set; }
        public virtual DbSet<TblUsers> TblUsers { get; set; }
        public virtual DbSet<TblUserType> TblUserType { get; set; }


        

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer(configuration.GetConnectionString("SQLConnection").ToString());
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblUserContacts>(entity =>
            {
                entity.HasKey(e => e.UserContactId);

                entity.ToTable("Tbl_User_Contacts");

                entity.Property(e => e.UserContactId).HasColumnName("UserContactID");

                entity.Property(e => e.CompanyName).HasMaxLength(250);

                entity.Property(e => e.ContactName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasColumnName("EmailID")
                    .HasMaxLength(250);

                entity.Property(e => e.MainPhone).HasMaxLength(20);

                entity.Property(e => e.MobilePhone).HasMaxLength(20);

                entity.Property(e => e.ModifyDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<TblUsers>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("tbl_Users");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Area).HasMaxLength(300);

                entity.Property(e => e.City).HasMaxLength(200);

                entity.Property(e => e.CompanyName).HasMaxLength(400);

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CurrencyName).HasMaxLength(200);

                entity.Property(e => e.EmailId)
                    .HasColumnName("EmailID")
                    .HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(400);

                entity.Property(e => e.HouseOfficeNo).HasMaxLength(200);

                entity.Property(e => e.Industry).HasMaxLength(500);

                entity.Property(e => e.IstermsCondition).HasColumnName("ISTermsCondition");

                entity.Property(e => e.MobileNumber).HasMaxLength(20);

                entity.Property(e => e.ModifyDate).HasColumnType("datetime");

                entity.Property(e => e.Password).HasMaxLength(200);

                entity.Property(e => e.StateProvince).HasMaxLength(200);

                entity.Property(e => e.UserTypeId).HasColumnName("UserTypeID");

                entity.Property(e => e.Zip).HasMaxLength(20);

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.TblUsers)
                    .HasForeignKey(d => d.UserTypeId)
                    .HasConstraintName("FK_tbl_Users_tbl_Users");
            });

            modelBuilder.Entity<TblUserType>(entity =>
            {
                entity.HasKey(e => e.UserTypeId);

                entity.ToTable("tbl_UserType");

                entity.Property(e => e.UserTypeId).HasColumnName("UserTypeID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserType).HasMaxLength(200);
            });
        }
    }
}
