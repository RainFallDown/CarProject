namespace CarProject.Core.Abstract
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task DeleteRowAsync(int id);
        Task<T> GetAsync(int id);
        Task UpdateAsync(T t);
        Task<int> InsertAsync(T t);
    }
}
