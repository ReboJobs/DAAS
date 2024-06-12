﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazorade.Msal.Configuration
{
    /// <summary>
    /// Contains options for customizing how your application uses MSAL.
    /// </summary>
    public class BlazoradeMsalOptions
    {

        /// <summary>
        /// The client ID representing your application.
        /// </summary>
        public string ClientId { get; set; } = "8b29c164-355c-4ee0-96d5-5c8f927f0b04";

        /// <summary>
        /// The tenant ID in which the application is registered. 
        /// </summary>
        /// <remarks>
        /// The tenant ID can either be a Guid, the default domain, i.e. <c>[your tenant].onmicrosoft.com</c>,
        /// or a vanity domain like <c>yourcompany.com</c>. If your application is a multi-tenant application,
        /// you can also set the tenant to <c>common</c>, <c>organizations</c> or <c>consumers</c>.
        /// </remarks>
        public string TenantId { get; set; } = "94e6b5f2-d1da-4de9-a4ca-88cfdb6c3de0";

        /// <summary>
        /// The full authority URI representing the Azure AD tenant that will take care of authenticating your users. If this
        /// property is set, <see cref="TenantId"/> is ignored.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The <c>Authority</c> property allows you to use both Azure AD and Azure AD B2C. Depending on which directory
        /// you are using, the value is constructed a bit differently.
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <term>Azure AD</term>
        /// <description>https://login.microsoftonline.com/{tenant-name}.onmicrosoft.com</description>
        /// </item>
        /// <item>
        /// <term>Azure AD B2C</term>
        /// <description>https://{tenant-name}.b2clogin.com/{tenant-name}.onmicrosoft.com/{policy-name}</description>
        /// </item>
        /// </list>
        /// </remarks>
        public string Authority { get; set; }

        /// <summary>
        /// The MSAL Browser version to use.
        /// </summary>
        /// <remarks>
        /// Defaults to 2.22.0. For more information see https://github.com/AzureAD/microsoft-authentication-library-for-js/tree/dev/lib/msal-browser.
        /// </remarks>
        public string MsalVersion { get; set; } = "2.22.0";

        /// <summary>
        /// Defines how interactive login is handled.
        /// </summary>
        /// <remarks>
        /// Defaults to <see cref="InteractiveLoginMode.Redirect"/>.
        /// </remarks>
        public InteractiveLoginMode InteractiveLoginMode { get; set; } = InteractiveLoginMode.Redirect;

        /// <summary>
        /// The default scopes to acquire if none are specified when acquiring tokens.
        /// </summary>
        /// <remarks>
        /// Defaults to an array with <c>openid</c> and <c>profile</c>.
        /// </remarks>
        public IEnumerable<string> DefaultScopes { get; set; } = new string[] { "openid", "profile" };

        /// <summary>
        /// The redirect URI for your application.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This is the URL where your users are redirected back after interactive login if <see cref="InteractiveLoginMode"/>
        /// is set to <see cref="InteractiveLoginMode.Redirect"/>.
        /// </para>
        /// <para>
        /// Can be set to an absolute or relative URI.
        /// </para>
        /// </remarks>
        public string RedirectUrl { get; set; }

        /// <summary>
        /// The URI that the users are redirected to after logging out of your application.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Can be set to an absolute or relative URI.
        /// </para>
        /// </remarks>
        public string PostLogoutUrl { get; set; }

        /// <summary>
        /// Defines how tokens are cached.
        /// </summary>
        /// <remarks>
        /// Defaults to <see cref="TokenCacheScope.Session"/>.
        /// </remarks>
        public TokenCacheScope TokenCacheScope { get; set; } = TokenCacheScope.Session;



        internal string GetAuthority()
        {
            return this.Authority?.Length > 0
                ? this.Authority
                : $"https://login.microsoftonline.com/{ this.TenantId ?? "common" }";
        }
    }
}
