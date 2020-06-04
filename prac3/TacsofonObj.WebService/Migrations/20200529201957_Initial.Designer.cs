﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TacsofonObj.InfrastructureServices.Gateways.Database;

namespace TacsofonObj.WebService.Migrations
{
    [DbContext(typeof(TacsofonObjContext))]
    [Migration("20200529201957_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("TacsofonObj.DomainObjects.tacsofonObj", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Adres")
                        .HasColumnType("TEXT");

                    b.Property<string>("Oplata")
                        .HasColumnType("TEXT");

                    b.Property<string>("Platnost")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Card")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TacsofonObj");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Adres = "Вавилова улица, дом 5А",
                            Platnost = "бесплатно",
                            Oplata = "карта",
                            Name = "Таксофон № 1449",
                            Card = "не действует",
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

                            
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
