using Avalonia.Media.Imaging;
using Avalonia.Platform;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Store.Models;
using Store.Views;
using System;
using System.Collections.ObjectModel;



namespace Store.ViewModels;
public partial class ProductPageViewModel : ViewModelBase
{
    [ObservableProperty] private string hinhAnhSP;
    [ObservableProperty] private string tenSP;
    [ObservableProperty] private decimal giaSP;
    [ObservableProperty] private int soLuongSP;
    [ObservableProperty] private ObservableCollection<SanPham> sanPhams = new();

    public ProductPageViewModel()
    {
        // Sample data for demonstration purposes                                                                                                                
        sanPhams.Add(new SanPham { MaSP = 1, TenSP = "Bánh mì", KichThuocSP = "M", SoLuongSP = 10, GiaSP = 100000, HinhAnhSP = $"D:\\HỌC TẬP\\IT008-Lập trình trực quan\\DoAn-IT008\\IT008-StoreManage\\Store\\Assets\\images\\Anh_Mau.png" });
        sanPhams.Add(new SanPham { MaSP = 2, TenSP = "Sữa tươi", KichThuocSP = "Đồ uống", SoLuongSP = 15, GiaSP = 30000, HinhAnhSP= "avares://Store/Assets/images/Anh_Mau2.png" });
        sanPhams.Add(new SanPham { MaSP = 1, TenSP = "Bánh mì", KichThuocSP = "M", SoLuongSP = 10, GiaSP = 100000, HinhAnhSP = "avares:\\D:\\HỌC TẬP\\IT008-Lập trình trực quan\\DoAn-IT008\\IT008-StoreManage\\Store\\Assets\\images\\Anh_Mau.png" });
        sanPhams.Add(new SanPham { MaSP = 2, TenSP = "Sữa tươi", KichThuocSP = "Đồ uống", SoLuongSP = 15, GiaSP = 30000, HinhAnhSP = "avares://Store/Assets/images/Anh_Mau2.png" });
        sanPhams.Add(new SanPham { MaSP = 1, TenSP = "Bánh mì", KichThuocSP = "M", SoLuongSP = 10, GiaSP = 100000, HinhAnhSP = $"D:\\HỌC TẬP\\IT008-Lập trình trực quan\\DoAn-IT008\\IT008-StoreManage\\Store\\Assets\\images\\Anh_Mau.png" });
        sanPhams.Add(new SanPham { MaSP = 2, TenSP = "Sữa tươi", KichThuocSP = "Đồ uống", SoLuongSP = 15, GiaSP = 30000, HinhAnhSP = "avares://Store/Assets/images/Anh_Mau2.png" });
    }
}