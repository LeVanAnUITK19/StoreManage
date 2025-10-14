using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models
{
    public class Chat
    {
        public int ChatId { get; set; }
        public int NguoiGuiId { get; set; }
        public int NguoiNhanId { get; set; }
        public string NoiDung {  get; set; }
    }
}
