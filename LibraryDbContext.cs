using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace LibraryManagement
{
    public class LibraryDbContext : DbContext
    {
        // DbSet cho mỗi thực thể
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<BorrowRecord> BorrowRecords { get; set; }
        public DbSet<BookLocation> BookLocations { get; set; }
        public DbSet<BookCopy> BookCopies { get; set; }
        public DbSet<InventoryCheck> InventoryChecks { get; set; }
        public DbSet<InventoryDetail> InventoryDetails { get; set; }
        public DbSet<LostBook> LostBooks { get; set; }

        // Cấu hình kết nối đến CSDL
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = ConfigurationManager.ConnectionStrings["LibraryDB"]?.ConnectionString;

                if (!string.IsNullOrEmpty(connectionString))
                {
                    optionsBuilder.UseSqlServer(connectionString, options =>
                    {
                        // Thêm retry policy để xử lý transient failures
                        options.EnableRetryOnFailure(
                            maxRetryCount: 3,
                            maxRetryDelay: TimeSpan.FromSeconds(5),
                            errorNumbersToAdd: null);

                        // Tăng command timeout
                        options.CommandTimeout(60);
                    });
                }
            }
        }

        // Cấu hình mô hình và tạo dữ liệu mẫu
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cấu hình các mối quan hệ để tránh chu kỳ cascade

            // Book - Author
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Book - Category
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // BorrowRecord - Book
            modelBuilder.Entity<BorrowRecord>()
                .HasOne(br => br.Book)
                .WithMany(b => b.BorrowRecords)
                .HasForeignKey(br => br.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            // BorrowRecord - Member
            modelBuilder.Entity<BorrowRecord>()
                .HasOne(br => br.Member)
                .WithMany(m => m.BorrowRecords)
                .HasForeignKey(br => br.MemberId)
                .OnDelete(DeleteBehavior.Restrict);

            // BorrowRecord - BookCopy
            modelBuilder.Entity<BorrowRecord>()
                .HasOne(br => br.BookCopy)
                .WithMany(bc => bc.BorrowRecords)
                .HasForeignKey(br => br.CopyId)
                .OnDelete(DeleteBehavior.Restrict);

            // BookCopy - Book
            modelBuilder.Entity<BookCopy>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.BookCopies)
                .HasForeignKey(bc => bc.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            // BookCopy - BookLocation
            modelBuilder.Entity<BookCopy>()
                .HasOne(bc => bc.Location)
                .WithMany(bl => bl.BookCopies)
                .HasForeignKey(bc => bc.LocationId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false); // LocationId có thể null

            // InventoryDetail - InventoryCheck
            modelBuilder.Entity<InventoryDetail>()
                .HasOne(id => id.InventoryCheck)
                .WithMany(ic => ic.InventoryDetails)
                .HasForeignKey(id => id.InventoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // InventoryDetail - BookCopy
            modelBuilder.Entity<InventoryDetail>()
                .HasOne(id => id.BookCopy)
                .WithMany(bc => bc.InventoryDetails)
                .HasForeignKey(id => id.CopyId)
                .OnDelete(DeleteBehavior.Restrict);

            // InventoryCheck - Employee
            modelBuilder.Entity<InventoryCheck>()
                .HasOne(ic => ic.Employee)
                .WithMany(e => e.InventoryChecks)
                .HasForeignKey(ic => ic.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // LostBook - BookCopy (một-một)
            modelBuilder.Entity<LostBook>()
                .HasOne(lb => lb.BookCopy)
                .WithOne(bc => bc.LostBook)
                .HasForeignKey<LostBook>(lb => lb.CopyId)
                .OnDelete(DeleteBehavior.Restrict);

            // LostBook - Employee
            modelBuilder.Entity<LostBook>()
                .HasOne(lb => lb.Employee)
                .WithMany(e => e.ReportedLostBooks)
                .HasForeignKey(lb => lb.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Dữ liệu mẫu cho Employee (tài khoản quản trị mặc định)
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 1,
                    Name = "Admin",
                    Email = "admin",
                    Password = "admin",
                    RoleId = 1,  // Quản trị viên
                    Status = true
                }
            );

            // Dữ liệu mẫu cho Category
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Khoa học", Description = "Sách về khoa học kỹ thuật" },
                new Category { CategoryId = 2, Name = "Văn học", Description = "Sách văn học" },
                new Category { CategoryId = 3, Name = "Lịch sử", Description = "Sách về lịch sử" },
                new Category { CategoryId = 4, Name = "Công nghệ thông tin", Description = "Sách về CNTT và lập trình" },
                new Category { CategoryId = 5, Name = "Kinh tế", Description = "Sách về kinh tế, kinh doanh" }
            );

            // Dữ liệu mẫu cho Author
            modelBuilder.Entity<Author>().HasData(
                new Author { AuthorId = 1, Name = "Nguyễn Nhật Ánh", Biography = "Tác giả văn học thiếu nhi nổi tiếng" },
                new Author { AuthorId = 2, Name = "Dale Carnegie", Biography = "Tác giả sách về kỹ năng và phát triển bản thân" },
                new Author { AuthorId = 3, Name = "Robert C. Martin", Biography = "Tác giả sách về lập trình và phát triển phần mềm" }
            );

            // Dữ liệu mẫu cho BookLocation
            modelBuilder.Entity<BookLocation>().HasData(
                new BookLocation { LocationId = 1, AreaCode = "A", ShelfNumber = 1, SectionNumber = 1, Description = "Khu vực sách văn học" },
                new BookLocation { LocationId = 2, AreaCode = "B", ShelfNumber = 2, SectionNumber = 1, Description = "Khu vực sách khoa học" },
                new BookLocation { LocationId = 3, AreaCode = "C", ShelfNumber = 3, SectionNumber = 1, Description = "Khu vực sách kỹ thuật" }
            );
        }
    }
}