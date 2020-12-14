using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SemVer
{
    public static class Interval
    {
        private const string versionChars = @"[0-9a-zA-Z\-\+\.\*]";

        public static Tuple<int, Comparator[]> TildeRange(string spec)
        {
            string pattern = String.Format(@"^\s*~\s*({0}+)\s*", versionChars);

            var regex = new Regex(pattern);
            var match = regex.Match(spec);
            if (!match.Success)
            {
                return null;
            }

            Version minVersion = null;
            Version maxVersion = null;

            var version = new PartialVersion(match.Groups[1].Value);
            if (version.Minor.HasValue)
            {
                minVersion = version.ToZeroVersion();
                maxVersion = new Version(version.Major.Value, version.Minor.Value + 1, 0);
            }
            else
            {
                minVersion = version.ToZeroVersion();
                maxVersion = new Version(version.Major.Value + 1, 0, 0);
            }

            return Tuple.Create(
                    match.Length,
                    minMaxComparators(minVersion, maxVersion));
        }

        
        private static Comparator[] minMaxComparators(Version minVersion, Version maxVersion,
                Comparator.Operator maxOperator=Comparator.Operator.LessThan)
        {
            var minComparator = new Comparator(
                    Comparator.Operator.GreaterThanOrEqual,
                    minVersion);
            if (maxVersion == null)
            {
                return new [] { minComparator };
            }
            else
            {
                var maxComparator = new Comparator(
                        maxOperator, maxVersion);
                return new [] { minComparator, maxComparator };
            }
        }
    }
}
