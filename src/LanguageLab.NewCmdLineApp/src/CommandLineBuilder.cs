namespace LanguageLab.NewCmdLineApp
{
    using System.CommandLine;
    using System.CommandLine.Invocation;
    using System.IO;
    using LanguageLab.NewCmdLineApp.CommandHandlers;

    /// <summary>
    /// The class builds the command-line options for each utility.
    /// See https://github.com/dotnet/command-line-api/wiki on how to work with the new System.CommandLine
    /// </summary>
    internal class CommandLineBuilder
    {
        private Option fOption =
            new Option<FileInfo>(
                new string[] { "-f", "--sourceFile" },
                "Source file")
            { IsRequired = true }.ExistingOnly();

        private Option dOption =
            new Option<DirectoryInfo>(
                new string[] { "-d", "--sourceDirectory" },
                "Source directory")
            { IsRequired = true }.ExistingOnly();

        private Option oOption =
            new Option<OutputType>(
                new string[] { "-o", "--outputType" },
                getDefaultValue: () => OutputType.Xlsx,
                "Sets the type of file output by the script. Options are xls, csv, txt.");

        private Option xsOption =
            new Option<bool>(
                new string[] { "-xs", "--excludeSuppressed" },
                getDefaultValue: () => false,
                "Exclude suppressed elements");

        private Option xoOption =
            new Option<bool>(
                new string[] { "-xo", "--excludeOnline" },
                getDefaultValue: () => false,
                "Exclude online elements");

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
            var subCommand = new Command("sub", "Describe your subcommand here");
            subCommand.AddOption(fOption);
            subCommand.AddOption(dOption);
            subCommand.AddOption(xsOption);
            subCommand.AddOption(xoOption);
            subCommand.AddOption(oOption);

            subCommand.Handler = CommandHandler.Create<FileInfo, DirectoryInfo, bool, bool, OutputType>((sourceFile, sourceDirectory, excludeSuppressed, excludeOnline, outputType) =>
            {
                ExampleCommandHandler ech = new ExampleCommandHandler(sourceFile, sourceDirectory, excludeSuppressed, excludeOnline, outputType);
                ech.Go();
            });

            return subCommand;
        }
    }
}