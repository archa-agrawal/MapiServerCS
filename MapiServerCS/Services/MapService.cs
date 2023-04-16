using System;
using MapiServerCS.models;

namespace MapiServerCS.Services
{
	public class MapService
	{
		

		IDictionary<string, Map> maps = new Dictionary<string, Map>();


        public Map CreateMap(Map newMap)
		{
			maps.Add(newMap.Id, newMap);
			return newMap;
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

