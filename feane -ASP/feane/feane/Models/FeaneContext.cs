using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace feane.Models;

public partial class FeaneContext : DbContext
{
    public FeaneContext()
    {
    }

    public FeaneContext(DbContextOptions<FeaneContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Blog> Blogs { get; set; }

    public virtual DbSet<BlogDetail> BlogDetails { get; set; }

    public virtual DbSet<BookTable> BookTables { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<ParentMenu> ParentMenus { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PreOrder> PreOrders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<ProductDetail> ProductDetails { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SubMenu> SubMenus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=MAY-CUA-HUNG\\SQLEXPRESS;Initial Catalog=feane;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__Account__B19D4181D9FF511D");

            entity.ToTable("Account");

            entity.Property(e => e.AccountId).HasColumnName("Account_id");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Fullname).HasMaxLength(255);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.RoleId).HasColumnName("Role_id");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Account__Role_id__4BAC3F29");
        });

        modelBuilder.Entity<Blog>(entity =>
        {
            entity.HasKey(e => e.BlogId).HasName("PK__Blog__C163EC1007F42C58");

            entity.ToTable("Blog");

            entity.Property(e => e.BlogId).HasColumnName("Blog_id");
            entity.Property(e => e.Alias).HasMaxLength(255);
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Descipption).HasMaxLength(255);
            entity.Property(e => e.EditedBy).HasMaxLength(255);
            entity.Property(e => e.EditedDate).HasColumnType("datetime");
            entity.Property(e => e.Image).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<BlogDetail>(entity =>
        {
            entity.HasKey(e => e.BlogDetailId).HasName("PK__BlogDeta__AC9FEF6FF5A470E7");

            entity.ToTable("BlogDetail");

            entity.Property(e => e.BlogDetailId).HasColumnName("BlogDetail_id");
            entity.Property(e => e.Alias).HasMaxLength(255);
            entity.Property(e => e.BlogId).HasColumnName("Blog_id");
            entity.Property(e => e.CommentId).HasColumnName("Comment_id");
            entity.Property(e => e.Content).HasMaxLength(500);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.EditedBy).HasMaxLength(255);
            entity.Property(e => e.EditedDate).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.Blog).WithMany(p => p.BlogDetails)
                .HasForeignKey(d => d.BlogId)
                .HasConstraintName("FK__BlogDetai__Blog___05D8E0BE");

            entity.HasOne(d => d.Comment).WithMany(p => p.BlogDetails)
                .HasForeignKey(d => d.CommentId)
                .HasConstraintName("FK__BlogDetai__Comme__06CD04F7");
        });

        modelBuilder.Entity<BookTable>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PK__BookTabl__C220CF9C8ED062D9");

            entity.ToTable("BookTable");

            entity.Property(e => e.BookId).HasColumnName("Book_id");
            entity.Property(e => e.AccountId).HasColumnName("Account_id");
            entity.Property(e => e.BookDate).HasColumnType("datetime");
            entity.Property(e => e.Note).HasMaxLength(255);

            entity.HasOne(d => d.Account).WithMany(p => p.BookTables)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__BookTable__Accou__656C112C");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK__Cart__D6862FC1D9A1F182");

            entity.ToTable("Cart");

            entity.Property(e => e.CartId).HasColumnName("Cart_id");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductId).HasColumnName("Product_id");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Product).WithMany(p => p.Carts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Cart__Product_id__6EF57B66");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__Comment__99D3E6C37E23FB2F");

            entity.ToTable("Comment");

            entity.Property(e => e.CommentId).HasColumnName("Comment_id");
            entity.Property(e => e.AccountId).HasColumnName("Account_id");
            entity.Property(e => e.CommentDate).HasColumnType("datetime");
            entity.Property(e => e.Content).HasMaxLength(500);

            entity.HasOne(d => d.Account).WithMany(p => p.Comments)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__Comment__Account__02FC7413");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__OrderDet__53D7B4883B70EE29");

            entity.ToTable("OrderDetail");

            entity.Property(e => e.OrderDetailId).HasColumnName("OrderDetail_id");
            entity.Property(e => e.OrderId).HasColumnName("Order_id");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductId).HasColumnName("Product_id");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderDeta__Order__6B24EA82");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__OrderDeta__Produ__6C190EBB");
        });

        modelBuilder.Entity<ParentMenu>(entity =>
        {
            entity.HasKey(e => e.ParentMenuId).HasName("PK__ParentMe__A7D275DC22AFEF41");

            entity.ToTable("ParentMenu");

            entity.Property(e => e.ParentMenuId).HasColumnName("ParentMenu_id");
            entity.Property(e => e.Alias)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payment__DA638B190E79C30B");

            entity.ToTable("Payment");

            entity.Property(e => e.PaymentId).HasColumnName("Payment_id");
            entity.Property(e => e.AccountId).HasColumnName("Account_id");
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentMethod).HasMaxLength(30);

            entity.HasOne(d => d.Account).WithMany(p => p.Payments)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__Payment__Account__71D1E811");
        });

        modelBuilder.Entity<PreOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__PreOrder__F1FF84539AF4D74D");

            entity.ToTable("PreOrder");

            entity.Property(e => e.OrderId).HasColumnName("Order_id");
            entity.Property(e => e.AccountId).HasColumnName("Account_id");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.OrderStatus).HasMaxLength(30);
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Account).WithMany(p => p.PreOrders)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PreOrder__Accoun__68487DD7");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__9833FF92562C4953");

            entity.ToTable("Product");

            entity.Property(e => e.ProductId).HasColumnName("Product_id");
            entity.Property(e => e.CategoryId).HasColumnName("Category_id");
            entity.Property(e => e.Detail).HasMaxLength(255);
            entity.Property(e => e.Image).HasMaxLength(255);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductName).HasMaxLength(255);

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Product__Categor__5535A963");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__ProductC__6DB28136E5AA0E76");

            entity.ToTable("ProductCategory");

            entity.Property(e => e.CategoryId).HasColumnName("Category_id");
            entity.Property(e => e.CategoryName).HasMaxLength(50);
        });

        modelBuilder.Entity<ProductDetail>(entity =>
        {
            entity.HasKey(e => e.ProductDetailId).HasName("PK__ProductD__3D4ABE5E7E81FB48");

            entity.ToTable("ProductDetail");

            entity.Property(e => e.ProductDetailId).HasColumnName("ProductDetail_id");
            entity.Property(e => e.Detail).HasMaxLength(255);
            entity.Property(e => e.Image).HasMaxLength(255);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductId).HasColumnName("Product_id");
            entity.Property(e => e.ProductName).HasMaxLength(255);

            entity.HasOne(d => d.Product).WithMany(p => p.ProductDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__ProductDe__Produ__5812160E");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__D80BB093F7E1D597");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId).HasColumnName("Role_id");
            entity.Property(e => e.RoleName).HasMaxLength(30);
        });

        modelBuilder.Entity<SubMenu>(entity =>
        {
            entity.HasKey(e => e.SubMenuId).HasName("PK__SubMenu__71A766DCB948D6C3");

            entity.ToTable("SubMenu");

            entity.Property(e => e.SubMenuId).HasColumnName("SubMenu_id");
            entity.Property(e => e.Alias)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ParentMenuId).HasColumnName("ParentMenu_id");
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.ParentMenu).WithMany(p => p.SubMenus)
                .HasForeignKey(d => d.ParentMenuId)
                .HasConstraintName("FK__SubMenu__ParentM__5070F446");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
