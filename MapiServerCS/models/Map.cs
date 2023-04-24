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
		[Column("creator_id")]
		public string UserId { get; set; }
		public ICollection<Location> Locations { get; } = new List<Location>();
		

		public Map(string heading, string description, string theme, string userId)
		{
			Heading = heading;
			Description = description;
			Theme = theme;
			Guid mapId = Guid.NewGuid();
			Id = mapId.ToString();
			UserId = userId;
		}
	}
}

