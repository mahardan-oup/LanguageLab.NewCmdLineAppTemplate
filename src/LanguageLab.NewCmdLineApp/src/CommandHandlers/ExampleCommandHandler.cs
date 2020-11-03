namespace LanguageLab.NewCmdLineApp.CommandHandlers
{
    using System;
    using System.IO;

    /// <summary>
    /// An example command handler class
    /// </summary>
    internal class ExampleCommandHandler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleCommandHandler" /> class.
        /// </summary>
        /// <param name="sourceFile">The full address of the XML file to be analyzed</param>
        /// <param name="sourceDirectory">The full address of directory to find source files in</param>
        /// <param name="excludeSuppressedElements"><c>true</c> if suppressed elements should be excluded from the analysis. <c>false</c> if not.</param>
        /// <param name="excludeOnlineElements"><c>true</c> if online-only elements should be excluded from the analysis. <c>false</c> if not.</param>
        /// <param name="outputType">The file type the script should return</param>
        public ExampleCommandHandler(FileInfo sourceFile, DirectoryInfo sourceDirectory, bool excludeSuppressedElements, bool excludeOnlineElements, OutputType outputType)
        {
            SourceFile = sourceFile;
            SourceDirectory = sourceDirectory;
            ExcludeSuppressedElements = excludeSuppressedElements;
            ExcludeOnlineElements = excludeOnlineElements;
            FileTypeToReturn = outputType == OutputType.Unspecified ? OutputType.Xlsx : outputType;
        }

        private FileInfo SourceFile { get; }

        private DirectoryInfo SourceDirectory { get; set; } = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));

        private bool ExcludeSuppressedElements { get; }

        private bool ExcludeOnlineElements { get; }

        private OutputType FileTypeToReturn { get; } = OutputType.Xlsx;

        /// <summary>
        /// Call this method to run the report.
        /// </summary>
        internal void Go()
        {
            Console.WriteLine($"Source file {SourceFile.Name} exist? {SourceFile.Exists}");
            Console.WriteLine($"Source directory {SourceDirectory.Name} exist? {SourceDirectory.Exists}");
            Console.WriteLine($"Exclude suppressed elements? {ExcludeSuppressedElements}");
            Console.WriteLine($"Exclude online elements? {ExcludeOnlineElements}");
            Console.WriteLine($"Output file type : {FileTypeToReturn}");
        }
    }
}