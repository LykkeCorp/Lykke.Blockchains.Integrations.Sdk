﻿using System.Collections.Generic;
using Lykke.Bil2.Contract.Common.Exceptions;
using Newtonsoft.Json;

namespace Lykke.Bil2.Contract.TransactionsExecutor.Requests
{
    /// <summary>
    /// Endpoint: [POST] /api/transactions/estimated/transfers
    /// </summary>
    public class EstimateSendingTransactionRequest
    {
        /// <summary>
        /// Transaction transfers.
        /// </summary>
        [JsonProperty("transfers")]
        public IReadOnlyCollection<Transfer> Transfers { get; }

        /// <summary>
        /// Fee options.
        /// </summary>
        [JsonProperty("fee")]
        public FeeOptions Fee { get; }

        /// <summary>
        /// Endpoint: [POST] /api/transactions/estimated/transfers
        /// </summary>
        public EstimateSendingTransactionRequest(
            IReadOnlyCollection<Transfer> transfers,
            FeeOptions fee)
        {
            TransactionTransfersValidator.Validate(transfers);

            Transfers = transfers;
            Fee = fee ?? throw RequestValidationException.ShouldBeNotNull(nameof(fee));
        }
    }
}
