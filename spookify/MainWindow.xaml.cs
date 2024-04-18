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

            InitializeComponent();

            // binding for Songs
            allSongs.Add(new Song(0, 4211, "Alison", "Nowhere", "Slowdive", "3:51", "C:/Users/alexa/Music/Slowdive/Nowhere/Alison.mp3"));
            allSongs.Add(new Song(1, 4212, "Catch the Breeze", "Just for a Day", "Slowdive", "4:19", "C:/Users/alexa/Music/Slowdive/Just for a Day/Catch the Breeze.mp3"));
            allSongs.Add(new Song(2, 4213, "A Strange Day", "Pornography", "The Cure", "5:04", "C:/Users/alexa/Music/The Cure/Pornography/A Strange Day.mp3"));
            allSongs.Add(new Song(3, 4214, "Lullaby", "Disintegration", "The Cure", "4:10", "C:/Users/alexa/Music/The Cure/Disintegration/Lullaby.mp3"));
            allSongs.Add(new Song(4, 4215, "When You Sleep", "Loveless", "My Bloody Valentine", "4:11", "C:/Users/alexa/Music/My Bloody Valentine/Loveless/When You Sleep.mp3"));
            allSongs.Add(new Song(5, 4216, "Only Shallow", "Loveless", "My Bloody Valentine", "4:18", "C:/Users/alexa/Music/My Bloody Valentine/Loveless/Only Shallow.mp3"));
            allSongs.Add(new Song(6, 4217, "Pictures of You", "Disintegration", "The Cure", "7:24", "C:/Users/alexa/Music/The Cure/Disintegration/Pictures of You.mp3"));
            allSongs.Add(new Song(7, 4218, "Blue Light", "Souvlaki", "Slowdive", "5:20", "C:/Users/alexa/Music/Slowdive/Souvlaki/Blue Light.mp3"));
            allSongs.Add(new Song(8, 4219, "Avalyn", "Just for a Day", "Slowdive", "5:05", "C:/Users/alexa/Music/Slowdive/Just for a Day/Avalyn.mp3"));
            allSongs.Add(new Song(9, 4220, "Fascination Street", "Disintegration", "The Cure", "5:16", "C:/Users/alexa/Music/The Cure/Disintegration/Fascination Street.mp3"));
            allSongs.Add(new Song(10,4221, "All I need", "In Rainbows", "Radiohead", "3:48", "C:/Users/alexa/Music/Radiohead/In Rainbows/All I need.mp3"));
            
            // set songs to allSongs deepcopy for now

            songs = new ObservableCollection<Song>(allSongs);
            
            DataContext = songs;

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AutoSuggestBox_TextChanged(Wpf.Ui.Controls.AutoSuggestBox sender, Wpf.Ui.Controls.AutoSuggestBoxTextChangedEventArgs args)
        {
            string filter = sender.Text.ToLower();

            songs.Clear();

            foreach (Song song in allSongs)
            {
                if (song.Title.ToLower().Contains(filter) || song.Album.ToLower().Contains(filter) || song.Artist.ToLower().Contains(filter))
                {
                    songs.Add(song);
                }
            }
        }

        // select song on left click 
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;
            Song song = (Song)row.Item;

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
    }
}