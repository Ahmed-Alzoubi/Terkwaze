using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRBlog.Hubs
{
    public class BlogHub : Hub
    {
        public async Task SendMessage(string user, string Message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, Message);
        }
    }
}