namespace LanguageLab.NewCmdLineApp.CommandHandlers
{
    using System;
    using System.IO;
    using System.Linq;
    using LanguageLab.NewCmdLineApp.Common;

    /// <summary>
    /// An example command handler class
    /// </summary>
    internal class SimpleCommandHandler : CommandHandlerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleCommandHandler" /> class.
        /// </summary>
        public SimpleCommandHandler()
        {
            FilePattern = "*.*";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleCommandHandler" /> class.
        /// </summary>
        /// <param name="sourceDirectory">The source directory for this command</param>
        /// <param name="filePattern">The source file pattern for this command</param>
        public SimpleCommandHandler(DirectoryInfo sourceDirectory, string filePattern)
        {
            SourceDirectory = sourceDirectory;
            FilePattern = filePattern;
        }

        /// <summary>
        /// Gets or sets the source directory to find the files to process
        /// </summary>
        protected DirectoryInfo SourceDirectory { get; set; } = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));

        /// <summary>
        /// Gets or sets the file pattern for files to use within source directory.
        /// </summary>
        protected string FilePattern { get; set; }

        /// <summary>
        /// Runs the simple command
        /// </summary>
        protected override void RunCommand()
        {
            SendToConsole("Running the simple command", ConsoleColor.Red);
        }

        /// <summary>
        /// Parses and validates as necessary the values of any command parameters not described in core options
        /// </summary>
        /// <returns><c>true</c> if all parameters are valid, <c>false</c> otherwise</returns>
        protected override bool ValidateOptions()
        {
            Console.WriteLine($"File pattern : {FilePattern}");
            var sourceFiles = SourceDirectory.EnumerateFiles(FilePattern, SearchOption.TopDirectoryOnly);
            Console.WriteLine($"Source Directory : {SourceDirectory.FullName}, {sourceFiles.Count()} files");
            return true;
        }
    }
}