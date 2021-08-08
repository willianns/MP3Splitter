using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MP3Splitter
{
    public class TrackList
    {
        public List<Track> Tracks { get; set; }

        public TrackList()
        {
            Tracks = new List<Track>();
        }

        /// <summary>
        /// Process multiple lines, one track information per line. The format template should be "hh:mm:ss hh:mm:ss track name", where start and end times may or may not including hours, depending on the position of your track
        /// </summary>
        /// <param name="formattedTrackList"></param>
        public void Parse(string[] formattedTrackList)
        {
            foreach (var trackInfo in formattedTrackList)
            {
                Match match = Regex.Match(trackInfo, @"([0-9]{1,2}:[0-9]{2}:?[0-9]{0,2})\s{1}([0-9]{1,2}:[0-9]{2}:?[0-9]{0,2})\s{1}(.+)");

                if (!match.Success)
                    throw new ArgumentException($"invalid format for track info '{trackInfo}'");

                string startingTime = match.Groups[1].Value;
                string endingTime = match.Groups[2].Value;
                string name = match.Groups[3].Value;

                Tracks.Add(new Track { Name = name, StartTime = startingTime, EndTime = endingTime });
            }
        }
    }
}
