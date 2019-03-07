﻿using JetBrains.Annotations;
using Lykke.Bil2.Contract.Common.JsonConverters;
using Newtonsoft.Json;

namespace Lykke.Bil2.Contract.Common
{
    /// <summary>
    /// Coins change - positive or negative number with fixed accuracy.
    /// </summary>
    [PublicAPI]
    [JsonConverter(typeof(CoinsChangeJsonConverter))]
    public sealed class CoinsChange : CoinsValueBase
    {
        private CoinsChange(string stringValue) : 
            base(stringValue, allowNegative: true)
        {
        }

        public static CoinsChange Create(string stringValue)
        {
            return new CoinsChange(stringValue);
        }

        public static CoinsChange FromDecimal(decimal value, int accuracy)
        {
            var stringValue = DecimalToString(value, accuracy);

            return new CoinsChange(stringValue);
        }
    }
}
