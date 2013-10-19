﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.md in the project root for license information.

using System.Collections.Generic;

namespace Microsoft.AspNet.SignalR.Hubs
{
    public class TypedHubConnectionContext<T> : IHubCallerConnectionContext<T>
    {
        private IHubCallerConnectionContext<dynamic> _dynamicContext;

        public TypedHubConnectionContext(IHubCallerConnectionContext<dynamic> dynamicContext)
        {
            _dynamicContext = dynamicContext;
        }

        public T Caller
        {
            get
            {
                return TypedClientBuilder<T>.Build(_dynamicContext.Caller);
            }
        }

        public T Others
        {
            get
            {
                return TypedClientBuilder<T>.Build(_dynamicContext.Others);
            }
        }

        public T OthersInGroup(string groupName)
        {
            return TypedClientBuilder<T>.Build(_dynamicContext.OthersInGroup(groupName));
        }

        public T OthersInGroups(IList<string> groupNames)
        {
            return TypedClientBuilder<T>.Build(_dynamicContext.OthersInGroups(groupNames));
        }

        public T All
        {
            get
            {
                return TypedClientBuilder<T>.Build(_dynamicContext.All);
            }
        }

        public T AllExcept(params string[] excludeConnectionIds)
        {
            return TypedClientBuilder<T>.Build(_dynamicContext.AllExcept(excludeConnectionIds));
        }

        public T Client(string connectionId)
        {
            return TypedClientBuilder<T>.Build(_dynamicContext.Client(connectionId));
        }

        public T Clients(IList<string> connectionIds)
        {
            return TypedClientBuilder<T>.Build(_dynamicContext.Clients(connectionIds));
        }

        public T Group(string groupName, params string[] excludeConnectionIds)
        {
            return TypedClientBuilder<T>.Build(_dynamicContext.Group(groupName, excludeConnectionIds));
        }

        public T Groups(IList<string> groupNames, params string[] excludeConnectionIds)
        {
            return TypedClientBuilder<T>.Build(_dynamicContext.Groups(groupNames, excludeConnectionIds));
        }

        public T User(string userId)
        {
            return TypedClientBuilder<T>.Build(_dynamicContext.User(userId));
        }

        public T Users(IList<string> userIds)
        {
            return TypedClientBuilder<T>.Build(_dynamicContext.Users(userIds));
        }
    }
}