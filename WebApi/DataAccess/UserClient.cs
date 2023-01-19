using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApi.DataAccess
{
	public class UserClient
	{
        private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _httpClientFactory;

        private static readonly RefitSettings RefitSettings = new RefitSettings
        {
            ContentSerializer = new SystemTextJsonContentSerializer(),
            CollectionFormat = CollectionFormat.Multi
        };

		public UserClient(HttpClient httpClient)
		{
            _httpClient = httpClient;
		}

        public UserClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private T For<T>(string clientName)
        {
            if (_httpClient != null)
            {
                return RestService.For<T>(_httpClient, RefitSettings);
            }

            _ = _httpClientFactory ?? throw new ArgumentException("Missing httpClientFactory");
            var client = _httpClientFactory.CreateClient(clientName);
            return RestService.For<T>(client, RefitSettings);
        }

        public IUser User => For<IUser>("User");
    }
}
