using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sample_webapi.Models
{
	public class UserModel
	{
		public string UserName { get; set; }
		public string Password { get; set; }
		public UserRole Role { get; set; }
	}

	public enum UserRole
	{
		Admin,
		User
	}

}