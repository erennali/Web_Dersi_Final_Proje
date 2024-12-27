using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace WebProje.Hubs;

public class NotificationHub : Hub
{
    public async Task SendNotification(Guid masaId, string message)
    {
        // bütün istemcilere bildirimi gönderme işlemidir
        await Clients.All.SendAsync("ReceiveNotification", masaId, message);
    }
}