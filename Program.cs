using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Maestro_Resizer
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new fmMain());
            }
            else if (args.Length == 3)
            {
                float width = float.Parse(args[0], CultureInfo.InvariantCulture.NumberFormat);
                float height = float.Parse(args[1], CultureInfo.InvariantCulture.NumberFormat);
                string filePath = args[2];
                ResizeImage(filePath, width, height);
            }
            else if (args.Length == 4)
            {
                float width = float.Parse(args[0], CultureInfo.InvariantCulture.NumberFormat);
                float height = float.Parse(args[1], CultureInfo.InvariantCulture.NumberFormat);
                string filePath = args[3];
                CropImage(filePath, width, height);
            }
        }

        public static void ResizeImage(string imagePath, float targetWidthCm, float targetHeightCm)
        {
            try
            {
                using (Image originalImage = Image.FromFile(imagePath))
                {
                    float dpi = 300;

                    float originalLongerSideInches = Math.Max(originalImage.Width, originalImage.Height) / originalImage.HorizontalResolution;
                    float targetLongerSideInches = Math.Max(targetWidthCm, targetHeightCm) / 2.54f;

                    float targetAspectRatio = targetWidthCm / targetHeightCm;
                    float originalAspectRatio = (float)originalImage.Width / originalImage.Height;

                    int newWidthPixels, newHeightPixels;
                    if (originalAspectRatio > targetAspectRatio)
                    {
                        newWidthPixels = (int)(targetLongerSideInches * dpi);
                        newHeightPixels = (int)(newWidthPixels / originalAspectRatio);
                    }
                    else
                    {
                        newHeightPixels = (int)(targetLongerSideInches * dpi);
                        newWidthPixels = (int)(newHeightPixels * originalAspectRatio);
                    }

                    using (Bitmap resizedImage = new Bitmap(newWidthPixels, newHeightPixels))
                    {
                        resizedImage.SetResolution(dpi, dpi);

                        using (Graphics graphics = Graphics.FromImage(resizedImage))
                        {
                            graphics.CompositingQuality = CompositingQuality.HighQuality;
                            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            graphics.SmoothingMode = SmoothingMode.HighQuality;
                            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                            graphics.DrawImage(originalImage, 0, 0, newWidthPixels, newHeightPixels);
                        }

                        string newImagePath = GetUniqueImagePath(imagePath, targetWidthCm, targetHeightCm);
                        resizedImage.Save(newImagePath, originalImage.RawFormat);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось изменить размер.\n" + ex.Message, "Ошибка изменения размера", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        public static void CropImage(string imagePath, float targetWidthCm, float targetHeightCm)
        {
            try
            {
                using (Image originalImage = Image.FromFile(imagePath))
                {
                    float dpi = 300;

                    int targetWidthPx = (int)Math.Round(targetWidthCm * dpi / 2.54);
                    int targetHeightPx = (int)Math.Round(targetHeightCm * dpi / 2.54);

                    bool isLandscape = originalImage.Width > originalImage.Height;

                    if (isLandscape && targetWidthPx < targetHeightPx)
                    {
                        (targetWidthPx, targetHeightPx) = (targetHeightPx, targetWidthPx);
                    }
                    else if (!isLandscape && targetWidthPx > targetHeightPx)
                    {
                        (targetWidthPx, targetHeightPx) = (targetHeightPx, targetWidthPx);
                    }

                    Rectangle cropRect = CalculateCropRectangle(originalImage.Width, originalImage.Height, targetWidthPx, targetHeightPx);

                    using (Bitmap croppedImage = new Bitmap(targetWidthPx, targetHeightPx))
                    {
                        croppedImage.SetResolution(dpi, dpi);

                        using (Graphics g = Graphics.FromImage(croppedImage))
                        {
                            g.DrawImage(originalImage, new Rectangle(0, 0, targetWidthPx, targetHeightPx), cropRect, GraphicsUnit.Pixel);
                        }

                        string croppedImagePath = GetUniqueImagePath(imagePath, targetWidthCm, targetHeightCm);
                        croppedImage.Save(croppedImagePath, originalImage.RawFormat);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось изменить размер.\n" + ex.Message, "Ошибка изменения размера", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private static Rectangle CalculateCropRectangle(int originalWidth, int originalHeight, int targetWidth, int targetHeight)
        {
            double sourceRatio = (double)originalWidth / originalHeight;
            double targetRatio = (double)targetWidth / targetHeight;

            int x, y, cropWidth, cropHeight;
            if (sourceRatio > targetRatio)
            {
                cropWidth = (int)(originalHeight * targetRatio);
                cropHeight = originalHeight;
                x = (originalWidth - cropWidth) / 2;
                y = 0;
            }
            else
            {
                cropWidth = originalWidth;
                cropHeight = (int)(originalWidth / targetRatio);
                x = 0;
                y = (originalHeight - cropHeight) / 2;
            }

            return new Rectangle(x, y, cropWidth, cropHeight);
        }

        private static string GetUniqueImagePath(string originalImagePath, float targetWidthCm, float targetHeightCm)
        {
            string directory = Path.GetDirectoryName(originalImagePath);
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(originalImagePath);
            string extension = Path.GetExtension(originalImagePath);
            string baseFileName = $"{targetWidthCm}x{targetHeightCm}_{fileNameWithoutExtension}";
            string newImagePath = Path.Combine(directory, $"{baseFileName}{extension}");

            int counter = 1;
            while (File.Exists(newImagePath))
            {
                newImagePath = Path.Combine(directory, $"{baseFileName} ({counter}){extension}");
                counter++;
            }

            return newImagePath;
        }
    }
}
