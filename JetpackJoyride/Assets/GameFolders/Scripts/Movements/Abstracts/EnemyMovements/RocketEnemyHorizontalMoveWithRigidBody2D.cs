using Assembly_CSharp.Assets.GameFolders.Scripts.Movements.Abstracts;

public class RocketEnemyHorizontalMoveWithRigidBody2D : AbstractEnemyHorizontalMoveWithRigidBody2D, IRocketEnemyHorizontalMove
{
    IRocketEnemyHorizontalMoveWithRigidBody2D _rocketEnemyHorizontalMoveWithRigidBody2D;
    public RocketEnemyHorizontalMoveWithRigidBody2D(IRocketEnemyHorizontalMoveWithRigidBody2D rocketEnemyHorizontalMoveWithRigidBody2D) : base(rocketEnemyHorizontalMoveWithRigidBody2D)
    {
        _rocketEnemyHorizontalMoveWithRigidBody2D = rocketEnemyHorizontalMoveWithRigidBody2D;
    }
}
