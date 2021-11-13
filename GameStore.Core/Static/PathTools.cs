using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.Static
{
    public static class PathTools
    {
        public static string PrductImageDefautl = "/img/Other/default-image.jpg";
        public static string PrductImagePath = "/upload/games/";
        public static string PrductImageServerPath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/{PrductImagePath}");
    }
}
