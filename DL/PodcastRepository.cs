using DL;
using Models;
using System.Collections.Generic;

namespace DAL
{
    public class PodcastRepository : IRepository<Podcast>
    {
        private SerializeringsKlass serializer;
        private List<Podcast> poddLista;
        private List<Avsnitt> avsnittLita;

        public PodcastRepository(SerializeringsKlass serializeringsKlass)
        {
            serializer = serializeringsKlass;
            List<Podcast> poddLista;
            List<Avsnitt> avsnittLista;

        }

        public void Add(Podcast theObject)
        {
            poddLista.Add(theObject);
            SparaData(poddLista);
        }

        public void Update(Podcast theObject)
        {
            var existingPodcast = poddLista.FirstOrDefault(p => p.Id == theObject.Id);

            if (existingPodcast != null)
            {
                existingPodcast.Id = theObject.Id;
                SparaData(poddLista);
            }
        }

        public void Delete(Podcast theObject)
        {
            poddLista.Remove(theObject);
            SparaData(poddLista);
        }

        public List<Podcast> GetAll()
        {
            poddLista = serializer.DeserializePodcasts();
            return poddLista;

        }

        public void SparaData(List<Podcast> theObject)
        {
            serializer.SerializePodcasts(poddLista);
        }
    }
}
