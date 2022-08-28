using MbzExtractor.dto.inner;
using MbzExtractor.dto;
using MbzExtractor.utils;
using NLog.Fluent;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using UsefulCsharpCommonsUtils.file.dir;
using NLog;

namespace MbzExtractor.business
{
    internal class MbzParser
    {
        private static Logger Log = LogManager.GetCurrentClassLogger();
        public Dir FolderToParse { get; }

        private readonly bool isLogUnknownNode;
        private int sectionIndex;

        public MbzParser(Dir tarFolder)
        {
            FolderToParse = tarFolder;
            isLogUnknownNode = false;
        }


        public BackupDatas Parse(Dir tarFolder)
        {


            BackupDatas datas = new BackupDatas();
            datas.RootFolder = tarFolder;

            if (tarFolder.ChildFiles().Any(r => r.Name.Equals("moodle_backup.xml")))
            {
                FileInfo moodleFileXml = tarFolder.ChildFiles().FirstOrDefault(r => r.Name.Equals("moodle_backup.xml"));

                Moodle_backup mBackup;
                try
                {
                    XmlSerializer ser = new XmlSerializer(typeof(Moodle_backup));
                    using (XmlReader reader = XmlReader.Create(moodleFileXml.FullName))
                    {
                        mBackup = (Moodle_backup)ser.Deserialize(reader);
                    }
                }
                catch (Exception ex)
                {
                    // TODO
                    throw ex;
                }

                datas.MoodleBackup = mBackup;


                Log.Info("Parsing Sections");
                ExtractAndParseSections(tarFolder, mBackup, datas);

                Log.Info("Parsing Activities");
                ExtractAndParseActivities(tarFolder, mBackup, datas);
            }
            else
            { // TODO
                throw new FileNotFoundException("moodle_backup.xml");
            }

            if (tarFolder.ChildFiles().Any(r => r.Name.Equals("files.xml")))
            {

                Log.Info("Parsing Files");
                var files = DeserializeFiles(tarFolder);
                datas.Files.AddRange(files.File);



            }

            return datas;

        }

        private void ExtractAndParseActivities(Dir tarFolder, Moodle_backup mBackup, BackupDatas datas)
        {
            foreach (var activity in mBackup.Information.Contents.Activities.Activity)
            {
                Log.Info($"> Activity {activity.Moduleid}");

                Dir dirActivity = new Dir(Path.Combine(tarFolder.Fullname, activity.Directory));
                if (dirActivity.Exists)
                {
                    if (dirActivity.ChildFiles().Any(r => r.Name.Equals($"{activity.Modulename}.xml")))
                    {
                        ActivityFull activityFull = DeserializeActivityFull(dirActivity, activity);

                        if (activityFull != null)
                        {

                            activityFull.TypeActivity = MbzUtils.GetTypeActivity(activityFull);

                            datas.Activities.Add(activityFull);


                            if (dirActivity.ChildFiles().Any(r => r.Name.Equals("inforef.xml")))
                            {
                                Log.Info("Inforef found. Parsing");
                                Inforef inforef = DeserializeInforef(dirActivity);

                                if (inforef != null)
                                {
                                    datas.InforefsByActivityId.Add(activityFull.Id, inforef);
                                }
                            }
                        }
                    }
                }
                else
                {
                    Log.Warn($"No directory for activity {activity.Moduleid} (seeking {activity.Directory})");
                }

                Console.WriteLine();

            }
        }

        private void ExtractAndParseSections(Dir tarFolder, Moodle_backup mBackup, BackupDatas datas)
        {
            foreach (var contentsSection in mBackup.Information.Contents.Sections.Section)
            {
                Dir dirSection = new Dir(Path.Combine(tarFolder.Fullname, contentsSection.Directory));
                if (dirSection.Exists && dirSection.ChildFiles().Any(r => r.Name.Equals("section.xml")))
                {
                    SectionFull sFull = DeserializeSectionFull(dirSection);

                    if (sFull != null)
                    {
                        sFull.Index = sectionIndex++;

                        datas.Sections.Add(sFull);
                    }
                }
            }
        }



        private Inforef DeserializeInforef(Dir dirActivity)
        {
            Inforef inforef;
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(Inforef));

                if (isLogUnknownNode)
                {
                    ser.UnknownNode += (sender, args) =>
                    {
                        Console.WriteLine(
                            $"Name: {args.Name}, Position: {args.LineNumber}:{args.LinePosition}, Text: {args.Text}");
                    };
                }


                using (XmlReader reader =
                       XmlReader.Create(dirActivity.ChildFiles().FirstOrDefault(r => r.Name.Equals("inforef.xml"))?.FullName))
                {
                    inforef = (Inforef)ser.Deserialize(reader);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return inforef;
        }

        private Files DeserializeFiles(Dir dirToSearch)
        {
            Files files;
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(Files));

                if (isLogUnknownNode)
                {
                    ser.UnknownNode += (sender, args) =>
                    {
                        Console.WriteLine(
                            $"Name: {args.Name}, Position: {args.LineNumber}:{args.LinePosition}, Text: {args.Text}");
                    };
                }


                using (XmlReader reader =
                       XmlReader.Create(dirToSearch.ChildFiles().FirstOrDefault(r => r.Name.Equals("files.xml"))?.FullName))
                {
                    files = (Files)ser.Deserialize(reader);
                }
            }
            catch (Exception e)
            {
                Log.Error(e, "Error when deserializing files");
                throw;
            }

            return files;
        }

        private ActivityFull DeserializeActivityFull(Dir dirActivity, Activity activity)
        {
            ActivityFull sFull;
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(ActivityFull));

                if (isLogUnknownNode)
                {
                    ser.UnknownNode += (sender, args) =>
                    {
                        Console.WriteLine(
                            $"Name: {args.Name}, Position: {args.LineNumber}:{args.LinePosition}, Text: {args.Text}");
                    };
                }

                using (XmlReader reader = XmlReader.Create(dirActivity.ChildFiles()
                           .FirstOrDefault(r => r.Name.Equals($"{activity.Modulename}.xml"))
                           ?.FullName))
                {
                    sFull = (ActivityFull)ser.Deserialize(reader);
                }
            }
            catch (Exception e)
            {
                Log.Error(e, "Error when deserializing activities");
                throw;
            }

            return sFull;
        }

        private SectionFull DeserializeSectionFull(Dir dirSection)
        {
            SectionFull sFull;
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(SectionFull));
                if (isLogUnknownNode)
                {
                    ser.UnknownNode += LogUnknowNode;
                }

                using (XmlReader reader =
                       XmlReader.Create(dirSection.ChildFiles().FirstOrDefault(r => r.Name.Equals("section.xml"))?.FullName))
                {
                    sFull = (SectionFull)ser.Deserialize(reader);
                }
            }
            catch (Exception e)
            {
                Log.Error(e, "Error when deserializing sections");
                throw;
            }

            return sFull;
        }

        private void LogUnknowNode(object sender, XmlNodeEventArgs args)
        {
            Console.WriteLine(
                $"Name: {args.Name}, Position: {args.LineNumber}:{args.LinePosition}, Text: {args.Text}");
        }
    }
}
