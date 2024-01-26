using BusTerminal.EnitityMap;

namespace BusTerminal.Db
{
    public class DbRepository<T> : IDbRepository<T> where T : class
    {
        private static DbRepository<T>? _dbRepositoryInstance;
        private BusTerminalDbContext _dbContex;
        private DbRepository()
        {
        }
        public static DbRepository<T> GetInstance() => _dbRepositoryInstance ??= new DbRepository<T>();
        public void Add(T entity)
        {
            _dbContex = new BusTerminalDbContext();
            if (entity is not null)
            {
                _dbContex.Add(entity);
                var changes = _dbContex.SaveChanges();
                if (changes < 1)
                {
                    throw new Exception("Changes were nos saved");
                }
                _dbContex.Dispose();
                return;
            }
            throw new Exception("Item cannot be null");
        }

        public List<T> GetAll()
        {
            _dbContex = new BusTerminalDbContext();
            return _dbContex.Set<T>().ToList();
        }
    }
}
