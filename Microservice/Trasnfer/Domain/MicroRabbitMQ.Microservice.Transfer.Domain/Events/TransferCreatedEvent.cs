﻿using MicroRabbitMQ.Domain.Core.Events;
using System;

namespace MicroRabbitMQ.Microservice.Transfer.Domain.Events
{
    public class TransferCreatedEvent : Event
    {
        public int From { get; private set; }
        public int To { get; private set; }
        public Decimal Amount { get; private set; }

        public TransferCreatedEvent(int from, int to, decimal amount)
        {
            From = from;
            To = to;
            Amount = amount;
        }
    }
}