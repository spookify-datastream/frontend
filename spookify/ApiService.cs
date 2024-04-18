using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.IO;

public class ApiService {
    private readonly HttpClient _client;
    private readonly string _destinationFolderPath;

    public ApiService(string baseUrl, string destinationFolder) {
        _destinationFolderPath = destinationFolder;
        _client = new HttpClient {
            BaseAddress = new Uri(baseUrl)
        };
        Console.WriteLine("Base address: " + baseUrl);
    }

    public async Task<bool> AddSongAsync(Song song) {
        var response = await _client.PostAsJsonAsync("Songs", song);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateSongAsync(Song song) {
        var response = await _client.PutAsJsonAsync("Songs", song);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteSongAsync(int songId) {
        var response = await _client.DeleteAsync($"Songs/{songId}");
        return response.IsSuccessStatusCode;
    }

    public async Task<Song> GetSongAsync(int songId) {
        return await _client.GetFromJsonAsync<Song>($"Songs/{songId}");
    }

    public async Task<List<Song>> GetAllSongsAsync() {
        return await _client.GetFromJsonAsync<List<Song>>("Songs");
    }

    public async Task<bool> DownloadSongFileAsync(Song song) {
        try {
            // Make the HTTP request to get the song file as a stream
            var response = await _client.GetAsync($"Songs/{song.Id}/file", HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();

            Directory.CreateDirectory(_destinationFolderPath);

            // Construct the local file path
            var localFilePath = Path.Combine(_destinationFolderPath, song.Filename);  // Assumes file is in mp3 format

            // Open a stream for the file to be written to
            using (var fileStream = new FileStream(localFilePath, FileMode.Create, FileAccess.Write, FileShare.None)) {
                // Copy the content from the response stream to the local file stream
                await response.Content.CopyToAsync(fileStream);
            }

            return true;
        } catch (Exception ex) {
            // Log the error or handle it accordingly
            Console.WriteLine($"An error occurred: {ex.Message}");
            return false;
        }

    }
}

public class Song {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Album { get; set; }
    public string Artist { get; set; }
    public int Streams { get; set; }
    public string Filename { get; set; }

}