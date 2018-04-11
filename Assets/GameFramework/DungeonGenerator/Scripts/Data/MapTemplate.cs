using UnityEngine;

namespace MyCompany.DungeonGenerator.Data
{
    [CreateAssetMenu(fileName = "Map Template", menuName = "MyCompany/Data/Create Map Template File")]
    public class MapTemplate : ScriptableObject
    {
        [SerializeField] private Vector2Int _minSize;
        [SerializeField] private Vector2Int _maxSize;
        [SerializeField] private int _minRoomCount;
        [SerializeField] private int _maxRoomCount;
        
        // *** Properties ***
        #region PROPERTIES
        
        public Vector2Int MinSize
        {
            get { return _minSize; }
        }

        public Vector2Int MaxSize
        {
            get { return _maxSize; }
        }

        public int MinRoomCount
        {
            get { return _minRoomCount; }
        }

        public int MaxRoomCount
        {
            get { return _maxRoomCount; }
        }

        #endregion
        
        
    }
}