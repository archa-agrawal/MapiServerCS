using System;

namespace MapiServerCS.models
{
	public class MapUpdate
	{
        public string Id { get; set; }
        public string Heading { get; set; }
        public string Description { get; set; }

        public MapUpdate(string id, string heading, string description)
        {
            Id = id;
            Heading = heading;
            Description = description;

        }
    }
}

