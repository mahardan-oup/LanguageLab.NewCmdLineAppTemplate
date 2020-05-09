namespace LanguageLab.NewCmdLineApp
{
    using System.CommandLine;

    /// <summary>
    /// A sample command line program
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main entry method for class
        /// </summary>
        /// <param name="args">Command line arguments for the program</param>
        /// <returns>Reports, usually</returns>
        public static void Main(string[] args)
        {
            var cmdBuilder = new CommandLineBuilder();
            var rootCommand = cmdBuilder.GetRootCommand();
            rootCommand.InvokeAsync(args).Wait();
        }
    }
}
