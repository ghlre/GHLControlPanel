namespace GHLCP
{
    public class PlatformPS3 : Platform
    {
        private static readonly string name = "PlayStation 3";

        public PlatformPS3() { }

        public override string Name => name;

        public override bool Extracts(string platform) => platform == "master" || platform == "ps3";

        public override string GetRelPath(string path) => path.ToUpper();
    }
}
