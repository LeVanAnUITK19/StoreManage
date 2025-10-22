using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Store.Models;
using Store.Views;
using System;
using System.Collections.ObjectModel;

namespace Store.ViewModels;


public partial class BillPageViewModel : ViewModelBase
{
    [ObservableProperty] private int soHD;
    [ObservableProperty] private string tenKH;
    [ObservableProperty] private DateTime  ngayLapHD;
    [ObservableProperty] private decimal tongTienHD;
    [ObservableProperty]
    private ObservableCollection<HoaDon> hoaDons = new();
    public ObservableCollection<string> DanhSachBoLoc { get; } = new()
 {
     "TenKH",
     "NgayLapHD",
     "TongTienHD",
     "Tất cả"
 };
    public BillPageViewModel()
    {
        // Sample data for demonstration purposes
        hoaDons.Add(new HoaDon { MaHD = 1, NgayLapHD = System.DateTime.Now, TongTienHD = 100000, GiamGiaHD = 5000, MaKH = 101, MaUser = 1, SoHD = 1, TrangThaiHD = "Completed" , TenKH="Le Van An"});
        hoaDons.Add(new HoaDon { MaHD = 2, NgayLapHD = System.DateTime.Now, TongTienHD = 200000, GiamGiaHD = 10000, MaKH = 102, MaUser = 2, SoHD = 2, TrangThaiHD = "Pending", TenKH = "Nguyễn Cao Cường" });
        hoaDons.Add(new HoaDon { MaHD = 1, NgayLapHD = System.DateTime.Now, TongTienHD = 100000, GiamGiaHD = 5000, MaKH = 101, MaUser = 1, SoHD = 1, TrangThaiHD = "Completed", TenKH = "Le Van An" });
        hoaDons.Add(new HoaDon { MaHD = 2, NgayLapHD = System.DateTime.Now, TongTienHD = 200000, GiamGiaHD = 10000, MaKH = 102, MaUser = 2, SoHD = 2, TrangThaiHD = "Pending", TenKH = "Nguyễn Cao Cường" });
        hoaDons.Add(new HoaDon { MaHD = 1, NgayLapHD = System.DateTime.Now, TongTienHD = 100000, GiamGiaHD = 5000, MaKH = 101, MaUser = 1, SoHD = 1, TrangThaiHD = "Completed", TenKH = "Le Van An" });
        hoaDons.Add(new HoaDon { MaHD = 2, NgayLapHD = System.DateTime.Now, TongTienHD = 200000, GiamGiaHD = 10000, MaKH = 102, MaUser = 2, SoHD = 2, TrangThaiHD = "Pending", TenKH = "Nguyễn Cao Cường" });
    }
    [RelayCommand]
    private void CreateBillButton()
    {
        CreateBillWindowView createBillWindow = new CreateBillWindowView();
        createBillWindow.Show();
    }
}