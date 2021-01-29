namespace LanguageLab.NewCmdLineApp
{
    using System;
    using System.CommandLine;
    using System.CommandLine.Invocation;
    using System.IO;
    using LanguageLab.NewCmdLineApp.CommandHandlers;
    using LanguageLab.NewCmdLineApp.Common;

    /// <summary>
    /// The class builds the command-line options for each utility.
    /// See https://github.com/dotnet/command-line-api/wiki on how to work with the new System.CommandLine
    /// </summary>
    internal class CommandLineBuilder
    {
        private Option sourceDirectoryOption =
            new Option<DirectoryInfo>(
                new string[] { "-d", "--sourceDirectory" },
                "Source directory")
            { IsRequired = true }.ExistingOnly();

        private Option recurseDirectoriesOption =
            new Option<bool>(
                new string[] { "-r", "--recurseDirectories" },
                getDefaultValue: () => false,
                "Add this flag to process all files in directory specified with -d AND all its child directories.");

        private Option outputTypeOption =
            new Option<ReportFileType>(
                new string[] { "-o", "--outputType" },
                getDefaultValue: () => ReportFileType.Xlsx,
                "Sets the type of file output by the script. Options are xlsx, csv, txt.");

        private Option targetDirectoryOption =
            new Option<DirectoryInfo>(
                new string[] { "-t", "--targetDirectory" },
                getDefaultValue: () => new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)),
                "Target directory for new files.").ExistingOnly();

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
            var rootCommand = new RootCommand("templateCmd");
            rootCommand.Add(BuildSimpleSubCommand());
            rootCommand.Add(BuildReportSubCommand());
            return rootCommand;
        }

        private Option FilePatternOption(string pattern)
        {
            return new Option<string>(
                new string[] { "-f", "--file" },
                getDefaultValue: () => pattern,
                $"File pattern for files to use within source directory. Default is {pattern}");
        }

        private void AddCoreReportCommandOptions(Command subCommand, string pattern)
        {
            subCommand.AddOption(sourceDirectoryOption);
            subCommand.AddOption(outputTypeOption);
            subCommand.AddOption(recurseDirectoriesOption);
            subCommand.AddOption(FilePatternOption(pattern));
        }

        private Command BuildSimpleSubCommand()
        {
            var subCommand = new Command("sub", "Describe your subcommand here");
            subCommand.AddOption(sourceDirectoryOption);
            subCommand.AddOption(FilePatternOption("Somefile.txt"));

            subCommand.Handler = CommandHandler.Create<DirectoryInfo, string>((sourceDirectory, file) =>
            {
                SimpleCommandHandler ech = new SimpleCommandHandler(sourceDirectory, file);
                ech.Go();
            });

            return subCommand;
        }

        private Command BuildReportSubCommand()
        {
            var subCommand = new Command("rep", "Describe your report command here");
            AddCoreReportCommandOptions(subCommand, "*.txt");

            subCommand.Handler = CommandHandler.Create<CoreReportOptions>((coreOptions) =>
            {
                SimpleReportHandler srh = new SimpleReportHandler(coreOptions);
                srh.Go();
            });

            return subCommand;
        }
    }
}