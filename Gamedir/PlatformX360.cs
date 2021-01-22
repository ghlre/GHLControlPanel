namespace GHLCP
{
    public class PlatformX360 : Platform
    {
        private static readonly string name = "Xbox 360";

        public PlatformX360() { }

        public override string Name => name;

        public override bool Extracts(string platform) => platform == "master" || platform == "360";
    }
}
