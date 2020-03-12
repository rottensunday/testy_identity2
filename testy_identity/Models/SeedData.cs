using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testy_identity.Models
{
    public class SeedData
    {
        private EFGroupsRepository groupsRepository;
        private EFUsersRepository usersRepository;
        public SeedData(EFGroupsRepository groupsRepo, EFUsersRepository usersRepo)
        {
            groupsRepository = groupsRepo;
            usersRepository = usersRepo;
        }

        public async Task SeedGroups()
        {
            Group group1 = new Group { Id = 0, Name = "GU1U2" };
            Group group2 = new Group { Id = 0, Name = "GU1A" };
            await groupsRepository.SaveGroupAsync(group1);
            await groupsRepository.SaveGroupAsync(group2);

            User u1 = usersRepository.Users.FirstOrDefault(u => u.Email == "user1@gmail.com");
            User u2 = usersRepository.Users.FirstOrDefault(u => u.Email == "user2@gmail.com");
            User a = usersRepository.Users.FirstOrDefault(u => u.Email == "arnachimm@gmail.com");

            await groupsRepository.AddUserToGroupAsync(u1, group1);
            await groupsRepository.AddUserToGroupAsync(u2, group1);
            await groupsRepository.AddUserToGroupAsync(u1, group2);
            await groupsRepository.AddUserToGroupAsync(a, group2);
        }
    }
}
