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
    public abstract void KillObject();
}
