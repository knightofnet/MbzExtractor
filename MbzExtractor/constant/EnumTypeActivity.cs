using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MbzExtractor.constant
{
    public sealed class EnumTypeActivity
    {
        public static readonly EnumTypeActivity Assign = new EnumTypeActivity(0, "Devoir");
        public static readonly EnumTypeActivity Resource = new EnumTypeActivity(1, "Ressource");
        public static readonly EnumTypeActivity Folder = new EnumTypeActivity(3, "Dossier");
        public static readonly EnumTypeActivity Label = new EnumTypeActivity(4, "Etiquette");
        public static readonly EnumTypeActivity Page = new EnumTypeActivity(5, "Page");
        public static readonly EnumTypeActivity Url = new EnumTypeActivity(6, "Url");


        public static readonly EnumTypeActivity Unknown = new EnumTypeActivity(999, "Non déterminé");




        public static IEnumerable<EnumTypeActivity> Values
        {
            get
            {
                yield return Assign;
                yield return Resource;
                yield return Folder;
                yield return Label;
                yield return Page;
                yield return Url;




            }
        }

        public int Index { get; }
        public String Libelle { get; }


        private EnumTypeActivity(int index, String libelle)
        {
            Index = index;
            Libelle = libelle;


        }

        private sealed class IndexEqualityComparer : IEqualityComparer<EnumTypeActivity>
        {
            public bool Equals(EnumTypeActivity x, EnumTypeActivity y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Index == y.Index;
            }

            public int GetHashCode(EnumTypeActivity obj)
            {
                return obj.Index;
            }
        }

        public static IEqualityComparer<EnumTypeActivity> IndexComparer { get; } = new IndexEqualityComparer();
    }


}

