using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace MapiServerCS.models
{
	[Table("maps")]
	public class Map
	{
		[System.ComponentModel.DataAnnotations.Key]
		[Column("id")]
        public string Id { get; set; }
		[Column("heading")]
        public string Heading { get; set; }
		[Column("description")]
		public string Description { get; set; }
		[Column("theme")]
		public string Theme { get; set; }
		

		public Map(string heading, string description, string theme)
		{
			Heading = heading;
			Description = description;
			Theme = theme;
			Guid mapId = Guid.NewGuid();
			Id = mapId.ToString();

		}


	}
}

