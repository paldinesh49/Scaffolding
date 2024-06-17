// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.DotNet.Scaffolding.Helpers.Extensions.Roslyn;
using Microsoft.DotNet.Scaffolding.Helpers.Services;
using Microsoft.DotNet.Scaffolding.Steps;

namespace Microsoft.DotNet.Tools.Scaffold.Aspire.Steps;

internal class GeneratedProjectNameRetrievalStep(string appHostProject, string targetProject, ILogger logger) : OutputScaffoldStep
{
    private readonly string _appHostProject = appHostProject;
    private readonly string _targetProject = targetProject;
    private readonly ILogger _logger = logger;

    public async override Task<bool> ExecuteAsync()
    {
        var workspaceSettings = new WorkspaceSettings
        {
            InputPath = _appHostProject
        };
        var hostAppSettings = new AppSettings();
        hostAppSettings.AddSettings("workspace", workspaceSettings);
        var codeService = new CodeService(hostAppSettings, _logger);

        var autoGeneratedProjectNames = await GetAutoGeneratedProjectNamesAsync(codeService);

        autoGeneratedProjectNames.TryGetValue(_targetProject, out var autoGenProjectName);

        Output = autoGenProjectName;

        return true;
    }

    private static async Task<Dictionary<string, string>> GetAutoGeneratedProjectNamesAsync(CodeService codeService)
    {
        var allDocuments = await codeService.GetAllDocumentsAsync();
        var allSyntaxRoots = await Task.WhenAll(allDocuments.Select(doc => doc.GetSyntaxRootAsync()));

        // Get all classes with the "Projects" namespace
        var classesInNamespace = allSyntaxRoots
            .SelectMany(root => root?.DescendantNodes().OfType<ClassDeclarationSyntax>() ?? [])
            .Where(cls => cls.IsInNamespace("Projects"))
            .ToList();

        Dictionary<string, string> autoGeneratedProjectNames = [];
        foreach (var classSyntax in classesInNamespace)
        {
            string? projectPathValue = classSyntax.GetStringPropertyValue("ProjectPath");
            // Get the full class name including the namespace
            var className = classSyntax.Identifier.Text;
            if (!string.IsNullOrEmpty(projectPathValue))
            {
                autoGeneratedProjectNames.Add(projectPathValue, $"Projects.{className}");
            }
        }

        return autoGeneratedProjectNames;
    }
}