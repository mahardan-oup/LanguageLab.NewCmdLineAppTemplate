namespace LanguageLab.NewCmdLineAppTemplate
{
    using System.CommandLine;
    using System.CommandLine.Builder;
    using System.CommandLine.Invocation;
    using System.IO;
    using LanguageLab.NewCmdLineAppTemplate.CommandHandlers;

    /// <summary>
    /// The class builds the command-line options for each utility.
    /// </summary>
    internal class CommandLineBuilder
    {
        private Option fOption = new Option(new string[] { "-f", "--sourceFile" }, "Source file") { Argument = new Argument<FileInfo>() { Arity = ArgumentArity.ExactlyOne }.ExistingOnly() };

        private Option xsOption = new Option(new string[] { "-xs", "--excludeSuppressed" }, "Exclude suppressed elements") { Argument = new Argument<bool>(defaultValue: () => false) };

        private Option xoOption = new Option(new string[] { "-xo", "--excludeOnline" }, "Exclude online elements") { Argument = new Argument<bool>(defaultValue: () => false) };

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandLineBuilder" /> class.
        /// </summary>
        internal CommandLineBuilder()
        {
        }

        /// <summary>
        /// Builds the command-line options, returning them as a  <see cref="System.CommandLine.RootCommand" /> object.
        /// </summary>
        /// <returns>The <see cref="System.CommandLine.RootCommand" /> object containing the command-line options for this program.</returns>
        internal RootCommand GetRootCommand()
        {
            var rootCommand = new RootCommand("dpsxml");
            rootCommand.Add(BuildSubCommand());
            return rootCommand;
        }

        private Command BuildSubCommand()
        {
            var subCommand = new Command("sub", "Describe your command here");
            subCommand.AddOption(fOption);
            subCommand.AddOption(xsOption);
            subCommand.AddOption(xoOption);

            subCommand.Handler = CommandHandler.Create<FileInfo, bool, bool>((sourceFile, excludeSuppressed, excludeOnline) =>
            {
                ExampleCommandHandler ech = new ExampleCommandHandler(sourceFile, excludeSuppressed, excludeOnline);
                ech.Go();
            });

            return subCommand;
        }
    }
}