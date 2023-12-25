using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Movements.Abstracts;
using Assembly_CSharp.Assets.GameFolders.Scripts.Pools.Concretes.EnemyPools;
using Assembly_CSharp.Assets.GameFolders.Scripts.ScriptableObjects.Concretes.EnemyScriptableObjects;
using UnityEngine;

public interface IRocketController : IEnemyController
{
}
public class RocketController : BaseEnemyController, IRocketController, IRocketEnemyHorizontalMoveWithRigidBody2D
{

    private Rigidbody2D _rocketRigidbody2D;
    public Rigidbody2D Rigidbody2D => _rocketRigidbody2D;

    [SerializeField] RocketSO _rocketSO;
    public float HorizontalMoveSpeed => _rocketSO.HorizontalMoveSpeed;
    IRocketEnemyHorizontalMove _rocketEnemyHorizontalMove;
    private void Awake()
    {
        _rocketRigidbody2D = GetComponent<Rigidbody2D>();
        _rocketEnemyHorizontalMove = new RocketEnemyHorizontalMoveWithRigidBody2D(this);
    }
    private void OnEnable()
    {
        _rocketEnemyHorizontalMove.HorizontalMoveTick();
    }
    public override void KillEnemyController()
    {
        RocketPool.Instance.Set(this);
    }
}

public interface IRocketEnemyHorizontalMove : IAbstractEnemyHorizontalMove
{
}
public interface IRocketEnemyHorizontalMoveWithRigidBody2D : IAbstractEnemyHorizontalMoveWithRigidBody2D
{
}
public class RocketEnemyHorizontalMoveWithRigidBody2D : AbstractEnemyHorizontalMoveWithRigidBody2D, IRocketEnemyHorizontalMove
{
    IRocketEnemyHorizontalMoveWithRigidBody2D _rocketEnemyHorizontalMoveWithRigidBody2D;
    public RocketEnemyHorizontalMoveWithRigidBody2D(IRocketEnemyHorizontalMoveWithRigidBody2D rocketEnemyHorizontalMoveWithRigidBody2D) : base(rocketEnemyHorizontalMoveWithRigidBody2D)
    {
        _rocketEnemyHorizontalMoveWithRigidBody2D = rocketEnemyHorizontalMoveWithRigidBody2D;
    }
}
