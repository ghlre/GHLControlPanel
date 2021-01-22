namespace GHLCP
{
    public abstract class Platform
    {
        public abstract string Name { get; }

        public abstract bool Extracts(string platform);

        public virtual string GetRelPath(string path) => path;

        public override string ToString() => Name;

        public static Platform IOS { get => new PlatformIOS(); }

        public static Platform PS3 { get => new PlatformPS3(); }

        public static Platform PS4 { get => new PlatformPS4(); }

        public static Platform WiiU { get => new PlatformWiiU(); }

        public static Platform X360 { get => new PlatformX360(); }

    }
}
