using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Familyregister.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using Models;

namespace Familyregister.Authentication
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IJSRuntime jsRuntime;
        private readonly IUserService userService;

        private User cachedUser;
        
        public CustomAuthenticationStateProvider(IJSRuntime jsRuntime, IUserService userService)
        {
            this.jsRuntime = jsRuntime;
            this.userService = userService;
        }

        // method called by the framework whenever authentication/ authorization is needed
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // the object containing the claims -> key-value pair
            var identity = new ClaimsIdentity();
            if (cachedUser == null)
            {
                string userAsJson = await jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "currentUser");
                if (!string.IsNullOrEmpty(userAsJson))
                {
                    User temp = JsonSerializer.Deserialize<User>(userAsJson);
                    ValidateLogin(temp.UserName, temp.Password);
                }
            }
            else
            {
                identity = SetUpClaimsForUser(cachedUser);
            }

            ClaimsPrincipal cachedClaimsPrincipal = new ClaimsPrincipal(identity);
            return await Task.FromResult(new AuthenticationState(cachedClaimsPrincipal));
        }

        public void ValidateLogin(string userName, string password)
        {
            Console.WriteLine("Validating log in");
            if (string.IsNullOrEmpty(userName)) throw new Exception("Enter username");
            if (string.IsNullOrEmpty(password)) throw new Exception("Enter password");

            ClaimsIdentity identity = new ClaimsIdentity();
            try
            {
                User user = userService.ValidateUserAsync(userName, password).Result;
                identity = SetUpClaimsForUser(user);
                string serializedData = JsonSerializer.Serialize(user);
                // storing user in session storage
                jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", serializedData);
                cachedUser = user;
            }
            catch (Exception e)
            {
                throw e;
            }

            // notifying the system that a user is logged in
            NotifyAuthenticationStateChanged(Task.FromResult(
                new AuthenticationState(new ClaimsPrincipal(identity))));
        }

        // deleting stored user cached and stored user, creating no-claims user info
        public void Logout()
        {
            cachedUser = null;
            var user = new ClaimsPrincipal(new ClaimsIdentity());
            jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", "");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }


        private ClaimsIdentity SetUpClaimsForUser(User user)
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim("Role", user.Role));

            ClaimsIdentity identity = new ClaimsIdentity(claims, "apiauth_type");
            return identity;
        }
    }
}