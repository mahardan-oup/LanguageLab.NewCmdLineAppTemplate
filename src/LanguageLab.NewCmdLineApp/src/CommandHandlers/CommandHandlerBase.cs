namespace LanguageLab.NewCmdLineApp.CommandHandlers
{
    using System;
    using System.IO;
    using System.Linq;
    using LanguageLab.NewCmdLineApp.Common;

    /// <summary>
    /// Abstract base class for all command handlers.
    /// </summary>
    public abstract class CommandHandlerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandHandlerBase" /> class.
        /// </summary>
        protected CommandHandlerBase()
        {
            FilePattern = "*.*";
            CheckChildDirectories = false;
            FileTypeToReturn = OutputType.Xlsx;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandHandlerBase" /> class.
        /// </summary>
        /// <param name="coreOptions">The source, target, output type, recurse and file pattern options for this command</param>
        protected CommandHandlerBase(CoreOptions coreOptions)
        {
            if (coreOptions == null)
            {
                throw new ArgumentNullException(nameof(coreOptions));
            }

            SourceDirectory = coreOptions.SourceDirectory;
            FilePattern = coreOptions.FilePattern;
            TargetDirectory = coreOptions.TargetDirectory;
            CheckChildDirectories = coreOptions.AllChildDirectories;
            FileTypeToReturn = coreOptions.OutputFileType;
        }

        /// <summary>
        /// Gets or sets the source directory to find the files to process
        /// </summary>
        protected DirectoryInfo SourceDirectory { get; set; } = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));

        /// <summary>
        /// Gets or sets the target directory for results to be saved into. Default is the desktop.
        /// </summary>
        protected DirectoryInfo TargetDirectory { get; set; } = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));

        /// <summary>
        /// Gets or sets a value indicating whether the command should look recursively through all subfolders of the source directory or not
        /// </summary>
        /// <value><c>true</c> to set recursive search. <c>false</c> to find files only in the one folder</value>
        protected bool CheckChildDirectories { get; set; }

        /// <summary>
        /// Gets or sets the file pattern for files to use within source directory.
        /// </summary>
        protected string FilePattern { get; set; }

        /// <summary>
        /// Gets or sets the output type for the result of the script. The default is an excel file.
        /// </summary>
        protected OutputType FileTypeToReturn { get; set; }

        /// <summary>
        /// Runs the handler
        /// </summary>
        public void Go()
        {
            if (!Initialize())
            {
                return;
            }

            RunCommand();
        }

        /// <summary>
        /// Runs the handler
        /// </summary>
        protected abstract void RunCommand();

        /// <summary>
        /// Parses and validates as necessary the values of any command parameters not described in core options
        /// </summary>
        /// <returns><c>true</c> if all parameters are valid, <c>false</c> otherwise</returns>
        protected abstract bool ValidateNonCoreOptions();

        private bool Initialize()
        {
            Console.WriteLine($"Search pattern : {FilePattern}");
            Console.WriteLine($"Check child directories : {CheckChildDirectories}");
            var sourceFiles = SourceDirectory.EnumerateFiles(FilePattern, CheckChildDirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
            Console.WriteLine($"Source Directory : {SourceDirectory.FullName}, {sourceFiles.Count()} files");
            Console.WriteLine($"Target Directory : {TargetDirectory.FullName}");
            Console.WriteLine($"Output file type : {FileTypeToReturn}");

            return ValidateNonCoreOptions();
        }
    }
}