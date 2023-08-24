using MediatR;

namespace ItMaraphoneExample.API.Requests.ChatRequests
{
    public class SendMessageRequest : IRequest
    {
        public string AddressTo { get; set; }

        public string AddressFrom { get; set; }

        public string Text { get; set; }
    }
}
