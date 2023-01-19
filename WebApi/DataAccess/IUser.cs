using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Refit;
using WebApi.Models;

namespace WebApi.DataAccess
{
	public interface IUser
	{
		[Get("/users")]
		Task<IEnumerable<User>> Get();

		[Get("/users/{id}")]
		Task<User> GetById(int id);

		[Post("/users")]
		Task<User> Add([Body] User model);

		[Put("/users/{id}")]
		Task<User> Update([Body] User model);
	}
}
