using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testy_identity.Models.ViewModels;

namespace testy_identity.Models
{
    public class EFGroupsRepository
    {
        private UsersContext _context;
        private UserManager<User> _userManager;
        public EFGroupsRepository(UsersContext ctx, UserManager<User> userManager)
        {
            _context = ctx;
            _userManager = userManager;
        }
        private IQueryable<UserGroup> UserGroups => _context.UserGroups;
        public IQueryable<Group> Groups => _context.Groups;
        public async Task<Group> SaveGroupAsync(Group group)
        {
            if(group.Id == 0)
            {
                await _context.Groups.AddAsync(group);
            }
            else
            {
                Group groupEntry = Groups.FirstOrDefault(x => x.Id == group.Id);
                if(groupEntry != null)
                {
                    groupEntry.UserGroups = group.UserGroups;
                    groupEntry.Name = group.Name;
                }
            }
            await _context.SaveChangesAsync();
            return group;
        }

        public async Task AddUserToGroupAsync(User user, Group group)
        {
            if(user != null && group != null)
            {
                if (UserGroupExists(user, group)) return;
                await _context.UserGroups.AddAsync(new UserGroup { User = user, Group = group });
            }
            else
            {
                return;
            }
            await _context.SaveChangesAsync();
        }
        public async Task AddUserToGroupWithoutSavingAsync(User user, Group group)
        {
            if (user != null && group != null)
            {
                if (UserGroupExists(user, group)) return;
                await _context.UserGroups.AddAsync(new UserGroup { User = user, Group = group });
            }
            else
            {
                return;
            }
        }

        public async Task<Group> InitializeGroup(IEnumerable<User> users, string name = "defaultName")
        {
            Group group = await SaveGroupAsync(new Group { Name = name, Id = 0 });
            foreach(User user in users)
            {
                await AddUserToGroupWithoutSavingAsync(user, group);
            }
            _context.SaveChanges();
            return group;
        }

        public async Task<List<UserGroupViewModel>> InitializeUserGroupViewModelAsync(IQueryable<Group> groups, User loggedUser)
        {
            List<UserGroupViewModel> userGroups = new List<UserGroupViewModel>();
            
            foreach(Group group in groups)
            {
                UserGroup ug = group.UserGroups.FirstOrDefault(x => x.UserID != loggedUser.Id);
                _context.Entry(ug).Reference(x => x.User).Load();
                User user = ug.User;
                userGroups.Add(new UserGroupViewModel { Group = group, User = user } );
            }
            List<User> restUsers = _userManager.Users.ToList();
            restUsers = restUsers.Except(userGroups.Select(x => x.User).ToList()).ToList();
            foreach (User user in restUsers)
            {
                if (user != loggedUser)
                {
                    userGroups.Add(new UserGroupViewModel { User = user, Group = null });
                }
            }
            return userGroups;
        }

        public async Task<IQueryable<Group>> GetDefaultGroupsAsync(User user)
        {
            IQueryable<Group> groups = _context.Groups.Include(g => g.UserGroups).Where(x => !x.IsCustom)
                .Where(x => x.UserGroups.Any(ug => ug.User.Id == user.Id));
            return groups;
        }
        public async Task<IEnumerable<User>> GetUsersAssociatedWithGroupAsync(Group group)
        {
            return _context.UserGroups.Include(x => x.User).Where(x => x.GroupID == group.Id).Select(x => x.User).AsEnumerable();
        }
        
        private bool UserGroupExists(User user, Group group)
        {
            bool returnVal = false;
            if(user != null && group != null)
            {
                UserGroup userGroupEntry = UserGroups.FirstOrDefault(x => x.GroupID == group.Id && x.UserID == user.Id);
                if (userGroupEntry != null) returnVal = true;
                else returnVal = false;
            }
            return returnVal;
        }
    }
}
