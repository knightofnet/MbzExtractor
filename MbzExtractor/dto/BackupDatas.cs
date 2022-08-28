using MbzExtractor.dto.inner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsefulCsharpCommonsUtils.file.dir;

namespace MbzExtractor.dto
{
    internal class BackupDatas
    {
        public Moodle_backup MoodleBackup { get; set; }

        public List<SectionFull> Sections { get; } = new List<SectionFull>();
        public List<ActivityFull> Activities { get; } = new List<ActivityFull>();
        public Dictionary<string, Inforef> InforefsByActivityId { get; } = new Dictionary<string, Inforef>();
        public List<FileMbz> Files { get; } = new List<FileMbz>();
        public Dir RootFolder { get; set; }
    }
}
