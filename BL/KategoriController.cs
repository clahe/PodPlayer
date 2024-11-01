using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class KategoriController
    {
        private readonly KategoriRepository kategoriRepository;
        private List<Kategori> kategoriLista = new List<Kategori>();

        public KategoriController(KategoriRepository repo)
        {
            kategoriRepository = repo;

        }

        public List<Kategori> HamtaKategori()
        {
            return kategoriRepository.GetAll();
        }

        public void SaveListKategori(List<Kategori> kategorier)
        {
            kategoriRepository.SparaData(kategorier);
        }

        public void AddKategori(Kategori kategori)
        {
            kategoriLista.Add(kategori);
            SaveListKategori(kategoriLista);
        }

        public void Update(Kategori kategori)
        {
            kategoriRepository.UpdateKategori(kategori);
        }

        public void Delete(Kategori theObject)
        {
            if (kategoriLista.Remove(theObject))
            {
                SaveListKategori(kategoriLista);
            }

        }


    }

}
