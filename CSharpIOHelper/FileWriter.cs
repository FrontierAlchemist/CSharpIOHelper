using System.IO;

namespace CSharpIOHelper
{
	public class FileWriter : FileHolder, IOutputWriter
	{
		private readonly StreamWriter file;

		public FileWriter(string path) : base(path)
		{
			file = new StreamWriter(path);
		}

		public void Write(string text) => file.Write(text);

		public void WriteLine(string text) => file.WriteLine(text);

		public override void CloseFile() => file.Close();
	}
}
