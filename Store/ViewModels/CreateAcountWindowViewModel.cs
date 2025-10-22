using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Store.Models;
using Store.Services;
using Store.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.ViewModels
{
    public partial class CreateAcountWindowViewModel : ViewModelBase
    {
        [ObservableProperty] private string tenDangNhap;
        [ObservableProperty] private string matKhau;
        [ObservableProperty] private string hoTen;
        [ObservableProperty] private string email;
        [ObservableProperty] private string sDT;
        [ObservableProperty] private string diaChi;
        [ObservableProperty] private DateTime? ngaySinh = DateTime.Now;
        [ObservableProperty] private string gioiTinh;
        [ObservableProperty] private string hinhAnh = null;

        public ObservableCollection<string> DanhSachGioiTinh { get; } = new()
        {
            "Nam",
            "Nữ",
            "Khác"
        };


        [RelayCommand]
        private void DangKyButton()
        {
            try
            {
                var user = new User
                {
                    TenDangNhap = TenDangNhap,
                    MatKhau = MatKhau,
                    HoTen = HoTen,
                    Email = Email,
                    SDT = SDT,
                    DiaChi = DiaChi,
                    NgaySinh = NgaySinh,
                    GioiTinh = GioiTinh,
                    HinhAnh = HinhAnh
                };
                UserService.InsertUser(user);
                // Sau khi thêm thành công
                System.Diagnostics.Debug.WriteLine($"Đã thêm sản phẩm: {HoTen}");


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi khi tạo sản phẩm: {ex.Message}");
            }
            /*if (string.IsNullOrWhiteSpace(TenDangNhap) || string.IsNullOrWhiteSpace(MatKhau))
            {
                Console.WriteLine("Tên đăng nhập và mật khẩu không được để trống!");
                return;
            }

            var user = new User
            {
                TenDangNhap = TenDangNhap,
                MatKhau = MatKhau,
                HoTen = HoTen,
                Email = Email,
                SDT = SDT,
                DiaChi = DiaChi,
                NgaySinh = NgaySinh,
                GioiTinh = GioiTinh,
                HinhAnh = HinhAnh
            };

            UserService.InsertUser(user);
            Console.WriteLine("Đăng ký thành công!");    */
        }

    }
}

