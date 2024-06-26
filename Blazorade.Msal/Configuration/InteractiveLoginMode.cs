﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazorade.Msal.Configuration
{
    /// <summary>
    /// Defines different ways of doing interactive login.
    /// </summary>
    public enum InteractiveLoginMode
    {
        /// <summary>
        /// Uses the default popup provided by MSAL for interactive login. This usually works in web applications.
        /// </summary>
        Popup,

        /// <summary>
        /// Handles login by using redirection.
        /// </summary>
        Redirect,

        /// <summary>
        /// Interactive login is disabled.
        /// </summary>
        Disabled
    }
}
