﻿// Copyright 2021 Sharafeev Ravil
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
//     You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
//     distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//     See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBotHost.Middleware
{
    public class DefaultBotUpdateContext : BotUpdateContext
    {
        public override ITelegramBotClient BotClient { get; set; }
        public override Update Update { get; set; }
        public override CancellationToken CancellationToken { get; set; }
        public override IServiceProvider RequestServices { get; set; }
    }
}