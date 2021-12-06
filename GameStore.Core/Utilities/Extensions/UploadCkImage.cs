using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.Utilities.Extensions
{
    public static class UploadCkImage
    {

        public static void AddCkImageToServer(this IFormFile upload)
        {
            var fileName = Guid.NewGuid() + Path.GetExtension(upload.FileName).ToLower();
            var path = Path.Combine("/wwwroot/upload/", "notes", fileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                upload.CopyTo(stream);
            }
            var url = $"{"/notes/"}{fileName}";
        }
    }
}
