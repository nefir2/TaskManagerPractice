using TaskManager.Lib;
namespace TaskManager
{
	internal class Program
	{
		internal static void Main(string[] args)
		{
			if (args.Length <= 0 || args[0].StartsWith("h") || args[0].StartsWith("-h") || args[0].StartsWith("--h"))
			{
				Help(Console.WriteLine);
				return;
			}
			try
			{
				Arguments.SetArg(Arguments.GetArg(args[0]), args, Console.WriteLine);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		internal static void Help(Action<string> output)
		{
			output?.Invoke
			(
				$"usage: {Environment.ProcessPath} {{a[dd]|d[elete]|l[ist]|h[elp]|-h|--help}} [parameters]...\n" +
				$"program that manages tasks.\n\n" +
				$"commands:\n" +
				$"\tadd [value]... - adds new values to tasks\n" +
				$"\tdelete [value]... - removes existing values from tasks\n" +
				$"\tlist - shows list of existing values\n" +
				$"\thelp|-h|--help - shows help\n"
			);
		}
	}
}