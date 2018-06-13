using System.Collections.Generic;
using UnityEngine;

namespace MyCompany.RogueSmash.Prototype
{
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private Collider safeVolume;
        [SerializeField] private Vector3 levelCenter;
        [SerializeField] private int levelWidth;
        [SerializeField] private int levelHeight;
        [SerializeField] private int obstacleCount;
        [SerializeField] private float itemDistanceBuffer = 2;
        [SerializeField] private GameObject obstaclePrefab;
    
        private List<Vector3> spawnedObstacleLocations = new List<Vector3>();

        void Start()
        {
            GenerateLevel();
        }

        private void GenerateLevel()
        {
            for (int i = 0; i < obstacleCount; ++i)
            {
                GenerateObstacle();
            }
        }

        private void GenerateObstacle()
        {
            int attempts = 0;
            bool slotFound = false;
            Vector3 randomPoint = Vector3.zero;
            while (attempts < 5 && !slotFound)
            {
                int x = Random.Range((int)levelCenter.x - levelWidth / 2, (int)levelCenter.x + levelWidth/2);
                int z = Random.Range((int)levelCenter.z - levelHeight/ 2, (int)levelCenter.z + levelHeight/2);
                randomPoint = new Vector3(x, levelCenter.y, z);
                if (TestPoint(randomPoint, spawnedObstacleLocations))
                {
                    slotFound = true;
                    spawnedObstacleLocations.Add(randomPoint);
                    Instantiate(obstaclePrefab, randomPoint, Quaternion.identity);
                }
                else
                {
                    attempts++;
                }
            }
        }
    
        private bool TestPoint(Vector3 pointToTest, List<Vector3> otherPoints)
        {
            if (safeVolume.bounds.Contains(pointToTest))
            {
                return false;
            }
            
            if (otherPoints.Count == 0)
            {
                return true;
            }
        
            foreach (Vector3 otherPoint in otherPoints)
            {
                if (Vector3.Distance(pointToTest, otherPoint) < itemDistanceBuffer)
                {
                    return false;
                }
            }

            return true;
        }
    }
}