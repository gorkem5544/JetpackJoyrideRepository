using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Pools.Concretes.EnemyPools;
using Assembly_CSharp.Assets.GameFolders.Scripts.ScriptableObjects.Concretes.EnemyScriptableObjects;
using UnityEngine;

public interface IRocketController : IBaseEnemyHorizontalMovement
{

}
public class RocketController : LifeCycleController, IRocketController
{
    [SerializeField] RocketSO _rocketSO;
    public IMoveSpeedSOService MoveSpeedSOService => _rocketSO;
    private Rigidbody2D _rigidbody2D;
    public Rigidbody2D Rigidbody2D => _rigidbody2D;


    RocketHorizontalMove _rocketHorizontalMove;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rocketHorizontalMove = new RocketHorizontalMove(this);
    }
    private void OnEnable()
    {
        _rocketHorizontalMove.MoveHorizontalWhenEnabled();
    }

    public override void KillObject()
    {
        RocketPool.Instance.Set(this);
        _currentTime = 0;
    }
}


public class RocketHorizontalMove : BaseEnemyHorizontalMove
{
    public RocketHorizontalMove(IBaseEnemyHorizontalMovement baseEnemyHorizontalMovement) : base(baseEnemyHorizontalMovement)
    {
    }
}