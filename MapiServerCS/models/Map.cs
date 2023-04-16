using System;
namespace MapiServerCS.models
{
	public class Map
	{

		public string Heading { get; set; }
		public string Description { get; set; }
		public string Theme { get; set; }
		public int CreatorId { get; }
		public int Id { get; }

		public Map(string heading, string description, string theme, int creatorId, int id)
		{
			Heading = heading;
			Description = description;
			Theme = theme;
			CreatorId = creatorId;
			Id = id;

		}


	}
}

