using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Store.Models;
using Store.Services;
using Store.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;


namespace Store.ViewModels
{
    public partial class CreateProductWindowViewModel : ViewModelBase
    {
        [ObservableProperty] private string maSP;
        [ObservableProperty] private string tenSP;
        [ObservableProperty] private decimal giaSP;
        [ObservableProperty] private int soLuongSP;
        [ObservableProperty] private string loaiSP;
        [ObservableProperty] private string kichThuocSP;
        [ObservableProperty] private string moTaSP;
        [ObservableProperty] private string hinhAnhDuongDan;
        public ObservableCollection<string> DanhSachLoaiSP { get; } = new()
        {
            "Quần ngắn",
            "Quần dài",
            "Áo bà ba",
            "Khác"
        };
        public ObservableCollection<string> DanhSachKichThuocSP { get; } = new()
        {
            "M",
            "L",
            "XL",
            "XXL",
            "FreeSize"
        };
        public CreateProductWindowViewModel()
        {
            // Tự động tạo mã sản phẩm ban đầu
            MaSP = SanPhanService.GenerateNewMaSP();
        }

        [RelayCommand]
        private void TaoSanPham()
        {
            try
            {
                var sanPham = new SanPham
                {
                    MaSP = MaSP,
                    TenSP = TenSP,
                    GiaSP = GiaSP,
                    SoLuongSP = SoLuongSP,
                    LoaiSP = LoaiSP,
                    KichThuocSP = KichThuocSP,
                    MoTaSP = MoTaSP,
                    HinhAnhSP = null, // Có thể sau này bạn sẽ load từ file
                };
                SanPhanService.InsertSanPham(sanPham);
                // Sau khi thêm thành công
                System.Diagnostics.Debug.WriteLine($"Đã thêm sản phẩm: {TenSP}");
                // Reset form
                TenSP = "";
                GiaSP = 0;
                SoLuongSP = 0;
                LoaiSP = "";
                KichThuocSP = "";
                MoTaSP = "";
                HinhAnhDuongDan = "";
                MaSP = SanPhanService.GenerateNewMaSP(); // tạo mã mới cho lần tiếp theo
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi khi tạo sản phẩm: {ex.Message}");
            }
        }
        [RelayCommand]
        public async Task OpenFileImage()
        {
            // Tạo FileDialog
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filters.Add(new FileDialogFilter() { Name = "Images", Extensions = { "png", "jpg", "jpeg", "bmp" } });
            openFileDialog.AllowMultiple = false;

            // Lấy Window hiện tại
            var window = App.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop
                ? desktop.MainWindow
                : null;

            if (window != null)
            {
                var result = await openFileDialog.ShowAsync(window);
                if (result != null && result.Length > 0)
                {
                    HinhAnhDuongDan = result[0]; // Lưu đường dẫn vào property
                }
            }
        }
       
    }
}
