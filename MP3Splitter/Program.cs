using System.Diagnostics;
using System.IO;
using Terminal.Gui;

Application.Init();

var top = Application.Top;

var win = new Window("MP3 Splitter")
{
	X = 0,
	Y = 0, 
	Width = Dim.Fill(),
	Height = Dim.Fill()
};
top.Add(win);

var arquivo = new Label("File: ") { X = 3, Y = 2 };

var faixas = new Label("Tracks / format per line -> {start 00:00} {track name}: ")
{
	X = Pos.Left(arquivo),
	Y = Pos.Top(arquivo) + 2
};

var arquivoText = new TextField()
{
	Width = 80
};

var arquivoButton = new Button()
{
	X = Pos.Right(arquivo),
	Y = Pos.Top(arquivo),
	Text = "..."
};
arquivoButton.Clicked += () => 
{
	var d = new OpenDialog("Open", "Open a music file") { AllowedFileTypes = new[] { "mp3" } };
	Application.Run(d);

	if (!d.Canceled)
	{
		var arquivoTextFilename = d.FilePaths.Count > 0 ? d.FilePaths[0] : d.FilePath;
		arquivoText.Text = Path.GetFileName(arquivoTextFilename.ToString());
	}
};

arquivoText.X = Pos.Right(arquivoButton) + 1;
arquivoText.Y = Pos.Top(arquivoButton);

var faixasText = new TextView()
{
	X = Pos.Left(arquivo),
	Y = Pos.Bottom(faixas),
	Width = 40,
	Height = 6,
	Multiline = true,
	ColorScheme = new ColorScheme 
	{ 
		Normal = new Attribute(Color.Black, Color.Gray) 
	}
};

var splitButton = new Button(3, 12, "Split");
splitButton.Clicked += () => 
{
	var process = new Process();

	var processStartInfo = new ProcessStartInfo();
	processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
	processStartInfo.FileName = "ffmpeg";
	processStartInfo.Arguments = "git status";
	processStartInfo.RedirectStandardOutput = true;
	processStartInfo.RedirectStandardError = true;

	process.OutputDataReceived += (object sender, DataReceivedEventArgs e) => { };
	process.Exited += (sender, e) => { };

	process.StartInfo = processStartInfo;
	process.Start();
};

win.Add(
	arquivo, faixas, arquivoButton, arquivoText, faixasText, splitButton
); ;

Application.Run();