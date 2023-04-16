using System;
namespace MapiServerCS.models
{
	public class Location
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public double Longitude { get; }
		public double Latitude { get; }
		public string LocationType { get; set; }
		public int MapId { get; }
		
		public Location(string title, string description, double longitude, double latitude, string locationType, int mapId)
		{
			Title = title;
			Description = description;
			Longitude = longitude;
			Latitude = latitude;
			LocationType = locationType;
			MapId = mapId;

		}
	}
}

