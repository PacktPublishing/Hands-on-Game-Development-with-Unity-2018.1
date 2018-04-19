using MyCompany.DungeonGenerator.Data;
using UnityEngine;

namespace MyCompany.DungeonGenerator.Core
{
    [System.Serializable]
    public class Map
    {
        // *** Private Members ***
        private MapTemplate mapTemplate;
        private Vector2Int size;
        private Vector2Int[] cells;
        private Room[] rooms;

        /// <summary>
        /// Constructor
        /// </summary>
        public Map(MapTemplate mapTemplate)
        {
            this.mapTemplate = mapTemplate;
            Init();
        }

        public void Init()
        {
            GenerateRooms();
        }

        private void GenerateRooms()
        {
            /* Initialize the room count randomly within the range specified by the template */
            rooms = new Room[Random.Range(mapTemplate.MinRoomCount, mapTemplate.MaxRoomCount)];
            
        }
    }
}