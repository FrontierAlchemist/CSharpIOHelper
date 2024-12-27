namespace CSharpIOHelper
{
	public abstract class FileHolder
	{
		protected readonly string path;

		public FileHolder(string path)
		{
			this.path = path;
		}

		public abstract void CloseFile();
	}
}
