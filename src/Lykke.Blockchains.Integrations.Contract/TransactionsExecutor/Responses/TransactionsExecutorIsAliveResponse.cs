﻿using System;
using JetBrains.Annotations;
using Lykke.Blockchains.Integrations.Contract.Common.Responses;
using Newtonsoft.Json;

namespace Lykke.Blockchains.Integrations.Contract.TransactionsExecutor.Responses
{
    /// <inheritdoc />
    [PublicAPI]
    public class TransactionsExecutorIsAliveResponse : IsAliveResponse
    {
        /// <summary>
        /// Optional.
        /// Should describe the problems if integration is unhealthy.
        /// For instance implementation could check 
        /// if node and all used intermediate APIs are running 
        /// well and they are consistent, configuration is 
        /// correct and all required dependencies are accessible.
        /// </summary>
        [CanBeNull]
        [JsonProperty("disease")]
        public string Disease { get; }

        public TransactionsExecutorIsAliveResponse(
            string name, 
            Version version, 
            string envInfo, 
            bool isDebug, 
            Version contractVersion, 
            string disease = null) : 

            base
            (
                name, 
                version, 
                envInfo, 
                isDebug, 
                contractVersion
            )
        {
            if(disease != null && string.IsNullOrWhiteSpace(disease))
                throw new ArgumentException("Disease should be either null or not empty string");

            Disease = disease;
        }
    }
}
