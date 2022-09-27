using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.Models.Entities
{
    public class ChatRoom
    {
        public Guid Id { get; set; }
        public string ConnectionId { get; set; }
        public ICollection<ChatMessage> ChatMessages { get; set; }
    }
}
