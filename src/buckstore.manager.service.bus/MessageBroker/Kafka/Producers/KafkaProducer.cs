﻿using System.Threading.Tasks;
using MassTransit.KafkaIntegration;
using buckstore.manager.service.application.IntegrationEvents;
using buckstore.manager.service.application.Adapters.MessageBroker;

namespace buckstore.manager.service.bus.MessageBroker.Kafka.Producers
{
    public class KafkaProducer<TEvent> : IMessageProducer<TEvent> where TEvent : IntegrationEvent
    {
        private readonly ITopicProducer<TEvent> _topicProducer;

        public KafkaProducer(ITopicProducer<TEvent> topicProducer)
        {
            _topicProducer = topicProducer;
        }

        public async Task Produce(TEvent message)
        {
            await _topicProducer.Produce(message);
        }
    }
}