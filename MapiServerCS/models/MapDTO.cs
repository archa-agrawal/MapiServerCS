using System;
using System.Text.Json.Serialization;

namespace MapiServerCS.models
{
	public class MapDTO
	{
		public string Heading { get; set; }
		public string Description { get; set; }
		public string Theme { get; set; }
		public string? Id { get; set; }

		[JsonConstructorAttribute]
		public MapDTO(string heading, string description, string theme)
		{
			Heading = heading;
			Description = description;
			Theme = theme;
		}

		public MapDTO(Map m)
		{
			Id = m.Id;
			Heading = m.Heading;
			Description = m.Description;
			Theme = m.Theme;
		}


	}
}

