using MP3Splitter;
using System;
using System.Diagnostics;
using System.IO;

// validate file
if (args.Length == 0)
{
    Console.WriteLine(@"
    usage: mp3splitter.exe my_file.mp3 [options]

      Options:
      -f <required path for ffmpeg executable - for Windows only>

      =========================================================================================================
      Info: Note the need to have a txt file in the same path as the mp3 file
      with the same name (eg my_file.txt) containing the specification of the ranges per line in the following format;
      The tracks will be generated in the same mp3 source folder.      

      Format: {start time} {end time} {trackname without special chars}
      
      Example: hh:mm:ss hh:mm:ss my trackname
      =========================================================================================================
    ");
    return;
}

var mp3SourceFile = args[0];

if (!File.Exists(mp3SourceFile))
{
    Console.WriteLine($"Invalid file {mp3SourceFile}");
    return;
}

// validate ffmpeg folder
var ffmpeg_path = "ffmpeg";
if (args.Length > 1 && args[1] == "-f")
{
    ffmpeg_path = args[2];

    if (!File.Exists(ffmpeg_path))
    {
        Console.WriteLine($"Invalid ffmpeg path {ffmpeg_path}");
        return;
    }
}

// file folder path
var mp3Path = Path.GetDirectoryName(mp3SourceFile);

var trackList = new TrackList();
var formattedTrackList = File.ReadAllText(Path.ChangeExtension(mp3SourceFile, "txt")).Split(new[] { Environment.NewLine }, StringSplitOptions.None);
trackList.Parse(formattedTrackList);

foreach (var faixa in trackList.Tracks)
{
    //the track name cannot have special chars like ?, ', /, \
    var processStartInfo = new ProcessStartInfo
    {
        WindowStyle = ProcessWindowStyle.Hidden,
        FileName = ffmpeg_path,
        Arguments = $"-ss {faixa.StartTime} -to {faixa.EndTime} -i \"{mp3SourceFile}\" -c: copy \"{Path.Combine(mp3Path, faixa.Name)}.mp3\"",
        RedirectStandardOutput = true,
        RedirectStandardError = true
    };

    using var process = new Process();
    //process.OutputDataReceived += (object sender, DataReceivedEventArgs e) => { };
    //process.Exited += (sender, e) => { };

    process.StartInfo = processStartInfo;
    process.Start();

    process.WaitForExit();

    if (process.ExitCode == 0)
    {
        Console.WriteLine($"track \"{faixa.Name}\" extracted");
    }
    else
    {
        Console.WriteLine($"error on track \"{faixa.Name}\"");
    }
}