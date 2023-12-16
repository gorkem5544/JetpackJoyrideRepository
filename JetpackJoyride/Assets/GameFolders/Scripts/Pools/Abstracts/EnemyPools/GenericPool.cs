
using System.Collections.Generic;
using UnityEngine;

public interface IResetPool
{
    void ResetAllObject();
}
public abstract class GenericPool<T> : MonoBehaviour, IResetPool where T : Component
{
    [SerializeField] T[] _prefabs;
    [SerializeField] int _countLoop;

    Queue<T> _poolPrefabs = new Queue<T>();

    private void Awake()
    {
        Singleton();
    }
    private void Start()
    {
        PlayerManager.Instance.GetPlayer().PlayerHealth.OnDead += ResetAllObject;
        PlayerManager.Instance.GetPlayer().PlayerHealth.OnReSpawn += ResetAllObject;

    }
    private void OnDisable()
    {
        PlayerManager.Instance.GetPlayer().PlayerHealth.OnDead -= ResetAllObject;
        PlayerManager.Instance.GetPlayer().PlayerHealth.OnReSpawn -= ResetAllObject;


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

    public abstract void ResetAllObject();

}



public abstract class SingletonMonoObject<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; protected set; }

    protected virtual void Awake()
    {
        SetSingletonMono();
    }

    protected abstract void SetSingletonMono();
}
public abstract class SingletonDontDestroyMonoObject<T> : SingletonMonoObject<T> where T : MonoBehaviour
{
    protected override void SetSingletonMono()
    {
        if (Instance == null)
        {
            Instance = this as T;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
public enum BarrierTypeEnum
{
    Small, Medium, Large
}
