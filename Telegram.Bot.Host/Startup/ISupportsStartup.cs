﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

// Modifications copyright (c) 2021 Sharafeev Ravil

using System;
using System.Diagnostics.CodeAnalysis;
using Telegram.Bot.Host.ApplicationBuilder;
using Telegram.Bot.Host.BotHost;
using Telegram.Bot.Host.GenericBotHost;

namespace Telegram.Bot.Host.Startup
{
    public interface ISupportsStartup
    {
        IBotHostBuilder Configure(
            Action<BotHostBuilderContext, IApplicationBuilder> configure);

        IBotHostBuilder UseStartup(
            [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors |
                                        DynamicallyAccessedMemberTypes.PublicMethods)]
            Type startupType);

        IBotHostBuilder UseStartup<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] TStartup>(
            Func<BotHostBuilderContext, TStartup> startupFactory);
    }
}