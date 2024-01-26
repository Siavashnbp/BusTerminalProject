namespace BusTerminalProject.Db
{
    public interface IDbRepository<T> where T : class
    {
        public void Add(T entity);
    }
}
