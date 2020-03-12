using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testy_identity.Models
{
    public class EFUsersRepository
    {
        private UsersContext context;
        public EFUsersRepository(UsersContext ctx) => context = ctx;
        public IQueryable<User> Users => context.Users;
        public async Task SaveUserAsync(User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }
    }
}
