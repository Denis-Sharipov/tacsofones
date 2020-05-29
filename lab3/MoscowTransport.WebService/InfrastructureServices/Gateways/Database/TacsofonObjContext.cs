using Microsoft.EntityFrameworkCore;
using TacsofonObj.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace TacsofonObj.InfrastructureServices.Gateways.Database
{
    public class TacsofonObjContext : DbContext
    {
        public DbSet<DomainObjects.TacsofonObj> TacsofonObjs { get; set; }


        public TacsofonObjContext(DbContextOptions options)
            : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DomainObjects.TacsofonObj>().HasData(
              new DomainObjects.TacsofonObj()
              {
                  Id = 1L,
                  Name = "Таксофон №1449",
                  Adres = "Вавилова улица, дом 5А",
                  Oplata = "карта",
                  Platnost = "бесплатно",
                  Card = "не действует"
              }
           );
        }      
    }
}
