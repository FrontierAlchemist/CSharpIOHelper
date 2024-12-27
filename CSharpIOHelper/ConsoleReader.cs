using System;

namespace CSharpIOHelper
{
	public class ConsoleReader : IInputReader
	{
		public string ReadLine()
			=> Console.ReadLine() ?? throw new FormatException("Error while trying to read a line from console.");
	}
}
