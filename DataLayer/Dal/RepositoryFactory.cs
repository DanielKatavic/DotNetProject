namespace Utility.Dal
{
    public static class RepositoryFactory
    {
        public static IRepository GetRepository() => new FileRepository();
    }
}
