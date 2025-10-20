using Microsoft.Data.Sqlite;
using Store.Models;
using System;
using System.Collections.Generic;
using System.IO;
using Avalonia.Media.Imaging;

namespace Store.Services
{
    public static class DatabaseService
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
                );

                CREATE TABLE IF NOT EXISTS SanPham (
                    MaSP TEXT PRIMARY KEY,
                    TenSP TEXT NOT NULL,
                    GiaSP REAL NOT NULL,
                    SoLuongSP INTEGER NOT NULL,
                    HinhAnhDuongDan TEXT,
                    KichThuocSP TEXT,
                    LoaiSP TEXT,
                    MoTaSP TEXT
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
                string newMaNV = GenerateNewMaNV();

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

        public static void InsertSanPham(SanPham sp)
        {
            using (var connection = new SqliteConnection($"Data Source={dbPath}"))
            {
                connection.Open();
                string newMaSP = GenerateNewMaSP();

                var cmd = connection.CreateCommand();
                cmd.CommandText = @"
                INSERT INTO SanPham 
                (MaSP, TenSP, GiaSP, SoLuongSP, HinhAnhDuongDan, KichThuocSP, LoaiSP, MoTaSP)
                VALUES ($MaSP, $TenSP, $GiaSP, $SoLuongSP, $HinhAnhDuongDan, $KichThuocSP, $LoaiSP, $MoTaSP)";
                cmd.Parameters.AddWithValue("$MaSP", newMaSP);
                cmd.Parameters.AddWithValue("$TenSP", sp.TenSP);
                cmd.Parameters.AddWithValue("$GiaSP", (double)sp.GiaSP);
                cmd.Parameters.AddWithValue("$SoLuongSP", sp.SoLuongSP);
                cmd.Parameters.AddWithValue("$HinhAnhDuongDan", sp.HinhAnhDuongDan ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("$KichThuocSP", sp.KichThuocSP);
                cmd.Parameters.AddWithValue("$LoaiSP", sp.LoaiSP);
                cmd.Parameters.AddWithValue("$MoTaSP", sp.MoTaSP ?? (object)DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }

        public static List<SanPham> GetAllSanPham()
        {
            var sanPhams = new List<SanPham>();

            using (var connection = new SqliteConnection($"Data Source={dbPath}"))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT MaSP, TenSP, GiaSP, SoLuongSP, LoaiSP, KichThuocSP, MoTaSP, HinhAnhDuongDan FROM SanPham";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var sp = new SanPham
                        {
                            MaSP = reader.GetString(0),
                            TenSP = reader.IsDBNull(1) ? "" : reader.GetString(1),
                            GiaSP = reader.IsDBNull(2) ? 1000 : reader.GetDecimal(2),
                            SoLuongSP = reader.IsDBNull(3) ? 1 : reader.GetInt32(3),
                            LoaiSP = reader.IsDBNull(4) ? "" : reader.GetString(4),
                            KichThuocSP = reader.IsDBNull(5) ? "" : reader.GetString(5),
                            MoTaSP = reader.IsDBNull(6) ? "" : reader.GetString(6),
                        };

                        if (!reader.IsDBNull(7))
                        {
                            try
                            {
                                string imagePath = reader.GetString(7);
                                if (File.Exists(imagePath))
                                    sp.HinhAnhSP = new Bitmap(imagePath);
                            }
                            catch { }
                        }

                        sanPhams.Add(sp);
                    }
                }
            }

            return sanPhams;
        }

        public static string GenerateNewMaNV()
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

        public static string GenerateNewMaSP()
        {
            using (var connection = new SqliteConnection($"Data Source={dbPath}"))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT MaSP FROM SanPham ORDER BY MaSP DESC LIMIT 1";
                var result = cmd.ExecuteScalar()?.ToString();

                if (string.IsNullOrEmpty(result))
                    return "SP001";

                int number = int.Parse(result.Substring(2));
                return $"SP{(number + 1):D3}";
            }
        }
    }
}
