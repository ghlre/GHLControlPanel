namespace GHLCP
{
    public class PlatformWiiU : Platform
    {
        private static readonly string name = "Wii U";

        public PlatformWiiU() { }

        public override string Name => name;

        public override bool Extracts(string platform) => platform == "master" || platform == "wiiu";
    }
}
