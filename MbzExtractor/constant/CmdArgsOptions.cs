using UsefulCsharpCommonsUtils.cli.argsparser;

namespace MbzExtractor.constant
{
    internal static class CmdArgsOptions
    {
        public static readonly Option OptShowHelp = new Option()
        {
            ShortOpt = "h",
            LongOpt = "help",
            Description = "Show help",
            HasArgs = false,
            Name = "OptShowHelp",
            IsMandatory = false

        };

        public static readonly Option OptFileMbz = new Option()
        {
            ShortOpt = "f",
            LongOpt = "file",
            Description = "File",
            HasArgs = true,
            Name = "OptFileMbz",
            IsMandatory = true

        };


        public static readonly Option OptOutDir = new Option()
        {
            ShortOpt = "o",
            LongOpt = "out-dir",
            Description = "Out folder",
            HasArgs = true,
            Name = "OptOutDir",
            IsMandatory = false

        };

        

    }
}
