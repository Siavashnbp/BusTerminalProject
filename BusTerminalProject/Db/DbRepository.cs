namespace BusTerminalProject.Db
{
    public class DbRepository<T> : IDbRepository<T> where T : class
    {
        private static DbRepository<T>? _dbRepositoryInstance;
        private BusTerminalDbContext? _dbContex;
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
                    throw new Exception("Changes were not saved");
                }
                _dbContex.Dispose();
                return;
            }
            throw new Exception("Item cannot be null");
        }

        public void Delete(T entity)
        {
            _dbContex = new BusTerminalDbContext();
            _dbContex.Set<T>().Remove(entity);
            var changes = _dbContex.SaveChanges();
            if (changes < 1)
            {
                throw new Exception("Changes were not saved");
            }
        }

        public T? FindById(int id)
        {
            _dbContex = new BusTerminalDbContext();
            return _dbContex.Set<T>().Find(id);
        }

        public List<T> GetAll()
        {
            _dbContex = new BusTerminalDbContext();
            return _dbContex.Set<T>().ToList();
        }

        public void Update(T entity)
        {
            _dbContex = new BusTerminalDbContext();
            _dbContex.Update(entity);
            var changes = _dbContex.SaveChanges();
            if (changes < 1)
            {
                throw new Exception("Changes were not saved");
            }
        }
    }
}
