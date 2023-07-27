using Microsoft.AspNetCore.SignalR;

namespace Pr_Signal_ir.MVC.Services
{
    public class NotifyHub:Hub
    {
        public void Send()
        {

        }
        public override Task OnConnectedAsync()
        {
            //Clients.All.SendAsync("Send", "1", "2");
            return base.OnConnectedAsync();

        }
    }
}
