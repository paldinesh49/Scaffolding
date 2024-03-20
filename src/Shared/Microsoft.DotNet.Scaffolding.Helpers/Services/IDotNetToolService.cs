// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.DotNet.Scaffolding.ComponentModel;

namespace Microsoft.DotNet.Scaffolding.Helpers.Services
{
    public interface IDotNetToolService
    {
        IList<DotNetToolInfo> DotNetTools { get; }
        DotNetToolInfo? GetDotNetTool(string componentName, string? version = null);
        List<CommandInfo> GetCommands(string dotnetToolName);
    }
}