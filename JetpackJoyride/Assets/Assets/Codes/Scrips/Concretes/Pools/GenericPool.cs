
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericPool<T> : MonoBehaviour where T : Component
{
    [SerializeField] T[] _prefabs;
    [SerializeField] int _countLoop;

    Queue<T> _poolPrefabs = new Queue<T>();

    private void Awake()
    {
        Singleton();
    }
    public T Get()
    {
        if (_poolPrefabs.Count == 0)
        {
            GrowPoolsObject();
        }
        return _poolPrefabs.Dequeue();
    }
    public abstract void Singleton();
    private void GrowPoolsObject()
    {
        for (int i = 0; i < _countLoop; i++)
        {
            T newPrefab = Instantiate(_prefabs[Random.Range(0, _prefabs.Length)]);
            newPrefab.transform.parent = this.transform;
            newPrefab.gameObject.SetActive(false);
            _poolPrefabs.Enqueue(newPrefab);
        }
    }
    public void Set(T poolObject)
    {
        poolObject.gameObject.SetActive(false);
        _poolPrefabs.Enqueue(poolObject);
    }
}
