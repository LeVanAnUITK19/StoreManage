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
                    HoTen TEXT NOT NULL,
                    Email TEXT NOT NULL,
                    SDT TEXT ,
                    DiaChi TEXT NOT NULL,
                    NgaySinh TEXT ,
                    GioiTinh TEXT  ,
                    HinhAnh TEXT,
                    MaVT TEXT NOT NULL
                );";
                cmd.ExecuteNonQuery();
            }
        }
        //Create
        public static void InsertUser(User user)
        {
            using (var connection = new SqliteConnection($"Data Source={dbPath}"))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                string newMaNV = GenerateNewMaUser();

                cmd.CommandText = @"
                INSERT INTO Users 
                (MaNV, TenDangNhap, MatKhau, HoTen, Email, SDT, DiaChi, NgaySinh, GioiTinh, HinhAnh, MaVT)
                VALUES ($MaNV, $TenDangNhap, $MatKhau, $HoTen, $Email, $SDT, $DiaChi, $NgaySinh, $GioiTinh, $HinhAnh, $MaVT)";

                cmd.Parameters.AddWithValue("$MaNV", newMaNV);
                cmd.Parameters.AddWithValue("$TenDangNhap", user.TenDangNhap);
                cmd.Parameters.AddWithValue("$MatKhau", user.MatKhau);
                cmd.Parameters.AddWithValue("$HoTen", user.HoTen );
                cmd.Parameters.AddWithValue("$Email", user.Email );
                cmd.Parameters.AddWithValue("$SDT", user.SDT );
                cmd.Parameters.AddWithValue("$DiaChi", user.DiaChi );
                cmd.Parameters.AddWithValue("$NgaySinh", user.NgaySinh?.ToString("yyyy-MM-dd") );
                cmd.Parameters.AddWithValue("$GioiTinh", user.GioiTinh );
                cmd.Parameters.AddWithValue("$HinhAnh", user.HinhAnh );
                cmd.Parameters.AddWithValue("$MaVT", user.MaVT);

                cmd.ExecuteNonQuery();
            }
           
        }
        
        // Read all users
        public static List<User> GetAllUser()
        {
            var users = new List<User>();

            using (var connection = new SqliteConnection($"Data Source={dbPath}"))
            {
                connection.Open();
                var cmd = connection.CreateCommand();

                // ✅ Tên bảng đúng là "Users"
                cmd.CommandText = @"
            SELECT MaNV, TenDangNhap, MatKhau, HoTen, Email, SDT, DiaChi, NgaySinh, GioiTinh, HinhAnh, MaVT 
            FROM Users";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var user = new User
                        {
                            MaNV = reader.IsDBNull(0) ? "" : reader.GetString(0),
                            TenDangNhap = reader.IsDBNull(1) ? "" : reader.GetString(1),
                            MatKhau = reader.IsDBNull(2) ? "" : reader.GetString(2),
                            HoTen = reader.IsDBNull(3) ? "" : reader.GetString(3),
                            Email = reader.IsDBNull(4) ? "" : reader.GetString(4),
                            SDT = reader.IsDBNull(5) ? "" : reader.GetString(5),
                            DiaChi = reader.IsDBNull(6) ? "" : reader.GetString(6),
                            NgaySinh = reader.IsDBNull(7) ? (DateTime?)null : DateTime.Parse(reader.GetString(7)),
                            GioiTinh = reader.IsDBNull(8) ? "" : reader.GetString(8),
                            HinhAnh = reader.IsDBNull(9) ? "" : reader.GetString(9),
                            MaVT = reader.IsDBNull(10) ? "" : reader.GetString(10),
                        };
                        users.Add(user);
                    }
                }
            }

            return users;
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
