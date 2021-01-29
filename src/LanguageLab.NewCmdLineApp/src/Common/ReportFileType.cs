namespace LanguageLab.NewCmdLineApp.Common
{
    /// <summary>
    /// Enum for the different report file types
    /// </summary>
    public enum ReportFileType
    {
        /// <summary>output type is not specified</summary>
        Unspecified = 0,

        /// <summary>command should return a text file</summary>
        Txt,

        /// <summary>command should return a csv file</summary>
        Csv,

        /// <summary>comman should return a xls file</summary>
        Xlsx,
    }
}