using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private static List<User> Users = new List<User>()
		{
			new User
			{
				Id = 1,
				Name = "Teo",
				Company = "A"
			},
			new User
			{
				Id = 2,
				Name = "Ty",
				Company = "B"
			},
			new User
			{
				Id = 3,
				Name = "Tun",
				Company = "A"
			}
		};

	
		[HttpGet]
		public IEnumerable<User> Get()
		{
			return Users;
		}

		[HttpGet("{id}")]
		public User GetById(int id)
		{
			return Users.Where(u => u.Id == id).FirstOrDefault();
		}

		[HttpPost]
		public void Post([FromBody] User model)
		{
			Users.Add(model);
		}

		[HttpPut("{id}")]
		public void Put(int id, [FromBody] User model)
		{
			var user = Users.Where(u => u.Id == id).FirstOrDefault();
			Users.Remove(user);
			Users.Add(model);
		}

		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			var user = Users.Where(u => u.Id == id).FirstOrDefault();
			Users.Remove(user);
		}
	}
}
