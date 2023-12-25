using Assembly_CSharp.Assets.GameFolders.Scripts.Movements.Abstracts;


public class GoldHorizontalMoveWithRigidBody2D : AbstractEntityHorizontalMoveWithRigidBody2D, IGoldHorizontalMove
{
    IGoldHorizontalMoveWithRigidBody2D _goldHorizontalMoveWithRigidBody2D;
    public GoldHorizontalMoveWithRigidBody2D(IGoldHorizontalMoveWithRigidBody2D goldHorizontalMoveWithRigidBody2D) : base(goldHorizontalMoveWithRigidBody2D)
    {
        _goldHorizontalMoveWithRigidBody2D = goldHorizontalMoveWithRigidBody2D;
    }
}


public interface IGoldHorizontalMove : IAbstractEntityHorizontalMove
{
}
public interface IGoldHorizontalMoveWithRigidBody2D : IAbstractEntityHorizontalMoveWithRigidBody2D
{
}

