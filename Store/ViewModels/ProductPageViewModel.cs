using Avalonia;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Store.Models;
using Store.Services;
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
        }
    }
}
