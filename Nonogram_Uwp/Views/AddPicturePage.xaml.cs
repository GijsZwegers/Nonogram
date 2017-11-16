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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Nonogram_Uwp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddPicturePage : Page
    {
        public AddPicturePage()
        {
            this.InitializeComponent();
        }

        private void TbNumberRows_TextChanged(object sender, TextChangedEventArgs e)
        {
            int parsedValue;
            if (!int.TryParse(tbNumberRows.Text, out parsedValue))
            {
                tbNumberRows.Text = "";
            }
            else if (Int32.Parse(tbNumberRows.Text) > 50)
            {
                tbNumberRows.Text = "";
            }
            else if (tbNumberRows.Text == "0")
            {
                tbNumberRows.Text = "";
            }
        }
    }
}
