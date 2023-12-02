namespace TaskManager.Lib
{
	public class Commands
	{
		private DataFileManager dfm;
		public Commands()
		{
			dfm = new DataFileManager();
		}
		public enum Cmnds { add, delete, list/*, exit*/ }
		public void Add(string[] args)
		{
			if (args.Length == 0) throw new ArgumentNullException(nameof(args));
            string line = "";
			for (int i = 0; i < args.Length; i++) dfm.AddValue(args[i]); //line = line.AddToEnd(args[i] + " ");
			//line = line.Trim();
			//dfm.AddValue(line);
		}
		/// <summary> deletes every value by each key in <paramref name="args"/>. </summary>
		/// <remarks> throws <see cref="KeyNotFoundException"/> if key is not found and stops program. </remarks>
		/// <param name="args">keys to delete from <see cref="dfm"/>.</param>
		/// <exception cref="ArgumentNullException"/>
		/// <exception cref="KeyNotFoundException"/>
		public void Delete(string[] args)
		{
			if (args.Length == 0) throw new ArgumentNullException();
			for (int i = 0; i < args.Length; i++)
			{
				try
				{
					dfm.RemoveValue(Convert.ToInt32(args[i]));
				}
				catch (KeyNotFoundException ex)
				{
					throw new KeyNotFoundException($"value for key \"{args[i]}\" is not found.", ex.InnerException);
				}
			}
		}
		/// <summary>
		/// shows a list of values in <see cref="dfm"/>.
		/// </summary>
		/// <param name="output">action that will be output string.</param>
		public void List(Action<string> output)
		{
			for (int i = 0; i < dfm.Data.Count; i++) output?.Invoke($"[{i}] = {dfm.Data[i]}");
		}
		//internal static void Exit()
		//{
		//	Environment.Exit(0);
		//}
	}
}
