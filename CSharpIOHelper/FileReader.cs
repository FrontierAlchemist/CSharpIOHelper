using System;
using System.IO;

namespace CSharpIOHelper
{
	public class FileReader : FileHolder, IInputReader
	{
		private readonly StreamReader file;

		public FileReader(string path) : base(path)
		{
			file = new StreamReader(path);
		}

		public string ReadLine()
			=> file.ReadLine() ?? throw new FormatException($"Error while trying to read a line from file with path: {path}.");

		public override void CloseFile() => file.Close();
	}
}
