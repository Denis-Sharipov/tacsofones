using Microsoft.EntityFrameworkCore;
using TacsofonObj.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace TacsofonObj.InfrastructureServices.Gateways.Database
{
    public class TacsofonObjContext : DbContext
    {
        public DbSet<tacsofonObj> TacsofonObjs { get; set; }

        public TacsofonObjContext(DbContextOptions options)
            : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            FillTestData(modelBuilder);
        }
        private void FillTestData(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<tacsofonObj>().HasData(
                new
                {
                    Id = 1L,
                    Adres = "Вавилова улица, дом 5А",
                    Card = "не действует",
                    Name = "Таксофон № 1449",
                    Oplata = "карта",
                    Platnost = "бесплатно",
                },
                new
                {
                    Id = 2L,
                    Adres = "Вавилова улица, дом 51, Школа №199",
                    Card = "не действует",
                    Name = "Таксофон № 1499",
                    Oplata = "карта",
                    Platnost = "бесплатно",

                },
                new
                {
                    Id = 3L,
                    Adres = "Вавилова улица, дом 6",
                    Card = "действует",
                    Name = "Таксофон № 76",
                    Oplata = "карта",
                    Platnost = "бесплатно",

                },
                new
                {
                    Id = 4L,
                    Adres = "Валдайский проезд, дом 14, Школа №158",
                    Card = "не действует",
                    Name = "Таксофон №1857",
                    Oplata = "карта",
                    Platnost = "бесплатно",

                }
               
            );
        }
    }
}
