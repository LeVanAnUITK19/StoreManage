using Avalonia;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Store.Models;
using Store.Views;
using System;
using System.Collections.ObjectModel;

namespace Store.ViewModels
{
    public partial class ProductPageViewModel : ViewModelBase
    {
        [ObservableProperty] private Bitmap hinhAnhSP;
        [ObservableProperty] private string tenSP;
        [ObservableProperty] private decimal giaSP;
        [ObservableProperty] private int soLuongSP;
        [ObservableProperty] private ObservableCollection<SanPham> sanPhams = new();

        public ProductPageViewModel()
        {

            
                sanPhams.Add(new SanPham
                {
                    MaSP = "SP001",
                    TenSP = "Bánh mì",
                    KichThuocSP = "M",
                    SoLuongSP = 10,
                    GiaSP = 100000,
                    HinhAnhSP = new Bitmap("D:\\HỌC TẬP\\IT008-Lập trình trực quan\\DoAn-IT008\\IT008-StoreManage\\Store\\Assets\\images\\Anh_Mau2.jpg")
                });
        }

        [RelayCommand]
        private void ThemSanPhamButton()
        {
            CreateProductWindowView createProductWindowView = new();
            createProductWindowView.Show();
        }
    }
}
