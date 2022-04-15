namespace Utility.Models
{
    public enum Gender { Male, Female }
    public enum Language { Croatian, English }
    public enum Access { Offline, Online }

    public static class Settings
    {
        private const char Del = '|';

        public static Gender GenderSelected { get; set; }
        public static Language LangSelected { get; set; }
        public static Access AccessSelected { get; set; }
        public static string? TeamSelected { get; set; }

        public static string ParseForFileLine() 
            => $"{GenderSelected}{Del}{LangSelected}{Del}{AccessSelected}{Del}{TeamSelected}";

        public static void ParseFromFileLine(string line)
        {
            string[] details = line.Split(Del);
            GenderSelected = (Gender)Enum.Parse(typeof(Gender), details[0]);
            LangSelected = (Language)Enum.Parse(typeof(Language), details[1]);
            AccessSelected = (Access)Enum.Parse(typeof(Access), details[2]);
        }
    }
}