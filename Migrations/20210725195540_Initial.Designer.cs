﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using pgsql_poc;

namespace pgsql_poc.Migrations
{
    [DbContext(typeof(PocContext))]
    [Migration("20210725195540_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("pgsql_poc.Intermediate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("RecordType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("RootId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RootId");

                    b.ToTable("Intermediate");
                });

            modelBuilder.Entity("pgsql_poc.IntermediateToLeaf", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Effective")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("IntermediateId")
                        .HasColumnType("integer");

                    b.Property<int>("LeafId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("IntermediateId");

                    b.HasIndex("LeafId");

                    b.ToTable("IntermediateToLeaf");
                });

            modelBuilder.Entity("pgsql_poc.Leaf", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Details")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Leaf");
                });

            modelBuilder.Entity("pgsql_poc.Root", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.HasKey("Id");

                    b.ToTable("Root");
                });

            modelBuilder.Entity("pgsql_poc.RootToLeaf", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Effective")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("LeafId")
                        .HasColumnType("integer");

                    b.Property<int>("RootId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("LeafId");

                    b.HasIndex("RootId");

                    b.ToTable("RootToLeaf");
                });

            modelBuilder.Entity("pgsql_poc.Intermediate", b =>
                {
                    b.HasOne("pgsql_poc.Root", "Root")
                        .WithMany("Intermediates")
                        .HasForeignKey("RootId");
                });

            modelBuilder.Entity("pgsql_poc.IntermediateToLeaf", b =>
                {
                    b.HasOne("pgsql_poc.Intermediate", "Intermediate")
                        .WithMany("LeafLinks")
                        .HasForeignKey("IntermediateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("pgsql_poc.Leaf", "Leaf")
                        .WithMany()
                        .HasForeignKey("LeafId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("pgsql_poc.RootToLeaf", b =>
                {
                    b.HasOne("pgsql_poc.Leaf", "Leaf")
                        .WithMany()
                        .HasForeignKey("LeafId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("pgsql_poc.Root", "Root")
                        .WithMany("LeafLinks")
                        .HasForeignKey("RootId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
