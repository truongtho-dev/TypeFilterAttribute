using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Extensions;
using WebApi.Securities.Context;

namespace WebApi.Middlewares
{
	public class IdentityContextMiddleware
	{
		private readonly RequestDelegate _next;

		public IdentityContextMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext context, IIdentityContextBuilder builder)
		{
			if(context !=null && context.User.Identity.IsAuthenticated)
			{
				var (identityContext, note) = await builder.BuildAsync(context);
				context.AddIdentityContext(identityContext);
			}

			await _next(context);
		}
	}

	public static class IdentityContextMiddlewareExtension
	{
		public static IApplicationBuilder UseIdentityContext(this IApplicationBuilder app)
		{
			app.UseMiddleware<IdentityContextMiddleware>();
			return app;
		}
	}


}
