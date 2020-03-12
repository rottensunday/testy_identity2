using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testy_identity.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user1, string user2, string sender, string message)
        {
            await Clients.Users(new List<string>() { user1, user2 }).SendAsync("ReceiveMessage", user1, user2, sender, message);
        }
        public string GetUser()
        {
            var user = Context.User;
            return user.Identity.Name;
        }
    }
}
