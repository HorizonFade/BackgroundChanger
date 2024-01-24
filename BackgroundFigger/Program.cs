using System;
using System.Net;
using System.Runtime.InteropServices;

namespace BackgroundFigger
{
    public class Program
    {
        const int SPI_SETDESKWALLPAPER = 20;
        const int SPIF_UPDATEINIFILE = 0x01;
        const int SPIF_SENDWININICHANGE = 0x02;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        static void Main(string[] args)
        {
            string imageUrl = GetAvailableWallpaper();
            string localPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
                "Wallpaper.jpg");
            if (!string.IsNullOrEmpty(imageUrl))
            { 
                 DownloadImage(imageUrl, localPath);
                 SetWallpaper(localPath);
                 Console.WriteLine("Wallpaper set successfully.");
            }
            else
            {
                Console.WriteLine("Invalid selection or wallpaper URL is empty.");
            }
            


            Console.ReadLine();
        }

        static void DownloadImage(string imageUrl, string localPath)
        {
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFile(imageUrl, localPath);
            }
        }

        static void SetWallpaper(string imagePath)
        {
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, imagePath, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }

        static string GetAvailableWallpaper()
        {
            string img1 = "https://i.ytimg.com/vi/hP0EFEaH7HM/maxresdefault.jpg";
            string img2 = "https://content1.promiflash.de/article-images/video_1080/olivia-jones-schaut-neutral.jpg";
            string img3 = "https://campus-springbreak.de/wp-content/uploads/2023/03/CSB23-MoneyBoy-Post-960x636.jpg";
            string img4 = "https://images5.alphacoders.com/134/1341364.png";
            string img5 = "https://i.redd.it/ceetrhas51441.jpg";
            string img6 = "https://i.kym-cdn.com/entries/icons/original/000/047/549/kurt_angle_meme.jpg";
            string img7 = "https://uploads.dailydot.com/d40/de/1128722a06dafd6c-e1496770911424.jpg";

            Console.WriteLine("a: geile Schnecke");
            Console.WriteLine("b: Transe");
            Console.WriteLine("c: Money Boy");
            Console.WriteLine("d: Snoop Dogg");
            Console.WriteLine("e: 2 BlackBoyz kissing (Inklusionsmeme)");
            Console.WriteLine("f: Suprise");
            Console.WriteLine("g: cruisin");
            string chosenPic = Console.ReadKey().KeyChar.ToString();
            switch (chosenPic)
            {
                case "a": return img1;
                case "c": return img2;
                case "d": return img3;
                case "e": return img4;
                case "f": return img5;
                case "g": return img6;
                case "h": return img7;
                default: return "";
            }

        }
    }
}

