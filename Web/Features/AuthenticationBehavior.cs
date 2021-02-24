using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Domain.Models;
using MediatR;
using Web.Constants;

namespace Web.Features
{
    public class AuthenticationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public AuthenticationBehavior(HttpClient httpClient, ISyncLocalStorageService localStorage)
        {
            var user = localStorage.GetItem<UserDto>(LocalStorageConstants.USER);
            if(user != null) {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", user.Token);
            }
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {            
            var response = await next();
            return response;
        }
    }   
}