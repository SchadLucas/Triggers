namespace Triggers.Platform
{
    using System;
    using System.IO;
    using System.Reflection;

    public interface IEnvironmentInfo
    {
        bool IsMono { get; }
        bool IsWindows { get; }
        Version AppVersion { get; }
        string NewLineCharactor { get; }
        char PathSeperator { get; }
        bool IsInteractive { get; }
    }

    public class EnvironmentInfo : IEnvironmentInfo
    {
        public EnvironmentInfo()
        {
            IsMono = Type.GetType("Mono.Runtime") != null;
            IsWindows = IsRunningOnWindows();
            PathSeperator = Path.DirectorySeparatorChar;
            AppVersion = Assembly.GetExecutingAssembly().GetName().Version;;
            NewLineCharactor = Environment.NewLine;
            IsInteractive = Environment.UserInteractive;
        }

        public bool IsMono { get; private set; }
        public bool IsWindows { get; private set; }
        public Version AppVersion { get; private set; }
        public string NewLineCharactor { get; private set; }
        public char PathSeperator { get; private set; }
        public bool IsInteractive { get; private set; }

        private bool IsRunningOnWindows()
        {
            var p = Environment.OSVersion.Platform;
            return p != PlatformID.Unix &&
                   p != PlatformID.MacOSX &&
                   (int) p != 128; // Mono
        }
    }
}