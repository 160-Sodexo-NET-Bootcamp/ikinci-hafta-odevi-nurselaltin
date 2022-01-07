﻿// <auto-generated />
using DataAcces.Concrete.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(ProjectContext))]
    partial class ProjectContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Entity.Concrete.Container", b =>
                {
                    b.Property<int>("ContainerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ContainerName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(10,6)");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal(10,6)");

                    b.Property<long>("VehicleID")
                        .HasColumnType("bigint");

                    b.HasKey("ContainerID");

                    b.HasIndex("VehicleID");

                    b.ToTable("Container");
                });

            modelBuilder.Entity("Entity.Concrete.Vehicle", b =>
                {
                    b.Property<long>("VehicleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

                    b.Property<string>("VehicleName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("VehiclePlate")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("VehicleID");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("Entity.Concrete.Container", b =>
                {
                    b.HasOne("Entity.Concrete.Vehicle", "Vehicle")
                        .WithMany("Containers")
                        .HasForeignKey("VehicleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Entity.Concrete.Vehicle", b =>
                {
                    b.Navigation("Containers");
                });
#pragma warning restore 612, 618
        }
    }
}
