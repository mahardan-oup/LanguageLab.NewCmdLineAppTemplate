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
        /// <param name="excludeSuppressedElements"><c>true</c> if suppressed elements should be excluded from the analysis. <c>false</c> if not.</param>
        /// <param name="excludeOnlineElements"><c>true</c> if online-only elements should be excluded from the analysis. <c>false</c> if not.</param>
        public ExampleCommandHandler(FileInfo sourceFile, bool excludeSuppressedElements, bool excludeOnlineElements)
        {
            SourceFile = sourceFile;
            ExcludeSuppressedElements = excludeSuppressedElements;
            ExcludeOnlineElements = excludeOnlineElements;
        }

        private FileInfo SourceFile { get; }

        private bool ExcludeSuppressedElements { get; }

        private bool ExcludeOnlineElements { get; }

        /// <summary>
        /// Call this method to run the report.
        /// </summary>
        internal void Go()
        {
            Console.WriteLine($"Source file {SourceFile.Name} exist? {SourceFile.Exists}");
            Console.WriteLine($"Exclude suppressed elements? {ExcludeSuppressedElements}");
            Console.WriteLine($"Exclude online elements? {ExcludeOnlineElements}");
        }
    }
}