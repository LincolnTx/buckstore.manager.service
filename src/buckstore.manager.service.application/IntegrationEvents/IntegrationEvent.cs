using System;
using MediatR;

namespace buckstore.manager.service.application.IntegrationEvents
{
    public class IntegrationEvent : INotification
    {
        public DateTime Timestamp { get; set; }
    }
}