using Assembly_CSharp.Assets.GameFolders.Scripts.Movements.Abstracts;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Movements.Abstracts
{
    public abstract class AbstractEnemyHorizontalMoveWithRigidBody2D : AbstractEntityHorizontalMoveWithRigidBody2D, IAbstractEnemyHorizontalMove
    {
        protected IAbstractEnemyHorizontalMoveWithRigidBody2D _abstractEnemyHorizontalMoveWithRigidBody2D;
        protected AbstractEnemyHorizontalMoveWithRigidBody2D(IAbstractEnemyHorizontalMoveWithRigidBody2D abstractEnemyHorizontalMoveWithRigidBody2D) : base(abstractEnemyHorizontalMoveWithRigidBody2D)
        {
            _abstractEnemyHorizontalMoveWithRigidBody2D = abstractEnemyHorizontalMoveWithRigidBody2D;
        }
    }

}