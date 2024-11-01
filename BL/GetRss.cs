using DAL;
using Models;
using System.ServiceModel.Syndication;
using System.Xml;

public class GetRss
{
    private readonly SerializeringsKlass enSerializer;

    public GetRss(SerializeringsKlass serializer)
    {
        enSerializer = serializer;
    }

    public static async Task<Podcast> HamtaPoddAsync(string rssUrl, Kategori kategori)
    {
        try
        {
            using (XmlReader reader = XmlReader.Create(rssUrl))
            {
                SyndicationFeed feed = await Task.Run(() => SyndicationFeed.Load(reader));

                string poddNamn = feed.Title.Text;
                string beskrivning = feed.Description.Text;

                var podcast = new Podcast
                {
                    Rubrik = poddNamn,
                    RssUrl = rssUrl,
                    Beskrivning = beskrivning,
                    /*avsnittLista = new List<Avsnitt>()*/ // Initiera lista för avsnitt
                };

                // Lägg till avsnitt från RSS-flödet
                foreach (var item in feed.Items)
                {
                    podcast.avsnittLista.Add(new Avsnitt
                    {
                        Rubrik = item.Title.Text,
                        Beskrivning = item.Summary?.Text,
                        Publiceringsdatum = item.PublishDate
                    });
                }

                return podcast;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ett fel inträffade: {ex.Message}");
            throw new Exception("Misslyckades med att hämta podcastdata från RSS-flödet.", ex);
        }
    }
}


