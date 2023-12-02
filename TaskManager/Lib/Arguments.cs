namespace TaskManager.Lib
{
	internal class Arguments
	{
		internal static Commands.Cmnds GetArg(string? firstArg)
		{
			if (firstArg is null) throw new ArgumentNullException(nameof(firstArg));
			return firstArg.ToLower().First() switch
			{
				'a' => Commands.Cmnds.add,
				'd' => Commands.Cmnds.delete,
				'l' => Commands.Cmnds.list,
				/*'e' => Commands.exit,*/
				_ => throw new ArgumentException("Argument doesn't match to any provided command.")
			};
		}
		internal static void SetArg(Commands.Cmnds command, string[] args)
		{
			switch (command)
			{
				case Commands.Cmnds.add:
					Commands.Add(args.Skip(1).ToArray());
					break;
				case Commands.Cmnds.delete:
					Commands.Delete(args.Skip(1).ToArray());
					break;
				case Commands.Cmnds.list:
					Commands.List();
					break;
				default:
					throw new ArgumentException("Argument doesn't match to any provided command.");
			}
		}
	}
}
