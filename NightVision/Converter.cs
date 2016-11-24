using System;
using System.Drawing;

namespace NightVision
{
    public class Converter
    {
        public Image Night1(Image source)
        {
            var xyz = toXYZ(source);
            var blur1 = new Gausian().ApplyFilter(xyz, (float)0.1, 11);
            var blur2 = rightDivision((Bitmap)blur1.Clone(), 6);
            var a = 0.2;
            var res = loopMatrix((Bitmap)source, (x, y) =>
            {
                var r = (int)Math.Round((blur1.GetPixel(x, y).R - blur2.GetPixel(x, y).R) * a + blur2.GetPixel(x, y).R);
                var g = (int)Math.Round((blur1.GetPixel(x, y).G - blur2.GetPixel(x, y).G) * a + blur2.GetPixel(x, y).G);
                var b = (int)Math.Round((blur1.GetPixel(x, y).B - blur2.GetPixel(x, y).B) * a + blur2.GetPixel(x, y).B);

                return Color.FromArgb(r, g, b);
            });
            res = toRGB(res);
            return res;
        }

        public Image Night2(Image source)
        {
            var xyz = toXYZ(source);
            var blur1 = new Gausian().ApplyFilter(xyz, (float)0.1, 11);
            var blur2 = rightDivision((Bitmap)blur1.Clone(), 6);
            var a = 2;
            var res = loopMatrix((Bitmap)source, (x, y) =>
            {
                var r = (int)Math.Round((blur1.GetPixel(x, y).R - blur2.GetPixel(x, y).R) * ((double)1 / a) + blur2.GetPixel(x, y).R);
                var g = (int)Math.Round((blur1.GetPixel(x, y).G - blur2.GetPixel(x, y).G) * ((double)1 / a) + blur2.GetPixel(x, y).G);
                var b = (int)Math.Round((blur1.GetPixel(x, y).B - blur2.GetPixel(x, y).B) * ((double)1 / a) + blur2.GetPixel(x, y).B);

                return Color.FromArgb(r, g, b);
            });
            res = toRGB(res);
            return res;
        }

        private delegate Color ProcessPixel(int x, int y);

        private Bitmap toXYZ(Image source)
        {
            source = (Image)source.Clone();
            var bitmap = (Bitmap)source;
            for (var x = 0; x < source.Width; x++)
            {
                for (var y = 0; y < source.Height; y++)
                {
                    var pixel = bitmap.GetPixel(x, y);
                    var r = (double)pixel.R / 255;
                    var g = (double)pixel.G / 255;
                    var b = (double)pixel.B / 255;
                    r = prepareComponent(r);
                    g = prepareComponent(g);
                    b = prepareComponent(b);
                    var X = r * 0.5149 + g * 0.3244 + b * 0.1607;
                    var Y = r * 0.2654 + g * 0.6704 + b * 0.0642;
                    var Z = r * 0.0248 + g * 0.1248 + b * 0.8504;
                    bitmap.SetPixel(x, y, Color.FromArgb((int)Math.Round(X), (int)Math.Round(Y), (int)Math.Round(Z)));
                }
            }
            return bitmap;
        }

        private Bitmap toRGB(Bitmap source)
        {
            var res = (Bitmap)source.Clone();

            res = loopMatrix(res, (x, y) =>
           {
               var pixel = res.GetPixel(x, y);
               var X = (double)pixel.R / 100;
               var Y = (double)pixel.G / 100;
               var Z = (double)pixel.B / 100;

               var r = (X * 2.6422874 + Y * -1.2234270 + Z * -0.3930143);
               var g = (X * -1.1119763 + Y * 2.0590183 + Z * 0.0159614);
               var b = (X * 0.0821699 + Y * -0.2807254 + Z * 1.4559877);


               if (r > 0.0031308)
               {
                   r = 1.055 * (Math.Pow(r, ((double)1 / 2.4))) - 0.055;
               }
               else
               {
                   r = 12.92 * r;
               }
               if (g > 0.0031308)
               {
                   g = 1.055 * (Math.Pow(g, ((double)1 / 2.4))) - 0.055;
               }
               else
               {
                   g = 12.92 * g;
               }
               if (b > 0.0031308)
               {
                   b = 1.055 * (Math.Pow(b, ((double)1 / 2.4))) - 0.055;
               }
               else
               {
                   b = 12.92 * b;
               }

               r *= 255;
               g *= 255;
               b *= 255;

               return Color.FromArgb(normalize(r), normalize(g), normalize(b));
           });

            return res;
        }

        private int normalize(double x)
        {
            return x <= 0 ? 0 : (int)Math.Round(x);
        }

        private double prepareComponent(double a)
        {
            if (a > 0.04045)
            {
                a = Math.Pow(((a + 0.055) / 1.055), 2.4);
            }
            else
            {
                a /= 12.92;
            }
            return a * 100;
        }

        private Bitmap rightDivision(Bitmap source, int divisor)
        {
            var dest = (Bitmap)source.Clone();

            for (var x = 0; x < source.Width; x++)
            {
                for (var y = 0; y < source.Height; y++)
                {
                    var pixel = source.GetPixel(x, y);
                    var r = pixel.R / 6;
                    var g = pixel.G / 6;
                    var b = pixel.B / 6;
                    dest.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            return dest;
        }

        private Bitmap loopMatrix(Bitmap source, ProcessPixel process)
        {
            var res = (Bitmap)source.Clone();
            for (var x = 0; x < source.Width; x++)
            {
                for (var y = 0; y < source.Height; y++)
                {
                    res.SetPixel(x, y, process(x, y));
                }
            }
            return res;
        }
    }
}
