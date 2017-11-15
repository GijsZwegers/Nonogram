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
        public List<Rectangle> lsUndoTappedRectangles = new List<Rectangle>();

        public Wrapper()
        {
            this.InitializeComponent();
            fContent.Navigate(typeof(Puzzle_Page));
        }

        private void AddImage_Click(object sender, RoutedEventArgs e)
        {
            if (fContent.Content.GetType() == typeof(Puzzle_Page))
            {
                fContent.Navigate(typeof(AddPicuturePage));
            }
            else
            {
                fContent.Navigate(typeof(Puzzle_Page));
            }
        }

        public void FillUndoList(Rectangle rtTapped)
        {
            lsUndoTappedRectangles.Add(rtTapped);
        }

        private void Undo_Click(object sender, RoutedEventArgs e)
        {
            Rectangle rtLastSet;
            rtLastSet = lsUndoTappedRectangles[lsUndoTappedRectangles.Count - 1];
            
            if (((SolidColorBrush)rtLastSet.Stroke).Color != Colors.White)
            {
                
            }
        }
    }
}
