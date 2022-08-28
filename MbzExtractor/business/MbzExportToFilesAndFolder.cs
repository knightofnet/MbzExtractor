using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MbzExtractor.constant;
using MbzExtractor.dto;
using MbzExtractor.dto.inner;
using MbzExtractor.utils;
using NLog;
using NLog.Fluent;
using UsefulCsharpCommonsUtils.file;
using UsefulCsharpCommonsUtils.file.dir;
using UsefulCsharpCommonsUtils.lang;
using static System.Collections.Specialized.BitVector32;

namespace MbzExtractor.business
{
    internal class MbzExportToFilesAndFolder
    {
        private static Logger Log = LogManager.GetCurrentClassLogger();

        public void DoOutWork(BackupDatas mB, string appConfOutFolder)
        {
            Dir outDir = new Dir(Path.Combine(appConfOutFolder, AppFileUtils.RemoveFilenameInvalidChar(mB.MoodleBackup.Information.Original_course_shortname)));
            outDir.CreateIfNot();

            foreach (SectionFull section in mB.Sections.OrderBy(r => r.Index))
            {
                string originalSectionName = section.Name;
                if (string.IsNullOrEmpty(originalSectionName))
                {
                    originalSectionName = "_NoNameSection";
                }

                string sectionName = AppFileUtils.RemoveFilenameInvalidChar(originalSectionName);
                int i = 1;
                while (outDir.ChildDirs().Any(r => r.Name.Equals(sectionName)))
                {
                    sectionName = AppFileUtils.RemoveFilenameInvalidChar(originalSectionName);
                    sectionName = $"{sectionName}_{i++}";
                }
                Dir sectionDir = outDir.CreateChildIfNot(sectionName);


                string[] moduleIds = section.Sequence.Split(',');
                foreach (string moduleId in moduleIds)
                {
                    ActivityFull[] activities = mB.Activities.Where(r => r.Moduleid.Equals(moduleId)).ToArray();
                    if (activities.Length > 1)
                    {
                        Log.Warn($"Multiple activities found for same Id : {moduleId}");
                    }

                    foreach (ActivityFull activityFull in activities)
                    {
                        if (activityFull.TypeActivity == EnumTypeActivity.Url)
                        {
                            CreateActivityUrlShorcut(activityFull.Url, sectionDir.Fullname);
                        }
                        else if (activityFull.TypeActivity == EnumTypeActivity.Resource)
                        {
                            CreateResourceOut(activityFull, activityFull.Resource.Name, sectionDir.Fullname, mB);
                        }
                        else if (activityFull.TypeActivity == EnumTypeActivity.Folder)
                        {
                            CreateResourceOut(activityFull, $"{activityFull.Folder.Name} ({EnumTypeActivity.Folder.Libelle})", sectionDir.Fullname, mB);
                        }
                        else if (activityFull.TypeActivity == EnumTypeActivity.Assign)
                        {
                            CreateResourceOut(activityFull, $"{activityFull.Assign.Name} ({EnumTypeActivity.Assign.Libelle})", sectionDir.Fullname, mB, true);
                        }
                    }
                }



            }

        }

