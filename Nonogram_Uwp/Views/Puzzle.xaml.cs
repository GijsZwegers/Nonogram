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
using Windows.UI.Popups;
using Nonogram_Uwp.Classes;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Nonogram_Uwp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Puzzle_Page : Page
    {
        //lists voor de items in de grid
        List<Rectangle> lsGridMain = new List<Rectangle>();
        List<Rectangle> lsGridLeft = new List<Rectangle>();
        List<Rectangle> lsGridTop = new List<Rectangle>();

        //grids aanmaken om te gebruiken
        Grid grTop = new Grid();
        Grid grMain = new Grid();
        Grid grLeft = new Grid();

        int iAantalRows = 4;
        public Puzzle_Page()
        {
            this.InitializeComponent();
            FillColumnsWithGrids(iAantalRows);
            FillGridWithGrids(iAantalRows);
        }
        private void FillGridWithGrids(int Aantal)
        {
            #region topgrid
            grTop.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 1, 31, 75));
            grTop.BorderThickness = new Thickness(0, 0, 0, 1);
            
            for (int i = 0; i < Aantal; i++)
            {
                ColumnDefinition c1  = new ColumnDefinition()
                { 
                Width = new GridLength(1, GridUnitType.Star)
                };
            grTop.ColumnDefinitions.Add(c1);
            }
            Grid.SetColumn(grTop, 2);
            Grid.SetRow(grTop, 1);
            grGrid.Children.Add(grTop);
            #endregion

            #region maingrid
            for (int i = 0; i < Aantal; i++)
            {
                ColumnDefinition c1 = new ColumnDefinition()
                {
                    Width = new GridLength(1, GridUnitType.Star)
                };
                grMain.ColumnDefinitions.Add(c1);
                RowDefinition r1 = new RowDefinition()
                {
                    Height = new GridLength(1, GridUnitType.Star)
                };
                grMain.RowDefinitions.Add(r1);
            }
            Grid.SetColumn(grMain, 2);
            Grid.SetRow(grMain, 2);
            grGrid.Children.Add(grMain);
            #endregion
            #region leftgrid
            grLeft.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 1, 31, 75));
            grLeft.BorderThickness = new Thickness(0, 0, 1, 0);

            for (int i = 0; i < Aantal; i++)
            {
                RowDefinition r1 = new RowDefinition()
                {
                    Height = new GridLength(1, GridUnitType.Star)
                };
                grLeft.RowDefinitions.Add(r1);
            }
            Grid.SetColumn(grLeft, 1);
            Grid.SetRow(grLeft, 2);
            grGrid.Children.Add(grLeft);
            #endregion
        }

        private void FillColumnsWithGrids(int Aantal)
        {
            for (int i = 0; i < Aantal; i++)
            {
                Rectangle LeftGrid = new Rectangle
                {
                    Fill = new SolidColorBrush(Colors.White),
                    Stroke = new SolidColorBrush(Color.FromArgb(255, 179, 205, 224)),
                    StrokeThickness = 1
                };
                Grid.SetRow(LeftGrid, i);
                Grid.SetColumn(LeftGrid, 0);
                grLeft.Children.Add(LeftGrid);
                lsGridLeft.Add(LeftGrid);

                Rectangle TopGrid = new Rectangle
                {
                    Fill = new SolidColorBrush(Colors.White),
                    Stroke = new SolidColorBrush(Color.FromArgb(255, 179, 205, 224)),
                    StrokeThickness = 1
                };
                Grid.SetRow(TopGrid, 0);
                Grid.SetColumn(TopGrid, i);
                grTop.Children.Add(TopGrid);
                lsGridTop.Add(TopGrid);
            }

            //Grids toevoegen aan de maingrid
            for (int length = 0; length < Aantal;)
            {
                for (int height = 0; height < Aantal;)
                {
                   
                    Rectangle MainGrid = new Rectangle
                    {
                        Fill = new SolidColorBrush(Colors.White),
                        Stroke = new SolidColorBrush(Color.FromArgb(255, 179, 205, 224)),
                        StrokeThickness = 1
                    };
                    //Functie die ervoor zorgt dat zodra er op een grad gedrukt word de kleur verandert
                    MainGrid.Tapped += Grid_Tapped;
                    Grid.SetRow(MainGrid, length);
                    Grid.SetColumn(MainGrid, height);
                    grMain.Children.Add(MainGrid);
                    lsGridMain.Add(MainGrid);
                    height++;
                }
                length++;
            }
        }

        public void Grid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var grid = sender as Rectangle;
            SolidColorBrush brush = grid.Fill as SolidColorBrush;
            if (grid != null)
            {
                if (brush.Color == Colors.Black)
                {
                    grid.Fill = new SolidColorBrush(Colors.White);
                }
                else
                {
                    grid.Fill = new SolidColorBrush(Colors.Black);
                }

            }
        }
    }
}
