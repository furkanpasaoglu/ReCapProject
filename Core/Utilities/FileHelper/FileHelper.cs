using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.FileHelper
{
    public class FileHelper
    {
        public static string SaveImageFile(string extension)
        {
            string resimUzantisi = Path.GetExtension(extension); 
            string yeniResimAdi = string.Format("{0}{1}", Guid.NewGuid().ToString("D"), resimUzantisi);
            string imageKlasoru = Path.Combine("wwwroot", "Images");
            string tamResimYolu = Path.Combine(imageKlasoru, yeniResimAdi); 
            string webResimYolu = string.Format("/Images/{0}", yeniResimAdi);
            if(!Directory.Exists(imageKlasoru))
                Directory.CreateDirectory(imageKlasoru);

            using (var fileStream = File.Create(tamResimYolu))
            {
                fileStream.CopyTo(fileStream);
                fileStream.Flush();
            }
            return webResimYolu;
        }

        public static bool DeleteImageFile(string fileName)
        {
            string fullPath = Path.Combine(fileName);
            if (File.Exists("wwwroot"+fullPath))
            {
                File.Delete("wwwroot"+fullPath);
                return true;
            }
            return false;
        }
    }
}