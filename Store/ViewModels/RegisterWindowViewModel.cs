using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Store.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Models;
using Store.Views;

namespace Store.ViewModels
{
    public partial  class RegisterWindowViewModel : ViewModelBase
    {
        [ObservableProperty] private string tenDangNhap;
        [ObservableProperty] private string matKhau;
        [ObservableProperty] private string hoTen;
        [ObservableProperty] private string email;
        [ObservableProperty] private string sDT;
        [ObservableProperty] private string diaChi;
        [ObservableProperty] private DateTime? ngaySinh = DateTime.Now;
        [ObservableProperty] private string gioiTinh = "Nam";
        [ObservableProperty] private string hinhAnh = "avares://Store/Assets/images/Anh_Mau.jpg";

        [RelayCommand]
        public void DangKyButton()
        {
            if (string.IsNullOrWhiteSpace(TenDangNhap) || string.IsNullOrWhiteSpace(MatKhau))
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

            DatabaseService.InsertUser(user);
            Console.WriteLine("Đăng ký thành công!");
            if (App.Current.ApplicationLifetime is Avalonia.Controls.ApplicationLifetimes.IClassicDesktopStyleApplicationLifetime desktop
                && desktop.MainWindow is Avalonia.Controls.Window mainWindow)
            {
                mainWindow.Close();
            }

        }
    }
}

