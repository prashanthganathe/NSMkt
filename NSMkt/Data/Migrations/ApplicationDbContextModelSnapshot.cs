﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NSMkt.Data;

#nullable disable

namespace NSMkt.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Identity")
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Role", "Identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims", "Identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims", "Identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins", "Identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles", "Identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens", "Identity");
                });

            modelBuilder.Entity("NSMkt.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<byte[]>("ProfilePicture")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("UsernameChangeLimit")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("User", "Identity");
                });

            modelBuilder.Entity("NSMkt.Models.OptionChainStockSummary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("CECOIDiffPer")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CECount")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("High")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("IsDoji")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsTop50")
                        .HasColumnType("bit");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Low")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Open")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PECOIDiffPer")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PECount")
                        .HasColumnType("int");

                    b.Property<decimal>("Res1")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Res2")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SummaryJson")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Sup1")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Sup2")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TurnOver")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("analysisTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("cecoi")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ceiv")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("celtp")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("celtpchange")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ceoi")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("cevolume")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("expiry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("expiryType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("futureprice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("group")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("indexprice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("isResOIStrong")
                        .HasColumnType("bit");

                    b.Property<bool>("isResVolStrong")
                        .HasColumnType("bit");

                    b.Property<bool>("isSpot")
                        .HasColumnType("bit");

                    b.Property<bool>("isSupOIStrong")
                        .HasColumnType("bit");

                    b.Property<bool>("isSupVolStrong")
                        .HasColumnType("bit");

                    b.Property<decimal>("ltp")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("pecoi")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("peiv")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("peltp")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("peltpchange")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("peoi")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("pevolume")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("prev1")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("prev1Resistance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("prev1Resistance1")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("prev1Support")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("prev1Support1")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("prev2")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("prev2Resistance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("prev2Resistance1")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("prev2Support")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("prev2Support1")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("prevClose")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("script")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("strike")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("strike_reflabel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("yearHigh")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("yearLow")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("OptionChainStockSummary", "Identity");
                });

            modelBuilder.Entity("NSMkt.Models.OptionChainSummary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("CECOIDiffPer")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("PECOIDiffPer")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Res1")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Res2")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SummaryJson")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Sup1")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Sup2")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("analysisTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("cecoi")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ceiv")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("celtp")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("celtpchange")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ceoi")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("cevolume")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("expiry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("expiryType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("futureprice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("group")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("highPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("indexprice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("isResOIStrong")
                        .HasColumnType("bit");

                    b.Property<bool>("isResVolStrong")
                        .HasColumnType("bit");

                    b.Property<bool>("isSpot")
                        .HasColumnType("bit");

                    b.Property<bool>("isSupOIStrong")
                        .HasColumnType("bit");

                    b.Property<bool>("isSupVolStrong")
                        .HasColumnType("bit");

                    b.Property<decimal>("lowPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("openPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("pecoi")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("peiv")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("peltp")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("peltpchange")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("peoi")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("pevolume")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("script")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("strike")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("strike_reflabel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OptionChainSummary", "Identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("NSMkt.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("NSMkt.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NSMkt.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("NSMkt.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
