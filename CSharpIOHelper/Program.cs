using System;

namespace CSharpIOHelper
{
	public class Program
	{
		static readonly IInputReader reader;
		static readonly IOutputWriter writer;

		static readonly Action? onProgramClosing;

		static Program()
		{
			if (IsDebug()) {
				const string PathToInputFile = "input.txt";
				const string PathToOutputFile = "output.txt";

				var fileReader = new FileReader(PathToInputFile);
				onProgramClosing += fileReader.CloseFile;
				reader = fileReader;

				var fileWriter = new FileWriter(PathToOutputFile);
				onProgramClosing += fileWriter.CloseFile;
				writer = fileWriter;
			} else {
				reader = new ConsoleReader();
				writer = new ConsoleWriter();
			}
		}

		private static int Main()
		{
			RunTest();
			Close();
			return 0;
		}

		private static void RunTest()
		{
			int count = int.Parse(reader.ReadLine());
			for (int i = 0; i < count; ++i) {
				writer.WriteLine("Hello, World!");
			}
		}

		private static bool IsDebug()
		{
#if DEBUG
			return true;
#else
			return false;
#endif
		}

		private static void Close()
		{
			onProgramClosing?.Invoke();
		}
	}
}
