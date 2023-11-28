

namespace ProductsProject.Service.Helpers
{
    public class EnviromentHelpers
    {
        public static string WebRootPath { get; set; }
        public static string AttachmentPath => Path.Combine(WebRootPath, PicturePath);
        public static string PicturePath = "ProductImages";
    }
}
