using WorldApi.Data;
using WorldApi.Models;

namespace WorldApi.Repository.IRepository
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAll();
        Task<Country> GetById(int id);
        Task Create(Country entity);
        Task Update(Country entity);
        Task Delete(Country entity);
        Task Save();

        bool IsCountryExist(string Name);
    }
}
