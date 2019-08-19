﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TMP2019.Data;

namespace TMP2019.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190816060149_InvoiceRowsAdded")]
    partial class InvoiceRowsAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TMP2019.Models.DataModels.AccountingModels.DataModels.AccountsToPerson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BankAccount");

                    b.Property<string>("BankName");

                    b.Property<int?>("PersonId");

                    b.Property<string>("SwishNumber");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("AccountsToPerson");
                });

            modelBuilder.Entity("TMP2019.Models.DataModels.AccountingModels.DataModels.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArticleDescription");

                    b.Property<double>("ArticlePrice");

                    b.HasKey("Id");

                    b.ToTable("Article");
                });

            modelBuilder.Entity("TMP2019.Models.DataModels.AccountingModels.DataModels.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompanyId");

                    b.Property<int?>("CompanyId1");

                    b.Property<string>("InvoceFooter");

                    b.Property<string>("InvoceHeader");

                    b.Property<DateTime>("InvoiceDate");

                    b.Property<int?>("InvoiceRowId");

                    b.Property<int?>("InvoiceRowId1");

                    b.Property<int?>("InvoiceRowId2");

                    b.Property<int?>("InvoiceRowId3");

                    b.Property<int?>("InvoiceRowId4");

                    b.Property<int?>("InvoiceRowId5");

                    b.Property<int?>("InvoiceRowId6");

                    b.Property<int?>("InvoiceRowId7");

                    b.Property<int?>("InvoiceRowId8");

                    b.Property<int?>("InvoiceRowId9");

                    b.Property<DateTime>("Maturity");

                    b.Property<string>("PaymentTerms");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CompanyId1");

                    b.HasIndex("InvoiceRowId");

                    b.HasIndex("InvoiceRowId1");

                    b.HasIndex("InvoiceRowId2");

                    b.HasIndex("InvoiceRowId3");

                    b.HasIndex("InvoiceRowId4");

                    b.HasIndex("InvoiceRowId5");

                    b.HasIndex("InvoiceRowId6");

                    b.HasIndex("InvoiceRowId7");

                    b.HasIndex("InvoiceRowId8");

                    b.HasIndex("InvoiceRowId9");

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("TMP2019.Models.DataModels.AccountingModels.DataModels.InvoiceRow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArticleId");

                    b.Property<double>("ArticlePrice");

                    b.Property<double>("Quantity");

                    b.Property<double>("RowTotal");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.ToTable("InvoiceRow");
                });

            modelBuilder.Entity("TMP2019.Models.DataModels.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActivityDescription");

                    b.Property<string>("ActivityName");

                    b.Property<int?>("ActivityTypeId");

                    b.Property<int?>("ArenaId");

                    b.Property<int?>("CampId");

                    b.Property<DateTime>("EndDateTime");

                    b.Property<DateTime>("StartDateTime");

                    b.HasKey("Id");

                    b.HasIndex("ActivityTypeId");

                    b.HasIndex("ArenaId");

                    b.HasIndex("CampId");

                    b.ToTable("Activity");
                });

            modelBuilder.Entity("TMP2019.Models.DataModels.ActivityType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActivityTypeName");

                    b.HasKey("Id");

                    b.ToTable("ActivityType");
                });

            modelBuilder.Entity("TMP2019.Models.DataModels.Arena", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArenaName");

                    b.HasKey("Id");

                    b.ToTable("Arena");
                });

            modelBuilder.Entity("TMP2019.Models.DataModels.Camp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArenaId");

                    b.Property<string>("CampDescription");

                    b.Property<string>("CampName");

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("ArenaId");

                    b.ToTable("Camp");
                });

            modelBuilder.Entity("TMP2019.Models.DataModels.Club", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClubName");

                    b.Property<int?>("DistrictId");

                    b.HasKey("Id");

                    b.HasIndex("DistrictId");

                    b.ToTable("Club");
                });

            modelBuilder.Entity("TMP2019.Models.DataModels.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName");

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("TMP2019.Models.DataModels.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DistrictName");

                    b.HasKey("Id");

                    b.ToTable("District");
                });

            modelBuilder.Entity("TMP2019.Models.DataModels.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArenaId");

                    b.Property<int?>("AwayTeamScore");

                    b.Property<int?>("HomeTeamScore");

                    b.Property<int?>("MatchCategoryId");

                    b.Property<DateTime>("MatchDateTime");

                    b.Property<string>("MatchNumber");

                    b.Property<int?>("PersonId");

                    b.Property<int?>("PersonId1");

                    b.Property<int?>("PersonId2");

                    b.Property<int?>("PersonId3");

                    b.Property<int?>("TeamId");

                    b.Property<int?>("TeamId1");

                    b.Property<int?>("TournamentId");

                    b.HasKey("Id");

                    b.HasIndex("ArenaId");

                    b.HasIndex("MatchCategoryId");

                    b.HasIndex("PersonId");

                    b.HasIndex("PersonId1");

                    b.HasIndex("PersonId2");

                    b.HasIndex("PersonId3");

                    b.HasIndex("TeamId");

                    b.HasIndex("TeamId1");

                    b.HasIndex("TournamentId");

                    b.ToTable("Match");
                });

            modelBuilder.Entity("TMP2019.Models.DataModels.MatchCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MatchCategoryName");

                    b.HasKey("Id");

                    b.ToTable("MatchCategory");
                });

            modelBuilder.Entity("TMP2019.Models.DataModels.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ActivityId");

                    b.Property<string>("BankAccount");

                    b.Property<string>("BankName");

                    b.Property<int?>("CampId");

                    b.Property<string>("City");

                    b.Property<int?>("ClubId");

                    b.Property<int?>("CompanyId");

                    b.Property<string>("Country");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int?>("PersonTypeId");

                    b.Property<string>("PhoneNumber1");

                    b.Property<string>("PhoneNumber2");

                    b.Property<string>("Ssn");

                    b.Property<string>("StreetAddress");

                    b.Property<string>("SwishNumber");

                    b.Property<int?>("TeamId");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.HasIndex("ActivityId");

                    b.HasIndex("CampId");

                    b.HasIndex("ClubId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("PersonTypeId");

                    b.HasIndex("TeamId");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("TMP2019.Models.DataModels.PersonType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PersonTypeName");

                    b.HasKey("Id");

                    b.ToTable("PersonType");
                });

            modelBuilder.Entity("TMP2019.Models.DataModels.Receipt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GameTotalKost");

                    b.Property<int>("HD1Alowens");

                    b.Property<int>("HD1Fee");

                    b.Property<int>("HD1LateGameKost");

                    b.Property<int>("HD1TotalFee");

                    b.Property<int>("HD1TravelKost");

                    b.Property<int>("HD2Alowens");

                    b.Property<int>("HD2Fee");

                    b.Property<int>("HD2LateGameKost");

                    b.Property<int>("HD2TotalFee");

                    b.Property<int>("HD2TravelKost");

                    b.Property<int>("LD1Alowens");

                    b.Property<int>("LD1Fee");

                    b.Property<int>("LD1LateGameKost");

                    b.Property<int>("LD1TotalFee");

                    b.Property<int>("LD1TravelKost");

                    b.Property<int>("LD2Alowens");

                    b.Property<int>("LD2Fee");

                    b.Property<int>("LD2LateGameKost");

                    b.Property<int>("LD2TotalFee");

                    b.Property<int>("LD2TravelKost");

                    b.Property<int?>("MatchId");

                    b.Property<int?>("PersonId");

                    b.Property<int?>("PersonId1");

                    b.Property<int?>("PersonId2");

                    b.Property<int?>("PersonId3");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.HasIndex("PersonId");

                    b.HasIndex("PersonId1");

                    b.HasIndex("PersonId2");

                    b.HasIndex("PersonId3");

                    b.ToTable("Receipt");
                });

            modelBuilder.Entity("TMP2019.Models.DataModels.TMPHockeyModels.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArenaId");

                    b.Property<int?>("AwayTeamScore");

                    b.Property<int?>("GameCategoryId");

                    b.Property<DateTime>("GameDateTime");

                    b.Property<string>("GameNumber");

                    b.Property<int?>("GameStatusId");

                    b.Property<int?>("HomeTeamScore");

                    b.Property<int?>("PersonId");

                    b.Property<int?>("PersonId1");

                    b.Property<int?>("PersonId2");

                    b.Property<int?>("PersonId3");

                    b.Property<string>("TSMNumber");

                    b.Property<int?>("TeamId");

                    b.Property<int?>("TeamId1");

                    b.HasKey("Id");

                    b.HasIndex("ArenaId");

                    b.HasIndex("GameCategoryId");

                    b.HasIndex("GameStatusId");

                    b.HasIndex("PersonId");

                    b.HasIndex("PersonId1");

                    b.HasIndex("PersonId2");

                    b.HasIndex("PersonId3");

                    b.HasIndex("TeamId");

                    b.HasIndex("TeamId1");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("TMP2019.Models.DataModels.TMPHockeyModels.GameCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GameCategoryName");

                    b.HasKey("Id");

                    b.ToTable("GameCategory");
                });

            modelBuilder.Entity("TMP2019.Models.DataModels.TMPHockeyModels.GameReceipt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GameId");

                    b.Property<int>("GameTotalKost");

                    b.Property<int>("HD1Alowens");

                    b.Property<int>("HD1Fee");

                    b.Property<int>("HD1LateGameKost");

                    b.Property<int>("HD1TotalFee");

                    b.Property<int>("HD1TravelKost");

                    b.Property<int>("HD2Alowens");

                    b.Property<int>("HD2Fee");

                    b.Property<int>("HD2LateGameKost");

                    b.Property<int>("HD2TotalFee");

                    b.Property<int>("HD2TravelKost");

                    b.Property<int>("LD1Alowens");

                    b.Property<int>("LD1Fee");

                    b.Property<int>("LD1LateGameKost");

                    b.Property<int>("LD1TotalFee");

                    b.Property<int>("LD1TravelKost");

                    b.Property<int>("LD2Alowens");

                    b.Property<int>("LD2Fee");

                    b.Property<int>("LD2LateGameKost");

                    b.Property<int>("LD2TotalFee");

                    b.Property<int>("LD2TravelKost");

                    b.Property<int?>("PersonId");

                    b.Property<int?>("PersonId1");

                    b.Property<int?>("PersonId2");

                    b.Property<int?>("PersonId3");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PersonId");

                    b.HasIndex("PersonId1");

                    b.HasIndex("PersonId2");

                    b.HasIndex("PersonId3");

                    b.ToTable("GameReceipt");
                });

            modelBuilder.Entity("TMP2019.Models.DataModels.TMPHockeyModels.GameStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GameStatusName");

                    b.HasKey("Id");

                    b.ToTable("GameStatus");
                });

            modelBuilder.Entity("TMP2019.Models.DataModels.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TeamName");

                    b.Property<int?>("TournamentId");

                    b.HasKey("Id");

                    b.HasIndex("TournamentId");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("TMP2019.Models.DataModels.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArenaId");

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("TournamentDescription");

                    b.Property<string>("TournamentName");

                    b.HasKey("Id");

                    b.HasIndex("ArenaId");

                    b.ToTable("Tournament");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TMP2019.Models.DataModels.AccountingModels.DataModels.AccountsToPerson", b =>
                {
                    b.HasOne("TMP2019.Models.DataModels.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("TMP2019.Models.DataModels.AccountingModels.DataModels.Invoice", b =>
                {
                    b.HasOne("TMP2019.Models.DataModels.Company", "Customer")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("TMP2019.Models.DataModels.Company", "Supplier")
                        .WithMany()
                        .HasForeignKey("CompanyId1");

                    b.HasOne("TMP2019.Models.DataModels.AccountingModels.DataModels.InvoiceRow", "Row1")
                        .WithMany()
                        .HasForeignKey("InvoiceRowId");

                    b.HasOne("TMP2019.Models.DataModels.AccountingModels.DataModels.InvoiceRow", "Row2")
                        .WithMany()
                        .HasForeignKey("InvoiceRowId1");

                    b.HasOne("TMP2019.Models.DataModels.AccountingModels.DataModels.InvoiceRow", "Row3")
                        .WithMany()
                        .HasForeignKey("InvoiceRowId2");

                    b.HasOne("TMP2019.Models.DataModels.AccountingModels.DataModels.InvoiceRow", "Row4")
                        .WithMany()
                        .HasForeignKey("InvoiceRowId3");

                    b.HasOne("TMP2019.Models.DataModels.AccountingModels.DataModels.InvoiceRow", "Row5")
                        .WithMany()
                        .HasForeignKey("InvoiceRowId4");

                    b.HasOne("TMP2019.Models.DataModels.AccountingModels.DataModels.InvoiceRow", "Row6")
                        .WithMany()
                        .HasForeignKey("InvoiceRowId5");

                    b.HasOne("TMP2019.Models.DataModels.AccountingModels.DataModels.InvoiceRow", "Row7")
                        .WithMany()
                        .HasForeignKey("InvoiceRowId6");

                    b.HasOne("TMP2019.Models.DataModels.AccountingModels.DataModels.InvoiceRow", "Row8")
                        .WithMany()
                        .HasForeignKey("InvoiceRowId7");

                    b.HasOne("TMP2019.Models.DataModels.AccountingModels.DataModels.InvoiceRow", "Row9")
                        .WithMany()
                        .HasForeignKey("InvoiceRowId8");

                    b.HasOne("TMP2019.Models.DataModels.AccountingModels.DataModels.InvoiceRow", "Row10")
                        .WithMany()
                        .HasForeignKey("InvoiceRowId9");
                });

            modelBuilder.Entity("TMP2019.Models.DataModels.AccountingModels.DataModels.InvoiceRow", b =>
                {
                    b.HasOne("TMP2019.Models.DataModels.AccountingModels.DataModels.Article", "Article")
                        .WithMany()
                        .HasForeignKey("ArticleId");
                });

            modelBuilder.Entity("TMP2019.Models.DataModels.Activity", b =>
                {
                    b.HasOne("TMP2019.Models.DataModels.ActivityType", "ActivityType")
                        .WithMany()
                        .HasForeignKey("ActivityTypeId");

                    b.HasOne("TMP2019.Models.DataModels.Arena", "Arena")
                        .WithMany()
                        .HasForeignKey("ArenaId");

                    b.HasOne("TMP2019.Models.DataModels.Camp")
                        .WithMany("Activities")
                        .HasForeignKey("CampId");
                });

            modelBuilder.Entity("TMP2019.Models.DataModels.Camp", b =>
                {
                    b.HasOne("TMP2019.Models.DataModels.Arena", "Arena")
                        .WithMany()
                        .HasForeignKey("ArenaId");
                });

            modelBuilder.Entity("TMP2019.Models.DataModels.Club", b =>
                {
                    b.HasOne("TMP2019.Models.DataModels.District", "District")
                        .WithMany()
                        .HasForeignKey("DistrictId");
                });

            modelBuilder.Entity("TMP2019.Models.DataModels.Match", b =>
                {
                    b.HasOne("TMP2019.Models.DataModels.Arena", "Arena")
                        .WithMany()
                        .HasForeignKey("ArenaId");

                    b.HasOne("TMP2019.Models.DataModels.MatchCategory", "MatchCategory")
                        .WithMany()
                        .HasForeignKey("MatchCategoryId");

                    b.HasOne("TMP2019.Models.DataModels.Person", "HD1")
                        .WithMany()
                        .HasForeignKey("PersonId");

                    b.HasOne("TMP2019.Models.DataModels.Person", "HD2")
                        .WithMany()
                        .HasForeignKey("PersonId1");

                    b.HasOne("TMP2019.Models.DataModels.Person", "LD1")
                        .WithMany()
                        .HasForeignKey("PersonId2");

                    b.HasOne("TMP2019.Models.DataModels.Person", "LD2")
                        .WithMany()
                        .HasForeignKey("PersonId3");

                    b.HasOne("TMP2019.Models.DataModels.Team", "HomeTeam")
                        .WithMany()
                        .HasForeignKey("TeamId");

                    b.HasOne("TMP2019.Models.DataModels.Team", "AwayTeam")
                        .WithMany()
                        .HasForeignKey("TeamId1");

                    b.HasOne("TMP2019.Models.DataModels.Tournament")
                        .WithMany("Matches")
                        .HasForeignKey("TournamentId");
                });

            modelBuilder.Entity("TMP2019.Models.DataModels.Person", b =>
                {
                    b.HasOne("TMP2019.Models.DataModels.Activity")
                        .WithMany("People")
                        .HasForeignKey("ActivityId");

                    b.HasOne("TMP2019.Models.DataModels.Camp")
                        .WithMany("People")
                        .HasForeignKey("CampId");

                    b.HasOne("TMP2019.Models.DataModels.Club", "Club")
                        .WithMany()
                        .HasForeignKey("ClubId");

                    b.HasOne("TMP2019.Models.DataModels.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("TMP2019.Models.DataModels.PersonType", "PersonType")
                        .WithMany()
                        .HasForeignKey("PersonTypeId");

                    b.HasOne("TMP2019.Models.DataModels.Team")
                        .WithMany("People")
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("TMP2019.Models.DataModels.Receipt", b =>
                {
                    b.HasOne("TMP2019.Models.DataModels.Match", "Match")
                        .WithMany()
                        .HasForeignKey("MatchId");

                    b.HasOne("TMP2019.Models.DataModels.Person", "HD1")
                        .WithMany()
                        .HasForeignKey("PersonId");

                    b.HasOne("TMP2019.Models.DataModels.Person", "HD2")
                        .WithMany()
                        .HasForeignKey("PersonId1");

                    b.HasOne("TMP2019.Models.DataModels.Person", "LD1")
                        .WithMany()
                        .HasForeignKey("PersonId2");

                    b.HasOne("TMP2019.Models.DataModels.Person", "LD2")
                        .WithMany()
                        .HasForeignKey("PersonId3");
                });

            modelBuilder.Entity("TMP2019.Models.DataModels.TMPHockeyModels.Game", b =>
                {
                    b.HasOne("TMP2019.Models.DataModels.Arena", "Arena")
                        .WithMany()
                        .HasForeignKey("ArenaId");

                    b.HasOne("TMP2019.Models.DataModels.TMPHockeyModels.GameCategory", "GameCategory")
                        .WithMany()
                        .HasForeignKey("GameCategoryId");

                    b.HasOne("TMP2019.Models.DataModels.TMPHockeyModels.GameStatus", "GameStatus")
                        .WithMany()
                        .HasForeignKey("GameStatusId");

                    b.HasOne("TMP2019.Models.DataModels.Person", "HD1")
                        .WithMany()
                        .HasForeignKey("PersonId");

                    b.HasOne("TMP2019.Models.DataModels.Person", "HD2")
                        .WithMany()
                        .HasForeignKey("PersonId1");

                    b.HasOne("TMP2019.Models.DataModels.Person", "LD1")
                        .WithMany()
                        .HasForeignKey("PersonId2");

                    b.HasOne("TMP2019.Models.DataModels.Person", "LD2")
                        .WithMany()
                        .HasForeignKey("PersonId3");

                    b.HasOne("TMP2019.Models.DataModels.Team", "HomeTeam")
                        .WithMany()
                        .HasForeignKey("TeamId");

                    b.HasOne("TMP2019.Models.DataModels.Team", "AwayTeam")
                        .WithMany()
                        .HasForeignKey("TeamId1");
                });

            modelBuilder.Entity("TMP2019.Models.DataModels.TMPHockeyModels.GameReceipt", b =>
                {
                    b.HasOne("TMP2019.Models.DataModels.TMPHockeyModels.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId");

                    b.HasOne("TMP2019.Models.DataModels.Person", "HD1")
                        .WithMany()
                        .HasForeignKey("PersonId");

                    b.HasOne("TMP2019.Models.DataModels.Person", "HD2")
                        .WithMany()
                        .HasForeignKey("PersonId1");

                    b.HasOne("TMP2019.Models.DataModels.Person", "LD1")
                        .WithMany()
                        .HasForeignKey("PersonId2");

                    b.HasOne("TMP2019.Models.DataModels.Person", "LD2")
                        .WithMany()
                        .HasForeignKey("PersonId3");
                });

            modelBuilder.Entity("TMP2019.Models.DataModels.Team", b =>
                {
                    b.HasOne("TMP2019.Models.DataModels.Tournament")
                        .WithMany("Teams")
                        .HasForeignKey("TournamentId");
                });

            modelBuilder.Entity("TMP2019.Models.DataModels.Tournament", b =>
                {
                    b.HasOne("TMP2019.Models.DataModels.Arena", "Arena")
                        .WithMany()
                        .HasForeignKey("ArenaId");
                });
#pragma warning restore 612, 618
        }
    }
}
