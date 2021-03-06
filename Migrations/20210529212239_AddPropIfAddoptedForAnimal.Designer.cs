// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjektSchronisko.AppData;

namespace ProjektSchronisko.Migrations
{
    [DbContext(typeof(AnimalsContext))]
    [Migration("20210529212239_AddPropIfAddoptedForAnimal")]
    partial class AddPropIfAddoptedForAnimal
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjektSchronisko.Models.Animal", b =>
                {
                    b.Property<Guid>("IdAnimal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AddDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("AdderId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AgeAnimal")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoPathURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RaceAnimal")
                        .HasColumnType("int");

                    b.Property<int>("TypeAnimale")
                        .HasColumnType("int");

                    b.Property<bool>("ifAdopted")
                        .HasColumnType("bit");

                    b.HasKey("IdAnimal");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("ProjektSchronisko.Models.Conversation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AddDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("User1Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("User2Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Conversations");
                });

            modelBuilder.Entity("ProjektSchronisko.Models.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AddDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ConversationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("From")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MessageU")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("Id");

                    b.HasIndex("ConversationId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("ProjektSchronisko.Models.ReportAnimal", b =>
                {
                    b.Property<Guid>("IdReport")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AddDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("AdderId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnimalName")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("TypeReport")
                        .HasColumnType("int");

                    b.HasKey("IdReport");

                    b.ToTable("ReportAnimal");
                });

            modelBuilder.Entity("ProjektSchronisko.Models.WorkHours", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("To")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("VolonteerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("WorkHours");
                });

            modelBuilder.Entity("ProjektSchronisko.Models.Message", b =>
                {
                    b.HasOne("ProjektSchronisko.Models.Conversation", "Conversation")
                        .WithMany("Messages")
                        .HasForeignKey("ConversationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conversation");
                });

            modelBuilder.Entity("ProjektSchronisko.Models.Conversation", b =>
                {
                    b.Navigation("Messages");
                });
#pragma warning restore 612, 618
        }
    }
}
