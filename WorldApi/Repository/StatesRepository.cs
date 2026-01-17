using Microsoft.EntityFrameworkCore;
using WorldApi.Data;
using WorldApi.Models;
using WorldApi.Repository.IRepository;

namespace WorldApi.Repository
{
    public class StatesRepository : IStatesRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public StatesRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(States entity)
        {
            await _dbContext.States.AddAsync(entity);
            await Save();
        }

        public async Task Delete(States entity)
        {
            _dbContext.States.Remove(entity);
            await Save();
        }

        public async Task<List<States>> GetAll()
        {
            List<States> states = await _dbContext.States.ToListAsync();
            return states;
        }

        public async Task<States> GetById(int id)
        {
            States state = await _dbContext.States.FindAsync(id);
            return state;
        }

        public bool IsStateExsits(string name)
        {
            var result = _dbContext.States.AsQueryable().Where(x => x.Name.ToLower().Trim() == name.ToLower().Trim()).Any();
            return result;
        }

        public Task<bool> IsStateExsitsAsync(string name)
        {
            var result = _dbContext.States.AsQueryable().Where(x => x.Name.ToLower().Trim() == name.ToLower().Trim()).AnyAsync();
            return result;
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(States entity)
        {
           _dbContext.States.Update(entity);
            await Save();
        }

    }
}
