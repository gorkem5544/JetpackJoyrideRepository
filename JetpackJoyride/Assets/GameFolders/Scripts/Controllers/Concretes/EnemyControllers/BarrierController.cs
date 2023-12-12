using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IEnemyController : IEntityController
{
    Rigidbody2D Rigidbody2D { get; }
}
public interface IBarrierController : IEnemyController
{

}
public class BarrierController : BaseEnemyController, IBarrierController
{
    [SerializeField] BarrierTypeEnum _barrierTypeEnum;
    public BarrierTypeEnum BarrierTypeEnum { get => _barrierTypeEnum; set => _barrierTypeEnum = value; }

    protected override void Awake()
    {
        base.Awake();
        _baseEnemyHorizontalMovement = new BarrierHorizontalMovement(this);


    }
    private void OnEnable()
    {
        _baseEnemyHorizontalMovement.MoveHorizontalWhenEnabled();
    }
    public override void DeadObject()
    {
        BarrierPool.Instance.SetPool(this);
    }

}


public interface IBaseEntityHorizontalMovement
{
    void MoveHorizontalWhenEnabled();
}
public abstract class BaseEnemyHorizontalMovement : IBaseEntityHorizontalMovement
{
    protected IEnemyController _enemyController;
    public BaseEnemyHorizontalMovement(IEnemyController enemyController)
    {
        _enemyController = enemyController;
    }
    public virtual void MoveHorizontalWhenEnabled()
    {
        _enemyController.Rigidbody2D.velocity = Vector2.left * 5f;
    }

}
public class BarrierHorizontalMovement : BaseEnemyHorizontalMovement, IBaseEntityHorizontalMovement
{
    
    public BarrierHorizontalMovement(IEnemyController enemyController) : base(enemyController)
    {

    }
}