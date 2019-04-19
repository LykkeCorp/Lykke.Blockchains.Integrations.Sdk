﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using JetBrains.Annotations;
using Lykke.Bil2.Contract.Common;
using Lykke.Bil2.SharedDomain;

namespace Lykke.Bil2.Contract.BlocksReader.Events
{
    /// <summary>
    /// "Transfer amount" transactions model.
    /// Should be published for each executed transaction in the block being read if
    /// integration uses “transfer amount” transactions model. Integration should either
    /// support “transfer coins” or “transfer amount” transactions model.
    /// </summary>
    [PublicAPI, DataContract]
    public class TransferAmountTransactionExecutedEvent
    {
        /// <summary>
        /// ID of the block.
        /// </summary>
        [DataMember(Order = 0)]
        public BlockId BlockId { get; }

        /// <summary>
        /// Number of the transaction in the block.
        /// </summary>
        [DataMember(Order = 1)]
        public int TransactionNumber { get; }

        /// <summary>
        /// ID of the transaction.
        /// </summary>
        [DataMember(Order = 2)]
        public TransactionId TransactionId { get; }

        /// <summary>
        /// Balance changing operations.
        /// </summary>
        [DataMember(Order = 3)]
        public IReadOnlyCollection<BalanceChange> BalanceChanges { get; }

        /// <summary>
        /// Fees in the particular asset, that was spent for the transaction.
        /// </summary>
        [DataMember(Order = 4)]
        public IReadOnlyCollection<Fee> Fees { get; }

        /// <summary>
        /// Optional.
        /// Flag which indicates, if transaction is irreversible.
        /// </summary>
        [CanBeNull, DataMember(Order = 5)]
        public bool? IsIrreversible { get; }

        /// <summary>
        /// "Transfer amount" transactions model.
        /// Should be published for each executed transaction in the block being read if
        /// integration uses “transfer amount” transactions model. Integration should either
        /// support “transfer coins” or “transfer amount” transactions model.
        /// </summary>
        /// <param name="blockId">ID of the block.</param>
        /// <param name="transactionNumber">Number of the transaction in the block.</param>
        /// <param name="transactionId">ID of the transaction.</param>
        /// <param name="balanceChanges">Balance changing operations.</param>
        /// <param name="fees">Fees in the particular asset, that was spent for the transaction.</param>
        /// <param name="isIrreversible">
        /// Optional.
        /// Flag which indicates, if transaction is irreversible.
        /// </param>
        public TransferAmountTransactionExecutedEvent(
            BlockId blockId,
            int transactionNumber,
            TransactionId transactionId,
            IReadOnlyCollection<BalanceChange> balanceChanges,
            IReadOnlyCollection<Fee> fees,
            bool? isIrreversible = null)
        {
            if (transactionNumber < 0)
                throw new ArgumentOutOfRangeException(nameof(transactionNumber), transactionNumber, "Should be zero or positive number");

            if (fees == null)
                throw new ArgumentNullException(nameof(fees));
            
            BalanceChangesValidator.Validate(balanceChanges);
            FeesValidator.ValidateFeesInResponse(fees);

            BlockId = blockId ?? throw new ArgumentNullException(nameof(blockId));
            TransactionNumber = transactionNumber;
            TransactionId = transactionId ?? throw new ArgumentNullException(nameof(transactionId));
            BalanceChanges = balanceChanges;
            Fees = fees;
            IsIrreversible = isIrreversible;
        }
    }
}
