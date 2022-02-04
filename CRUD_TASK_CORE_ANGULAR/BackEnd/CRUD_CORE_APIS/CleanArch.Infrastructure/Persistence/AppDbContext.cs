using CleanArch.Application.Common.Interfaces;
using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Infrastructure.Persistence
{
    public class AppDbContext : DbContext , IDbContext
    {
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Governate> Governate { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<AddressInfo> AddressInfo { get; set; }

        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return base.SaveChangesAsync(cancellationToken);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<City>().HasData
                (
                new City() { Id = 1, CityName = "Cairo"},
                new City() { Id = 2, CityName = "Alex" },
                new City() { Id = 3, CityName = "Assuit" }
                );

            modelBuilder.Entity<Governate>().HasData
                (
                new Governate() { Id = 1,  GovName= "Egypt" },
                new Governate() { Id = 2, GovName = "Saudi" },
                new Governate() { Id = 3, GovName = "France" }
                );

            #region ToDo Delete

            //modelBuilder.Entity<AddressInfo>().HasData
            //    (
            //    new AddressInfo() { Id = 1, GovId = 1 , CityId = 1 , BuildingNumber= "19" , Street = "9" },
            //    new AddressInfo() { Id = 2, GovId = 2, CityId = 2, BuildingNumber = "19", Street = "9" },
            //    new AddressInfo() { Id = 3, GovId = 3, CityId = 3, BuildingNumber = "12", Street = "9" },
            //    new AddressInfo() { Id = 4, GovId = 1, CityId = 1, BuildingNumber = "9", Street = "9" }
            //    );

            //modelBuilder.Entity<User>().HasData
            //    (
            //    new User() { 
            //        Id = 1, 
            //        FirstName = "Karim", 
            //        MiddleName = "Alaa" , 
            //        LastName = "Sayed" , 
            //        AddressId = 1 , 
            //        BirthDate = new DateTime(1996,2,5) , 
            //        IsDeleted = false ,
            //        Email = "karimalaa@test.com" ,
            //        MobileNumber = "0101123405940" },
            //    new User()
            //    {
            //        Id = 2,
            //        FirstName = "Karim",
            //        MiddleName = "Alaa",
            //        LastName = "Sayed",
            //        AddressId = 1,
            //        BirthDate = new DateTime(1996, 2, 5),
            //        IsDeleted = false,
            //        Email = "karimalaa@test.com",
            //        MobileNumber = "0101123405940"
            //    },
            //    new User()
            //    {
            //        Id = 3,
            //        FirstName = "Nour",
            //        MiddleName = "Alaa",
            //        LastName = "Sayed",
            //        AddressId = 1,
            //        BirthDate = new DateTime(1996, 2, 5),
            //        IsDeleted = false,
            //        Email = "karimalaa@test.com",
            //        MobileNumber = "0101123405940"
            //    },
            //    new User()
            //    {
            //        Id = 4,
            //        FirstName = "Sondos",
            //        MiddleName = "Alaa",
            //        LastName = "Sayed",
            //        AddressId = 1,
            //        BirthDate = new DateTime(1996, 2, 5),
            //        IsDeleted = false,
            //        Email = "karimalaa@test.com",
            //        MobileNumber = "0101123405940"
            //    },
            //    new User()
            //    {
            //        Id = 5,
            //        FirstName = "Wael",
            //        MiddleName = "Alaa",
            //        LastName = "Sayed",
            //        AddressId = 1,
            //        BirthDate = new DateTime(1996, 2, 5),
            //        IsDeleted = false,
            //        Email = "karimalaa@test.com",
            //        MobileNumber = "0101123405940"
            //    },
            //    new User()
            //    {
            //        Id = 6,
            //        FirstName = "Ehab",
            //        MiddleName = "Alaa",
            //        LastName = "Sayed",
            //        AddressId = 1,
            //        BirthDate = new DateTime(1996, 2, 5),
            //        IsDeleted = false,
            //        Email = "karimalaa@test.com",
            //        MobileNumber = "0101123405940"
            //    });

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {

            var builder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = "Server=DESKTOP-MHB2G7J\\SQL2016;Database=CleanArchDB;User Id=sa;Password=123;Trusted_Connection=True;MultipleActiveResultSets=true";
            builder.UseSqlServer(connectionString);
            return new AppDbContext(builder.Options);
        }
    }
}
