﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

// Modifications copyright (c) 2021 Sharafeev Ravil

using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Telegram.Bot.Host.Startup
{
    internal class ConfigureServicesBuilder
    {
        public ConfigureServicesBuilder(MethodInfo configureServices)
        {
            MethodInfo = configureServices;
        }

        public MethodInfo MethodInfo { get; }

        public Func<Func<IServiceCollection, IServiceProvider>, Func<IServiceCollection, IServiceProvider>>
            StartupServiceFilters { get; set; } = f => f;

        public Func<IServiceCollection, IServiceProvider> Build(object instance)
        {
            return services => Invoke(instance, services);
        }

        private IServiceProvider Invoke(object instance, IServiceCollection services)
        {
            return StartupServiceFilters(Startup)(services);

            IServiceProvider Startup(IServiceCollection serviceCollection)
            {
                return InvokeCore(instance, serviceCollection);
            }
        }

        private IServiceProvider InvokeCore(object instance, IServiceCollection services)
        {
            if (MethodInfo == null)
                return null;

            var parameters = MethodInfo.GetParameters();
            if (parameters.Length > 1 || parameters.Any(p => p.ParameterType != typeof(IServiceCollection)))
                throw new InvalidOperationException(
                    "The ConfigureServices method must either be parameterless or take only one parameter of type IServiceCollection.");

            var arguments = new object[MethodInfo.GetParameters().Length];

            if (parameters.Length > 0)
                arguments[0] = services;

            return MethodInfo.InvokeWithoutWrappingExceptions(instance, arguments) as IServiceProvider;
        }
    }
}