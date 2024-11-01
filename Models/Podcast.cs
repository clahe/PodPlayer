using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Podcast
    {

        public string Rubrik { get; set; }

        public string Beskrivning { get; set; }

        public string Kategori { get; set; }

        public string Id { get; set; }

        public string RssUrl { get; set; }

        public int AntalAvsnitt { get; set; }

        public string Titel { get; set; }
        public int Uppdateringsfrekvens { get; set; }

        public DateTime SenasteAvsnittsdatum { get; set; }
        public List<Avsnitt> avsnittLista { get; set; } = new List<Avsnitt>();



        public Podcast(string rubrik, string beskrivning, string rssUrl, string kategori, int uppdateringsfrekvens, int antalAvsnitt)
        {
            Rubrik = rubrik;
            Beskrivning = beskrivning;
            RssUrl = rssUrl;
            Kategori = kategori;
            Uppdateringsfrekvens = Uppdateringsfrekvens;
            AntalAvsnitt = antalAvsnitt;
        }




        public Podcast(string rubrik, string beskrivning, string id, int antal, string kategori, string rssURL, string titel)
        {
            Rubrik = rubrik;
            Beskrivning = beskrivning;
            Id = id;
            Kategori = kategori;
            RssUrl = rssURL;
            Titel = titel;

        }

        public Podcast()
        {
            avsnittLista = new List<Avsnitt>();

        }


    }
}
