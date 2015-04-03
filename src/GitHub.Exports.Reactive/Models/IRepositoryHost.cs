﻿using System;
using System.Collections.Generic;
using System.Reactive;
using GitHub.Api;
using GitHub.Authentication;
using GitHub.Caches;
using GitHub.Primitives;

namespace GitHub.Models
{
    public interface IRepositoryHost
    {
        HostAddress Address { get; }
        IApiClient ApiClient { get; }
        IHostCache Cache { get; }
        bool IsGitHub { get; }
        bool IsLoggedIn { get; }
        bool IsLoggingIn { get; }
        bool IsEnterprise { get; }
        string Title { get; }

        /// <summary>
        /// Retrieves all the accounts associated with this host.
        /// </summary>
        /// <returns></returns>
        IObservable<IReadOnlyList<IAccount>> GetAccounts();

        IObservable<AuthenticationResult> LogIn(string usernameOrEmail, string password);
        IObservable<AuthenticationResult> LogInFromCache();
        IObservable<Unit> LogOut();
    }
}
