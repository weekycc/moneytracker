using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weekysoft.store.Util
{
    public class ImageUtil
    {
        //public static async Task<byte[]> GetPhotoBytesAsync(BitmapImage bitmapImage)
        //{
        //}

        private static void ConvertToRGBA(int pixelHeight, int pixelWidth, byte[] pixels)
        {
            if (pixels == null)
                return;

            int offset;
            for (int row = 0; row < (uint)pixelHeight; row++)
            {
                for (int col = 0; col < (uint)pixelWidth; col++)
                {
                    offset = (row * (int)pixelWidth * 4) + (col * 4);
                    byte B = pixels[offset];
                    byte G = pixels[offset + 1];
                    byte R = pixels[offset + 2];
                    byte A = pixels[offset + 3];

                    // convert to RGBA format for BitmapEncoder
                    pixels[offset] = R; // Red
                    pixels[offset + 1] = G; // Green
                    pixels[offset + 2] = B; // Blue
                    pixels[offset + 3] = A; // Alpha
                }
            }
        }
    }
}
