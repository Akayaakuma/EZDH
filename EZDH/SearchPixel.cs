using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EZDH
{
    class SearchPixel
    {
        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, uint dwExtraInf);

        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int x, int y);

        static public Coordinate SearchPixelScreen(string hexcode)
        {
            // Take an image from the screen
            // Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height); // Create an empty bitmap with the size of the current screen 

            Bitmap bitmap = new Bitmap(SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height); // Create an empty bitmap with the size of all connected screen 

            Graphics graphics = Graphics.FromImage(bitmap as Image); // Create a new graphics objects that can capture the screen

            graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size); // Screenshot moment → screen content to graphics object

            Color desiredPixelColor = ColorTranslator.FromHtml(hexcode);

            // Go one to the right and then check from top to bottom every pixel (next round -> go one to right and go down again)
            for (int x = 0; x < SystemInformation.VirtualScreen.Width; x++)
            {
                for (int y = 0; y < SystemInformation.VirtualScreen.Height; y++)
                {
                    // Get the current pixels color
                    Color currentPixelColor = bitmap.GetPixel(x, y);

                    // Finally compare the pixels hex color and the desired hex color (if they match we found a pixel)
                    if (desiredPixelColor == currentPixelColor)
                    {
                        //MessageBox.Show(String.Concat("Found Pixel - Now set mouse cursor  " + x, "x " + y, "y"));
                        return new Coordinate(x, y);
                    }
                }
            }
            return null;
        }

        static public bool SearchPixelOne(string hexcode, Coordinate coordinate)
        {
            int x = coordinate.GetX();
            int y = coordinate.GetY();

            // Take an image from the screen
            // Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height); // Create an empty bitmap with the size of the current screen 

            Bitmap bitmap = new Bitmap(1, 1); // Create an empty bitmap with the size of all connected screen 

            Graphics graphics = Graphics.FromImage(bitmap as Image); // Create a new graphics objects that can capture the screen

            graphics.CopyFromScreen(x, y, 0, 0, bitmap.Size); // Screenshot moment → screen content to graphics object

            Color desiredPixelColor = ColorTranslator.FromHtml(hexcode);

            // Get the current pixels color
            Color currentPixelColor = bitmap.GetPixel(0, 0);

            //bitmap.Save(@"C:\Users\alexp\Desktop\pixelsuche\try1.png", ImageFormat.Png);  speichert das bild

            // Finally compare the pixels hex color and the desired hex color (if they match we found a pixel)
            if (desiredPixelColor == currentPixelColor)
            {
                //MessageBox.Show(String.Concat("Found Pixel - Now set mouse cursor  " + x, "x " + y, "y"));
                bitmap.Dispose();
                graphics.Dispose();
                return true;
            }
            //MessageBox.Show("Did not find pixel");
            graphics.Dispose();
            bitmap.Dispose();
            return false;
        }
    }
}
