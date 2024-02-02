using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace BGFiggerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string imageUrls = "";
        const int SPI_SETDESKWALLPAPER = 20;
        const int SPIF_UPDATEINIFILE = 0x01;
        const int SPIF_SENDWININICHANGE = 0x02;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
        public MainWindow()
        {
            InitializeComponent();
            myListBox.ItemsSource = new List<string>()
            {
                "Geile Schnecke",
                "Tranny",
                "Money Boy",
                "Snoop Dogg",
                "2 Dudes Kissing",
                "Surprise",
                "Cruisin",
                "Inder Lore",
                "Merkel Döner",
                "Gay Indians"
            };

        }
        static void DownloadImage(string imageUrl, string localPath)
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    wc.DownloadFile(imageUrl, localPath);
                }
            }
            catch
            {
                MessageBox.Show("Please enter valid Link use .png or .jpg", "Wallpaper");
            }
        }

        static void SetWallpaper(string imagePath)
        {
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, imagePath, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }

        private void ChangeWallpaper_Click(object sender, RoutedEventArgs e)
        {
            string localPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
                "Wallpaper.jpg");

            if (!string.IsNullOrEmpty(imagePreview.Source.ToString()))
            {
                DownloadImage(imagePreview.Source.ToString(), localPath);
                SetWallpaper(localPath);
                MessageBox.Show("Wallpaper changed","Wallpaper");
            }
        }

        private void ChangeOwnWallpaper_Click(object sender, RoutedEventArgs e)
        {
            string localPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
                "Wallpaper.jpg");

            if (!string.IsNullOrEmpty(myTextBox.Text)&&(myTextBox.Text.EndsWith(".jpg")||myTextBox.Text.EndsWith(".png")))
            {
                DownloadImage(myTextBox.Text, localPath);
                SetWallpaper(localPath);
                MessageBox.Show("Wallpaper changed", "Wallpaper");
            }
            else
            {
                MessageBox.Show("Please enter valid Link use .png or .jpg", "Wallpaper");
            }
        }

        private void myListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string img1 = "https://i.ytimg.com/vi/hP0EFEaH7HM/maxresdefault.jpg";
            string img2 = "https://content1.promiflash.de/article-images/video_1080/olivia-jones-schaut-neutral.jpg";
            string img3 = "https://campus-springbreak.de/wp-content/uploads/2023/03/CSB23-MoneyBoy-Post-960x636.jpg";
            string img4 = "https://picstatio.com/large/lhrp9o/snoop-dogg-celebrity-rapper-hd-wallpaper.jpg";
            string img5 = "https://i.redd.it/ceetrhas51441.jpg";
            string img6 = "https://i.kym-cdn.com/entries/icons/original/000/047/549/kurt_angle_meme.jpg";
            string img7 = "https://uploads.dailydot.com/d40/de/1128722a06dafd6c-e1496770911424.jpg";
            string img8 = "https://i.ytimg.com/vi/xrkOdp5wUtQ/sddefault.jpg";
            string img9 = "https://pbs.twimg.com/media/EVlnkohWoAM1qrz.jpg";
            string img10 = "https://i.imgflip.com/3i2kpm.jpg";

            switch (myListBox.SelectedIndex)
            {
                case 0: imagePreview.Source = new BitmapImage(new Uri(img1)); break;
                case 1: imagePreview.Source = new BitmapImage(new Uri(img2)); break;
                case 2: imagePreview.Source = new BitmapImage(new Uri(img3)); break;
                case 3: imagePreview.Source = new BitmapImage(new Uri(img4)); break;
                case 4: imagePreview.Source = new BitmapImage(new Uri(img5)); break;
                case 5: imagePreview.Source = new BitmapImage(new Uri(img6)); break;
                case 6: imagePreview.Source = new BitmapImage(new Uri(img7)); break;
                case 7: imagePreview.Source = new BitmapImage(new Uri(img8)); break;
                case 8: imagePreview.Source = new BitmapImage(new Uri(img9)); break;
                case 9: imagePreview.Source = new BitmapImage(new Uri(img10)); break;
            }

        }

    }
}