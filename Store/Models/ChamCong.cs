using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models
{
    public class ChamCong
    {
        public int      MaCC { get; set; }
        public DateOnly Ngay { get; set; }
        public TimeOnly GioVao { get; set; }
        public TimeOnly GioRa { get; set; }
        public int      MaUser { get; set; }
        public bool     TrangThai { get; set; }
        public int      MaCa { get; set; }
        public User User { get; set; }
        public CaLam CaLam { get; set; }
        public ChamCong() { }
    }
}
