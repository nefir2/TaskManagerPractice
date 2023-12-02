using TaskManager.Lib;
namespace TaskManager
{
	internal class Program
	{
		internal static void Main(string[] args)
		{
			if (args.Length <= 1)
			{

			}
			Arguments.SetArg(Arguments.GetArg(args[0]), args);
		}
	}
}