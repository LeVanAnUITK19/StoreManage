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
       
    }
    [RelayCommand]
    private void CreateBillButton()
    {
        CreateBillWindowView createBillWindow = new CreateBillWindowView();
        createBillWindow.Show();
    }
}