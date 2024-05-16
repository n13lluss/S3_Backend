using Microsoft.AspNetCore.SignalR;

namespace Travelblog.Api.Controllers
{
    public class BlogHub: Hub
    {
        public async Task SendBlogUpdate(string message)
        {
            await Clients.All.SendAsync("ReceiveBlogUpdate", message);
        }
    }
}
