using CommunityToolkit.Mvvm.ComponentModel;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Views;
using Store.Models;

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

        public CreateBillWindowViewModel()
        {
            // Thêm dữ liệu mẫu
            sanPhams.Add(new SanPham { MaSP = 1, TenSP = "Bánh mì", KichThuocSP = "M", SoLuongSP = 10, GiaSP = 100000 });
            sanPhams.Add(new SanPham { MaSP = 2, TenSP = "Sữa tươi", KichThuocSP = "Đồ uống", SoLuongSP = 15, GiaSP = 30000 });
            sanPhams.Add(new SanPham { MaSP = 3, TenSP = "Cà phê", KichThuocSP = "Đồ uống", SoLuongSP = 25, GiaSP = 50000 });
        }
    }
}
