using Microsoft.Data.Sqlite;
using Store.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Store.Services
{
    public static class HoaDonService
    {
        private static readonly string dbPath = Path.Combine(AppContext.BaseDirectory, "store.db");

        // ------------------ INIT TABLE ------------------
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
                CREATE TABLE IF NOT EXISTS HoaDon (
                    MaHD INTEGER PRIMARY KEY AUTOINCREMENT,
                    NgayLapHD TEXT NOT NULL,
                    TongTienHD REAL NOT NULL,
                    GiamGiaHD REAL DEFAULT 0,
                    MaKH TEXT NOT NULL,
                    MaUser TEXT NOT NULL,
                    SoHD INTEGER NOT NULL,
                    TrangThaiHD TEXT NOT NULL
                );";
                cmd.ExecuteNonQuery();
            }
        }

        // ------------------ CREATE ------------------
        public static void InsertHoaDon(HoaDon hd)
        {
            using (var connection = new SqliteConnection($"Data Source={dbPath}"))
            {
                connection.Open();

                var cmd = connection.CreateCommand();
                cmd.CommandText = @"
                INSERT INTO HoaDon 
                (NgayLapHD, TongTienHD, GiamGiaHD, MaKH, MaUser, SoHD, TrangThaiHD)
                VALUES ($NgayLapHD, $TongTienHD, $GiamGiaHD, $MaKH, $MaUser, $SoHD, $TrangThaiHD);";

                cmd.Parameters.AddWithValue("$NgayLapHD", hd.NgayLapHD.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("$TongTienHD", (double)hd.TongTienHD);
                cmd.Parameters.AddWithValue("$GiamGiaHD", (double)hd.GiamGiaHD);
                cmd.Parameters.AddWithValue("$MaKH", hd.MaKH);
                cmd.Parameters.AddWithValue("$MaUser", hd.MaUser);
                cmd.Parameters.AddWithValue("$SoHD", hd.SoHD);
                cmd.Parameters.AddWithValue("$TrangThaiHD", hd.TrangThaiHD);

                cmd.ExecuteNonQuery();
            }
        }

        // ------------------ READ ALL ------------------
        public static List<HoaDon> GetAllHoaDon()
        {
            var hoaDons = new List<HoaDon>();

            using (var connection = new SqliteConnection($"Data Source={dbPath}"))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"
                SELECT MaHD, NgayLapHD, TongTienHD, GiamGiaHD, MaKH, MaUser, SoHD, TrangThaiHD
                FROM HoaDon
                ORDER BY MaHD DESC;";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var hd = new HoaDon
                        {
                            MaHD = reader.GetInt32(0),
                            NgayLapHD = DateTime.Parse(reader.GetString(1)),
                            TongTienHD = reader.IsDBNull(2) ? 0 : reader.GetDecimal(2),
                            GiamGiaHD = reader.IsDBNull(3) ? 0 : reader.GetDecimal(3),
                            MaKH = int.Parse(reader.GetString(4)),
                            MaUser = int.Parse(reader.GetString(5)),
                            SoHD = reader.GetInt32(6),
                            TrangThaiHD = reader.GetString(7),
                        };
                        hoaDons.Add(hd);
                    }
                }
            }

            return hoaDons;
        }

        // ------------------ READ ONE ------------------
        public static HoaDon? GetHoaDonById(int maHD)
        {
            using (var connection = new SqliteConnection($"Data Source={dbPath}"))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"
                SELECT MaHD, NgayLapHD, TongTienHD, GiamGiaHD, MaKH, MaUser, SoHD, TrangThaiHD 
                FROM HoaDon WHERE MaHD = $MaHD";
                cmd.Parameters.AddWithValue("$MaHD", maHD);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new HoaDon
                        {
                            MaHD = reader.GetInt32(0),
                            NgayLapHD = DateTime.Parse(reader.GetString(1)),
                            TongTienHD = reader.IsDBNull(2) ? 0 : reader.GetDecimal(2),
                            GiamGiaHD = reader.IsDBNull(3) ? 0 : reader.GetDecimal(3),
                            MaKH = int.Parse(reader.GetString(4)),
                            MaUser = int.Parse(reader.GetString(5)),
                            SoHD = reader.GetInt32(6),
                            TrangThaiHD = reader.GetString(7),
                        };
                    }
                }
            }

            return null;
        }

        // ------------------ UPDATE ------------------
        public static void UpdateHoaDon(HoaDon hd)
        {
            using (var connection = new SqliteConnection($"Data Source={dbPath}"))
            {
                connection.Open();

                var cmd = connection.CreateCommand();
                cmd.CommandText = @"
                UPDATE HoaDon SET
                    NgayLapHD = $NgayLapHD,
                    TongTienHD = $TongTienHD,
                    GiamGiaHD = $GiamGiaHD,
                    MaKH = $MaKH,
                    MaUser = $MaUser,
                    SoHD = $SoHD,
                    TrangThaiHD = $TrangThaiHD
                WHERE MaHD = $MaHD;";

                cmd.Parameters.AddWithValue("$NgayLapHD", hd.NgayLapHD.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("$TongTienHD", (double)hd.TongTienHD);
                cmd.Parameters.AddWithValue("$GiamGiaHD", (double)hd.GiamGiaHD);
                cmd.Parameters.AddWithValue("$MaKH", hd.MaKH);
                cmd.Parameters.AddWithValue("$MaUser", hd.MaUser);
                cmd.Parameters.AddWithValue("$SoHD", hd.SoHD);
                cmd.Parameters.AddWithValue("$TrangThaiHD", hd.TrangThaiHD);
                cmd.Parameters.AddWithValue("$MaHD", hd.MaHD);

                cmd.ExecuteNonQuery();
            }
        }

        // ------------------ DELETE ------------------
        public static void DeleteHoaDon(int maHD)
        {
            using (var connection = new SqliteConnection($"Data Source={dbPath}"))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "DELETE FROM HoaDon WHERE MaHD = $MaHD";
                cmd.Parameters.AddWithValue("$MaHD", maHD);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
