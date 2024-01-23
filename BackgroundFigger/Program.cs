using System.Net;
using System.Runtime.InteropServices;

namespace BackgroundFigger
{
    public class Program
    {

        static String pathOfBg = @"P:\Desktop\Wallpaper.jpg";
        const int SPI_SETDESKWALLPAPER = 20;
        const int SPIF_UPDATEINIFILE = 0x01;
        const int SPIF_SENDWININICHANGE = 0x02;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
        static void chosePic()
        {
            Uri img1 = new Uri("https://i.ytimg.com/vi/hP0EFEaH7HM/maxresdefault.jpg");
            Uri img2 = new Uri("https://content1.promiflash.de/article-images/video_1080/olivia-jones-schaut-neutral.jpg");
            Uri img3 = new Uri("https://campus-springbreak.de/wp-content/uploads/2023/03/CSB23-MoneyBoy-Post-960x636.jpg");
            Uri img4 = new Uri("https://images5.alphacoders.com/134/1341364.png");
            Uri img5 = new Uri("https://i.redd.it/ceetrhas51441.jpg");
            Uri img6 = new Uri("https://i.kym-cdn.com/entries/icons/original/000/047/549/kurt_angle_meme.jpg");
            Uri img7 = new Uri("https://uploads.dailydot.com/d40/de/1128722a06dafd6c-e1496770911424.jpg");

            Uri finalIMG = null;

            //hier weitere Bildernamen eintragen
            Console.WriteLine("a: geile Schnecke");
            Console.WriteLine("b: Transe");
            Console.WriteLine("c: Money Boy");
            Console.WriteLine("d Snoop Dogg");
            Console.WriteLine("e: 2 BlackBoyz kissing (Inklusionsmeme)");
            Console.WriteLine("f: Suprise");
            Console.WriteLine("g: cruisin");
            char chosenPicKey = Console.ReadKey().KeyChar;

            //hier images ergänzen
            switch (chosenPicKey)
            {
                case 'a': finalIMG = img1; return;
                case 'c': finalIMG = img2; return;
                case 'd': finalIMG = img3; return;
                case 'e': finalIMG = img4; return;
                case 'f': finalIMG = img5; return;
                case 'g': finalIMG = img6; return;
                case 'h': finalIMG = img7; return;
                default: chosePic(); break;
            }
            
            Console.WriteLine(pathOfBg);
            WebClient wc = new WebClient();
            wc.DownloadFile(finalIMG, pathOfBg);


            int uAction = SPI_SETDESKWALLPAPER;
            int uParam = 0;
            int fuWinIni = SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE;
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, pathOfBg, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }
        static void Main(string[] args)
        {
            chosePic();
            Console.WriteLine("test");
            Console.ReadLine();
        }
    }
}
