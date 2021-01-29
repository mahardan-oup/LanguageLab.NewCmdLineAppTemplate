namespace LanguageLab.NewCmdLineApp.Common
{
    using System;
    using System.IO;

    /// <summary>
    /// Complex type holding all directory related options for each command
    /// </summary>
    public class CoreReportOptions
    {
        /// <summary>
        /// Gets or sets the source directory to find the files to process
        /// </summary>
        public DirectoryInfo SourceDirectory { get; set; } = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));

        /// <summary>
        /// Gets or sets a value indicating whether the command should look recursively through all subfolders of the source directory or not
        /// </summary>
        /// <value><c>true</c> to set recursive search. <c>false</c> to find files only in the one folder</value>
        public bool RecurseDirectories { get; set; }

        /// <summary>
        /// Gets or sets the file pattern for files to use within source directory.
        /// </summary>
        public string FilePattern { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the output type for the result of the script. The default is an excel file.
        /// </summary>
        public ReportFileType ReportFileType { get; set; } = ReportFileType.Xlsx;
    }
}