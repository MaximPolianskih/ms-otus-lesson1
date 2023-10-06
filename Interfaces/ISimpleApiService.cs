using SimpleApi.Models.Entities;

namespace SimpleApi.Interfaces
{
    public interface ISimpleApiService
    {
        public Task CreateAsync(UserEntity user, CancellationToken cancellationToken);
        public Task<UserEntity?> GetAsync(int id, CancellationToken cancellationToken);
        public Task DeleteAsync(int id, CancellationToken cancellationToken);
        public Task UpdateAsync(int id, UserEntity user, CancellationToken cancellationToken);
    }
}
