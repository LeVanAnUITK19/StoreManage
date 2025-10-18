using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models
{
    public class HoaDon
    {
        public int      MaHD { get; set; }
        public DateTime NgayLapHD { get; set; }
        public decimal  TongTienHD { get; set; }
        public decimal  GiamGiaHD { get; set; }
        public int      MaKH { get; set; }
        public int      MaUser { get; set; }
        public int      SoHD { get; set; }
        public string   TrangThaiHD { get; set; }

        //Thêm tạm
        public string TenKH { get; set; } 
        public HoaDon() { }
    }
}
