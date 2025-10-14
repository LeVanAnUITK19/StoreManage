using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models
{
    public class User 
    {
        public int       MaUser { get; set; }
        public string    TenDangNhap { get; set; }
        public string    TenUser { get; set; }
        public string    MatKhau { get; set; }
        public string    EmailUser { get; set; }
        public string    SDTUser { get; set; }
        public string    DiaChiUser { get; set; }
        public string    GioiTinhUser { get; set; }
        public DateOnly  NgaySinhUser { get; set; }
        public string    HinhAnhUser { get; set; }
        public string    MaVT { get; set; }


        public  User() {}
    }
}
