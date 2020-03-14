using System.Collections;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Windows.Media.Imaging;

namespace _2020._03._01_Bike_Repository.DAL.Model
{
    internal class ImagePathHelper
    {
        private BitmapImage ConvertBitmapToImage(Bitmap bitmap)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Bmp);
                memoryStream.Position = 0;
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memoryStream;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                return bitmapImage;
            }
        }

        public BitmapImage GetImageByModel(string model)
        {
            ResourceManager MyResourceClass = new ResourceManager(typeof(FileStore.Resource));
            ResourceSet resourceSet = FileStore.Resource.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            foreach (DictionaryEntry entry in resourceSet)
            {
                model = model.Replace(' ', '_');
                model = model.Replace('.', '_');
                if (model == entry.Key.ToString())
                {
                    return ConvertBitmapToImage(entry.Value as Bitmap);
                }
            }
            return ConvertBitmapToImage(FileStore.Resource.no_image_found);
        }
    }
}
