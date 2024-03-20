// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.DotNet.Scaffolding.ComponentModel;
using Microsoft.DotNet.Scaffolding.Helpers.General;

namespace Microsoft.DotNet.Scaffolding.Helpers.Services
{
    public class DotNetToolService : IDotNetToolService
    {
        private IList<DotNetToolInfo>? _dotNetTools;
        public IList<DotNetToolInfo> DotNetTools
        {
            get
            {
                _dotNetTools ??= GetDotNetTools();
                return _dotNetTools;
            }
        }

        public List<CommandInfo>? GetCommands(string dotnetToolName)
        {
            var commands = new List<CommandInfo>();
            var runner = DotnetCliRunner.CreateDotNet(dotnetToolName, ["get-commands"]);
            var exitCode = runner.ExecuteAndCaptureOutput(out var stdOut, out var stdErr);
            if (exitCode == 0 && !string.IsNullOrEmpty(stdOut))
            {
                try
                {
                    commands = JsonSerializer.Deserialize<List<CommandInfo>>(stdOut);
                }
                catch (Exception)
                {

                }
            }

            return commands;
        }

        public DotNetToolInfo? GetDotNetTool(string componentName, string? version = null)
        {
            var matchingTools = DotNetTools.Where(x => x.Command.Equals(componentName, StringComparison.OrdinalIgnoreCase));
            if (string.IsNullOrEmpty(version))
            {
                return matchingTools.FirstOrDefault();
            }
            else
            {
                return matchingTools.FirstOrDefault(x => x.Version.Equals(version));
            }
        }

        internal static IList<DotNetToolInfo> GetDotNetTools()
        {
            var dotnetToolList = new List<DotNetToolInfo>();
            var runner = DotnetCliRunner.CreateDotNet("tool", ["list", "-g"]);
            var exitCode = runner.ExecuteAndCaptureOutput(out var stdOut, out var stdErr);
            if (exitCode == 0 && !string.IsNullOrEmpty(stdOut))
            {
                var stdOutByLine = stdOut.Split(Environment.NewLine);
                foreach (var line in stdOutByLine)
                {
                    var parsedDotNetTool = ParseToolInfo(line);
                    if (parsedDotNetTool != null &&
                        !parsedDotNetTool.Command.Equals("dotnet-scaffold", StringComparison.OrdinalIgnoreCase) &&
                        !parsedDotNetTool.PackageName.Equals("package", StringComparison.OrdinalIgnoreCase))
                    {
                        dotnetToolList.Add(parsedDotNetTool);
                    }
                }
            }

            return dotnetToolList;
        }

        internal static DotNetToolInfo? ParseToolInfo(string line)
        {
            var match = Regex.Match(line, @"^(\S+)\s+(\S+)\s+(\S+)");
            if (match.Success)
            {
                return new DotNetToolInfo
                {
                    PackageName = match.Groups[1].Value,
                    Version = match.Groups[2].Value,
                    Command = match.Groups[3].Value
                };
            }

            return null;
        }
    }
}