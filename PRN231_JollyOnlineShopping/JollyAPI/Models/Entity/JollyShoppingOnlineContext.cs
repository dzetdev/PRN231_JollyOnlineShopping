using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JollyAPI.Models.Entity
{
    public partial class JollyShoppingOnlineContext : DbContext
    {
        public JollyShoppingOnlineContext()
        {
        }

        public JollyShoppingOnlineContext(DbContextOptions<JollyShoppingOnlineContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Blog> Blogs { get; set; } = null!;
        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Color> Colors { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Image> Images { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Rating> Ratings { get; set; } = null!;
        public virtual DbSet<Size> Sizes { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<WishItem> WishItems { get; set; } = null!;
        public virtual DbSet<WishList> WishLists { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server =(local); database = JollyShoppingOnline;uid=sa;pwd=sa123;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .HasColumnName("city");

                entity.Property(e => e.District)
                    .HasMaxLength(255)
                    .HasColumnName("district");

                entity.Property(e => e.Street)
                    .HasMaxLength(255)
                    .HasColumnName("street");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Ward)
                    .HasMaxLength(255)
                    .HasColumnName("ward");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Address__user_id__5AEE82B9");
            });

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.ToTable("Blog");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .HasColumnName("image");

                entity.Property(e => e.PublishedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("publishedDate");

                entity.Property(e => e.ShortContent)
                    .HasMaxLength(255)
                    .HasColumnName("shortContent");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Blog__user_id__5BE2A6F2");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK__Category__parent__5CD6CB2B");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.ToTable("Color");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Hex)
                    .HasMaxLength(255)
                    .HasColumnName("hex");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BlogId).HasColumnName("blog_id");

                entity.Property(e => e.Content)
                    .HasMaxLength(255)
                    .HasColumnName("content");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.BlogId)
                    .HasConstraintName("FK__Comment__blog_id__5DCAEF64");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Comment__user_id__5EBF139D");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("Image");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ColorId).HasColumnName("color_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Url)
                    .HasColumnType("text")
                    .HasColumnName("url");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.ColorId)
                    .HasConstraintName("FK_Image_Color");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Image_Product");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("Item");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CartId).HasColumnName("cart_id");

                entity.Property(e => e.Color)
                    .HasMaxLength(50)
                    .HasColumnName("color")
                    .IsFixedLength();

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Size)
                    .HasMaxLength(50)
                    .HasColumnName("size")
                    .IsFixedLength();

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.CartId)
                    .HasConstraintName("FK__Item__cart_id__619B8048");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Item__product_id__628FA481");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("address");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(255)
                    .HasColumnName("customerName");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .HasColumnName("phone");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Order__user_id__6383C8BA");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId })
                    .HasName("PK__OrderDet__022945F613752234");

                entity.ToTable("OrderDetail");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Color)
                    .HasMaxLength(50)
                    .HasColumnName("color");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Size)
                    .HasMaxLength(50)
                    .HasColumnName("size");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderDeta__order__6477ECF3");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderDeta__produ__656C112C");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Gender)
                    .HasMaxLength(255)
                    .HasColumnName("gender");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Product__categor__66603565");

                entity.HasMany(d => d.Colors)
                    .WithMany(p => p.Products)
                    .UsingEntity<Dictionary<string, object>>(
                        "ProductColor",
                        l => l.HasOne<Color>().WithMany().HasForeignKey("ColorId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Product_C__color__6754599E"),
                        r => r.HasOne<Product>().WithMany().HasForeignKey("ProductId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Product_C__produ__68487DD7"),
                        j =>
                        {
                            j.HasKey("ProductId", "ColorId").HasName("PK__Product___E6164119740BB4B1");

                            j.ToTable("Product_Color");

                            j.IndexerProperty<int>("ProductId").HasColumnName("product_id");

                            j.IndexerProperty<int>("ColorId").HasColumnName("color_id");
                        });

                entity.HasMany(d => d.Sizes)
                    .WithMany(p => p.Products)
                    .UsingEntity<Dictionary<string, object>>(
                        "ProductSize",
                        l => l.HasOne<Size>().WithMany().HasForeignKey("SizeId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Product_S__size___6A30C649"),
                        r => r.HasOne<Product>().WithMany().HasForeignKey("ProductId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Product_S__produ__693CA210"),
                        j =>
                        {
                            j.HasKey("ProductId", "SizeId").HasName("PK__Product___47DED116A58D392F");

                            j.ToTable("Product_Size");

                            j.IndexerProperty<int>("ProductId").HasColumnName("product_id");

                            j.IndexerProperty<int>("SizeId").HasColumnName("size_id");
                        });
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("Rating");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content)
                    .HasMaxLength(255)
                    .HasColumnName("content");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Rating__product___6B24EA82");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Rating__user_id__6C190EBB");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.ToTable("Size");

                entity.HasIndex(e => e.Name, "UQ__Size__72E12F1BACCCB7D9")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.CartId, "UQ__User__2EF52A2608D2B458")
                    .IsUnique();

                entity.HasIndex(e => e.WishlistId, "UQ__User__6151514F4DCE02BA")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CartId).HasColumnName("cart_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.FullName)
                    .HasMaxLength(255)
                    .HasColumnName("fullName");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .HasColumnName("phone");

                entity.Property(e => e.Role)
                    .HasMaxLength(255)
                    .HasColumnName("role");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.WishlistId).HasColumnName("wishlist_id");

                entity.HasOne(d => d.Cart)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.CartId)
                    .HasConstraintName("fk_cart");

                entity.HasOne(d => d.Wishlist)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.WishlistId)
                    .HasConstraintName("fk_wishlist");
            });

            modelBuilder.Entity<WishItem>(entity =>
            {
                entity.ToTable("WishItem");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.WishlistId).HasColumnName("wishlist_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.WishItems)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__WishItem__produc__6EF57B66");

                entity.HasOne(d => d.Wishlist)
                    .WithMany(p => p.WishItems)
                    .HasForeignKey(d => d.WishlistId)
                    .HasConstraintName("FK__WishItem__wishli__6FE99F9F");
            });

            modelBuilder.Entity<WishList>(entity =>
            {
                entity.ToTable("WishList");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
