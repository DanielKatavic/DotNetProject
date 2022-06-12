namespace Utility.Models
{
    public enum Gender { Male, Female }
    public enum Language { Hrvatski, English }
    public enum Access { Offline, Online }

    public static class Settings
    {
        private const char Del = '|';
        private const char ResSplitter = 'x';

        public static Gender GenderSelected { get; set; }
        public static Language LangSelected { get; set; }
        public static Access AccessSelected { get; set; }
        public static Team? TeamSelected { get; set; }
        public static int WindowHeight { get; set; }
        public static int WindowWidth { get; set; }
        public static bool IsFullScreen { get; set; }

        public static string ParseForFileLine()
            => $"{GenderSelected}{Del}{LangSelected}{Del}{AccessSelected}{Del}{TeamSelected?.Country}{Del}{TeamSelected?.FifaCode}{Del}{WindowHeight}{ResSplitter}{WindowWidth}{Del}{IsFullScreen}";

        public static void ParseFromFileLine(string line)
        {
            string[] details = line.Split(Del);
            GenderSelected = (Gender)Enum.Parse(typeof(Gender), details[0]);
            LangSelected = (Language)Enum.Parse(typeof(Language), details[1]);
            AccessSelected = (Access)Enum.Parse(typeof(Access), details[2]);
            TeamSelected = new Team 
            {
                Country = details[3],
                FifaCode = details[4]
            };
        }

        public static void SaveResolution(string? resolution)
        {
            string[]? res = resolution?.Split(ResSplitter);
            WindowWidth = int.Parse(res[0]);
            WindowHeight = int.Parse(res[1]);
        }
    }
}