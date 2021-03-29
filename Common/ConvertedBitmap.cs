using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Net;
using WebApi.Services;

namespace WebApi.Common
{
    public class ConvertedBitmap
    {
 
        public static Stream BitmapToStream(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                var qrCode = new MemoryStream(stream.ToArray());
                return qrCode;
            }
        }

        public static Bitmap BitmapImage(string url)
        {

            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();

            using (Stream dataStream = response.GetResponseStream())
            {
                if (dataStream == null)
                    return null;
                using (var sr = new BinaryReader(dataStream))
                {
                    byte[] image = sr.ReadBytes(100000000);

                    using (var ms = new MemoryStream(image))
                    {
                        Bitmap bmp = new Bitmap(ms);
                        return bmp;
                    }
                }
            }
        }

    }
}
