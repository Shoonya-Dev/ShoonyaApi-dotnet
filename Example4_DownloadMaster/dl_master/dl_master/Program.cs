using System.Net;
using System.IO;
using System.IO.Compression;
using System;

namespace dl_master
{
    class Program
    {
        static void DownloadFile(string url)
        {
            var file = Path.GetFileName(url);
            Console.WriteLine($"Downloading {file} from {url}");
            try
            { 
                using (var client = new WebClient())
                {
                    client.DownloadFile(url, file);
                    ZipFile.ExtractToDirectory(file, Directory.GetCurrentDirectory());

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        static void Main(string[] args)
        {
            string[] masters = new string[4];
            masters[0] = "https://api.shoonya.com/NSE_symbols.txt.zip";
            masters[1] = "https://api.shoonya.com/NFO_symbols.txt.zip";
            masters[2] = "https://api.shoonya.com/CDS_symbols.txt.zip";
            masters[3] = "https://api.shoonya.com/MCX_symbols.txt.zip";
            masters[4] = "https://api.shoonya.com/BSE_symbols.txt.zip";
            masters[5] = "https://api.shoonya.com/BFO_symbols.txt.zip";

            foreach(var master in masters)
                DownloadFile(master);

            Console.ReadLine();
        }
    }
}
