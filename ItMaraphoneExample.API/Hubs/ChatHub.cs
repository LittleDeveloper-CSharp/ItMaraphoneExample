using ItMaraphoneExample.API.Models;
using ItMaraphoneExample.API.Requests.ChatRequests;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace ItMaraphoneExample.API.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IMediator _mediator;

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public async Task SendMessage(SendMessageRequest message)
        {
            await _mediator.Send(message);
        
            
        }
    }
}
