namespace LanguageLab.NewCmdLineAppTemplate.CommandHandlers
{
    using System;
    using System.IO;

    internal class ExampleCommandHandler
    {
        private FileInfo SourceFile { get; }
        private bool ExcludeSuppressedElements { get; }
        private bool ExcludeOnlineElements { get; }

        public ExampleCommandHandler(FileInfo sourceFile, bool excludeSuppressedElements, bool excludeOnlineElements)
        {
            SourceFile = sourceFile;
            ExcludeSuppressedElements = excludeSuppressedElements;
            ExcludeOnlineElements = excludeOnlineElements;
        }

        internal void Go()
        {
            Console.WriteLine($"Source file {SourceFile.Name} exist? {SourceFile.Exists}" );
            Console.WriteLine($"Exclude suppressed elements? {ExcludeSuppressedElements}");
            Console.WriteLine($"Exclude online elements? {ExcludeOnlineElements}");
        }
    }
}