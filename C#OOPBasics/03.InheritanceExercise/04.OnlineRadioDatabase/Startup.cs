using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _04.OnlineRadioDatabase
{
    public class Startup
    {
        public static void Main()
        {
            int numberOfSongs = int.Parse(Console.ReadLine());
            var songs = new List<Song>();

            for (int index = 0; index < numberOfSongs; index++)
            {
                var songTokens = Console.ReadLine().Split(';').ToArray();

                try
                {
                    var artist = new Artist(songTokens[0]);
                    var lenght = songTokens[2];
                    var song = new Song(artist, songTokens[1], lenght);
                    songs.Add(song);
                    Console.WriteLine("Song added.");
                }
                catch (Exception ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            var result = 0;
            foreach (var song in songs)
            {
                DateTime time;
                if (DateTime.TryParseExact(song.Lenght, "mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out time))
                {
                }
                if (DateTime.TryParseExact(song.Lenght, "m:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out time))
                {
                }
                if (DateTime.TryParseExact(song.Lenght, "mm:s", CultureInfo.InvariantCulture, DateTimeStyles.None, out time))
                {
                }
                if (DateTime.TryParseExact(song.Lenght, "m:s", CultureInfo.InvariantCulture, DateTimeStyles.None, out time))
                {
                }

                result += time.Second + time.Minute * 60;
            }

            TimeSpan t = TimeSpan.FromSeconds(result);
            string playlistLenght = $"{t.Hours:D1}h {t.Minutes:D1}m {t.Seconds:D1}s";

            Console.WriteLine($"Songs added: {songs.Count}");
            Console.WriteLine($"Playlist length: {playlistLenght}");
        }
    }
}