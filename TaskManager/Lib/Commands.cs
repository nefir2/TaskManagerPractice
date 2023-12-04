namespace TaskManager.Lib
{
	/// <summary>
	/// class with realization of commands.
	/// </summary>
	public class Commands
	{
		/// <summary>
		/// file provider.
		/// </summary>
		private readonly DataFileManager dfm;
		/// <summary>
		/// ctor that initializing new object for <see cref="dfm"/>
		/// </summary>
		public Commands()
		{
			dfm = new DataFileManager();
		}
		/// <summary>
		/// enum with provided commands to program.
		/// </summary>
		public enum Cmnds { add, delete, list/*, exit*/ }
		/// <summary>
		/// adds new value to file.
		/// </summary>
		/// <param name="args">values to add to file.</param>
		/// <exception cref="ArgumentNullException"/>
		public void Add(string[] args)
		{
			if (args.Length == 0) throw new ArgumentNullException(nameof(args)); //if no args - nothing to add.
			for (int i = 0; i < args.Length; i++) dfm.AddValue(args[i]); //adds a value.
		}
		/// <summary> deletes every value by each key in <paramref name="args"/>. </summary>
		/// <remarks> throws <see cref="KeyNotFoundException"/> if key is not found and stops program. </remarks>
		/// <param name="args">keys to delete from <see cref="dfm"/>.</param>
		/// <exception cref="ArgumentNullException"/>
		/// <exception cref="KeyNotFoundException"/>
		public void Delete(string[] args, Action<string> output)
		{
			if (args.Length == 0) throw new ArgumentNullException(nameof(args)); //if no args throws null args exception
			for (int i = 0; i < args.Length; i++) //cycle for all args if it more than or equals 1
			{
				try //try to remove
				{
					dfm.RemoveValue(Convert.ToInt32(args[i])); //removing chosen value
				}
				catch (KeyNotFoundException) //if key not exists, shows error message about it
				{
					output.Invoke($"value for key \"{args[i]}\" is not found.");
				}
				catch (Exception ex) //for any other exceptions
				{
					output.Invoke(ex.Message);
				}
			}
		}
		/// <summary>
		/// shows a list of values in <see cref="dfm"/>.
		/// </summary>
		/// <param name="output">action that will be output string.</param>
		public void List(Action<string> output)
		{
			for (int i = 0; i < dfm.Data.Count; i++) output?.Invoke($"{i}) {dfm.Data[i]}"); //output list of values in exact format using outter outputer
		}
		//internal static void Exit()
		//{
		//	Environment.Exit(0);
		//}
	}
}