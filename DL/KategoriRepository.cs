using DL;
using Models;
using System;
using System.Collections.Generic;

namespace DAL
{
    public class KategoriRepository : IRepository<Kategori>
    {
        private readonly SerializeringsKlass serializer;
        private List<Kategori> kategoriLista;

        public KategoriRepository(SerializeringsKlass serializeringsKlass)
        {
            serializer = serializeringsKlass;
            List<Kategori> kategoriLista;
        }

        public void Add(Kategori theObject)
        {
            kategoriLista.Add(theObject);
            SparaData(kategoriLista);
        }

        public void Update(Kategori theNewObject)
        {
            var updateKategori = kategoriLista.FirstOrDefault(k => k.KategoriNamn.Equals(theNewObject.KategoriNamn));
            SparaData(kategoriLista);
        }

        public void Delete(Kategori kategori)
        {
            kategoriLista.Remove(kategori);
            SparaData(kategoriLista);
        }

        public void UpdateKategori(Kategori theObject)
        {
            var existingKategori = kategoriLista.FirstOrDefault(p => p.KategoriNamn == theObject.KategoriNamn);

            if (existingKategori != null)
            {
                existingKategori.KategoriNamn = theObject.KategoriNamn;
                SparaData(kategoriLista);
            }
        }

        public List<Kategori> GetAll()
        {
            kategoriLista = serializer.DeserializeKategorier();
            return kategoriLista;
        }

        public void SparaData(List<Kategori> kategori)
        {
            serializer.SerializeKategori(kategoriLista);
        }
    }
}
