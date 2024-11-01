
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;
using DAL;
using System.Xml.Linq;

namespace BL
{
    public class PodcastController
    {

        private readonly PodcastRepository podcastRepository;
        private List<Podcast> poddLista;


        public PodcastController(PodcastRepository repo)
        {
            podcastRepository = repo;
            poddLista = podcastRepository.GetAll();
        }

        public List<Podcast> HamtaPodcast()
        {
            return podcastRepository.GetAll();
        }

        public void AddPodcast(Podcast podcast)
        {
            if (podcast != null)
            {
                podcastRepository.Add(podcast);
                SavePodcast(poddLista);
            }

        }

        public void UpdatePodcast(Podcast theNewObject)
        {
            if (theNewObject != null)
            {
                podcastRepository.Update(theNewObject);
                SavePodcast(poddLista);
            }
        }

        public void DeletePodcast(Podcast theObject)
        {
            podcastRepository.Delete(theObject);
        }

        public void SavePodcast(List<Podcast> theObject)
        {
            podcastRepository.SparaData(poddLista);
        }

        public DateTime HamtaSenasteAvsnittDatum(Podcast podcast)
        {
            return podcast.SenasteAvsnittsdatum;
        }

        public void LaggTillAvsnittTillPodcast(Podcast podcast, Avsnitt avsnitt)
        {
            if (podcast != null && avsnitt != null)
            {
                podcast.avsnittLista.Add(avsnitt);
                SavePodcast(poddLista);
            }

        }

    }
}
