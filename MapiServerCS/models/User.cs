using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace MapiServerCS.models
{
	[Table ("users")]
	public class User
	{
		[System.ComponentModel.DataAnnotations.Key]
		[Column("id")]
		public string Id { get; set; }
		[Column("email")]
		public string Email { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("avatar")]
        public string Avatar { get; set; }
		public ICollection<Map> Maps { get; } = new List<Map>();


	
		public User( string email, string password, string firstName, string lastName, string avatar)
		{
			Email = email;
			Password = password;
			FirstName = firstName;
			LastName = lastName;
			Avatar = avatar;
			Guid userId = Guid.NewGuid();
			Id = userId.ToString();


		}
	}
}

