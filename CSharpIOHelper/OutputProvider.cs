namespace CSharpIOHelper
{
	public class OutputProvider
	{
		private readonly IOutputWriter writer;

		public OutputProvider(IOutputWriter writer)
		{
			this.writer = writer;
		}

		public void Write(string text) => writer.Write(text);

		public void Write(object obj) => writer.Write(obj.ToString()!);

		public void WriteLine(string text) => writer.WriteLine(text);

		public void WriteLine(object obj) => writer.WriteLine(obj.ToString()!);
	}
}
