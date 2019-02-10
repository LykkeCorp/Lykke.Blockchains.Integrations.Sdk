﻿using System;
using BlocksReaderExample.Services;
using BlocksReaderExample.Settings;
using JetBrains.Annotations;
using Lykke.Blockchains.Integrations.Sdk.BlocksReader;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BlocksReaderExample
{
    [UsedImplicitly]
    public class Startup
    {
        private const string IntegrationName = "Example";

        [UsedImplicitly]
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            return services.BuildBlockchainBlocksReaderServiceProvider<AppSettings>(options =>
            {
                options.IntegrationName = IntegrationName;

                options.BlockReaderFactory = c => new BlockReader();
                options.AddIrreversibleBlockPulling(c => new IrreversibleBlockProvider());

                options.UseSettings = settings =>
                {
                    services.AddSingleton<INodeClient>(new NodeClient(settings.CurrentValue.NodeUrl));
                };
            });
        }

        [UsedImplicitly]
        public void Configure(IApplicationBuilder app)
        {
            app.UseBlockchainBlocksReader(options =>
            {
                options.IntegrationName = IntegrationName;
            });
        }
    }
}
