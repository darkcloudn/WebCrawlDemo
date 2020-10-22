using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawl
{
    class Truyen
    {
        String tacGia;
        String context;
        public Truyen()
        {
            
        }
        public Truyen(string tacGia, string context)
        {
            this.tacGia = tacGia;
            this.context = context;
        }

        public string TacGia { get => tacGia; set => tacGia = value; }
        public string Context { get => context; set => context = value; }
        
        public string toString()
        {
            return tacGia + "\n" + context;
        }

    }
}
