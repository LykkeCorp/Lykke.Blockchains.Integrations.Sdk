﻿using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Lykke.Bil2.Contract.TransactionsExecutor.Responses
{
    /// <summary>
    /// Endpoint: [GET] /api/addresses/{address}/formats
    /// </summary>
    [PublicAPI]
    public class AddressFormatsResponse
    {
        /// <summary>
        /// List of the all known formats for the given address.
        /// </summary>
        [JsonProperty("formats")]
        public IReadOnlyCollection<AddressFormat> Formats { get; }

        public AddressFormatsResponse(IReadOnlyCollection<AddressFormat> formats)
        {
            if (formats == null)
                throw new ArgumentNullException(nameof(formats));

            if (!formats.Any())
                throw new ArgumentException("Should be not empty collection", nameof(formats));

            if (formats.Count(x => x.FormatName == null) > 1)
                throw new ArgumentException("Only one item with empty format name allowed", nameof(formats));

            Formats = formats;
        }
    }
}
