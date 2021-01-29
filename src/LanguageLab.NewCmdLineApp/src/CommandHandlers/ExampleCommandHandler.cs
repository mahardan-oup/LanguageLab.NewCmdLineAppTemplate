namespace LanguageLab.NewCmdLineApp.CommandHandlers
{
    using System;
    using System.IO;
    using System.Linq;
    using LanguageLab.NewCmdLineApp.Common;

    /// <summary>
    /// An example command handler class
    /// </summary>
    internal class ExampleCommandHandler : CommandHandlerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleCommandHandler" /> class.
        /// </summary>
        /// <param name="sourceFile">The full address of the XML file to be analyzed</param>
        /// <param name="coreOptions">The source, target, outputType, recurse and file pattern options for this command</param>
        public ExampleCommandHandler(FileInfo sourceFile, CoreOptions coreOptions)
        : base(coreOptions)
        {
            SourceFile = sourceFile;
        }

        private FileInfo SourceFile { get; }

        /// <summary>
        /// Runs the command
        /// </summary>
        protected override void RunCommand()
        {
            Console.WriteLine("Running the exaple command");
        }

        /// <summary>
        /// Echoes and validates the selected non-core options to the console
        /// </summary>
        /// <returns><c>true</c> if all non-core options are valid. <c>false</c> otherwise</returns>
        protected override bool ValidateNonCoreOptions()
        {
            Console.WriteLine($"Source file {SourceFile.Name} exist? {SourceFile.Exists}");
            return SourceFile.Exists;
        }
    }
}