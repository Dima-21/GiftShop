using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.Models
{
    public partial class GiftShopContext : DbContext
    {
        public GiftShopContext()
        {
        }

        public GiftShopContext(DbContextOptions<GiftShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<Charact> Charact { get; set; }
        public virtual DbSet<Goods> Goods { get; set; }
        public virtual DbSet<GoodsImage> GoodsImage { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderGoods> OrderGoods { get; set; }
        public virtual DbSet<OrderStatus> OrderStatus { get; set; }
        public virtual DbSet<Property> Property { get; set; }
        public virtual DbSet<CartItem> CartItem { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Data Source=DIMA-PC\\SQLEXPRESS; Initial Catalog=GiftShop;Integrated Security=True");
                optionsBuilder.UseSqlServer("Data Source=SQL5052.site4now.net; Initial Catalog=db_a7a7c0_giftshop; User Id=db_a7a7c0_giftshop_admin;Password=!Zhmurchuk21");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Charact>(entity =>
            {
                entity.HasKey(e => new { e.GoodsId, e.PropId });

                entity.HasIndex(e => e.PropId);

                entity.Property(e => e.Value)
                    .IsRequired(false)
                    .HasMaxLength(100);

                entity.HasOne(d => d.Goods)
                    .WithMany(p => p.Charact)
                    .HasForeignKey(d => d.GoodsId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_charact_goods");



                //entity.HasOne(d => d.Group)
                //    .WithMany(p => p.Charact)
                //    .HasForeignKey(d => d.GroupId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_charact_group");

                entity.HasOne(d => d.Prop)
                    .WithMany(p => p.Charact)
                    .HasForeignKey(d => d.PropId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_charact_property");
            });

            modelBuilder.Entity<Goods>(entity =>
            {
                


                entity.HasIndex(e => e.GroupId);

                //entity.Property(e => e.Id).ValueGeneratedOnAdd();

                //entity.Property(e => e.GoodsId);


                entity.Property(e => e.Amount).HasDefaultValueSql("(CONVERT([smallint],(0)))");

                //entity.Property(e => e.Code);


                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PublishData).HasColumnType("datetime").HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ShortDescript).HasMaxLength(200);

                entity.HasOne(d => d.Group)
                   .WithMany(p => p.Goods)
                   .HasForeignKey(d => d.GroupId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_Goods_Group");


            });

            modelBuilder.Entity<GoodsImage>(entity =>
            {
                entity.HasKey(e => new { e.GoodsId, e.ImageId });

                entity.ToTable("Goods_Image");

                entity.HasIndex(e => e.ImageId);

                entity.HasIndex(e => new { e.GoodsId, e.ImageId })
                    .HasName("UK_goods_image")
                    .IsUnique();

                entity.HasOne(d => d.Goods)
                    .WithMany(p => p.GoodsImage)
                    .HasForeignKey(d => d.GoodsId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_goods_image_goods");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.GoodsImage)
                    .HasForeignKey(d => d.ImageId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_goods_image");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UK_group")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(70);

                entity.Property(e => e.ShortDescript).HasMaxLength(1000);
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasIndex(e => e.UserId);


                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.OrdCloseDate).HasColumnType("datetime");

                entity.Property(e => e.OrderDate).HasColumnType("datetime").HasDefaultValueSql("(getdate())");


                entity.Property(e => e.OrderNum).ValueGeneratedNever();

                entity.Property(e => e.OrderStatusId).IsRequired();

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_order_AspNetUsers");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.Property(e => e.StatusName).IsRequired();
                entity.Property(e => e.StatusCode).IsRequired();
            });

            modelBuilder.Entity<OrderGoods>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.GoodsId });

                entity.ToTable("Order_Goods");

                entity.HasIndex(e => e.GoodsId);

                entity.Property(e => e.Amount).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Goods)
                    .WithMany(p => p.OrderGoods)
                    .HasForeignKey(d => d.GoodsId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_order_goods_goods");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderGoods)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_order_goods_order");
            });



            modelBuilder.Entity<Property>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("UK_property_name")
                    .IsUnique();

                //entity.HasIndex(e => e.GroupId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

     
                entity.HasOne(d => d.Group)
                  .WithMany(p => p.Properties)
                  .HasForeignKey(d => d.GroupId)
                  .OnDelete(DeleteBehavior.Cascade)
                  .HasConstraintName("FK_Property_Group");
            });

            //modelBuilder.Entity<Group>().HasData(new Group { Id = 1, Name = "Подарочные наборы", Icon = "group-icon-gift.png" });
            //modelBuilder.Entity<Group>().HasData(new Group { Id = 2, Name = "Сладости", Icon = "group-icon-sweets.png" });
            //modelBuilder.Entity<Group>().HasData(new Group { Id = 3, Name = "Всё для праздника", Icon = "group-icon-allToParty.png" });

            //modelBuilder.Entity<Price>().HasData(new Models.Price { Id = 1, OrigPrice = 550, ValidFrom = DateTime.Now });
            //modelBuilder.Entity<Price>().HasData(new Models.Price { Id = 2, OrigPrice = 340, ValidFrom = DateTime.Now, PercentDisc = 20 });
            //modelBuilder.Entity<Price>().HasData(new Models.Price { Id = 3, OrigPrice = 450, ValidFrom = DateTime.Now, SumDisc = 100 });
            //modelBuilder.Entity<Price>().HasData(new Models.Price { Id = 4, OrigPrice = 220, ValidFrom = DateTime.Now });



            //modelBuilder.Entity<Goods>().HasData(new Goods
            //{
            //    //Id = 1,
            //    Name = "Подарочный набор 1",
            //    GroupId = 1,
            //    //Code = 100000,
            //    Amount = 10,
            //    IsHidden = false,
            //    ShortDescript = "Подарочный набор 1. Описание",
            //    Descript = "Подарочный набор 1. Полное описание",
            //    PublishData = new DateTime(2020, 1, 1),
            //    Price = 150,
            //});

            //modelBuilder.Entity<Goods>().HasData(new Goods
            //{
            //    //Id = 2,
            //    Name = "Подарочный набор 2",
            //    GroupId = 1,
            //    //Code = 100001,
            //    IsHidden = false,
            //    Amount = 0,
            //    ShortDescript = "Подарочный набор 2. Описание",
            //    Descript = "Подарочный набор 2. Полное описание",
            //    PublishData = new DateTime(2020, 1, 1),
            //    Price = 300,
            //});

            //modelBuilder.Entity<Goods>().HasData(new Goods
            //{
            //    //Id = 3,
            //    Name = "Подарочный набор 3",
            //    GroupId = 1,
            //    //Code = 100002,
            //    IsHidden = false,
            //    Amount = 2,
            //    ShortDescript = "Подарочный набор 3. Описание",
            //    Descript = "Подарочный набор 3. Полное описание",
            //    PublishData = new DateTime(2020, 1, 1),
            //    Price = 450,
            //});

            //modelBuilder.Entity<Goods>().HasData(new Goods
            //{
            //    //Id = 4,
            //    Name = "Конфеты Raffaello",
            //    GroupId = 2,
            //    //Code = 200000,
            //    Amount = 15,
            //    ShortDescript = "Конфеты Raffaello 240г",
            //    Descript = "Конфеты Raffaello. Полное описание",
            //    PublishData = new DateTime(2020, 1, 1),
            //    Price = 120,
            //});

            //modelBuilder.Entity<Property>().HasData(new Property { Id = 1, Name = "Вес", IsFilter = false });
            //modelBuilder.Entity<Property>().HasData(new Property { Id = 2, Name = "Категория людей", IsFilter = true });

            //modelBuilder.Entity<Charact>().HasData(new Charact { GoodsId = 1, PropId = 1, Value = "780г" });
            //modelBuilder.Entity<Charact>().HasData(new Charact { GoodsId = 2, PropId = 1, Value = "560г" });
            //modelBuilder.Entity<Charact>().HasData(new Charact { GoodsId = 1, PropId = 2, Value = "Для детей" });
            //modelBuilder.Entity<Charact>().HasData(new Charact { GoodsId = 2, PropId = 2, Value = "Для мужчин" });
            //modelBuilder.Entity<Charact>().HasData(new Charact { GoodsId = 3, PropId = 2, Value = "Для девушек" });

            //modelBuilder.Entity<Image>().HasData(new Image { Id = 1, Name = "good1_001.jpg" });
            //modelBuilder.Entity<Image>().HasData(new Image { Id = 2, Name = "good1_002.jpg" });
            //modelBuilder.Entity<Image>().HasData(new Image { Id = 3, Name = "good1_003.jpg" });

            //modelBuilder.Entity<Image>().HasData(new Image { Id = 4, Name = "good2_001.jpg" });
            //modelBuilder.Entity<Image>().HasData(new Image { Id = 5, Name = "good2_002.jpg" });
            //modelBuilder.Entity<Image>().HasData(new Image { Id = 6, Name = "good2_003.jpg" });

            //modelBuilder.Entity<Image>().HasData(new Image { Id = 7, Name = "good3_001.jpg" });

            //modelBuilder.Entity<GoodsImage>().HasData(new GoodsImage { GoodsId = 1, ImageId = 1 });
            //modelBuilder.Entity<GoodsImage>().HasData(new GoodsImage { GoodsId = 1, ImageId = 2 });
            //modelBuilder.Entity<GoodsImage>().HasData(new GoodsImage { GoodsId = 1, ImageId = 3 });
            //modelBuilder.Entity<GoodsImage>().HasData(new GoodsImage { GoodsId = 2, ImageId = 4 });
            //modelBuilder.Entity<GoodsImage>().HasData(new GoodsImage { GoodsId = 2, ImageId = 5 });
            //modelBuilder.Entity<GoodsImage>().HasData(new GoodsImage { GoodsId = 2, ImageId = 6 });
            //modelBuilder.Entity<GoodsImage>().HasData(new GoodsImage { GoodsId = 3, ImageId = 7 });


        }
    }
}
