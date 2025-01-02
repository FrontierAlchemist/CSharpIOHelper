using System;
using System.Collections.Generic;
using System.Globalization;

namespace CSharpIOHelper
{
	public class InputProvider
	{
		private readonly IInputReader reader;
		private readonly IEnumerator<string> enumerator;

		public InputProvider(IInputReader reader)
		{
			this.reader = reader;
			enumerator = GetEnumerator();
		}

		public T GetValue<T>() where T : IParsable<T>
		{
			return T.Parse(GetNextStringFromInput(), CultureInfo.CurrentCulture);
		}

		public T[] GetArray<T>(int size) where T: IParsable<T>
		{
			T[] array = new T[size];
			for (int i = 0; i < size; ++i) {
				array[i] = GetValue<T>();
			}
			return array;
		}

		public List<T> GetList<T>(int size) where T: IParsable<T>
		{
			List<T> list = new(size);
			for (int i = 0; i < size; ++i) {
				list.Add(GetValue<T>());
			}
			return list;
		}

		private string GetNextStringFromInput()
		{
			enumerator.MoveNext();
			return enumerator.Current;
		}

		private IEnumerator<string> GetEnumerator()
		{
			while (true) {
				string[] valuesFromInput = reader.ReadLine().Split(' ');
				foreach (string value in valuesFromInput) {
					yield return value;
				}
			}
		}
	}
}
