using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MbzExtractor.utils
{
    public static class AppFileUtils
    {

        public static string RemoveFilenameInvalidChar(string filename)
        {

            char[] iChars = Path.GetInvalidFileNameChars();
            return string.Concat(filename.Split(iChars))?.Trim();

        }

    }
}
