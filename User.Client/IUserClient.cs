using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace UserClient
{
	public interface IUserClient
	{
		[Get("/users")]
		Task<IEnumerable<User>> Get();
	}

	class UserClient : IUserClient
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public UserClient(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public Task<IEnumerable<User>> Get()
		{
			throw new NotImplementedException();
		}
	}
}
