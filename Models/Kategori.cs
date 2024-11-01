using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Kategori
    {
        public string KategoriNamn { get; set; }


        public Kategori(string kategoriNamn)
        {
            KategoriNamn = kategoriNamn;
        }

        public Kategori()
        {

        }

        public override string ToString()
        {
            return KategoriNamn;
        }
    }
}
