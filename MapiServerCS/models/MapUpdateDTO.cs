using System;

namespace MapiServerCS.models
{
	public class MapUpdateDTO
	{
        public string Id { get; set; }
        public string Heading { get; set; }
        public string Description { get; set; }

        public MapUpdateDTO(string id, string heading, string description)
        {
            Id = id;
            Heading = heading;
            Description = description;

        }


    }
}

