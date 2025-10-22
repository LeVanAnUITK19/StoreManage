using CommunityToolkit.Mvvm.ComponentModel;
using Store.Models;
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
   public partial class CreateBillWindowViewModel : ViewModelBase
    {
        [ObservableProperty] private string maSP;
        [ObservableProperty] private string tenSP;
        [ObservableProperty] private string kichThuocSP;
        [ObservableProperty] private int    soLuong;
        [ObservableProperty] private decimal giaSP;
        [ObservableProperty]
        private ObservableCollection<SanPham> sanPhams = new();

        [ObservableProperty]
        private ObservableCollection<KhachHang> danhSachKhachHang = new();
        [ObservableProperty]
        private ObservableCollection<SanPham> danhSachSanPham = new();

        [ObservableProperty]
        private KhachHang? khachHangDuocChon; 
        [ObservableProperty]
        private SanPham? sanPhamDuocChon; 


        public CreateBillWindowViewModel()
        {
            LoadKhachHang();
            LoadSanPham();
        }
        private void LoadKhachHang()
        {
            var ds = KhachHangService.GetAllKhachHang();
            danhSachKhachHang = new ObservableCollection<KhachHang>(ds);
        }
        private void LoadSanPham()
        {
            var ds1 = SanPhanService.GetAllSanPham();
            danhSachSanPham = new ObservableCollection<SanPham>(ds1);
        }
    }
}
