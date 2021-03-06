﻿// <auto-generated />
using System;
using MeetGroup.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MeetGroup.Data.Migrations
{
    [DbContext(typeof(MeetGroupDbContext))]
    [Migration("20201206012002_AddSala")]
    partial class AddSala
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("MeetGroup.Business.Models.Sala", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<int>("Capacidade")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("PossuiAcessoAInternet")
                        .HasColumnType("boolean");

                    b.Property<bool>("PossuiComputador")
                        .HasColumnType("boolean");

                    b.Property<bool>("PossuiTV")
                        .HasColumnType("boolean");

                    b.Property<bool>("PossuiWebCam")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Salas");
                });
#pragma warning restore 612, 618
        }
    }
}
