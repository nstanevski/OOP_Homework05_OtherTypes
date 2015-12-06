using System;

namespace _03_GenericList.Attributes
{
    [AttributeUsage(AttributeTargets.Struct
        | AttributeTargets.Class
        | AttributeTargets.Interface
        | AttributeTargets.Enum
        | AttributeTargets.Method)]
    public class VersionAttribute:Attribute
    {
        private int majorVersion;
        private int minorVersion;

        public VersionAttribute(int majorVersion, int minorVersion)
        {
            this.MajorVersion = majorVersion;
            this.MinorVersion = minorVersion;
        }

        public int MajorVersion
        {
            get { return this.majorVersion; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Version attribute cannot be negative");
                }
                this.majorVersion = value;
            }
        }

        public int MinorVersion
        {
            get { return this.minorVersion; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Version attribute cannot be negative");
                }
                this.minorVersion = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}.{1}", this.MajorVersion, this.MinorVersion);
        }
    }
}
