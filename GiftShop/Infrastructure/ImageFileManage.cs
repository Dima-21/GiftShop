using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GiftShop.Infrastructure
{
    public class ImageFileManage
    {
        public static void AddPicture(IEnumerable<IFormFile> images, string folderPath, string targetFolderName)
        {
            foreach (IFormFile image in images)
            {
                // путь к папке Files
                string path = $"\\{targetFolderName}\\" + image.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(folderPath + path, FileMode.Create))
                {
                    //await createModel.Images.First().CopyToAsync(fileStream);
                    image.CopyTo(fileStream);
                }
            }
        }

        public static void DeletePicture(string fileName, string folderPath, string targetFolderName)
        {
            // путь к папке Files
            string path = folderPath + $"\\{targetFolderName}\\" + fileName;

            // Удаляем картинку
            if (File.Exists(path))
                File.Delete(path);
        }

        public static bool EqualsImage(IFormFile image, string folderPath, string targetFolderName, string fileName)
        {
            string path = folderPath + $"\\{targetFolderName}\\" + fileName;

            if (!File.Exists(path))
                return false;

            var streamImage1 = image.OpenReadStream();
            var streamImage2 = File.OpenRead(path);
            bool equals = streamImage1.Length.Equals(streamImage2.Length) && image.FileName == fileName;
            streamImage1.Close();
            streamImage2.Close();


            return equals;
        }
    }
}
