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
            
           
        }
    }
}
