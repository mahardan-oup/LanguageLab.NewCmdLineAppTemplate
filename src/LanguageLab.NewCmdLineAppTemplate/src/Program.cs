namespace LanguageLab.NewCmdLineAppTemplate
{
    using System.CommandLine.Invocation;

    internal class Program
    {
        public static int Main(string[] args)
        {
            var cmdBuilder = new CommandLineBuilder();
            var rootCommand = cmdBuilder.GetRootCommand();
            return rootCommand.InvokeAsync(args).Result;
        }
    }
}
