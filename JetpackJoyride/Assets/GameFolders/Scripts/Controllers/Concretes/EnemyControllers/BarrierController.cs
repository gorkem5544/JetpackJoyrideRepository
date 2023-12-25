using System;
using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes;
using Assembly_CSharp.Assets.GameFolders.Scripts.Movements.Abstracts;
using Assembly_CSharp.Assets.GameFolders.Scripts.Movements.Concretes;
using Assembly_CSharp.Assets.GameFolders.Scripts.ScriptableObjects.Concretes.EnemyScriptableObjects;
using UnityEngine;
public class BarrierController : BaseEnemyController, IBarrierController, IBarrierEnemyHorizontalMoveWithRigidBody2D
{
    [SerializeField] BarrierTypeEnum _barrierTypeEnum;
    public BarrierTypeEnum BarrierTypeEnum { get => _barrierTypeEnum; set => _barrierTypeEnum = value; }

    [SerializeField] EnemyBarrierSO _enemyBarrierSO;

    public IHorizontalMoveSpeed MoveSpeedSOService => _enemyBarrierSO;

    public float HorizontalMoveSpeed => _enemyBarrierSO.HorizontalMoveSpeed;

    Rigidbody2D _rigidbody2D;
    public Rigidbody2D Rigidbody2D => _rigidbody2D;

    IBarrierEnemyHorizontalMove _barrierEnemyHorizontalMove;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _barrierEnemyHorizontalMove = new BarrierEnemyHorizontalMoveWithRigidBody2D(this);
    }
    private void OnEnable()
    {
        _barrierEnemyHorizontalMove.HorizontalMoveTick();
    }
    public override void KillEnemyController()
    {
        BarrierGenericPool.Instance.SetPool(this);
    }
}




