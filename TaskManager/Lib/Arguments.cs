namespace TaskManager.Lib
{
	/// <summary>
	/// class with arguments and available commands
	/// </summary>
	public class Arguments
	{
		/// <summary> checks first argument and set suitable method. </summary>
		/// <param name="firstArg">the first argument from all args. represents command to program.</param>
		/// <returns>returns chosen command as <see cref="Commands.Cmnds"/>.</returns>
		/// <exception cref="ArgumentNullException"/>
		/// <exception cref="ArgumentException"/>
		public static Commands.Cmnds GetArg(string firstArg)
		{
			if (firstArg is null) throw new ArgumentNullException(nameof(firstArg)); //if no args - throws exception
			return firstArg.ToLower().First() switch //choosing command by first symbol, without knowing about is LowerCase or Uppercase.
			{
				'a' => Commands.Cmnds.add,
				'd' => Commands.Cmnds.delete,
				'l' => Commands.Cmnds.list,
				//'e' => Commands.exit, //this is unnecessary because it works with arguments to program and closes. 
				_ => throw new ArgumentException("Argument doesn't match to any provided command.") //if command not found, throws this exception
			};
		}
		/// <summary> choses suitable method in <see cref="Commands"/> class, and throws in it remaining arguments </summary>
		/// <remarks> skips first argument, because this is command to program. </remarks>
		/// <param name="command">chosen command</param>
		/// <param name="args">all arguments from executed command to program.</param>
		/// <exception cref="ArgumentException"/>
		public static void SetArg(Commands.Cmnds command, string[] args, Action<string> output)
		{
			Commands cms = new Commands(); //object with Commands
			switch (command) //switch chosen command
			{
				case Commands.Cmnds.add:
					cms.Add(args.Skip(1).ToArray()); //skips first arg, because it's the command
					break;
				case Commands.Cmnds.delete:
					cms.Delete(args.Skip(1).ToArray(), output); //output to show error without interrupting sequence
					break;
				case Commands.Cmnds.list:
					cms.List(output); //show list of values from file, output for choosing place to output
					break;
				default:
					throw new ArgumentException("Argument doesn't match to any provided command."); //if chosen command not found, this throws.
			}
		}
	}
}