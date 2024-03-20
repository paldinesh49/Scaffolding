// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections;
using System.Collections.Generic;
using Spectre.Console;
using Spectre.Console.Cli;
using Spectre.Console.Flow;

namespace Microsoft.DotNet.Tools.Scaffold.Flow
{
    internal static class FlowContextExtensions
    {
        public static string? GetComponentName(this IFlowContext context, bool throwIfEmpty = false)
        {
            return context.GetValueOrThrow<string>(FlowContextProperties.ComponentName, throwIfEmpty);
        }

        public static string? GetSourceProjectPath(this IFlowContext context, bool throwIfEmpty = false)
        {
            return context.GetValueOrThrow<string>(FlowContextProperties.SourceProjectPath, throwIfEmpty);
        }

        public static Build.Evaluation.Project? GetSourceProject(this IFlowContext context, bool throwIfEmpty = false)
        {
            return context.GetValueOrThrow<Build.Evaluation.Project>(FlowContextProperties.SourceProject, throwIfEmpty);
        }

        public static ScaffoldCommand.Settings? GetCommandSettings(this IFlowContext context, bool throwIfEmpty = false)
        {
            return context.GetValueOrThrow<ScaffoldCommand.Settings>(FlowContextProperties.CommandSettings, throwIfEmpty);
        }

        public static IRemainingArguments? GetRemainingArgs(this IFlowContext context, bool throwIfEmpty = false)
        {
            return context.GetValueOrThrow<IRemainingArguments>(FlowContextProperties.RemainingArgs, throwIfEmpty);
        }

        public static IDictionary<string, List<string>>? GetArgsDict(this IFlowContext context, bool throwIfEmpty = false)
        {
            return context.GetValueOrThrow<IDictionary<string, List<string>>>(FlowContextProperties.CommandArgs, throwIfEmpty);
        }
        public static Status WithSpinner(this Status status)
        {
            return status
                .AutoRefresh(true)
                .Spinner(Spinner.Known.Aesthetic)
                .SpinnerStyle(Styles.Highlight);
        }

        private static T? GetValueOrThrow<T>(this IFlowContext context, string propertyName, bool throwIfEmpty = false)
        {
            var value = context.GetValue<T>(propertyName);
            if (throwIfEmpty && value is null)
            {
                throw new ArgumentNullException(propertyName);
            }

            return value;
        }
    }

}