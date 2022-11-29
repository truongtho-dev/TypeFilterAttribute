using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Filter
{
	public class AddResponseHeaderFilter : IAsyncActionFilter
	{
		public Messages[] Messages { get; set; }

		public AddResponseHeaderFilter(Messages[] messages)
		{
			Messages = messages;
		}
		public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			foreach (var item in Messages)
			{
				context.HttpContext.Response.Headers.Add(item.ToString(), item.ToString());
			}

			_ = await next.Invoke();
		}
	}
	public class AddResponseHeaderAttribute: TypeFilterAttribute
	{
		public AddResponseHeaderAttribute(params Messages[] messages): base(typeof(AddResponseHeaderFilter))
		{
			Arguments = new object[] { messages };
		}
	}

	public enum Messages
	{
		One = 1,
		Two = 2,
		Three = 3
	}
}
