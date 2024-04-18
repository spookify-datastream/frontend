using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace spookify
{
    /// <summary>
    /// Interaction logic for UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window
    {
        //public UpdateWindow(Song song)
        public UpdateWindow()
        {
            InitializeComponent();
        }

        private void ClickUpdateSong(object sender, RoutedEventArgs e)
        {
            // update song in allSongs
        }
    }
}
