
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Combats.Concretes.PlayerCombats;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes;
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
    private PlayerHealth _playerHealth;

    private void Awake()
    {
        Singleton();
    }

    private void Start()
    {
        if (GameManager.Instance.GameManagerState == GameManagerState.GameState)
        {
            _playerHealth = PlayerManager.Instance.PlayerController.PlayerHealth;
            _playerHealth.PlayerHitEvent += ResetAllObject;
            _playerHealth.PlayerReviveEvent += ResetAllObject;
        }
    }
    private void OnDisable()
    {
        _playerHealth.PlayerHitEvent -= ResetAllObject;
        _playerHealth.PlayerReviveEvent -= ResetAllObject;
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
