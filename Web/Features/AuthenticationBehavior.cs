using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Blazored.Toast.Services;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Components;
using Web.Constants;

namespace Web.Features
{
    public class AuthenticationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private const string AUTHORIZATION = "Authorization";
        NavigationManager _navigation;
        ISyncLocalStorageService _localStorage;
        HttpClient _httpClient;
        public AuthenticationBehavior(HttpClient httpClient, ISyncLocalStorageService localStorage, NavigationManager navigation)
        {
            _navigation = navigation;
            _localStorage = localStorage;
            _httpClient = httpClient;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var user = _localStorage.GetItem<UserDto>(LocalStorageConstants.USER);
            if(user != null && (!_httpClient.DefaultRequestHeaders.Contains(AUTHORIZATION) || _httpClient.DefaultRequestHeaders.Authorization.Parameter != user.Token)) {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", user.Token);
            }

            TResponse response = default(TResponse);
            try {
                response = await next();
            } catch(HttpRequestException e) {
                if(e.StatusCode == HttpStatusCode.Unauthorized) {
                    _httpClient.DefaultRequestHeaders.Remove(AUTHORIZATION);
                    _localStorage.Clear();
                    _navigation.NavigateTo("login");
                }
            }            
            return response;
        }
    }   
}