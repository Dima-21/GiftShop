﻿// <auto-generated />
using System;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(GiftShopContext))]
    partial class GiftShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Models.AspNetRoleClaims", b =>
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

            modelBuilder.Entity("DAL.Models.AspNetRoles", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("([NormalizedName] IS NOT NULL)");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("DAL.Models.AspNetUserClaims", b =>
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

            modelBuilder.Entity("DAL.Models.AspNetUserLogins", b =>
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

            modelBuilder.Entity("DAL.Models.AspNetUserRoles", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("DAL.Models.AspNetUsers", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

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
                        .HasFilter("([NormalizedUserName] IS NOT NULL)");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("DAL.Models.AspNetUserTokens", b =>
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

            modelBuilder.Entity("DAL.Models.CartItem", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short>("Amount");

                    b.Property<int>("GoodsId");

                    b.Property<string>("ShopCartId");

                    b.HasKey("Id");

                    b.HasIndex("GoodsId");

                    b.ToTable("CartItem");
                });

            modelBuilder.Entity("DAL.Models.Charact", b =>
                {
                    b.Property<int>("GoodsId");

                    b.Property<int>("PropId");

                    b.Property<string>("Value")
                        .HasMaxLength(100);

                    b.HasKey("GoodsId", "PropId");

                    b.HasIndex("PropId");

                    b.ToTable("Charact");

                    b.HasData(
                        new { GoodsId = 1, PropId = 1, Value = "780г" },
                        new { GoodsId = 2, PropId = 1, Value = "560г" },
                        new { GoodsId = 1, PropId = 2, Value = "Для детей" },
                        new { GoodsId = 2, PropId = 2, Value = "Для мужчин" },
                        new { GoodsId = 3, PropId = 2, Value = "Для девушек" }
                    );
                });

            modelBuilder.Entity("DAL.Models.Goods", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short>("Amount")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("(CONVERT([smallint],(0)))");

                    b.Property<int>("Code");

                    b.Property<string>("Descript");

                    b.Property<int>("GroupId");

                    b.Property<bool>("IsHidden");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<decimal>("Price");

                    b.Property<DateTime>("PublishData")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("ShortDescript")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("UK_goods_name");

                    b.ToTable("Goods");
                });

            modelBuilder.Entity("DAL.Models.GoodsImage", b =>
                {
                    b.Property<int>("GoodsId");

                    b.Property<int>("ImageId");

                    b.HasKey("GoodsId", "ImageId");

                    b.HasIndex("ImageId");

                    b.HasIndex("GoodsId", "ImageId")
                        .IsUnique()
                        .HasName("UK_goods_image");

                    b.ToTable("Goods_Image");

                    b.HasData(
                        new { GoodsId = 1, ImageId = 1 },
                        new { GoodsId = 1, ImageId = 2 },
                        new { GoodsId = 1, ImageId = 3 },
                        new { GoodsId = 2, ImageId = 4 },
                        new { GoodsId = 2, ImageId = 5 },
                        new { GoodsId = 2, ImageId = 6 },
                        new { GoodsId = 3, ImageId = 7 }
                    );
                });

            modelBuilder.Entity("DAL.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Icon");

                    b.Property<string>("Image");

                    b.Property<bool>("IsHidden");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70);

                    b.Property<string>("ShortDescript")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("UK_group");

                    b.ToTable("Group");

                    b.HasData(
                        new { Id = 1, Icon = "group-icon-gift.png", IsHidden = false, Name = "Подарочные наборы" },
                        new { Id = 2, Icon = "group-icon-sweets.png", IsHidden = false, Name = "Сладости" },
                        new { Id = 3, Icon = "group-icon-allToParty.png", IsHidden = false, Name = "Всё для праздника" }
                    );
                });

            modelBuilder.Entity("DAL.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Image");

                    b.HasData(
                        new { Id = 1, Name = "good1_001.jpg" },
                        new { Id = 2, Name = "good1_002.jpg" },
                        new { Id = 3, Name = "good1_003.jpg" },
                        new { Id = 4, Name = "good2_001.jpg" },
                        new { Id = 5, Name = "good2_002.jpg" },
                        new { Id = 6, Name = "good2_003.jpg" },
                        new { Id = 7, Name = "good3_001.jpg" }
                    );
                });

            modelBuilder.Entity("DAL.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BranchNumber");

                    b.Property<string>("City");

                    b.Property<string>("Email");

                    b.Property<DateTime?>("OrdCloseDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("OrderDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("OrderNum");

                    b.Property<short>("OrderStatusId");

                    b.Property<string>("Phone");

                    b.Property<string>("RecipientName");

                    b.Property<int>("Sum");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("OrderStatusId");

                    b.HasIndex("UserId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("DAL.Models.OrderGoods", b =>
                {
                    b.Property<int>("OrderId");

                    b.Property<int>("GoodsId");

                    b.Property<short>("Amount")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((1))");

                    b.Property<int>("Price");

                    b.HasKey("OrderId", "GoodsId");

                    b.HasIndex("GoodsId");

                    b.ToTable("Order_Goods");
                });

            modelBuilder.Entity("DAL.Models.OrderStatus", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short>("StatusCode");

                    b.Property<string>("StatusName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("OrderStatus");
                });

            modelBuilder.Entity("DAL.Models.Property", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GroupId");

                    b.Property<bool>("IsFilter");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasName("UK_property_name");

                    b.ToTable("Property");

                    b.HasData(
                        new { Id = 1, GroupId = 0, IsFilter = false, Name = "Вес" },
                        new { Id = 2, GroupId = 0, IsFilter = true, Name = "Категория людей" }
                    );
                });

            modelBuilder.Entity("DAL.Models.AspNetRoleClaims", b =>
                {
                    b.HasOne("DAL.Models.AspNetRoles", "Role")
                        .WithMany("AspNetRoleClaims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAL.Models.AspNetUserClaims", b =>
                {
                    b.HasOne("DAL.Models.AspNetUsers", "User")
                        .WithMany("AspNetUserClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAL.Models.AspNetUserLogins", b =>
                {
                    b.HasOne("DAL.Models.AspNetUsers", "User")
                        .WithMany("AspNetUserLogins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAL.Models.AspNetUserRoles", b =>
                {
                    b.HasOne("DAL.Models.AspNetRoles", "Role")
                        .WithMany("AspNetUserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAL.Models.AspNetUsers", "User")
                        .WithMany("AspNetUserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAL.Models.AspNetUserTokens", b =>
                {
                    b.HasOne("DAL.Models.AspNetUsers", "User")
                        .WithMany("AspNetUserTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAL.Models.CartItem", b =>
                {
                    b.HasOne("DAL.Models.Goods", "Goods")
                        .WithMany()
                        .HasForeignKey("GoodsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAL.Models.Charact", b =>
                {
                    b.HasOne("DAL.Models.Goods", "Goods")
                        .WithMany("Charact")
                        .HasForeignKey("GoodsId")
                        .HasConstraintName("FK_charact_goods")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAL.Models.Property", "Prop")
                        .WithMany("Charact")
                        .HasForeignKey("PropId")
                        .HasConstraintName("FK_charact_property")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAL.Models.Goods", b =>
                {
                    b.HasOne("DAL.Models.Group", "Group")
                        .WithMany("Goods")
                        .HasForeignKey("GroupId")
                        .HasConstraintName("FK_Goods_Group");
                });

            modelBuilder.Entity("DAL.Models.GoodsImage", b =>
                {
                    b.HasOne("DAL.Models.Goods", "Goods")
                        .WithMany("GoodsImage")
                        .HasForeignKey("GoodsId")
                        .HasConstraintName("FK_goods_image_goods")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAL.Models.Image", "Image")
                        .WithMany("GoodsImage")
                        .HasForeignKey("ImageId")
                        .HasConstraintName("FK_goods_image")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAL.Models.Order", b =>
                {
                    b.HasOne("DAL.Models.OrderStatus", "OrderStatus")
                        .WithMany("Orders")
                        .HasForeignKey("OrderStatusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAL.Models.AspNetUsers", "User")
                        .WithMany("Order")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_order_AspNetUsers");
                });

            modelBuilder.Entity("DAL.Models.OrderGoods", b =>
                {
                    b.HasOne("DAL.Models.Goods", "Goods")
                        .WithMany("OrderGoods")
                        .HasForeignKey("GoodsId")
                        .HasConstraintName("FK_order_goods_goods")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAL.Models.Order", "Order")
                        .WithMany("OrderGoods")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK_order_goods_order")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAL.Models.Property", b =>
                {
                    b.HasOne("DAL.Models.Group", "Group")
                        .WithMany("Properties")
                        .HasForeignKey("GroupId")
                        .HasConstraintName("FK_Property_Group");
                });
#pragma warning restore 612, 618
        }
    }
}
