using AutoMapper;
using LogicalModels.UserAggregate.Data;
using LogicalModels.UserAggregate.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataModels.UserAggregate;

internal sealed class UserRepository : IUserRepository
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    public UserRepository(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<User> Insert(User user, CancellationToken ct = default)
    {
        if (user is null)
        {
            throw new Exception("User can NOT be passed as null.");
        }

        var userData = _mapper.Map<UserData>(user);

        var entry = await _dbContext.Users.AddAsync(userData, ct);
        return _mapper.Map<User>(entry.Entity);
    }

    public async Task<IEnumerable<User>> Get(CancellationToken ct = default)
    {
        var usersData = await _dbContext.Users.ToListAsync(ct);

        return _mapper.Map<IEnumerable<User>>(usersData);
    }

    public async Task<User> GetById(int id, CancellationToken ct = default)
    {
        var userData = await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id, ct);

        if (userData is null)
        {
            throw new Exception("There is NO user with the given id");
        }

        return _mapper.Map<User>(userData);
    }

    public async Task<User> Delete(int id, CancellationToken ct = default)
    {
        var user = await GetById(id, ct);
        var userData = _mapper.Map<UserData>(user);
        var entry = _dbContext.Users.Remove(userData);
        return _mapper.Map<User>(entry.Entity);
    }
}
