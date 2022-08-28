using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using MbzExtractor.business;
using MbzExtractor.constant;
using MbzExtractor.dto;
using MbzExtractor.dto.inner;
using MbzExtractor.utils;
using NLog;
using SharpCompress.Archives.GZip;
using SharpCompress.Archives.Tar;
using SharpCompress.Common;
using SharpCompress.Readers;
using UsefulCsharpCommonsUtils.file;
using UsefulCsharpCommonsUtils.file.dir;
using UsefulCsharpCommonsUtils.lang;
using File = System.IO.File;

namespace MbzExtractor
{
    internal class Program
    {
        private static Logger Log = null;

        private static readonly string AppDataDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MbzExtractor");


        private AppConf _appConf = null;

        static void Main(string[] args)
        {
            InitLogger();

            Log.Debug("Start program...");




            ArgsParser argsParser = new ArgsParser();
            AppConf appConf = argsParser.ParseDirect(args);

            Program mainProgram = new Program();

            try
            {
                mainProgram.Launch(appConf);
                Environment.Exit(EnumExitCodes.OK.Index);
            }
            catch (Exception ex)
            {
#if DEBUG
                Log.Error(ex);
                throw ex;
#else
                
#endif
            }
            finally
            {
                Log.Debug("End of the program");
            }

        }

        private void Launch(AppConf pConf)
        {
            _appConf = pConf;


            
            Log.Info("Expanding archive");
            string outPath = null;
            Dir tarFolder = null;
            if (File.Exists(pConf.FileMbz))
            {
                outPath = Path.Combine(Path.GetTempPath(), CommonsStringUtils.RandomString(16));
                tarFolder = Untar(_appConf.FileMbz, outPath);
                Log.Debug($"Expanding in ${tarFolder.Fullname}");
            }
            else
            {
                outPath= Path.Combine(Path.GetTempPath(), pConf.FileMbz);
                tarFolder = new Dir(outPath);
                Log.Debug($"Reading in ${tarFolder.Fullname}");
            }

            
            Console.WriteLine();


            Log.Info("Start parsing datas...");
            MbzParser mbzParser = new MbzParser(tarFolder);
            BackupDatas mB = mbzParser.Parse(tarFolder);
            Log.Info("End parsing datas.");
            Console.WriteLine();


            Log.Info("Start ordering...");
            MbzExportToFilesAndFolder mbzOut = new MbzExportToFilesAndFolder();
            mbzOut.DoOutWork(mB, _appConf.OutFolder);
            Log.Info("End ordering");
            Console.WriteLine();


            Log.Info("Delete temp files");
            if (mB.RootFolder.Exists)
            {
                mB.RootFolder.Delete();
            }
            Console.WriteLine();

#if DEBUG
            Console.ReadLine();
#endif
        }



        private Dir Untar(string file, string outDir)
        {
            Dir retDir = new Dir(outDir);
            retDir.CreateIfNot();

            using (Stream stream = File.OpenRead(file))
            {
                var reader = ReaderFactory.Open(stream);
                while (reader.MoveToNextEntry())
                {
                    if (!reader.Entry.IsDirectory)
                    {
                        ExtractionOptions opt = new ExtractionOptions
                        {
                            ExtractFullPath = true,
                            Overwrite = true
                        };
                        reader.WriteEntryToDirectory(outDir, opt);
                    }
                }
            }

            return retDir;
        }

        private static void InitLogger()
        {
            var config = new NLog.Config.LoggingConfiguration();
            // Targets where to log to: File and Console
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = Path.Combine(AppDataDir, "log.log") };
            var logconsole = new NLog.Targets.ColoredConsoleTarget("logconsole");


            logfile.ArchiveAboveSize = (long)CommonsFileUtils.HumanReadableSizeToLong("1 Mo");
            //logfile.ArchiveOldFileOnStartup = true;

            logconsole.Layout = "${message}";

            // Rules for mapping loggers to targets            
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

            // Apply config           
            LogManager.Configuration = config;

            Log = NLog.LogManager.GetCurrentClassLogger();
        }
    }
}