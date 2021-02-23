using System.Net.Http;
using System.Net.Http.Headers;
using Blazored.LocalStorage;
using BlazorState;
using Domain.Models;
using Web.Constants;

namespace Web.Features
{
    public abstract class BaseHandler<TAction> : ActionHandler<TAction> where TAction : IAction
    {
        private readonly HttpClient _httpClient;
        private readonly ISyncLocalStorageService _localStorage;
        protected UserDto _loggedUser { get; set; }
        public BaseHandler(IStore store, HttpClient httpClient, ISyncLocalStorageService localStorage) : base(store)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _loggedUser = localStorage.GetItem<UserDto>(LocalStorageConstants.USER);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _loggedUser.Token);
        }
    }
    
}