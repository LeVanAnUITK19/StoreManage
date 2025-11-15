using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Store.Models;
using Store.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Store.ViewModels;

public partial class CustomerPageViewModel : ViewModelBase
{
    [ObservableProperty] private ObservableCollection<KhachHang> khachHangs = new();
    private readonly DispatcherTimer _timer;
    public ObservableCollection<string> DanhSachBoLoc { get; } = new()
        {
            "TenKH",
            "SDT",
            "DiaChi"
        };
    public CustomerPageViewModel()
    {
        LoadKhachHangs();
        // ✅ Tạo timer lặp lại mỗi 5 giây
        _timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(5)
        };
        _timer.Tick += (s, e) => LoadKhachHangs();
        _timer.Start();
    }
    private void LoadKhachHangs()
    {
        var list = KhachHangService.GetAllKhachHang();

        khachHangs.Clear();
        foreach (var kh in list)
        {
            khachHangs.Add(kh);
        }
    }
    [RelayCommand]
    public void TaoKhachHangButton()
    {
       CreateCustomerWindowView createCustomerWindowView = new CreateCustomerWindowView();
       createCustomerWindowView.Show();
    }
    /* public ProductPageViewModel()
 {
     LoadSanPhams();
 }
 private void LoadSanPhams()
 {
     var list = SanPhanService.GetAllSanPham();

     sanPhams.Clear();
     foreach (var sp in list)
     {
         sanPhams.Add(sp);
     }
 }
 [RelayCommand]
 private void ThemSanPhamButton()
 {
     CreateProductWindowView createProductWindowView = new();
     createProductWindowView.Show();
     LoadSanPhams();
 }*/
}