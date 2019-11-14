using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlaylistAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("MusicPlaylistAnalyzer <music_playlist_file_path> <report_file_path>");
                Environment.Exit(1);
            }

            string musicInfoFilePath = args[0];
            string reportFilePath = args[1];

            List<Song> songList = null;

            try
            {
                songList = SongLoader.Load(musicInfoFilePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(2);
            }

            var report = MusicPlaylistReport.GenerateText(songList);

            try
            {
                System.IO.File.WriteAllText(reportFilePath, report);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(3);
            }
        }
    }
}
