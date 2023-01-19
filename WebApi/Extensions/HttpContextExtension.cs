using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Extensions
{
	public static class HttpContextExtension
	{
		private const string IdentityContextKey = "IdentityContextKey";

		public static IdentityContext GetIdentityContext(this HttpContext context)
		{
			if (context == null) return null;

			context.Items.TryGetValue(IdentityContextKey, out var identityContext);
			return (IdentityContext)identityContext;
		}

		public static void AddIdentityContext(this HttpContext context, IdentityContext identityContext)
		{
			context.Items.Add(IdentityContextKey, identityContext);
		}
	}

	public class IdentityContext
	{
		public int AccountId { get; set; }
	}
}
