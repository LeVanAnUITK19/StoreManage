using Microsoft.Data.Sqlite;
using Store.Models;
using System;
using System.Collections.Generic;
using System.IO;
using Avalonia.Media.Imaging;

namespace Store.Services
{
    public static class UserService 
    {
        private static readonly string dbPath = Path.Combine(AppContext.BaseDirectory, "store.db");

        public static void Initialize()
        {
            Console.WriteLine($"Database Path: {dbPath}");

            string dbDirectory = Path.GetDirectoryName(dbPath)!;
            if (!Directory.Exists(dbDirectory))
                Directory.CreateDirectory(dbDirectory);

            using (var connection = new SqliteConnection($"Data Source={dbPath}"))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Users (
                    MaNV TEXT PRIMARY KEY,
                    TenDangNhap TEXT NOT NULL,
                    MatKhau TEXT NOT NULL,
                    HoTen TEXT,
                    Email TEXT,
                    SDT TEXT,
                    DiaChi TEXT,
                    NgaySinh TEXT,
                    GioiTinh TEXT,
                    HinhAnh TEXT
                );";
                cmd.ExecuteNonQuery();
            }
        }
        public static void InsertUser(User user)
        {
            using (var connection = new SqliteConnection($"Data Source={dbPath}"))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                string newMaNV = GenerateNewMaUser();

                cmd.CommandText = @"
                INSERT INTO Users 
                (MaNV, TenDangNhap, MatKhau, HoTen, Email, SDT, DiaChi, NgaySinh, GioiTinh, HinhAnh)
                VALUES ($MaNV, $TenDangNhap, $MatKhau, $HoTen, $Email, $SDT, $DiaChi, $NgaySinh, $GioiTinh, $HinhAnh)";

                cmd.Parameters.AddWithValue("$MaNV", newMaNV);
                cmd.Parameters.AddWithValue("$TenDangNhap", user.TenDangNhap);
                cmd.Parameters.AddWithValue("$MatKhau", user.MatKhau);
                cmd.Parameters.AddWithValue("$HoTen", user.HoTen ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("$Email", user.Email ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("$SDT", user.SDT ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("$DiaChi", user.DiaChi ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("$NgaySinh", user.NgaySinh?.ToString("yyyy-MM-dd") ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("$GioiTinh", user.GioiTinh ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("$HinhAnh", user.HinhAnh ?? (object)DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }
        public static string GenerateNewMaUser()
        {
            using (var connection = new SqliteConnection($"Data Source={dbPath}"))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT MaNV FROM Users ORDER BY MaNV DESC LIMIT 1";
                var result = cmd.ExecuteScalar()?.ToString();

                if (string.IsNullOrEmpty(result))
                    return "NV001";

                int number = int.Parse(result.Substring(2));
                return $"NV{(number + 1):D3}";
            }
        }
    }
}
