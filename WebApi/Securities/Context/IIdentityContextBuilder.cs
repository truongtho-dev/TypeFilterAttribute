using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Extensions;

namespace WebApi.Securities.Context
{
	public interface IIdentityContextBuilder
	{
		Task<(IdentityContext identityContext, Notification note)> BuildAsync(HttpContext context);
	}

	public class Notification
	{
		public string ErrorCode { get; private set; }
		public string ErrorMessage { get; private set; }
	}

	public class IdentityContextBuilder : IIdentityContextBuilder
	{
		public Task<(IdentityContext identityContext, Notification note)> BuildAsync(HttpContext context)
		{
			throw new NotImplementedException();
		}
	}
}
