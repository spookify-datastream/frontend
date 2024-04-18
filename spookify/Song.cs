namespace spookify
{
    internal class Song
    {
        //Song(#,ID,Title,Album,Artist,Duration,Path)
        public int Number { get; set; }
        public int ID { get; set; }
        public string Title { get; set; }
        public string Album { get; set; }
        public string Artist { get; set; }
        public string Duration { get; set; }
        public string Path { get; set; }

        public Song(int number, int id, string title, string album, string artist, string duration, string path)
        {
            Number = number;
            ID = id;
            Title = title;
            Album = album;
            Artist = artist;
            Duration = duration;
            Path = path;
        }
    }
}