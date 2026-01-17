using Microsoft.EntityFrameworkCore;
using WorldApi.Data;
using WorldApi.Models;
using WorldApi.Repository.IRepository;

namespace WorldApi.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CountryRepository(ApplicationDbContext dbContext )
        {
            _dbContext = dbContext;
        }
        public async Task Create(Country entity)
        {
            await _dbContext.Countries.AddAsync(entity);
            await Save();
        }

        public async Task Delete(Country entity)
        {
            _dbContext.Countries.Remove(entity);
            await Save();
        }

        public async Task<List<Country>> GetAll()
        {
            var countries = await _dbContext.Countries.ToListAsync();
            return countries;
        }

        public async Task<Country> GetById(int id)
        {
            var country = await _dbContext.Countries.FindAsync(id);
            return country;
        }

        public bool IsCountryExist(string name)
        {
            var result = _dbContext.Countries.AsQueryable().Where(x => x.Name.ToLower().Trim() == name.ToLower().Trim()).Any();
            return result;
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Country entity)
        {
            _dbContext.Countries.Update(entity);
            await Save();
        }
    }
}
