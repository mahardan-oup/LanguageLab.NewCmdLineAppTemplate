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

        private Option tdOption =
            new Option<DirectoryInfo>(
                new string[] { "-td", "--targetDirectory" },
                getDefaultValue: () => new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)),
                "Target directory for new files.").ExistingOnly();

        private Option allChildDirectoriesOption =
            new Option<bool>(
                new string[] { "-acd", "--allChildDirectories" },
                getDefaultValue: () => false,
                "Add this flag to process all files in directory specified with -d AND all its child directories.");

        private Option oOption =
            new Option<OutputType>(
                new string[] { "-o", "--outputType" },
                getDefaultValue: () => OutputType.Xlsx,
                "Sets the type of file output by the script. Options are xlsx, csv, txt.");

        private Option fpOption =
            new Option<string>(
                new string[] { "-fp", "--filePattern" },
                getDefaultValue: () => "*.txt",
                "File pattern for files to use within source directory. Default is *.txt");

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
            subCommand.AddOption(tdOption);
            subCommand.AddOption(fpOption);
            subCommand.AddOption(oOption);
            subCommand.AddOption(allChildDirectoriesOption);

            subCommand.Handler = CommandHandler.Create<FileInfo, CoreOptions>((sourceFile, coreOptions) =>
            {
                ExampleCommandHandler ech = new ExampleCommandHandler(sourceFile, coreOptions);
                ech.Go();
            });

            return subCommand;
        }
    }
}