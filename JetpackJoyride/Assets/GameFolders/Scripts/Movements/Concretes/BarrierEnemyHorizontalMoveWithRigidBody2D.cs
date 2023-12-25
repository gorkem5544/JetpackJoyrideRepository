using Assembly_CSharp.Assets.GameFolders.Scripts.Movements.Abstracts;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Movements.Concretes
{
    public class BarrierEnemyHorizontalMoveWithRigidBody2D : AbstractEnemyHorizontalMoveWithRigidBody2D, IBarrierEnemyHorizontalMove
    {
        IBarrierEnemyHorizontalMoveWithRigidBody2D _barrierEnemyHorizontalMoveWithRigidBody2D;
        public BarrierEnemyHorizontalMoveWithRigidBody2D(IBarrierEnemyHorizontalMoveWithRigidBody2D barrierEnemyHorizontalMoveWithRigidBody2D) : base(barrierEnemyHorizontalMoveWithRigidBody2D)
        {
            _barrierEnemyHorizontalMoveWithRigidBody2D = barrierEnemyHorizontalMoveWithRigidBody2D;
        }
    }
    public interface IBarrierEnemyHorizontalMove : IAbstractEnemyHorizontalMove
    {

    }
    public interface IBarrierEnemyHorizontalMoveWithRigidBody2D : IAbstractEnemyHorizontalMoveWithRigidBody2D
    {

    }

}