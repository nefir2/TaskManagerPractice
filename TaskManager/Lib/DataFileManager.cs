namespace TaskManager.Lib
{
	/// <summary>
	/// class that represents file manager with dictionary storing.
	/// </summary>
	public class DataFileManager
	{
		/// <summary>
		/// separator to separate key and value in data base file.
		/// </summary>
		private const string separator = " ";
		/// <summary>
		/// name of data base file.
		/// </summary>
		private const string nameOfDB = "Tasks.db";
		/// <summary>
		/// field for stored data in file.
		/// </summary>
		private Dictionary<int, string> data;
		/// <summary>
		/// returns dictionary value.
		/// </summary>
		public Dictionary<int, string> Data => data; //get dictionary to get data from it
		/// <summary>
		/// reads data from file, and writes to <see cref="data"/> if file exists. else making new object for <see cref="data"/>.
		/// </summary>
		public DataFileManager()
		{
			data = new Dictionary<int, string>(); //creates new object for dictionary
			if (File.Exists(nameOfDB) && File.ReadAllLines(nameOfDB).Length > 0) ReadFile(); //writes all data from file to dictionary
		}
		/// <summary> uses <see cref="data.this[]"/>. </summary>
		/// <value> sets a value and rewriting a file with new value. </value>
		/// <param name="k">key to value.</param>
		/// <returns>returns a value by <paramref name="k"/> parameter.</returns>
		public string this[int k]
		{
			get => data[k]; //returns value from data
			set
			{
				data[k] = value; //changes value to chosen key
				WriteFile(); //rewrite file with new data
			}
		}
		/// <summary>
		/// adds a value to the end of <see cref="data"/>.
		/// </summary>
		/// <param name="str"></param>
		public void AddValue(string str)
		{
			data.Add(data.Count, str); //adding new value to the end
			WriteFile(); //rewrite file with new data
		}
		/// <summary>
		/// removes value from <see cref="data"/> and resets keys to avoid key skip.
		/// </summary>
		/// <param name="key">key to remove.</param>
		/// <exception cref="KeyNotFoundException"/>
		public void RemoveValue(int key)
		{
			if (!data.TryGetValue(key, out _)) throw new KeyNotFoundException(); //throws if key is not found
			data.Remove(key); //remove chosen value
			if (data.Count > 1) for (int i = key; i < data.Count - 1; i++) data[i] = data[i + 1]; //move all values to removed
			if (key != data.Count) data.Remove(data.Count - 1); //remove clone if it is not last key.
			WriteFile(); //rewrite file with new data
		}
		private static void ClearFile()
		{
			using FileStream fs = new(nameOfDB, FileMode.Open, FileAccess.ReadWrite); //opening file stream by using
			fs.SetLength(0); //clear file
		}
		/// <summary>
		/// remaking a file for data, and writes <see cref="data"/> in file, in exact format.
		/// </summary>
		private void WriteFile()
		{
			ClearFile(); //clears file to overwrite it.
			for (int i = 0; i < data.Count; i++) File.AppendAllText(nameOfDB, $"{i}{separator}{data[i]}\n"); //save all lines to file. here stores format for saving.
		}
		/// <summary>
		/// reads all lines from file and writes in <see cref="data"/>.
		/// </summary>
		private void ReadFile()
		{
			string[] LinesInFile = File.ReadAllLines(nameOfDB); //reads lines from file.
			foreach (string Line in LinesInFile) data.Add(ParseLine(Line, out string v), v); //sets read lines in dictionary.
		}
		/// <summary> parses line and checks for key and value in this line, separated by <see cref="separator"/>. </summary>
		/// <remarks> returns <c>-1</c> and <paramref name="v"/> as <c>""</c> if line was not parsed. </remarks>
		/// <param name="line">full line, to parse it.</param>
		/// <param name="v">value that returns from parsed <paramref name="line"/>.</param>
		/// <returns>key that returns from parsed <paramref name="line"/>.</returns>
		/// <exception cref="ArgumentNullException"/>
		private static int ParseLine(string line, out string v)
		{
			if (line is null) throw new ArgumentNullException(nameof(line));
			int k = -1; //default value, if it can't be parsed.
			v = "";
			for (int i = 0; i < line.Length; i++) //cycle to parse a string.
			{
				if (line[i].ToString().Equals(separator)) //if first entry of separator symbol is found, then return parsed to 2 values (before and after separator).
				{
					k = Convert.ToInt32(line.Cut(0, i)); //cut first value from string.
					v = line.Cut(i + 1, line.Length); //cut second value from string.
					break; //end of cycle, all was found.
				}
			}
			return k; //v is already returned by "out" keyword, now returns k.
		}
	}
}
