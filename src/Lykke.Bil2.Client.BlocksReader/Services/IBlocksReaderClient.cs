﻿using System;
using JetBrains.Annotations;

namespace Lykke.Bil2.Client.BlocksReader.Services
{
    /// <summary>
    /// Blockchain integration blocks reader client
    /// </summary>
    /// <remarks>
    /// Use <see cref="BlocksReaderClientServiceCollectionExtensions.AddBlocksReaderClient"/> to register <see cref="IBlocksReaderClient"/>
    /// implementation in the service provider.
    /// </remarks>
    [PublicAPI]
    public interface IBlocksReaderClient : IDisposable
    {
        /// <summary>
        /// Starts the client should be called in order to use <see cref="IBlocksReaderApi"/> and handles events using <see cref="IBlockEventsHandler"/>
        /// </summary>
        void Start();
    }
}
