using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using testy_identity.Models;
using testy_identity.Models.ViewModels;

namespace testy_identity.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly EFGroupsRepository _groupsRepository;
        private readonly EFUsersRepository _usersRepository;
        private readonly UserManager<User> _userManager;

        public IndexModel(ILogger<IndexModel> logger,
            EFGroupsRepository groupsRepo,
            EFUsersRepository usersRepo,
            UserManager<User> userManager)
        {
            _logger = logger;
            _groupsRepository = groupsRepo;
            _usersRepository = usersRepo;
            _userManager = userManager;
        }
        [BindProperty]
        public List<UserGroupViewModel> UserGroups { get; set; }

        public async Task OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                UserGroups = new List<UserGroupViewModel>();
                User loggedUser = null; ;
                try
                {
                    loggedUser = await _userManager.GetUserAsync(HttpContext.User);
                }
                catch (Exception e)
                {
                    Console.WriteLine("No user signed in");
                }

                IQueryable<Group> groups = await _groupsRepository.GetDefaultGroupsAsync(loggedUser);
                UserGroups = await _groupsRepository.InitializeUserGroupViewModelAsync(groups, loggedUser);
            }

        }
    }
}
