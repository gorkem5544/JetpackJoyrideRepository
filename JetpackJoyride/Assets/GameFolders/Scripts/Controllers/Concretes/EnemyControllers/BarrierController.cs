using System;
using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes;
using Assembly_CSharp.Assets.GameFolders.Scripts.ScriptableObjects.Concretes.EnemyScriptableObjects;
using UnityEngine;
public interface IEnemyController : IEntityController
{
    Rigidbody2D Rigidbody2D { get; }
}
public interface IBaseEnemyHorizontalMovement : IEnemyController
{
    IMoveSpeedSOService MoveSpeedSOService { get; }
}
public interface IBarrierController : IBaseEnemyHorizontalMovement
{
}
public class BarrierController : BaseEnemyController, IBarrierController
{
    [SerializeField] BarrierTypeEnum _barrierTypeEnum;
    public BarrierTypeEnum BarrierTypeEnum { get => _barrierTypeEnum; set => _barrierTypeEnum = value; }

    [SerializeField] EnemyBarrierSO _enemyBarrierSO;

    public IMoveSpeedSOService MoveSpeedSOService => _enemyBarrierSO;

    BarrierEnemyHorizontalMove _barrierEnemyHorizontalMove;

    protected override void Awake()
    {
        base.Awake();
        _barrierEnemyHorizontalMove = new BarrierEnemyHorizontalMove(this);


    }
    private void OnEnable()
    {
        _barrierEnemyHorizontalMove.MoveHorizontalWhenEnabled();
    }
    public override void DeadObject()
    {
        BarrierPool.Instance.SetPool(this);
    }

}


public interface IMoveHorizontalWhenEnabledService
{
    void MoveHorizontalWhenEnabled();
}
public interface IEntityHorizontalMove : IMoveHorizontalWhenEnabledService
{
}
public interface IBaseEnemyHorizontalMove : IEntityHorizontalMove
{
}
public abstract class BaseEnemyHorizontalMove : IBaseEnemyHorizontalMove
{
    protected IBaseEnemyHorizontalMovement _baseEnemyHorizontalMovement;
    IMoveSpeedSOService _moveSpeedSOService;
    public BaseEnemyHorizontalMove(IBaseEnemyHorizontalMovement baseEnemyHorizontalMovement)
    {
        _baseEnemyHorizontalMovement = baseEnemyHorizontalMovement;
        _moveSpeedSOService = _baseEnemyHorizontalMovement.MoveSpeedSOService;
    }
    public virtual void MoveHorizontalWhenEnabled()
    {
        _baseEnemyHorizontalMovement.Rigidbody2D.velocity = Vector2.left * _moveSpeedSOService.HorizontalMoveSpeed;
    }


}
public class BarrierEnemyHorizontalMove : BaseEnemyHorizontalMove
{
    public BarrierEnemyHorizontalMove(IBaseEnemyHorizontalMovement baseEnemyHorizontalMovement) : base(baseEnemyHorizontalMovement)
    {
    }

}