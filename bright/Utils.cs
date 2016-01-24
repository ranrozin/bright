using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace bright
{
    static class Utils
    {
        static public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                try
                {
                    imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                }
                catch
                {
                    imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.MemoryBmp);

                }
                return ms.ToArray();
            }
        }
    }
}
