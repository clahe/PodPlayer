using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Models;
using DAL;

namespace DAL
{
    public class SerializeringsKlass
    {
        private readonly string filePath = "Podcasts.xml";
        private readonly string kategoriFilePath = "Kategorier.xml";

        public void Serialize<T>(List<T> dataList, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(dataList.GetType());

            using (FileStream filestream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(filestream, dataList);
            }
        }

        public List<T> Deserialize<T>(string filePath)
        {
            if (!File.Exists(filePath)) return new List<T>(); // Skapa tom lista om fil saknas

            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            using (FileStream enFilestream = new FileStream(filePath, FileMode.Open))
            {
                return (List<T>)serializer.Deserialize(enFilestream);
            }
        }


        public void SerializePodcasts(List<Podcast> poddLista)
        {
            Serialize(poddLista, filePath);
        }

        public List<Podcast> DeserializePodcasts()
        {
            return Deserialize<Podcast>(filePath);
        }

        public void SerializeKategori(List<Kategori> kategoriLista)
        {
            Serialize(kategoriLista, kategoriFilePath);

        }

        public List<Kategori> DeserializeKategorier()
        {
            return Deserialize<Kategori>(kategoriFilePath);
        }
    }
}
