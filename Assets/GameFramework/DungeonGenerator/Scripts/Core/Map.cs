using MyCompany.DungeonGenerator.Data;
using UnityEngine;

namespace MyCompany.DungeonGenerator.Core
{
    [System.Serializable]
    public class Map
    {
        // *** Private Members ***
        private MapTemplate _mapTemplate;
        private Vector2Int _size;
        private Vector2Int[] _cells;
        private Room[] _rooms;

        /// <summary>
        /// Constructor
        /// </summary>
        public Map(MapTemplate mapTemplate)
        {
            _mapTemplate = mapTemplate;
            Init();
        }

        public void Init()
        {
            GenerateRooms();
        }

        private void GenerateRooms()
        {
            /* Initialize the room count randomly within the range specified by the template */
            _rooms = new Room[Random.Range(_mapTemplate.MinRoomCount, _mapTemplate.MaxRoomCount)];
            
        }
    }
}