// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Microsoft.DotNet.Scaffolding.Shared.Cli.Utils;
using Microsoft.DotNet.Scaffolding.Shared.Helpers;
using Microsoft.DotNet.Scaffolding.Shared.Services;
using Microsoft.DotNet.Scaffolding.Shared.Spectre;
using Microsoft.DotNet.Scaffolding.Shared.Spectre.Services;
using Spectre.Console.Cli;

namespace Microsoft.DotNet.Tools.Scaffold.Commands.Commands
{
    internal class ExternalCommand : Command<CommandSettings>
    {
        public class Settings : DefaultCommandSettings
        {
            [CommandArgument(0, "[Command]")]
            public string CommandName { get; set; } = default!;
        }

        public ExternalCommand()//IToolService packageInfoService)
        {
            //_packageInfoService = packageInfoService ?? throw new ArgumentNullException(nameof(packageInfoService));
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] CommandSettings settings)
        {
            var toolInfo = new ToolInfo();// _packageInfoService.GetToolInfo(context.Name);
            if (toolInfo is null)
            {
                return -1;
                //throw a fit
            }

            var exeName = toolInfo.ToolExeName;
            if (!Path.HasExtension(exeName) || Path.GetExtension(exeName).ToLower() != ".exe")
            {
                exeName += ".exe";
            }
            /*
            var packagesFolder = ""; Path.Combine(_packageInfoService.DotnetScaffolderFolder, "packages");

            var exePath = ""; FileSystemHelper.GetFirstFilePath(packagesFolder, exeName);
            DotnetCommands.InvokeExternalCommand(exePath, new List<string>());
            */
            return 0;
        }

       // private IToolService _packageInfoService;
    }
}