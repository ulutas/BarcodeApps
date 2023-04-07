using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using BarcodeLib;
using ZXing;
using System.Drawing;
using Image = System.Drawing.Image;

namespace BarcodeApps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Barkod yazdırmak için metni girin: ");
            string text = Console.ReadLine();

            writeBarcode(text);
            readBarcode();
        }

        static void writeBarcode(string word)
        {
            Barcode barcode = new Barcode();

            Image img = barcode.Encode(TYPE.CODE128, word); //Barkodu resme dönüştürme

            Bitmap bmp = new Bitmap(img);// Barkod resmini Bitmap'e dönüştürme

            string filePath = @"C:\Users\GO\source\repos\BarcodeApps\BarcodeApps\barcode" + DateTime.Now.ToString("ddMMyyyy") + ".png";

            bmp.Save(filePath);// Barkodu dosyaya kaydetme
        }

        static void readBarcode()
        {

            BarcodeReader barcodeReader = new BarcodeReader(); // Barkod okuyucu nesnesi oluşturma

            barcodeReader.Options.TryHarder = true; //Daha doğru okuma için

            var barcodeBitMap = new Bitmap(@"C:\Users\GO\source\repos\BarcodeApps\BarcodeApps\barcode" + DateTime.Now.ToString("ddMMyyyy") + ".png");

            var result = barcodeReader.Decode(barcodeBitMap); // Barkodu okuma

            if (result != null) // Eğer barkod okunamazsa sonuç null olacaktır
                Console.WriteLine("Barkod içeriği: " + result.Text);
            else
                Console.WriteLine("Barkod okunamadı.");


            // Konsol penceresini açık tutmak için
            Console.ReadKey();
        }
    }
}
