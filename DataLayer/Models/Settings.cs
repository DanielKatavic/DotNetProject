namespace Utility.Models
{
    public enum Gender { Male, Female }
    public enum Language { Croatian, English }
    public enum Access { Offline, Online }

    public static class Settings
    {
        public static Gender GenderSelected { get; set; }
        public static Language LangSelected { get; set; }
        public static Access AccessSelected { get; set; }
        public static Team? TeamSelected { get; set; }
    }
}