namespace HR.LeaveManagement.Application.Contracts.Persistence
{

    //This is for the deafult CRUD operations that may need to be preformed.

    public interface IGenericRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAsync();

        Task<T> GetByIdAsync(int id);

        Task CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

    }


}