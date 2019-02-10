﻿using System;
using JetBrains.Annotations;

namespace Lykke.Blockchains.Integrations.RabbitMq
{
    /// <summary>
    /// RabbitMq endpoint - represents RabbitMq connection and provides entrypoints
    /// to start listening for the messages and publish messages.
    /// </summary>
    [PublicAPI]
    public interface IRabbitMqEndpoint : IDisposable
    {
        /// <summary>
        /// Creates exchange if it does not exist or just ignore it if it already exists.
        /// </summary>
        void DeclareExchange(string exchangeName);

        /// <summary>
        /// Creates message publisher
        /// </summary>
        IMessagePublisher CreatePublisher(string exchangeName, string corellationId = null);

        /// <summary>
        /// Starts listening for the messages
        /// </summary>
        void StartListening(
            string listeningExchangeName,
            string listeningRoute,
            IMessageSubscriptionsRegistry subscriptionsRegistry,
            string replyExchangeName = null,
            int parallelism = 1);

        /// <summary>
        /// Starts endpoint. Should be called before any other methods
        /// </summary>
        void Start();
    }
}