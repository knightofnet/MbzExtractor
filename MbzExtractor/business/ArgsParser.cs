using System.Collections.Generic;
using MbzExtractor.constant;
using MbzExtractor.dto;
using UsefulCsharpCommonsUtils.cli.argsparser;

namespace MbzExtractor.business
{
    internal class ArgsParser : CliParser<AppConf>
    {
        public ArgsParser()
        {
            AddOption(CmdArgsOptions.OptFileMbz);
            AddOption(CmdArgsOptions.OptOutDir);
            AddOption(CmdArgsOptions.OptShowHelp);
        }

        public override AppConf ParseDirect(string[] args)
        {
            return Parse(args, ParseTrt);

        }

        private AppConf ParseTrt(Dictionary<string, Option> arg)
        {
            AppConf conf = new AppConf();

            if (HasOption(CmdArgsOptions.OptShowHelp, arg))
            {
                conf.ShowHelp = true;
            }


            conf.FileMbz = GetSingleOptionValue(CmdArgsOptions.OptFileMbz, arg);

            conf.OutFolder = GetSingleOptionValue(CmdArgsOptions.OptOutDir, arg);



            // ...

            return conf;

        }
    }
}
