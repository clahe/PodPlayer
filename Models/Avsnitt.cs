using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Avsnitt
    {
        public int Id { get; set; }

        public string Rubrik { get; set; }
        public string Namn { get; set; }

        public string Beskrivning { get; set; }

        public DateTimeOffset Publiceringsdatum { get; set; }



        public Avsnitt(string beskrivning) { }

        public Avsnitt() { }
    }
}
