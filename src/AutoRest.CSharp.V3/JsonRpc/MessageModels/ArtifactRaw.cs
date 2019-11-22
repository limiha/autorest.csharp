﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.Utilities;

namespace AutoRest.CSharp.V3.JsonRpc.MessageModels
{
    internal class ArtifactRaw : IArtifact
    {
        public string? Uri { get; set; }
        public string? Type { get; set; }
        public string? Content { get; set; }
        public RawSourceMap? SourceMap { get; set; } = null;

        public override string ToString() => $@"{{""uri"":""{Uri}"",""type"":""{Type}"",""content"":""{Content.ToStringLiteral()}""{SourceMap.TextOrEmpty($@",""sourceMap"":{SourceMap}")}}}";
    }
}
