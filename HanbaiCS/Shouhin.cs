using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanbaiCS
{
    class Shouhin
    {
        public int Sid { get; set; }
        public String Sname { get; set; }
        public int Tanka { get; set; }

        public Shouhin(int sid, string sname, int tanka)
        {
            Sid = sid;
            Sname = sname;
            Tanka = tanka;
        }
    }
}
