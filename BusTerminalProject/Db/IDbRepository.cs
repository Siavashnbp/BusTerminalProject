﻿namespace BusTerminalProject.Db
{
    public interface IDbRepository<T> where T : class
    {
        public void Add(T entity);
        public List<T> GetAll();
        public T? FindById(int id);
        public void Update(T entity);
        public void Delete(T entity);

    }
}
