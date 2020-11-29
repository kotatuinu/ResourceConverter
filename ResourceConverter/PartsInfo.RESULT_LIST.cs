using System;
using System.Collections.Generic;

namespace ResourceConverter
{
    public abstract partial class PartsInfo
    {
        public struct RESULT_LIST
        {
            public PARTSKIND PartsKind { get; private set; }
            public Dictionary<string, List<string>> ParamGroupMap { get; private set; }

            public RESULT_LIST(PARTSKIND partsKind, Dictionary<string, List<string>> paramGroupMap)
            {
                PartsKind = partsKind;
                ParamGroupMap = paramGroupMap;
            }
            public static bool operator ==(RESULT_LIST lhs, RESULT_LIST rhs)
            {
                return (lhs.PartsKind == rhs.PartsKind) && (DicEquals(lhs.ParamGroupMap, rhs.ParamGroupMap));
            }
            public static bool operator !=(RESULT_LIST lhs, RESULT_LIST rhs)
            {
                return !(lhs == rhs);
            }

            public static bool DicEquals(Dictionary<string, List<string>> lhs, Dictionary<string, List<string>> rhs)
            {
                if (lhs == null && rhs == null) { return true; }
                if (!(lhs != null && rhs != null)) { return false; }
                if (lhs.Count != rhs.Count) { return false; }
                var lite = lhs.GetEnumerator();
                while (lite.MoveNext())
                {
                    if (!rhs.ContainsKey(lite.Current.Key)) { return false; }
                    if (lite.Current.Value.Count != rhs[lite.Current.Key].Count) { return false; }

                    var lvite = lite.Current.Value.GetEnumerator();
                    var rvite = rhs[lite.Current.Key].GetEnumerator();
                    while (lvite.MoveNext() && rvite.MoveNext())
                    {
                        if (lvite.Current != rvite.Current) { return false; }

                    }
                }
                return true;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(PartsKind, ParamGroupMap);
            }

            public override bool Equals(object obj) => obj is RESULT_LIST lIST &&
                       PartsKind == lIST.PartsKind &&
                       EqualityComparer<Dictionary<string, List<string>>>.Default.Equals(ParamGroupMap, lIST.ParamGroupMap);
        }
    }
}