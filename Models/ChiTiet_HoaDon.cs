using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models
{
    public class Chi_Tiet_HoaDon
    {
        public int      MaHD { get; set; }
        public int      MaSP { get; set; }
        public int      SoLuong { get; set; }
        public decimal  DonGia { get; set; }
        public int      KhuyenMai { get; set; }
        public decimal  ThanhTien { get; set; }
       
        public HoaDon HoaDon { get; set; }
        public SanPham SanPham { get; set; }
        public Chi_Tiet_HoaDon() { }
    }
}
