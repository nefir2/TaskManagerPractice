namespace TaskManager.Lib
{
	internal class DataFileManager
	{
		private const string separator = " ";
		private const string nameOfDB = "Tasks.db";
		private Dictionary<int, string> data = new Dictionary<int, string>();
		//internal Dictionary<int, string> Data { get => data; set => data = value; } //if get data, then fetch file, and from file return data. if set data, then fetch file, check if id is exist, and set data.
		DataFileManager() { }
		private void ReadFile()
		{
			string[] LinesInFile = File.ReadAllLines(nameOfDB);
			foreach (string Line in LinesInFile)
			{

			}			
		}
		private KeyValuePair<int, string> ParseLine(string line)
		{
			int k = -1;
			string v = "";
			for (int i = 0; i < line.Length; i++)
			{
				if (line[i].Equals(separator))
				{
					k = Convert.ToInt32(line.Cut(0, i));
					v = line.Cut(i + 1, line.Length);
					break;
				}
			}
			return new KeyValuePair<int, string>(k, v);
		}
	}
}
