using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Windows.Forms;
using System.IO;

namespace MyGameList.Utilities
{
    public class EverythingAboutImages
    {
        public static BitmapImage GetImageFromFile()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                        "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                        "Portable Network Graphic (*.png)|*.png";
            op.ShowDialog();
            BitmapImage result = new BitmapImage(new Uri(op.FileName));
            return result;
        }
        public static byte[] ConvertImageToByteArray(BitmapImage image)
        {
            byte[] result;
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                result = ms.ToArray();
            }
            return result;
        }
        public static BitmapImage Convert(Bitmap value)
        {
            Image defaultImage = value;
            using (MemoryStream ms = new MemoryStream())
            {
                defaultImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }
        public static BitmapImage ConvertByteArrayToImage(byte[] array)
        {
            if (array == null)
            {
                Image defaultImage = Properties.Resources.gamePlaceholder;
                using (MemoryStream ms = new MemoryStream())
                {
                    defaultImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    array = ms.ToArray();
                }
            }
            using (var ms = new MemoryStream(array))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }
    }
}
