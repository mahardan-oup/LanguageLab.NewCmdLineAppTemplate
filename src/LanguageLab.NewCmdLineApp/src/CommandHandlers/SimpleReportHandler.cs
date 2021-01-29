namespace LanguageLab.NewCmdLineApp.CommandHandlers
{
    using System;
    using System.Collections.Generic;
    using LanguageLab.Common.IO;
    using LanguageLab.NewCmdLineApp.Common;

    /// <summary>
    /// Handler that builds a simple report
    /// </summary>
    public class SimpleReportHandler : ReportCommandHandlerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleReportHandler"/> class.
        /// </summary>
        public SimpleReportHandler()
         : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleReportHandler"/> class.
        /// </summary>
        /// <param name="coreOptions">The core options for this command</param>
        public SimpleReportHandler(CoreReportOptions coreOptions)
         : base(coreOptions)
        {
        }

        /// <inheritdoc/>
        protected override void BuildReport()
        {
            SendToConsole("Running Simple Report Command", ConsoleColor.Red);
            ReportFileName = "SimpleReport";
            Worksheet ws = new Worksheet("SheetName");
            ws.Rows.Add(new List<string> { "Hello", "World" });
            Reports.Add(ws);
        }

        /// <inheritdoc/>
        protected override bool ValidateNonCoreOptions()
        {
            return true;
        }
    }
}