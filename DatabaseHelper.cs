using Microsoft.EntityFrameworkCore;

namespace LibraryManagement
{
    public class DatabaseHelper
    {
        public static async Task<bool> InitializeDatabaseAsync()
        {
            try
            {
                using (var context = new LibraryDbContext())
                {
                    // Tạo database nếu chưa tồn tại
                    var created = await context.Database.EnsureCreatedAsync();

                    if (created)
                    {
                        Console.WriteLine("Database đã được tạo thành công!");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Database đã tồn tại.");
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi tạo database: {ex.Message}");
                return false;
            }
        }

        // Phương thức test kết nối
        public static async Task<bool> TestConnectionAsync()
        {
            try
            {
                using (var context = new LibraryDbContext())
                {
                    var canConnect = await context.Database.CanConnectAsync();

                    if (canConnect)
                    {
                        Console.WriteLine("✓ Kết nối database thành công!");

                        // Test query đơn giản
                        try
                        {
                            var employeeCount = await context.Employees.CountAsync();
                            Console.WriteLine($"✓ Tìm thấy {employeeCount} nhân viên trong database");
                        }
                        catch
                        {
                            // Bảng có thể chưa tồn tại, nhưng kết nối OK
                            Console.WriteLine("✓ Kết nối OK, có thể database chưa có dữ liệu");
                        }

                        return true;
                    }
                    else
                    {
                        Console.WriteLine("✗ Không thể kết nối database");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ Lỗi kết nối: {ex.Message}");
                return false;
            }
        }

        // Phương thức test kết nối đồng bộ (cho LibraryDbContext.TestConnection())
        public static bool TestConnectionSync()
        {
            try
            {
                using (var context = new LibraryDbContext())
                {
                    return context.Database.CanConnect();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi kết nối: {ex.Message}");
                return false;
            }
        }

        // Phương thức chạy migration thủ công
        public static async Task<bool> RunMigrationsAsync()
        {
            try
            {
                using (var context = new LibraryDbContext())
                {
                    await context.Database.MigrateAsync();
                    Console.WriteLine("Migration hoàn tất!");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi migration: {ex.Message}");
                return false;
            }
        }

        // Phương thức tạo database và chèn dữ liệu mặc định
        public static bool InitializeDatabaseSync()
        {
            try
            {
                using (var context = new LibraryDbContext())
                {
                    // Tạo database nếu chưa tồn tại
                    var created = context.Database.EnsureCreated();

                    if (created)
                    {
                        Console.WriteLine("Database đã được tạo thành công!");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Database đã tồn tại.");
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi tạo database: {ex.Message}");
                return false;
            }
        }

        // Phương thức kiểm tra và tạo bảng nếu cần
        public static bool CheckAndCreateTables()
        {
            try
            {
                using (var context = new LibraryDbContext())
                {
                    // Kiểm tra xem bảng Employee có tồn tại không
                    var tableExists = context.Database.SqlQueryRaw<int>(
                        "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Employees'"
                    ).AsEnumerable().FirstOrDefault();

                    if (tableExists == 0)
                    {
                        // Tạo lại database với tất cả bảng
                        context.Database.EnsureCreated();
                        Console.WriteLine("Đã tạo các bảng trong database");
                        return true;
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi kiểm tra bảng: {ex.Message}");
                return false;
            }
        }

        // Phương thức lấy thông tin kết nối
        public static string GetConnectionInfo()
        {
            try
            {
                using (var context = new LibraryDbContext())
                {
                    var connectionString = context.Database.GetConnectionString();
                    return $"Connection String: {connectionString}";
                }
            }
            catch (Exception ex)
            {
                return $"Lỗi lấy thông tin kết nối: {ex.Message}";
            }
        }
    }
}