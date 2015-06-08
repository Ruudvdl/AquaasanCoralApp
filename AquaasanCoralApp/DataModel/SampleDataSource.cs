using MyToolkit.Multimedia;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Xml;
using Windows.Data.Json;
using Windows.Storage;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Web.Syndication;

// The data model defined by this file serves as a representative example of a strongly-typed
// model.  The property names chosen coincide with data bindings in the standard item templates.
//
// Applications may use this model as a starting point and build on it, or discard it entirely and
// replace it with something appropriate to their needs. If using this model, you might improve app 
// responsiveness by initiating the data loading task in the code behind for App.xaml when the app 
// is first launched.

namespace AquaasanCoralApp.Data
{
    /// <summary>
    /// Generic item data model.
    /// </summary>
    public class Dealer
    {
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Uri { get; set; }

    }

    public class YoutubeVideo
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string PubDate { get; set; }
        public Uri YoutubeLink { get; set; }
        public Uri VideoLink { get; set; }
        public Uri ImagePath { get; set; }
    }

    /// <summary>
    /// Creates a collection of groups and items with content read from a static json file.
    /// 
    /// SampleDataSource initializes with data read from a static json file included in the 
    /// project.  This provides sample data at both design-time and run-time.
    /// </summary>
    public sealed class SampleDataSource
    {
        private async Task<ObservableCollection<YoutubeVideo>> GetYoutubeChannel(string url)
        {
            try
            {
                HttpClient client = new HttpClient();
                var feedXML = await client.GetStringAsync(new Uri(url));
                //StringReader stringReader = new StringReader(feedXML);

                //XmlReader xmlReader = XmlReader.Create(stringReader);
                SyndicationFeed feed = new SyndicationFeed();
                feed.Load(feedXML);
                ObservableCollection<YoutubeVideo> videosList = new ObservableCollection<YoutubeVideo>();
                YoutubeVideo video;
                foreach (SyndicationItem item in feed.Items)
                {
                    video = new YoutubeVideo();

                    video.YoutubeLink = item.Links[0].Uri;
                    string a = video.YoutubeLink.ToString().Remove(0, 31);
                    video.Id = a.Substring(0, 11);
                    video.Title = item.Title.Text;
                    video.PubDate = item.PublishedDate.DateTime.ToString("dd-mm-yyyy");

                    video.ImagePath = YouTube.GetThumbnailUri(video.Id, YouTubeThumbnailSize.Small);

                    videosList.Add(video);
                }

                return videosList;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
        }
        public ObservableCollection<Dealer> Items { get; set; }
        public ObservableCollection<YoutubeVideo> YouTubeVideos { get; set; }

        public SampleDataSource()
        {
            YouTubeVideos = new ObservableCollection<YoutubeVideo>();
            FillYoutubeList();
            Items = new ObservableCollection<Dealer>();

            var AquaMedic = new Dealer(){Title = "Aqua Medic", ImagePath="Assets/aquamedicc.png", Uri ="http://www.aqua-medic.de/"};
            var RedSea = new Dealer(){Title = "Red Sea", ImagePath="Assets/redsea.png", Uri ="http://www.redseafish.com/"};
            var CaribSea = new Dealer(){Title = "CaribSea", ImagePath="Assets/caribsea.png", Uri ="http://www.caribsea.com/"};
            var TritonLab = new Dealer() { Title = "TritonLab", ImagePath = "Assets/triton.png", Uri = "http://www.triton-lab.de/" };

            var Vertex = new Dealer(){Title = "Vertex Aquaristik", ImagePath="Assets/vertex.png", Uri ="http://www.vertexaquaristik.com/"};
            var GieseMann = new Dealer() { Title = "Giesemann", ImagePath = "Assets/giesemann.jpg", Uri = "http://www.giesemann.de/11,2,,.html" };
            var DD = new Dealer() { Title = "D-D The Aquarium Solution", ImagePath = "Assets/dd.png", Uri = "http://www.theaquariumsolution.com/" };
            var Salifert = new Dealer() { Title = "Salifert", ImagePath = "Assets/salifert.jpg", Uri = "http://salifert.com/" };

            var Eheim = new Dealer() { Title = "Eheim", ImagePath = "Assets/triton.png", Uri = "https://www.eheim.com/en_GB/home" };
            var Elos = new Dealer() { Title = "Elos", ImagePath = "Assets/vertex.png", Uri = "http://www.elos.eu/" };
            var DsrReefing = new Dealer() { Title = "DSR Reefing", ImagePath = "Assets/dsr.jpg", Uri = "http://www.dsrreefing.nl/full_dsr.html" };
            var Grotech = new Dealer() { Title = "Grotech", ImagePath = "Assets/grotech.jpg", Uri = "http://www.grotech-aquarientechnik.de/" };

            var Jebao = new Dealer() { Title = "Jebao", ImagePath = "Assets/jebao.jpg", Uri = "http://www.caribsea.com/" };
            var KorallenZucht = new Dealer() { Title = "Korallen-Zucht", ImagePath = "Assets/koraal.png", Uri = "http://www.korallen-zucht.de/" };
            var DeJongMarinelife = new Dealer() { Title = "De Jong Marine Life", ImagePath = "Assets/dejong.png", Uri = "http://www.dejongmarinelife.nl/" };
            var Tunze = new Dealer() { Title = "Tunze", ImagePath = "Assets/tunze.jpg", Uri = "http://tunze.com/" };

            var RiffSystem = new Dealer() { Title = "RiffSystem", ImagePath = "Assets/riffkeramik.jpg", Uri = "http://www.riffkeramik.de/" };
            var Cristallo = new Dealer() { Title = "Cristallo Aquariums", ImagePath = "Assets/cristallo.jpg", Uri = "http://www.cristalloaquariumbouw.nl/info/home.html" };
            var Ati = new Dealer() { Title = "ATI", ImagePath = "Assets/atia.jpg", Uri = "http://atiaquaristik.com/de/" };
            var Ams = new Dealer() { Title = "AMS", ImagePath = "Assets/aquamarinesupply.png", Uri = "http://www.aquamarinesupply.be/index.php?action=home&lang=NL" };


            Items.Add(AquaMedic);
            Items.Add(RedSea);
            Items.Add(CaribSea);
            Items.Add(TritonLab);
            Items.Add(Vertex);
            Items.Add(GieseMann);
            Items.Add(DD);
            Items.Add(Salifert);
            Items.Add(Eheim);
            Items.Add(Elos);

            Items.Add(DsrReefing);
            Items.Add(Grotech);
            Items.Add(Jebao);
            Items.Add(KorallenZucht);
            Items.Add(DeJongMarinelife);
            Items.Add(Tunze);
            Items.Add(RiffSystem);
            Items.Add(Cristallo);
            Items.Add(Ati);
            Items.Add(Ams);

        }

        private async void FillYoutubeList()
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                string YoutubeChannel = "Aquaasan";
                int index = 1;
                int max_results = 50;
                var temp = await GetYoutubeChannel("http://gdata.youtube.com/feeds/base/users/" + YoutubeChannel + "/uploads?alt=rss&v=2&orderby=published&start-index=" + index + "&max-results=" + max_results);
                foreach(var vid in temp)
                {
                    YouTubeVideos.Add(vid);
                }
                //YouTubeVideos = await GetYoutubeChannel("https://www.youtube.com/user/Aquaasan/videos");
            }
        }
    }
}