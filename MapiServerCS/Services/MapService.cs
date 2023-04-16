using System;
using MapiServerCS.models;

namespace MapiServerCS.Services
{
	public class MapService
	{
		public MapService()
		{
		}

		IDictionary<int, Map> maps = new Dictionary<int, Map>();

		int mapId = 1;

		public Map CreateMap(string heading, string description, string theme, int creatorId)
		{
			Map newMap = new Map(heading, description, theme, creatorId, mapId);
			maps.Add(mapId, newMap);
			mapId++;
			return newMap;
		}

		public Map GetMap(int mapId)
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
	}
}

