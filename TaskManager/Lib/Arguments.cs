namespace TaskManager.Lib
{
	public class Arguments
	{
		/// <summary> checks first argument and set suitable method. </summary>
		/// <param name="firstArg">the first argument from all args. represents command to program.</param>
		/// <returns>returns chosen command as <see cref="Commands.Cmnds"/>.</returns>
		/// <exception cref="ArgumentNullException"/>
		/// <exception cref="ArgumentException"/>
		public static Commands.Cmnds GetArg(string firstArg)
		{
			if (firstArg is null) throw new ArgumentNullException(nameof(firstArg));
			return firstArg.ToLower().First() switch
			{
				'a' => Commands.Cmnds.add,
				'd' => Commands.Cmnds.delete,
				'l' => Commands.Cmnds.list,
				//'e' => Commands.exit, //this is unnecessary because it works with arguments to program and closes. 
				_ => throw new ArgumentException("Argument doesn't match to any provided command.")
			};
		}
		/// <summary> choses suitable method in <see cref="Commands"/> class, and throws in it remaining arguments </summary>
		/// <remarks> skips first argument, because this is command to program. </remarks>
		/// <param name="command">chosen command</param>
		/// <param name="args">all arguments from executed command to program.</param>
		/// <exception cref="ArgumentException"/>
		public static void SetArg(Commands.Cmnds command, string[] args, Action<string> output)
		{
			Commands cms = new Commands();
			switch (command)
			{
				case Commands.Cmnds.add:
					cms.Add(args.Skip(1).ToArray());
					break;
				case Commands.Cmnds.delete:
					cms.Delete(args.Skip(1).ToArray());
					break;
				case Commands.Cmnds.list:
					cms.List(output);
					break;
				default:
					throw new ArgumentException("Argument doesn't match to any provided command.");
			}
		}
	}
}
