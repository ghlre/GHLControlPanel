namespace GHLCP
{
    public class PlatformIOS : Platform
    {
        private static readonly string name = "iOS";

        public PlatformIOS() { }

        public override string Name => name;

        public override bool Extracts(string platform) => platform == "others" || platform == "ios";
    }
}
