using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Movements.Abstracts
{
    public abstract class AbstractEntityHorizontalMoveWithRigidBody2D : IAbstractEntityHorizontalMove
    {
        protected IAbstractEntityHorizontalMoveWithRigidBody2D _abstractEntityHorizontalMoveWithRigidBody2D;

        public AbstractEntityHorizontalMoveWithRigidBody2D(IAbstractEntityHorizontalMoveWithRigidBody2D abstractEntityHorizontalMoveWithRigidBody2D)
        {
            _abstractEntityHorizontalMoveWithRigidBody2D = abstractEntityHorizontalMoveWithRigidBody2D;
        }

        public virtual void HorizontalMoveTick()
        {
            _abstractEntityHorizontalMoveWithRigidBody2D.Rigidbody2D.velocity = Vector2.left * _abstractEntityHorizontalMoveWithRigidBody2D.HorizontalMoveSpeed;
        }
    }

}