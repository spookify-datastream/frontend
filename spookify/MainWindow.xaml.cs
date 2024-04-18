using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace spookify
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ObservableCollection<Song> songs = new ObservableCollection<Song>();
        private ObservableCollection<Song> allSongs = new ObservableCollection<Song>();

        public MainWindow()
        {
            
            //ConfigurationHelper.InitializeConfiguration();
            //string apiBaseUrl = ConfigurationHelper.GetApiBaseUrl();
            //string destinationFolder = ConfigurationHelper.GetDestinationFolderPath();

            

            InitializeComponent();
            
            ApiService apiService = new ApiService(
                "http://localhost:5006/",
                "C:\\Users\\vdeniss\\Documents\\GitHub\\frontend\\temp");


            // get song with id 1

            Song song = apiService.GetSongAsync(1).Result;
            
            MessageBox.Show(song.Title+", "+song.Artist);

            
            
            songs = new ObservableCollection<Song>(allSongs);
            
            DataContext = songs;

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        // select song on left click 
        private void rowSelect(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;
            Song song = (Song)row.Item;
            // select song
            songsDataGrid.SelectedItem = song;

            setCurrentSong(song);
            
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void ClickUpdate(object sender, RoutedEventArgs e)
        {
            // open UpdateWindow for selected song
            
            UpdateWindow updateWindow = new UpdateWindow();
            //UpdateWindow updateWindow = new UpdateWindow((Song)DataGrid.SelectedItem);

            updateWindow.Show();

        }

        private void ClickCreate(object sender, RoutedEventArgs e)
        {
            // open CreateWindow

            CreateWindow createWindow = new CreateWindow();
            createWindow.Show();

        }

        private void ClickDelete(object sender, RoutedEventArgs e)
        {
            // delete selected song
        }

        private void DataGrid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var dep = (DependencyObject)e.OriginalSource;

            // Find the clicked row
            while (dep != null && !(dep is DataGridRow))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }

            if (dep is DataGridRow row)
            {
                // Select the clicked row
                if (!row.IsSelected)
                {
                    row.IsSelected = true;
                }
                
                Song song = (Song)row.Item;
                songsDataGrid.SelectedItem = song;

                setCurrentSong(song);
            }
        }

        private void setCurrentSong(Song song)
        {
            currentTitle.Text = song.Title;
            currentArtist.Text = song.Artist;
            currentAlbum.Text = song.Album;
            currentId.Text = song.Id.ToString();
            currentFilename.Text = song.Filename;
            currentStreams.Text = song.Streams.ToString();
        }
    }
}