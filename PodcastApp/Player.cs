using BL;
using DAL;
using Models;
using System;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Timers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace PodcastApp
{
    public partial class Player : System.Windows.Forms.Form
    {
        private PodcastController podcastController;
        private KategoriController kategoriController;
        private List<Kategori> kategoriLista;
        private List<Podcast> poddLista;
        private Validering validering;
        private System.Timers.Timer rssTimer;



        public Player()
        {
            InitializeComponent();

            rssTimer = new System.Timers.Timer();
            rssTimer.Elapsed += KollaEfterSenasteAvsnitt; 
            rssTimer.AutoReset = true; 
            rssTimer.Enabled = false; 

            comboBoxFilterFrekvens.Items.Add("1 minut");
            comboBoxFilterFrekvens.Items.Add("5 minuter");
            comboBoxFilterFrekvens.Items.Add("10 minuter");



            var serializer = new SerializeringsKlass();
            var podcastRepository = new PodcastRepository(serializer);
            var kategoriRepository = new KategoriRepository(serializer);


            podcastController = new PodcastController(podcastRepository);
            kategoriController = new KategoriController(kategoriRepository);
            validering = new Validering();




        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            poddLista = podcastController.HamtaPodcast();

            listView1.Items.Clear(); 
            foreach (var podcast in poddLista)
            {
                var item = new ListViewItem(podcast.Rubrik);
                item.SubItems.Add(podcast.Kategori);
                item.SubItems.Add(podcast.Uppdateringsfrekvens.ToString() + " minuter");
                item.SubItems.Add(podcast.avsnittLista.Count.ToString());
                listView1.Items.Add(item);
            }

            MessageBox.Show("Podcastlistan har uppdaterats!", "Uppdatering");
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void Form1_Load(object sender, EventArgs e)
        {

            poddLista = podcastController.HamtaPodcast();
            kategoriLista = kategoriController.HamtaKategori();


            foreach (var kategori in kategoriLista)
            {
                listBoxListaAvKategori.Items.Add(kategori);
                comboBoxFilterKategori.Items.Add(kategori);
            }


            foreach (var podcast in poddLista)
            {
                var item = new ListViewItem(podcast.Rubrik);
                item.SubItems.Add(podcast.Kategori);
                item.SubItems.Add(podcast.Uppdateringsfrekvens.ToString() + " minuter");
                item.SubItems.Add(podcast.avsnittLista.Count.ToString());
                listView1.Items.Add(item);
            }

        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            string rssUrl = textBoxUrl.Text;
            string poddNamn = textBoxNamnRuta.Text;

            if (string.IsNullOrEmpty(rssUrl) || string.IsNullOrEmpty(poddNamn))
            {
                MessageBox.Show("Fyll i både podcastens namn och RSS-URL.", "Varning");
                return;
            }

            if (!validering.IsUrlValid(rssUrl))
            {
                MessageBox.Show("Rss länken är felaktig");
                return;
            }

            if (!validering.ArPoddDubbel(poddNamn, poddLista))
            {
                MessageBox.Show("Podden med det namnet finns redan. Vänligen ange ett unikt namn.", "Fel");
                return;
            }


            if (listBoxListaAvKategori.SelectedItem == null)
            {
                MessageBox.Show("Välj en kategori.");
                return;
            }

            string valdKategori = listBoxListaAvKategori.SelectedItem.ToString();
            var kategori = kategoriLista.FirstOrDefault(k => k.KategoriNamn.Equals(valdKategori, StringComparison.OrdinalIgnoreCase));

            if (kategori == null)
            {
                MessageBox.Show("Kategorin kunde inte hittas.", "Fel");
                return;
            }

            int uppdateringsfrekvens = 1;
            if (comboBoxFilterFrekvens.SelectedItem != null)
            {
                switch (comboBoxFilterFrekvens.SelectedItem.ToString())
                {
                    case "1 minut":
                        uppdateringsfrekvens = 1;
                        break;
                    case "5 minuter":
                        uppdateringsfrekvens = 5;
                        break;
                    case "10 minuter":
                        uppdateringsfrekvens = 10;
                        break;
                }
            }

            try
            {

                Podcast syndicationFeed = await GetRss.HamtaPoddAsync(rssUrl, kategori);


                var podcast = new Podcast
                {
                    Rubrik = poddNamn,
                    RssUrl = rssUrl,
                    Kategori = valdKategori,
                    avsnittLista = syndicationFeed.avsnittLista,
                    Uppdateringsfrekvens = uppdateringsfrekvens
                };


                podcastController.AddPodcast(podcast);
                podcastController.SavePodcast(poddLista);


                var item = new ListViewItem(podcast.Rubrik);
                item.SubItems.Add(valdKategori);
                item.SubItems.Add(uppdateringsfrekvens + " minuter");
                item.SubItems.Add(podcast.avsnittLista.Count.ToString());
                listView1.Items.Add(item);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ett fel har uppstått: " + ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            textBoxUrl.Clear();
        }



        private void button3_Click(object sender, EventArgs e)
        {
            string kategoriNamn = textBoxKategroiRuta.Text;
            Kategori nyKategori = new Kategori(kategoriNamn);


            if (!string.IsNullOrEmpty(kategoriNamn) && !kategoriLista.Contains(nyKategori))
            {
                kategoriLista.Add(nyKategori);
                listBoxListaAvKategori.Items.Add(nyKategori);
                comboBoxFilterKategori.Items.Add(nyKategori);

                textBoxKategroiRuta.Clear();
                kategoriController.SaveListKategori(kategoriLista);

            }
            else
            {
                MessageBox.Show("Kategorin är antingen tom eller finns redan i listan.");
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (listBoxListaAvKategori.SelectedItem is Kategori kategori)
            {
               
                var result = MessageBox.Show($"Vill du verkligen ta bort kategorin '{kategori.KategoriNamn}'?",
                                              "Bekräfta borttagning",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);


                if (result == DialogResult.Yes)
                {

                    kategoriController.Delete(kategori);


                    kategoriLista.Remove(kategori);


                    kategoriController.SaveListKategori(kategoriLista);


                    listBoxListaAvKategori.Items.Clear();
                    foreach (var kat in kategoriLista)
                    {
                        listBoxListaAvKategori.Items.Add(kat);
                    }

                    MessageBox.Show("Kategorin har tagits bort.");
                }
            }
            else
            {
                MessageBox.Show("Välj en kategori att ta bort.");
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0 && !string.IsNullOrWhiteSpace(textBoxNamnRuta.Text))
            {
                var selectedItem = listView1.SelectedItems[0];
                string valtFlodeNamn = selectedItem.Text;

                var flode = poddLista.FirstOrDefault(p => p.Rubrik == valtFlodeNamn);
                if (flode != null)
                {
                    string nyttFlodeNamn = textBoxNamnRuta.Text.Trim();

                    flode.Rubrik = nyttFlodeNamn;

                    selectedItem.Text = nyttFlodeNamn;

                    podcastController.SavePodcast(poddLista);

                    textBoxNamnRuta.Clear();
                    MessageBox.Show("Flödesnamnet har uppdaterats!");
                }
                else
                {
                    MessageBox.Show("Det valda flödet kunde inte hittas.");
                }
            }
            else
            {
                MessageBox.Show("Välj ett flöde och ange ett nytt namn.");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count > 0)
            {

                var selectedItem = listView1.SelectedItems[0];
                string valdPoddRubrik = selectedItem.Text;


                var podden = poddLista.FirstOrDefault(p => p.Rubrik == valdPoddRubrik);

                if (podden == null)
                {
                    MessageBox.Show("Podden kunde inte hittas.", "Fel");
                    return;
                }

                if (listBoxListaAvKategori.SelectedItem == null)
                {
                    MessageBox.Show("Välj en ny kategori.", "Fel");
                    return;
                }


                var nyKategori = listBoxListaAvKategori.SelectedItem as Kategori;


                podden.Kategori = nyKategori.KategoriNamn;


                podcastController.SavePodcast(poddLista);


                selectedItem.SubItems[1].Text = nyKategori.KategoriNamn;

                MessageBox.Show("Kategorin har uppdaterats.");
            }
            else
            {
                MessageBox.Show("Välj en podd för att ändra kategori.");
            }
        }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBoxListaOverAvsnitt_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listBoxListaOverAvsnitt.SelectedItems.Count > 0 && listView1.SelectedItems.Count > 0)
            {

                var selectedItem = listView1.SelectedItems[0];
                string valdPodd = selectedItem.Text;


                var podden = poddLista.FirstOrDefault(p => p.Rubrik == valdPodd);
                if (podden != null)
                {

                    var valdAvsnitt = podden.avsnittLista.FirstOrDefault(a => a.Rubrik == listBoxListaOverAvsnitt.SelectedItem.ToString());
                    if (valdAvsnitt != null)
                    {

                        textBoxBeskrivning.Text = valdAvsnitt.Beskrivning;
                    }
                }
            }
        }



        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {

                var selectedItem = listView1.SelectedItems[0];
                string valtFlodeNamn = selectedItem.Text;


                var podd = poddLista.FirstOrDefault(p => p.Rubrik == valtFlodeNamn);

                if (podd != null)
                {
                    listBoxListaOverAvsnitt.Items.Clear();

                    List<Avsnitt> avsnittLista = podd.avsnittLista;
                    foreach (var avsnitt in avsnittLista)
                    {
                        listBoxListaOverAvsnitt.Items.Add(avsnitt.Rubrik);
                    }
                }
                else
                {
                    MessageBox.Show("Det valda objektet kunde inte hittas i flödeslistan.");
                }
            }
        }

        private void comboBoxFilterKategori_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (comboBoxFilterKategori.SelectedItem != null)
            {

                string valdKategori = comboBoxFilterKategori.SelectedItem.ToString();


                var filteradePoddar = poddLista
                    .Where(p => p.Kategori == valdKategori)
                    .ToList();


                listView1.Items.Clear();


                foreach (var podcast in filteradePoddar)
                {
                    var item = new ListViewItem(podcast.Rubrik);
                    item.SubItems.Add(podcast.Kategori);
                    item.SubItems.Add(podcast.Uppdateringsfrekvens.ToString() + " minuter");
                    item.SubItems.Add(podcast.avsnittLista.Count.ToString());
                    listView1.Items.Add(item);
                }
            }
        }

        private void comboBoxFilterFrekvens_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (comboBoxFilterFrekvens.SelectedItem != null)
            {
                int selectedFrequency = 0;

                switch (comboBoxFilterFrekvens.SelectedItem.ToString())
                {
                    case "1 minut":
                        selectedFrequency = 1;
                        break;
                    case "5 minuter":
                        selectedFrequency = 5;
                        break;
                    case "10 minuter":
                        selectedFrequency = 10;
                        break;
                    default:
                        rssTimer.Stop(); 
                        return; 
                }

                
                FiltreraPoddMedFrekvens(selectedFrequency);

          
                StartTimer(selectedFrequency);
            }
            else
            {
                rssTimer.Stop(); 
            }
        }


        private void StartTimer(int intervalInMinutes)
        {
            rssTimer.Interval = intervalInMinutes * 60 * 1000; 
            rssTimer.Start();
        }

        private void KollaEfterSenasteAvsnitt(object sender, ElapsedEventArgs e)
        {
            foreach (var podd in podcastController.HamtaPodcast())
            {
                DateTime latestEpisodeDate = podcastController.HamtaSenasteAvsnittDatum(podd); 

                if (latestEpisodeDate > podd.SenasteAvsnittsdatum)
                {
                    podd.SenasteAvsnittsdatum = latestEpisodeDate;

                    Invoke((MethodInvoker)delegate
                    {
                        MessageBox.Show($"Nytt avsnitt tillgängligt i {podd.Rubrik}!");

                    });
                }
            }
        }

        private void FiltreraPoddMedFrekvens(int frekvens)
        {
            var filteredPodcasts = poddLista.Where(p => p.Uppdateringsfrekvens == frekvens).ToList();

            listView1.Items.Clear();

            foreach (var podcast in filteredPodcasts)
            {
                var item = new ListViewItem(podcast.Rubrik);
                item.SubItems.Add(podcast.Kategori);
                item.SubItems.Add(podcast.Uppdateringsfrekvens + " minuter");
                item.SubItems.Add(podcast.avsnittLista.Count.ToString());
                listView1.Items.Add(item);
            }
        }

        private void PodcastApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            podcastController.SavePodcast(poddLista);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


    }
}


