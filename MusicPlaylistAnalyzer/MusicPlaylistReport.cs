using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlaylistAnalyzer
{
    public static class MusicPlaylistReport
    {
        public static string GenerateText(List<Song> songList)
        {
            string report = "Music Playlist Report\n\n";

            if (songList.Count() < 1)
            {
                report += "No data is available.\n";

                return report;
            }

            report += "Songs that received 200 or more plays:\n";
            var song200 = from songs in songList where songs.Plays >= 200 select songs;
            foreach(var song in song200)
            {
                report += song + "\n";
            }

            report += "\nNumber of Alternative songs: ";
            var songAlternative = from songs in songList where songs.Genre == "Alternative" select songs;
            report += songAlternative.Count();

            report += "\n\nNumber of Hip-Hop/Rap songs: ";
            var songRap = from songs in songList where songs.Genre == "Hip-Hop/Rap" select songs;
            report += songRap.Count();

            report += "\n\nSongs from the album Welcome to the Fishbowl:\n";
            var songFishBowl = from songs in songList where songs.Album == "Welcome to the Fishbowl" select songs;
            foreach (var song in songFishBowl)
            {
                report += song + "\n";
            }

            report += "\n\nSongs from before 1970:\n";
            var song1970= from songs in songList where songs.Year < 1970 select songs;
            foreach (var song in song1970)
            {
                report += song + "\n";
            }

            report += "\nSong names longer than 85 characters:\n";
            var song85long = from songs in songList where songs.Name.Length > 85 select songs;
            foreach (var song in song85long)
            {
                report += song + "\n";
            }

            report += "\nLongest song:\n";
            var songLongest = from songs in songList orderby songs.Time descending select songs;
            report += songLongest.First() + "\n";


            return report;
        }
    }
}
