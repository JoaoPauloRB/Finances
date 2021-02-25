using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Components;
using Web.Constants;

namespace Web.Features
{
    public class AuthenticationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        NavigationManager _navigation;
        public AuthenticationBehavior(HttpClient httpClient, ISyncLocalStorageService localStorage, NavigationManager navigation)
        {
            _navigation = navigation;
            var user = localStorage.GetItem<UserDto>(LocalStorageConstants.USER);
            if(user != null) {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", user.Token);
            }
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            TResponse response = default(TResponse);
            try {
                response = await next();
            } catch(HttpRequestException e) {
                if(e.StatusCode == HttpStatusCode.Unauthorized) {
                    _navigation.NavigateTo("login");
                }
            }            
            return response;
        }
    }   
}