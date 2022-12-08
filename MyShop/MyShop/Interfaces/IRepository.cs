namespace MyShop.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public T? GetById(Guid id);

        public void Update(T entity);

        public List<T> GetAll();
    }
}
