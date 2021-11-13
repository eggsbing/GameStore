using GameStore.Core.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.Utilities.Extensions
{
    public class ThumbSize
    {
        private int _width, _height;

        public ThumbSize(int width, int height)
        {
            _width = width;
            _height = height;
        }
        public int Width => _width;
        public int Height => _height;
    }
    public static class UploadImageExtension
    {
        public static void AddImageToServer(this IFormFile image, string fileName, string orginalPath, ThumbSize thumbSize = null, string deletefileName = null)
        {
            string imagePath = Path.Combine(orginalPath, fileName);
            string imageThumbPath = Path.Combine(orginalPath, $"thumb_{fileName}");
            string deletePath = Path.Combine(orginalPath, deletefileName ?? "");
            string deleteThumbPath = Path.Combine(orginalPath, $"thumb_{deletefileName ?? ""}");

            if (image != null && image.IsImage())
            {
                if (!Directory.Exists(orginalPath))
                    Directory.CreateDirectory(orginalPath);

                if (!string.IsNullOrEmpty(deletefileName))
                {
                    if (File.Exists(deletePath))
                        File.Delete(deletePath);

                    if (File.Exists(deleteThumbPath))
                        File.Delete(deleteThumbPath);
                }

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    if (!Directory.Exists(imagePath))
                        image.CopyTo(stream);
                }

                if (thumbSize != null && thumbSize.Width > 50 && thumbSize.Height > 50)
                {
                    ImageOptimizer resizer = new ImageOptimizer();
                    resizer.ImageResizer(orginalPath + fileName, imageThumbPath, thumbSize.Width, thumbSize.Height);
                }
            }
        }

        public static void DeleteImage(this string deletefileName, string orginalPath)
        {
            string deletePath = Path.Combine(orginalPath, deletefileName);
            string deleteThumbPath = Path.Combine(orginalPath, $"thumb_{deletefileName}");

            if (!string.IsNullOrEmpty(deletePath))
            {
                if (File.Exists(deletePath))
                    File.Delete(deletePath);

                if (File.Exists(deleteThumbPath))
                    File.Delete(deleteThumbPath);
            }
        }
    }
}
