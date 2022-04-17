namespace Utility.Dal
{
    public interface IRepository
    {
        void SaveSettings(string informations);
        string LoadFile();
    }
}
