using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using testy_identity.Hubs;
using testy_identity.Models;

namespace testy_identity
{
    public class ChatRoomModel : PageModel
    {
        private EFGroupsRepository groupsRepository;
        private EFUsersRepository usersRepository;
        public ChatRoomModel(EFGroupsRepository groupsRepo, EFUsersRepository usersRepo)
        {
            groupsRepository = groupsRepo;
            usersRepository = usersRepo;
        }
        [BindProperty(SupportsGet = true)]
        public int GroupId { get; set; }
        [BindProperty(SupportsGet = true)]
        public string User1 { get; set; }
        [BindProperty(SupportsGet = true)]
        public string User2 { get; set; }
        public IEnumerable<User> Users { get; set; }
        public Group Group { get; set; }
        public IQueryable<User> usersCollection;

        public async Task OnGet()
        {
            if(GroupId == 0)
            {
                Group = await groupsRepository.InitializeGroup(usersRepository.Users.Where(x => x.Id == User1 || x.Id == User2));
            }
            else
            {
                Group = groupsRepository.Groups.FirstOrDefault(g => g.Id == GroupId);
            }
            Users = await groupsRepository.GetUsersAssociatedWithGroupAsync(Group);
        }
    }
}