        private void CreateResourceOut(ActivityFull activityFull, string originalRessourceName, string sectionDirFullname, BackupDatas mb, bool isAddUserIdInPath = false)
        {
            Log.Debug(
                $"CreateResourceOut(activityFull: {activityFull}, originalRessourceName: {originalRessourceName}, sectionDirFullname: {sectionDirFullname}, mb: , isAddUserIdInPath: {isAddUserIdInPath}");

            try
            {

                Dir sectionDir = new Dir(sectionDirFullname);


                if (string.IsNullOrEmpty(originalRessourceName))
                {
                    originalRessourceName = "_NoNameRessource";
                }

                string ressourceName = AppFileUtils.RemoveFilenameInvalidChar(originalRessourceName);
                int i = 1;
                while (sectionDir.ChildDirs().Any(r => r.Name.Equals(ressourceName)))
                {
                    ressourceName = AppFileUtils.RemoveFilenameInvalidChar(originalRessourceName);
                    ressourceName = $"{ressourceName}_{i++}";
                }

                Log.Debug($"ressourceName: {ressourceName}");
                Dir ressourceDir = sectionDir.CreateChildIfNot(ressourceName);


                if (mb.InforefsByActivityId.ContainsKey(activityFull.Id))
                {

                    Inforef inforef = mb.InforefsByActivityId[activityFull.Id];

                    if (inforef.Fileref != null)
                    {

                        foreach (FileInfoRef fileInfoRef in inforef.Fileref.File)
                        {
                            FileMbz file = mb.Files.FirstOrDefault(r => r.Id.Equals(fileInfoRef.Id));
                            if (file == null)
                            {
                                Log.Warn($"No file found for id {fileInfoRef.Id}");
                                continue;
                            }

                            if (file.Filename.Equals(".")) continue;

                            Log.Debug(file.Contenthash);

                            FileInfo filePhysical = new FileInfo(Path.Combine(
                                mb.RootFolder.Fullname,
                                "files",
                                file.Contenthash.Substring(0, 2),
                                file.Contenthash
                            ));

                            if (!File.Exists(filePhysical.FullName))
                            {
                                Log.Warn($"Unable to find {filePhysical.FullName}");
                                continue;
                            }

                            string pathFinal = string.Empty;
                            if (isAddUserIdInPath && !string.IsNullOrEmpty(file.Userid) &&
                                !file.Userid.Equals("$@NULL@$"))
                            {
                                pathFinal = pathFinal.Length == 0 ? file.Userid : Path.Combine(pathFinal, file.Userid);
                                ;
                                ressourceDir.CreateChildIfNot(pathFinal);
                            }

                            if (!string.IsNullOrEmpty(file.Filepath.Trim('/')))
                            {
                                pathFinal = pathFinal.Length == 0
                                    ? file.Filepath.Trim('/')
                                    : Path.Combine(pathFinal, file.Filepath.Trim('/'));
                                ressourceDir.CreateChildIfNot(pathFinal);
                            }

                            bool isOverwrite = false;
                            string filepathFinal = Path.Combine(ressourceDir.Fullname, pathFinal,
                                AppFileUtils.RemoveFilenameInvalidChar(file.Filename));
                            if (File.Exists(filepathFinal))
                            {
                                FileInfo fFinExist = new FileInfo(filepathFinal);
                                if (fFinExist.Length == filePhysical.Length
                                    && AppFileUtils.RemoveFilenameInvalidChar(file.Filename).Equals(fFinExist.Name)
                                   )
                                {
                                    isOverwrite = true;
                                }
                                else if (AppFileUtils.RemoveFilenameInvalidChar(file.Filename).Equals(fFinExist.Name))
                                {
                                    filepathFinal = Path.Combine(ressourceDir.Fullname, pathFinal, $"{file.Id}_" +
                                        AppFileUtils.RemoveFilenameInvalidChar(file.Filename));

                                }
                            }

                            if (filepathFinal.Length >= 255)
                            {
                                filepathFinal = @"\\?\" + filepathFinal;
                            }

                            Log.Debug(
                                $"Copy file: source: {filePhysical.FullName}, target: {filepathFinal}, isOverwrite: {isOverwrite}");

                            FileInfo fileCopied = filePhysical.CopyTo(filepathFinal, isOverwrite);
                            if (fileCopied.Exists)
                            {

                                fileCopied.CreationTime = AppDateUtils.DateTimeFromUnix(file.Timecreated) ??
                                                          fileCopied.CreationTime;
                                fileCopied.LastWriteTime = AppDateUtils.DateTimeFromUnix(file.Timemodified) ??
                                                           fileCopied.LastWriteTime;

                            }

                        }
                    }
                }
            }
            catch (Exception e)
            {
                Log.Error(e, "Error when retreving files");
                throw e;
            }
        }

        private static void CreateActivityUrlShorcut(Url activityFullUrl, string outDir)
        {
            try
            {
                Ini iniFile = new Ini(Path.Combine(outDir, $"{AppFileUtils.RemoveFilenameInvalidChar(activityFullUrl.Name)}.url"));
                iniFile.WriteValue("IDList", "InternetShortcut", " ");
                iniFile.WriteValue("URL", "InternetShortcut", activityFullUrl.Externalurl);

                iniFile.Save();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error when creating url shortcut");
                throw ex;
            }

        }
    }
}
