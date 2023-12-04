using TaskManager.Lib;
namespace TaskManager
{
	/// <summary>
	/// main class for entry point.
	/// </summary>
	internal class Program
	{
		/// <summary>
		/// entry point.
		/// </summary>
		/// <param name="args">arguments from console.</param>
		internal static void Main(string[] args)
		{
			if (args.Length <= 0 || args[0].StartsWith("h") || args[0].StartsWith("-h") || args[0].StartsWith("--h")) //if no args, or it's request for help, than it shows help end closes program
			{
				Help(Console.WriteLine); //write help by Console.WriteLine method
				return; //close app
			}

			try //try to manage
			{
				Arguments.SetArg(Arguments.GetArg(args[0]), args, Console.WriteLine); //choose command, insert arguments and using Console.WriteLine for any outputs. after chosen command, chooses suitable method
			}
			catch (Exception ex) //if any exception - write it
			{
				Console.WriteLine(ex.Message);
			}
		}
		/// <summary>
		/// shows help in chosen output.
		/// </summary>
		/// <param name="output">output method.</param>
		internal static void Help(Action<string> output)
		{
			output?.Invoke
			(
				$"usage: {Environment.ProcessPath} {{ a[dd] | d[elete] | l[ist] | h[elp] | -h | --help }} [ values... ]\n" + //write full path with name to executable file
				$"program that manages tasks.\n\n" +
				$"commands:\n" +
				$"\tadd [ values... ] - adds new values to tasks\n" +
				$"\tdelete [ values... ] - removes existing values from tasks\n" +
				$"\tlist - shows list of existing values\n" +
				$"\thelp|-h|--help - shows help\n"
			);
		}
	}
}