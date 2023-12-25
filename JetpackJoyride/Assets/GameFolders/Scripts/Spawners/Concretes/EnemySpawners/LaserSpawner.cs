using Concretes.Pools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawner : ILaserSpawner
{
    Transform[] _spawnTransforms;
    int _randomSpawnTypeIndex;
    List<Transform> _newLaserTransforms = new List<Transform>();
    int _randomSpawnLaserCount;
    int _spawnerIndex;
    LaserController _laserController;
    public LaserSpawner(Transform[] spawnTransforms)
    {

        _spawnTransforms = spawnTransforms;
    }

    public void LaserSpawnAction()
    {
        _randomSpawnTypeIndex = Random.Range(0, 2);
        switch (_randomSpawnTypeIndex)
        {
            case 0:
                SingleLaserSpawn();
                break;
            case 1:
                MultipleLaserSpawn();
                break;
        }
    }
    public void MultipleLaserSpawn()
    {
        _randomSpawnLaserCount = Random.Range(0, 4);

        foreach (var item in _spawnTransforms)
        {
            _newLaserTransforms.Add(item);
        }
        for (int i = 0; i < _randomSpawnLaserCount; i++)
        {
            int index = Random.Range(0, _newLaserTransforms.Count);
            LaserSpawn(_newLaserTransforms[index]);
            _newLaserTransforms.RemoveAt(index);
        }
        _newLaserTransforms.Clear();
    }
    public void LaserSpawn(Transform transform)
    {
        CreateLaser();
        _laserController.transform.position = new Vector3(0, transform.transform.position.y);
    }
    public void SingleLaserSpawn()
    {
        _spawnerIndex = Random.Range(0, _spawnTransforms.Length);
        CreateLaser();
        _laserController.transform.position = new Vector3(0, _spawnTransforms[_spawnerIndex].transform.position.y);
    }
    private void CreateLaser()
    {
        _laserController = LaserPool.Instance.Get();
        _laserController.gameObject.SetActive(true);
    }
}
public interface ILaserSpawner
{
    void LaserSpawnAction();
    void SingleLaserSpawn();
}
