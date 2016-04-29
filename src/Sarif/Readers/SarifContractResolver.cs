﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Newtonsoft.Json.Serialization;
using System;
using Microsoft.CodeAnalysis.Sarif.Sdk;

namespace Microsoft.CodeAnalysis.Sarif.Readers
{
    public class SarifContractResolver : DefaultContractResolver
    {
        public static readonly SarifContractResolver Instance = new SarifContractResolver();

        protected override JsonContract CreateContract(Type objectType)
        {
            JsonContract contract = base.CreateContract(objectType);

            // this will only be called once and then cached
            if (objectType == typeof(Uri))
                contract.Converter = UriConverter.Instance;

            else if (objectType == typeof(DateTime))
                contract.Converter = DateTimeConverter.Instance;

            else if (objectType == typeof(Version))
                contract.Converter = VersionConverter.Instance;

            else if (objectType == typeof(SarifVersion))
                contract.Converter = SarifVersionConverter.Instance;

            else if (objectType == typeof(ResultLevel))
                contract.Converter = ResultLevelConverter.Instance;

            else if (objectType == typeof(NotificationLevel))
                contract.Converter = NotificationLevelConverter.Instance;

            else if (objectType == typeof(AlgorithmKind))
                contract.Converter = AlgorithmKindConverter.Instance;

            return contract;
        }
    }
}
