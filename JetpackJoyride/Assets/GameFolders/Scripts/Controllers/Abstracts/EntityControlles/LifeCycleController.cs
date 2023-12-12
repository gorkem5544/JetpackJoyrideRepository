using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LifeCycleController : MonoBehaviour
{
    [SerializeField] protected float _maxLifeTime;
    protected float _currentTime;

    public virtual void Update()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime > _maxLifeTime)
        {
            KillObject();
        }
    }
    protected abstract void KillObject();
}
public abstract class BaseEnemyController : LifeCycleController, IEnemyController
{
    Rigidbody2D _rigidbody2D;
    public Rigidbody2D Rigidbody2D => _rigidbody2D;
    protected BaseEnemyHorizontalMovement _baseEnemyHorizontalMovement;
    protected virtual void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    protected override void KillObject()
    {
        _currentTime = 0;
        DeadObject();
    }
    public abstract void DeadObject();
}