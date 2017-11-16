using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Nonogram_Uwp.Views;
using Windows.UI.Xaml.Shapes;
using Windows.UI;
using Nonogram_Uwp.Classes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Nonogram_Uwp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Wrapper : Page
    {
        public static List<Rectangle> lsTappedRectangles = new List<Rectangle>();

        public Wrapper()
        {
            this.InitializeComponent();
            fContent.Navigate(typeof(Puzzle_Page));
        }

        private void AddImage_Click(object sender, RoutedEventArgs e)
        {
            if (fContent.Content.GetType() == typeof(Puzzle_Page))
            {
                fContent.Navigate(typeof(AddPicturePage));
            }
            else
            {
                fContent.Navigate(typeof(Puzzle_Page));
            }
        }

        static public void FillUndoList(Rectangle rtTapped)
        {
            lsTappedRectangles.Add(rtTapped);
        }

        private void Undo_Click(object sender, RoutedEventArgs e)
        {
            if (!lsTappedRectangles.Any())
            {
                
            }
            else
            {
                Rectangle rtLastSet;
                rtLastSet = lsTappedRectangles[lsTappedRectangles.Count - 1];
                SolidColorBrush brush = rtLastSet.Fill as SolidColorBrush;
                if (brush.Color == Colors.Black)
                {
                    rtLastSet.Fill = new SolidColorBrush(Colors.White);
                }
                else if (brush.Color == Colors.White)
                {
                    rtLastSet.Fill = new SolidColorBrush(Colors.Black);
                }
                lsTappedRectangles.RemoveAt(lsTappedRectangles.Count - 1);
            }
            
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            foreach (Rectangle rectangle in lsTappedRectangles)
            {
                rectangle.Fill = new SolidColorBrush(Colors.White);
            }
            lsTappedRectangles.Clear();
        }
    }
}
