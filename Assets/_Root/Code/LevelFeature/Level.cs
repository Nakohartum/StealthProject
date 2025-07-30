using System;
using System.Collections.Generic;
using GameOne.Player;
using UnityEngine;
using Zenject;

namespace _Root.Code.LevelFeature
{
    public class Level : MonoBehaviour
    {
        public List<SpawnPoint> SpawnPoints = new List<SpawnPoint>();
        

        public SpawnPoint GetSpawnPoint(string spawnPointName)
        {
            return SpawnPoints.Find(spawnPoint => spawnPoint.ID == spawnPointName);
        }
    }
}