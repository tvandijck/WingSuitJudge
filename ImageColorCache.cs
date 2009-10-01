using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace WingSuitJudge
{
    internal static class ImageColorCache
    {
        private static Bitmap mSilhouette = Properties.Resources.wingsuit_outline;

        private static Dictionary<Color, Image> mSilhouetteCache = new Dictionary<Color, Image>();

        public static Image GetSilhouetteImage(Color aColor)
        {
            Image result;
            if (!mSilhouetteCache.TryGetValue(aColor, out result))
            {
                result = Multiply(mSilhouette, aColor);
                mSilhouetteCache.Add(aColor, result);
            }
            return result;
        }
        
        private static Image Multiply(Image aImage, Color aColor)
        {
            Image dest = new Bitmap(aImage.Width, aImage.Height, PixelFormat.Format32bppArgb);
            using (Graphics gfx = Graphics.FromImage(dest))
            {
                float[][] colorMatrixElements = 
                    { 
                        new float[] {aColor.R/255.0f,  0,  0,  0,  0},
                        new float[] {0,  aColor.G/255.0f,  0,  0,  0},
                        new float[] {0,  0,  aColor.B/255.0f,  0,  0},
                        new float[] {0,  0,  0,  1,  0},
                        new float[] {0,  0,  0,  0,  1}
                    };

                ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);
                ImageAttributes imageAttributes = new ImageAttributes();
                imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                gfx.DrawImage(aImage, new Rectangle(0, 0, aImage.Width, aImage.Height),
                    0, 0, aImage.Width, aImage.Height, GraphicsUnit.Pixel, imageAttributes);
            }
            return dest;
        }
    }
}
