using Microsoft.EntityFrameworkCore;
using SimpleApi.DataContext;
using SimpleApi.Interfaces;
using SimpleApi.Models.Entities;

namespace SimpleApi.Services
{
    public class SimpleApiService : ISimpleApiService
    {
        private readonly ApplicationDbContext _dbContext;

        public SimpleApiService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateAsync(UserEntity user, CancellationToken cancellationToken)
        {
            await _dbContext.AddAsync(user, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            await _dbContext.Users.Where(w => w.Id == id).ExecuteDeleteAsync(cancellationToken);
        }

        public async Task<UserEntity?> GetAsync(int id, CancellationToken cancellationToken)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(w => w.Id == id, cancellationToken);
        }

        public async Task UpdateAsync(int id, UserEntity user, CancellationToken cancellationToken)
        {
            await _dbContext.Users.ExecuteUpdateAsync(u => u
                .SetProperty(p => p.FirstName, v => user.FirstName)
                .SetProperty(p => p.LastName, v => user.LastName)
                .SetProperty(p => p.Email, v => user.Email)
                .SetProperty(p => p.Phone, v => user.Phone),
                cancellationToken);
        }
    }
}
