using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LifeCycleController : MonoBehaviour
{
    [SerializeField] float _maxLifeTime;
    protected float _currentLifeTime;

    public virtual void Update()
    {
        _currentLifeTime += Time.deltaTime;
        if (_currentLifeTime > _maxLifeTime)
        {
            KillObject();
        }
    }
    public abstract void KillObject();
}
