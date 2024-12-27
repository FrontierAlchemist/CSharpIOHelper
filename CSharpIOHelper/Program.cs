using System;

namespace CSharpIOHelper
{
	public class Program
	{
		static readonly InputProvider input;
		static readonly OutputProvider output;

		static Action? onProgramClosing;

		static Program()
		{
			input = new(GetReader());
			output = new(GetWriter());

			IInputReader GetReader()
			{
				const string PathToInputFile = "input.txt";

				IInputReader reader;
				if (IsDebug()) {
					var fileReader = new FileReader(PathToInputFile);
					onProgramClosing += fileReader.CloseFile;
					reader = fileReader;
				} else {
					reader = new ConsoleReader();
				}

				return reader;
			}

			IOutputWriter GetWriter()
			{
				const string PathToOutputFile = "output.txt";

				IOutputWriter writer;
				if (IsDebug()) {
					var fileWriter = new FileWriter(PathToOutputFile);
					onProgramClosing += fileWriter.CloseFile;
					writer = fileWriter;
				} else {
					writer = new ConsoleWriter();
				}

				return writer;
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
			int arraySize = input.GetValue<int>();
			var array = input.GetArray<string>(arraySize);
			output.WriteLine(string.Join(", ", array));
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
