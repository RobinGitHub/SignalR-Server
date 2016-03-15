// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.


using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.SignalR.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.AspNetCore.SignalR.Hubs
{
    /// <summary>
    /// Describes a hub method provider that builds a collection of available methods on a given hub.
    /// </summary>
    public interface IMethodDescriptorProvider
    {
        /// <summary>
        /// Retrieve all methods on a given hub.
        /// </summary>
        /// <param name="hub">Hub descriptor object.</param>
        /// <returns>Available methods.</returns>
        IEnumerable<MethodDescriptor> GetMethods(HubDescriptor hub);

        /// <summary>
        /// Tries to retrieve a method.
        /// </summary>
        /// <param name="hub">Hub descriptor object</param>
        /// <param name="method">Name of the method.</param>
        /// <param name="descriptor">Descriptor of the method, if found. Null otherwise.</param>
        /// <param name="parameters">Method parameters to match.</param>
        /// <returns>True, if a method has been found.</returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "2#", Justification = "This is a well known pattern for efficient lookup")]
        bool TryGetMethod(HubDescriptor hub, string method, out MethodDescriptor descriptor, IList<IJsonValue> parameters);
    }
}