using Microsoft.Data.Sqlite;
using Store.Models;
using System;
using System.IO;

namespace Store.Services
{
    public static class DatabaseService
    {
        private static string dbPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "StoreApp",
            "store.db"
        );

        public static void Initialize()
        {
            // BƯỚC 1: Đảm bảo thư mục tồn tại TRƯỚC TIÊN
            string dbDirectory = Path.GetDirectoryName(dbPath)!;
            if (!Directory.Exists(dbDirectory))
            {
                Directory.CreateDirectory(dbDirectory);
            }

            // BƯỚC 2: Chỉ tạo database và bảng nếu file chưa tồn tại
            if (!File.Exists(dbPath))
            {
                using (var connection = new SqliteConnection($"Data Source={dbPath}"))
                {
                    connection.Open();
                    var cmd = connection.CreateCommand();
                    cmd.CommandText = @"
                        CREATE TABLE Users (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            TenDangNhap TEXT NOT NULL,
                            MatKhau TEXT NOT NULL,
                            HoTen TEXT,
                            Email TEXT,
                            SDT TEXT,
                            DiaChi TEXT,
                            NgaySinh TEXT,
                            GioiTinh TEXT,
                            HinhAnh TEXT
                        )";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void InsertUser(User user)
        {
            using (var connection = new SqliteConnection($"Data Source={dbPath}"))
            {
                connection.Open();
                var cmd = connection.CreateCommand();

                // SỬA LẠI SQL: Bỏ dấu $ ở tên cột HinhAnh
                cmd.CommandText = @"
                    INSERT INTO Users 
                    (TenDangNhap, MatKhau, HoTen, Email, SDT, DiaChi, NgaySinh, GioiTinh, HinhAnh)
                    VALUES ($TenDangNhap, $MatKhau, $HoTen, $Email, $SDT, $DiaChi, $NgaySinh, $GioiTinh, $HinhAnh)";

                cmd.Parameters.AddWithValue("$TenDangNhap", user.TenDangNhap);
                cmd.Parameters.AddWithValue("$MatKhau", user.MatKhau);
                cmd.Parameters.AddWithValue("$HoTen", user.HoTen ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("$Email", user.Email ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("$SDT", user.SDT ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("$DiaChi", user.DiaChi ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("$NgaySinh", user.NgaySinh?.ToString("yyyy-MM-dd") ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("$GioiTinh", user.GioiTinh ?? (object)DBNull.Value);

                // SỬA LẠI TÊN PARAMETER: Phải là "$HinhAnh" cho khớp
                cmd.Parameters.AddWithValue("$HinhAnh", user.HinhAnh ?? (object)DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }
    }
}