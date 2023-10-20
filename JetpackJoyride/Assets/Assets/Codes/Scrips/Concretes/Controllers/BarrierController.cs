using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierController : LifeCycleController
{
    Rigidbody2D _rigidbody2D;

    public override void KillObject()
    {
        _currentTime = 0;
        BarrierPool.Instance.Set(this);
    }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    private void OnEnable()
    {
        _rigidbody2D.velocity = Vector2.left * 5f;
    }
    // Update is called once per frame

}
