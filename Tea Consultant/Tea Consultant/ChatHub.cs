using Microsoft.AspNetCore.SignalR;

namespace SignalR
{
    public class ChatHub : Hub
    {
        public async Task Send(string message, string userName)
        {
            Bot bot1 = new Bot();
            await Clients.All.SendAsync("Receive", message, userName);
            await this.Clients.All.SendAsync("Otvet", bot1.otveBota(message));
        }
    }
}
