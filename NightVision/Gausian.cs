using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightVision
{
    internal class Gausian
    {
        internal Bitmap ApplyFilter(Bitmap image, float sigma, int windowSize)
        {
            var window = InitializeWindow(sigma, windowSize);

            var img = new LockBitmap(image);
            var dest = new Bitmap(image);
            img.LockBits();
            var destImage = new LockBitmap(dest);
            destImage.LockBits();

            Parallel.For(0, img.Width, x =>
            {
                Color[] tmp = new Color[img.Height];
                for (var y = 0; y < img.Height; y++)
                {
                    var sum = 0.0;
                    var r = 0.0;
                    var g = 0.0;
                    var b = 0.0;
                    for (var i = 0; i < window.Length; i++)
                    {
                        var l = x + i - windowSize;
                        if (l >= 0 && l < img.Width)
                        {
                            var sourceColor = img.GetPixel(l, y);
                            r += sourceColor.R * window[i];
                            g += sourceColor.G * window[i];
                            b += sourceColor.B * window[i];
                            sum += window[i];
                        }
                    }
                    tmp[y] = Color.FromArgb((r / sum).GetValidColorComponent(), (g / sum).GetValidColorComponent(),
                        (b / sum).GetValidColorComponent());
                }
                for (var i = 0; i < img.Height; i++)
                {
                    destImage.SetPixel(x, i, tmp[i]);
                }
            });

            Parallel.For(0, img.Height, y =>
            {
                Color[] tmp = new Color[img.Width];
                for (var x = 0; x < img.Width; x++)
                {
                    var sum = 0.0;
                    var r = 0.0;
                    var g = 0.0;
                    var b = 0.0;
                    for (var i = 0; i < window.Length; i++)
                    {
                        var l = y + i - windowSize;
                        if (l >= 0 && l < img.Height)
                        {
                            var sourceColor = destImage.GetPixel(x, l);
                            r += sourceColor.R * window[i];
                            g += sourceColor.G * window[i];
                            b += sourceColor.B * window[i];
                            sum += window[i];
                        }
                    }
                    tmp[x] = Color.FromArgb((r / sum).GetValidColorComponent(), (g / sum).GetValidColorComponent(),
                        (b / sum).GetValidColorComponent());
                }
                for (var i = 0; i < img.Width; i++)
                {
                    img.SetPixel(i, y, tmp[i]);
                }
            });
            img.UnlockBits();
            destImage.UnlockBits();
            return image;
        }

        private float[] InitializeWindow(float sigma, int size)
        {
            
            var window = new float[size * 2 + 1];
            window[size] = 1;
            for (var i = size + 1; i < window.Length; i++)
            {
                var counter = i - size;
                window[i] = (float)Math.Exp(-(counter * counter) / (2 * sigma * sigma));
            }
            for (var i = size - 1; i >= 0; i--)
            {
                window[i] = window[window.Length - i - 1];
            }
            return window;
        }
       
    }
}
