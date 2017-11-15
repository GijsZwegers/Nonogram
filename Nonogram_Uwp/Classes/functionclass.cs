using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.Media;
using System.IO;
using Windows.Graphics.Imaging;
using Nonogram_Uwp.Views;
using Windows.UI.Xaml.Shapes;

namespace Nonogram_Uwp.Classes
{
    class Functionclass
    {

        private async Task<Color> GetColorFromPixel(string fileNameOfImage, int xCoordinate, int yCoordinate)
        {
            var imageFile = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(fileNameOfImage); // image inladen
            var imagestream = await imageFile.OpenStreamForReadAsync(); // 
            var imageDecoder = await BitmapDecoder.CreateAsync(imagestream.AsRandomAccessStream()); // stream decoderen
            var imagePixelData = await imageDecoder.GetPixelDataAsync(); // informatie uit pixel halen
            var bytes = imagePixelData.DetachPixelData();

            var k = (xCoordinate * (int)imageDecoder.PixelWidth + yCoordinate) * 3; // Naar de geselecteerde codrinaten navigeren
            return Color.FromArgb(0, bytes[k + 0], bytes[k + 1], bytes[k + 2]); // rood groen en blauw uit de kleuren halen
        }

        public void FillUndoList()
        {
            List<Rectangle> lsUndoTappedRectangles = new List<Rectangle>();

        }


    }
}
