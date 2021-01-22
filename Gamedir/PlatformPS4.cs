namespace GHLCP
{
    public class PlatformPS4 : Platform
    {
        private static readonly string name = "PlayStation 4";

        public PlatformPS4() { }

        public override string Name => name;

        public override bool Extracts(string platform) => platform == "master" || platform == "others" || platform == "ps4";
    }
}
