using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.ScriptableObjects.Concretes.SpawnerScriptableObject
{

    [CreateAssetMenu(fileName = "BarrierSpawnerSO", menuName = "JetPackJoyride/BarrierSpawnerSO", order = 0)]
    public class BarrierSpawnerSO : ScriptableObject
    {
        [SerializeField] Transform[] _spawnTransforms;
        [SerializeField] float _maxSpawnTime;
        [SerializeField] float _minSpawnTime;

        public Transform[] SpawnTransforms { get => _spawnTransforms; set => _spawnTransforms = value; }
        public float MaxSpawnTime { get => _maxSpawnTime; set => _maxSpawnTime = value; }
        public float MinSpawnTime { get => _minSpawnTime; set => _minSpawnTime = value; }
    }
}