using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace MapiServerCS.models
{
	[Table("locations")]
	public class Location
	{
		[System.ComponentModel.DataAnnotations.Key]
		[Column("id")]
		public string Id { get; set; }
		[Column("title")]
		public string Title { get; set; }
		[Column("description")]
		public string Description { get; set; }
		[Column("longitude")]
		public double Longitude { get; set; }
		[Column("latitude")]
		public double Latitude { get; set; }
		[Column("type")]
		public string LocationType { get; set; }
		
		
		public Location(string title, string description, double longitude, double latitude, string locationType)
		{
			Title = title;
			Description = description;
			Longitude = longitude;
			Latitude = latitude;
			LocationType = locationType;
            Guid locationId = Guid.NewGuid();
            Id = locationId.ToString();
        }
	}
}

