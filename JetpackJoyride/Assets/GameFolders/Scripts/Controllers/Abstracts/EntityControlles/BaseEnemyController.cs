public abstract class BaseEnemyController : LifeCycleController, IEnemyController
{
    public override void KillObject()
    {
        _currentLifeTime = 0;
        KillEnemyController();
    }
    public abstract void KillEnemyController();
}