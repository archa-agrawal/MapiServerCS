using System;
using MapiServerCS.models;

namespace MapiServerCS.Services
{
	public class MapService
	{
		public MapService()
		{
		}

		IDictionary<string, Map> maps = new Dictionary<int, Map>();


		public Map CreateMap(Map newMap)
		{
			Map nextMap = new Map(newMap.Heading, newMap.Description, newMap.Theme, newMap.CreatorId);
			maps.Add(nextMap.Id, nextMap);
			return nextMap;
		}

		public Map GetMap(string mapId)
		{
			try
			{
                return maps[mapId];
		
            }
			catch(KeyNotFoundException ex)
			{
				throw new Exception("Invalid id", ex);
			}
			
		}

		public Map EditMap(Map editedMap)
		{
			try
			{
				maps[editedMap.Id].Heading = editedMap.Heading;
				maps[editedMap.Id].Description = editedMap.Description;
				return maps[editedMap.Id];
			}
			catch(KeyNotFoundException ex)
			{
				throw new Exception("invalid id", ex);
			}

			
		}
	}
}

