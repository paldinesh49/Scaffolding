// Copyright (c) Microsoft Corporation. All rights reserved.

using System.Collections.Generic;
using System.Composition;
using Microsoft.CodeAnalysis;
using Spectre.Console.Flow;

namespace Microsoft.DotNet.Tools.Scaffold.Commands.Services;

internal class FlowProvider : IFlowProvider
{
    public FlowProvider()
    {
    }

    /// <inheritdoc />
    public IFlow? CurrentFlow { get; private set; }

    /// <inheritdoc />
    public IFlow GetFlow(IEnumerable<IFlowStep> steps, Dictionary<string, object> properties, bool nonInteractive)
    {
        var flow = new FlowRunner(steps, properties, nonInteractive)
            .Breadcrumbs()
            .SelectedOptions();

        CurrentFlow = flow;

        return flow;
    }
}